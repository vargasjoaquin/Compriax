using AutoMapper;
using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Constants;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Domain.Enums;
using FluentValidation;

namespace CompriaxSystem.Application.Services
{
    public class SaleService(IUnitOfWork unitOfWork, ICurrentUserService currentUser, IMapper mapper, IValidator<SaleDto> saleValidator, IAfipService afipService) : ISaleService
    {
        /// <summary>
        /// Procesa una venta completa: valida stock, autoriza ante AFIP, impacta inventario y registra la transacción en el turno de caja.
        /// </summary>
        /// <param name="saleDto">Datos de la venta a realizar.</param>
        /// <returns>Resultado de la operación con el número de comprobante y estado fiscal.</returns>
        public async Task<OperationResult> ProcessSaleAsync(SaleDto saleDto)
        {
            var validation = await saleValidator.ValidateAsync(saleDto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            int currentUserId = currentUser.CurrentUser!.UserId;

            string currentUsername = currentUser.CurrentUser!.Username;
            
            int cashRegisterId = currentUser.OperationalContext!.CashRegisterId;

            var activeCashShift = await unitOfWork.CashShifts.GetActiveShiftByRegisterIdAsync(cashRegisterId);

            var lastDocumentNumber = await unitOfWork.Sales.GetLastDocumentNumberAsync(saleDto.DocumentTypeId);
            string newDocumentNumber = GenerateNextNumber(lastDocumentNumber);
            
            saleDto.DocumentNumber = newDocumentNumber;

            AfipAuthorizeResultDto fiscalResult;
            
            try
            {
                fiscalResult = await afipService.AuthorizeInvoiceAsync(saleDto);
            }
            catch (Exception ex)
            {
                return OperationResult.Failure($"Fallo de comunicación con servicio fiscal: {ex.Message}");
            }

            await unitOfWork.BeginTransactionAsync();
            
            try
            {
                var sale = mapper.Map<Sale>(saleDto);
                
                sale.DocumentNumber = newDocumentNumber;
                sale.DocumentTypeId = saleDto.DocumentTypeId;
                sale.PaymentMethodId = saleDto.PaymentMethodId > 0 ? saleDto.PaymentMethodId : 1;
                sale.CustomerId = saleDto.CustomerId;
                sale.UserId = currentUserId;
                sale.CashRegisterId = cashRegisterId;
                sale.CashShiftId = activeCashShift?.Id;
                sale.CreatedAt = DateTime.UtcNow;

                sale.SubTotal = saleDto.SubTotal > 0 ? saleDto.SubTotal : saleDto.Items.Sum(x => x.Quantity * x.UnitPrice);
                sale.DiscountAmount = saleDto.DiscountAmount;
                sale.TotalAmount = saleDto.TotalAmount > 0 ? saleDto.TotalAmount : (sale.SubTotal - sale.DiscountAmount);
                sale.PaymentReceived = saleDto.PaymentReceived;
                sale.PaymentChange = Math.Max(0, saleDto.PaymentReceived - sale.TotalAmount);

                if (fiscalResult.Success)
                {
                    sale.Cae = fiscalResult.Cae;
                    sale.CaeExpirationDate = fiscalResult.CaeExpirationDate;
                    sale.PointOfSale = fiscalResult.PointOfSale > 0 ? fiscalResult.PointOfSale : 1;
                    sale.AfipQrUrl = fiscalResult.QrUrl;
                    sale.FiscalStatus = fiscalResult.FiscalStatus;

                    saleDto.Cae = fiscalResult.Cae;
                    saleDto.CaeExpirationDate = fiscalResult.CaeExpirationDate;
                    saleDto.PointOfSale = fiscalResult.PointOfSale;
                    saleDto.AfipQrUrl = fiscalResult.QrUrl;
                }
                else
                {
                    sale.FiscalStatus = FiscalStatuses.NON_FISCAL;
                }

                sale.DocumentType = null!;
                sale.Customer = null!;
                sale.User = null!;
                sale.PaymentMethod = null!;
                sale.CashShift = null!;
                sale.CashRegister = null!;

                foreach (var saleItem in sale.SaleItems)
                {
                    saleItem.Product = null!;
                    saleItem.Sale = null!;

                    var product = await unitOfWork.Products.GetByIdAsync(saleItem.ProductId);

                    if (product == null || !product.IsActive)
                    {
                        await unitOfWork.RollbackAsync();
                        return OperationResult.Failure($"El producto con ID {saleItem.ProductId} no fue encontrado o está inactivo.");
                    }

                    if (product.CurrentStock < saleItem.Quantity)
                    {
                        await unitOfWork.RollbackAsync();
                        return OperationResult.Failure($"Stock insuficiente en '{product.Name}'. Disponible: {product.CurrentStock:N0}, Solicitado: {saleItem.Quantity}");
                    }

                    saleItem.CostPrice = product.BuyPrice;
                    product.CurrentStock -= saleItem.Quantity;

                    unitOfWork.Products.Update(product);

                    await unitOfWork.Products.AddMovementAsync(new StockMovement
                    {
                        ProductId = saleItem.ProductId,
                        UserId = currentUserId,
                        Quantity = -saleItem.Quantity,
                        MovementType = MovementType.Sale,
                        Remarks = $"Venta Nro: {newDocumentNumber} [Caja #{cashRegisterId}]",
                        CreatedBy = currentUsername,
                        CreatedAt = DateTime.UtcNow
                    });
                }

                await unitOfWork.Sales.AddAsync(sale);
                
                bool operationSucceeded = await unitOfWork.CompleteAsync();

                if (!operationSucceeded)
                    throw new InvalidOperationException("No se detectaron cambios al persistir la venta.");

                await unitOfWork.CommitAsync();

                string caeMessage = !string.IsNullOrWhiteSpace(sale.Cae) ? $" [CAE: {sale.Cae}]" : "";
                string cashShiftMessage = activeCashShift != null ? $" [Turno Caja #{activeCashShift.Id}]" : "";

                return OperationResult.Ok($"Venta procesada exitosamente. Comprobante: {newDocumentNumber}{caeMessage}{cashShiftMessage}");
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackAsync();
                return OperationResult.Failure($"Error crítico al persistir la venta: {ex.Message}");
            }
        }

        /// <summary>
        /// Verifica la disponibilidad física de un producto en el inventario antes de permitir su venta.
        /// </summary>
        /// <param name="productId">Id del producto.</param>
        /// <param name="requestedQuantity">Cantidad que se desea vender.</param>
        /// <returns>Resultado indicando si hay stock suficiente o si el producto está inactivo.</returns>
        public async Task<OperationResult> ValidateStockAsync(int productId, int requestedQuantity)
        {
            var product = await unitOfWork.Products.GetByIdAsync(productId);

            if (product == null)
                return OperationResult.Failure("Producto no encontrado.");

            if (!product.IsActive)
                return OperationResult.Failure($"El producto '{product.Name}' está inactivo.");

            if (product.CurrentStock < requestedQuantity)
                return OperationResult.Failure($"Stock insuficiente. Disponible: {product.CurrentStock:N0}");

            return OperationResult.Ok();
        }

        /// <summary>
        /// Obtiene el próximo número de comprobante disponible para un tipo de comprobante.
        /// </summary>
        /// <param name="documentTypeId">Id del tipo de documento fiscal.</param>
        /// <returns>Próximo número de comprobante disponible.</returns>
        public async Task<string> GetNextDocumentNumberAsync(int documentTypeId)
        {
            var lastDocumentNumber = await unitOfWork.Sales.GetLastDocumentNumberAsync(documentTypeId);
            return GenerateNextNumber(lastDocumentNumber);
        }

        /// <summary>
        /// Genera el siguiente número correlativo de comprobante a partir del último número registrado.
        /// </summary>
        /// <param name="lastDocumentNumber">Último número de comprobante registrado.</param>
        /// <returns>Próximo número de comprobante con ocho dígitos.</returns>
        private static string GenerateNextNumber(string? lastDocumentNumber)
        {
            if (!string.IsNullOrWhiteSpace(lastDocumentNumber) && long.TryParse(lastDocumentNumber, out long lastDocumentNumberValue))
                return (lastDocumentNumberValue + 1).ToString().PadLeft(8, '0');

            return "00000001";
        }
    }
}