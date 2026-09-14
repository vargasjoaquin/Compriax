using AutoMapper;
using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Domain.Enums;
using FluentValidation;

namespace CompriaxSystem.Application.Services
{
    public class SaleService(
        IUnitOfWork unitOfWork,
        ICurrentUserService currentUser,
        IMapper mapper,
        IValidator<SaleDto> saleValidator,
        IAfipService afipService) : ISaleService
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
            int registerId = currentUser.OperationalContext!.CashRegisterId;

            var activeShift = await unitOfWork.CashShifts.GetActiveShiftByRegisterIdAsync(registerId);

            var lastNumber = await unitOfWork.Sales.GetLastDocumentNumberAsync(saleDto.DocumentTypeId);
            string newDocumentNumber = GenerateNextNumber(lastNumber);
            
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
                sale.CashRegisterId = registerId;
                sale.CashShiftId = activeShift?.Id;
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
                    sale.FiscalStatus = "No Fiscal";
                }

                sale.DocumentType = null!;
                sale.Customer = null!;
                sale.User = null!;
                sale.PaymentMethod = null!;
                sale.CashShift = null!;
                sale.CashRegister = null!;

                foreach (var item in sale.SaleItems)
                {
                    item.Product = null!;
                    item.Sale = null!;

                    var product = await unitOfWork.Products.GetByIdAsync(item.ProductId);

                    if (product == null || !product.IsActive)
                    {
                        await unitOfWork.RollbackAsync();
                        return OperationResult.Failure($"El producto con ID {item.ProductId} no fue encontrado o está inactivo.");
                    }

                    if (product.CurrentStock < item.Quantity)
                    {
                        await unitOfWork.RollbackAsync();
                        return OperationResult.Failure($"Stock insuficiente en '{product.Name}'. Disponible: {product.CurrentStock:N0}, Solicitado: {item.Quantity}");
                    }

                    item.CostPrice = product.BuyPrice;
                    product.CurrentStock -= item.Quantity;

                    unitOfWork.Products.Update(product);

                    await unitOfWork.Products.AddMovementAsync(new StockMovement
                    {
                        ProductId = item.ProductId,
                        UserId = currentUserId,
                        Quantity = -item.Quantity,
                        MovementType = MovementType.Sale,
                        Remarks = $"Venta Nro: {newDocumentNumber} [Caja #{registerId}]",
                        CreatedBy = currentUsername,
                        CreatedAt = DateTime.UtcNow
                    });
                }

                await unitOfWork.Sales.AddAsync(sale);
                bool success = await unitOfWork.CompleteAsync();

                if (!success)
                    throw new InvalidOperationException("No se detectaron cambios al persistir la venta.");

                await unitOfWork.CommitAsync();

                string caeTag = !string.IsNullOrWhiteSpace(sale.Cae) ? $" [CAE: {sale.Cae}]" : "";
                string shiftTag = activeShift != null ? $" [Turno Caja #{activeShift.Id}]" : "";

                return OperationResult.Ok($"Venta procesada exitosamente. Comprobante: {newDocumentNumber}{caeTag}{shiftTag}");
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackAsync();
                return OperationResult.Failure("Error crítico al persistir la venta: " + (ex.InnerException?.Message ?? ex.Message));
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

        public async Task<string> GetNextDocumentNumberAsync(int documentTypeId)
        {
            var lastNumber = await unitOfWork.Sales.GetLastDocumentNumberAsync(documentTypeId);
            return GenerateNextNumber(lastNumber);
        }

        private static string GenerateNextNumber(string? lastNumber)
        {
            if (!string.IsNullOrWhiteSpace(lastNumber) && long.TryParse(lastNumber, out long lastId))
                return (lastId + 1).ToString().PadLeft(8, '0');

            return "00000001";
        }
    }
}