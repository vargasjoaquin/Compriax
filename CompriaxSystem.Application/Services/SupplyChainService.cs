using AutoMapper;
using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Domain.Enums;
using DocumentFormat.OpenXml.Drawing;
using FluentValidation;

namespace CompriaxSystem.Application.Services
{
    public class SupplyChainService(
        IUnitOfWork unitOfWork,
        ICurrentUserService currentUser,
        IMapper mapper,
        IValidator<SupplierDto> supplierValidator,
        IValidator<PurchaseCreateDto> purchaseValidator) : ISupplyChainService
    {
        public async Task<IEnumerable<SupplierDto>> GetSuppliersAsync()
        {
            var suppliers = await unitOfWork.Suppliers.GetAllAsync();
            return mapper.Map<IEnumerable<SupplierDto>>(suppliers);
        }

        public async Task<OperationResult> UpsertSupplierAsync(SupplierDto dto)
        {
            var validation = await supplierValidator.ValidateAsync(dto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            string cuit = dto.CUIT.Trim();

            var allSuppliers = await unitOfWork.Suppliers.GetAllAsync();
            bool cuitExists = allSuppliers.Any(s => s.CUIT.Equals(cuit, StringComparison.OrdinalIgnoreCase) && s.Id != dto.Id);

            if (cuitExists)
                return OperationResult.Failure($"El CUIT '{cuit}' ya se encuentra registrado por otro proveedor activo.");

            if (dto.Id == 0)
            {
                var supplier = mapper.Map<Supplier>(dto);
                supplier.CUIT = cuit;
                await unitOfWork.Suppliers.AddAsync(supplier);
            }
            else
            {
                var supplier = await unitOfWork.Suppliers.GetByIdAsync(dto.Id);
                
                if (supplier == null)
                    return OperationResult.Failure("Proveedor no encontrado.");

                mapper.Map(dto, supplier);
                supplier.CUIT = cuit;
                unitOfWork.Suppliers.Update(supplier);
            }

            return await unitOfWork.CompleteAsync()
                ? OperationResult.Ok("Proveedor guardado exitosamente.")
                : OperationResult.Failure("No se realizaron cambios en la base de datos.");
        }

        public async Task<OperationResult> DeleteSupplierAsync(int id)
        {
            var supplier = await unitOfWork.Suppliers.GetByIdAsync(id);
            
            if (supplier == null)
                return OperationResult.Failure("Proveedor no encontrado.");

            var purchases = await unitOfWork.Purchases.GetHistoryAsync(DateTime.MinValue, DateTime.MaxValue);
            bool hasPurchases = purchases.Any(p => p.SupplierId == id);

            supplier.IsDeleted = true;
            supplier.LastUpdatedBy = currentUser.CurrentUser!.Username;
            supplier.LastUpdatedAt = DateTime.UtcNow;

            unitOfWork.Suppliers.Update(supplier);

            return await unitOfWork.CompleteAsync()
                ? OperationResult.Ok("Proveedor eliminado correctamente.")
                : OperationResult.Failure("Error al procesar la eliminación.");
        }

        public async Task<OperationResult> ProcessPurchaseAsync(PurchaseCreateDto dto)
        {
            var validation = await purchaseValidator.ValidateAsync(dto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            int currentUserId = currentUser.CurrentUser!.UserId;
            string currentUsername = !string.IsNullOrWhiteSpace(currentUser.CurrentUser?.Username) ? currentUser.CurrentUser.Username : "admin";

            await unitOfWork.BeginTransactionAsync();
            try
            {
                var purchase = mapper.Map<Purchase>(dto);

                purchase.DocumentTypeId = dto.DocumentTypeId;
                purchase.SupplierId = dto.SupplierId;
                purchase.UserId = currentUserId;
                purchase.PaymentMethodId = dto.PaymentMethodId > 0 ? dto.PaymentMethodId : 1;
                purchase.DocumentNumber = dto.DocumentNumber.Trim();
                purchase.TotalAmount = dto.Items.Sum(x => x.Quantity * x.BuyPrice);
                purchase.SubTotal = purchase.TotalAmount;
                purchase.TaxAmount = 0;
                purchase.Status = "Completada";
                purchase.CreatedAt = DateTime.UtcNow;

                purchase.DocumentType = null!;
                purchase.Supplier = null!;
                purchase.User = null!;
                purchase.PaymentMethod = null!;

                foreach (var item in purchase.PurchaseItems)
                {
                    item.Product = null!;
                    item.Purchase = null!;
                    item.SubTotal = item.Quantity * item.BuyPrice;

                    var product = await unitOfWork.Products.GetByIdAsync(item.ProductId);
                    
                    if (product == null)
                        continue;

                    product.CurrentStock += item.Quantity;
                    product.BuyPrice = item.BuyPrice;
                    product.LastUpdatedAt = DateTime.UtcNow;
                    product.LastUpdatedBy = currentUsername;

                    await unitOfWork.Products.AddMovementAsync(new StockMovement
                    {
                        ProductId = item.ProductId,
                        UserId = currentUserId,
                        Quantity = item.Quantity,
                        MovementType = MovementType.Purchase,
                        Remarks = $"Compra Nro: {dto.DocumentNumber}",
                        CreatedBy = currentUsername,
                        CreatedAt = DateTime.UtcNow
                    });
                }

                await unitOfWork.Purchases.AddAsync(purchase);
                bool success = await unitOfWork.CompleteAsync();

                if (!success)
                    throw new InvalidOperationException("No se detectaron cambios al persistir la compra.");

                await unitOfWork.CommitAsync();

                return OperationResult.Ok($"Compra N.° '{dto.DocumentNumber}' registrada y stock actualizado con éxito.");
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackAsync();
                return OperationResult.Failure("Fallo crítico en el registro de compra: " + ex.Message);
            }
        }

        public async Task<string> GetNextPurchaseNumberAsync(int documentTypeId)
        {
            var lastNumber = await unitOfWork.Purchases.GetLastDocumentNumberAsync(documentTypeId);
            var getDocumentTypes = await unitOfWork.GetDocumentTypesAsync();
            var documentsType = getDocumentTypes.FirstOrDefault(x => x.Id == documentTypeId);

            string prefix = "FAC-X";

            if (documentsType != null)
            {
                string name = documentsType.Name.ToUpperInvariant();

                // 1. Facturas y Comprobantes Directos
                if (name.Contains("CLIENTE CASUAL")) 
                    prefix = "FAC-CAS";
                else if (name.Contains("FACTURA A") && !name.Contains("TICKET"))
                    prefix = "FAC-A";
                else if (name.Contains("FACTURA B") && !name.Contains("TICKET")) 
                    prefix = "FAC-B";
                else if (name.Contains("FACTURA C")) 
                    prefix = "FAC-C";
                else if (name.Contains("FACTURA M")) 
                    prefix = "FAC-M";
                else if (name.Contains("EXPORTACIÓN") || name.Contains("EXPORTACION"))
                    prefix = "FAC-E";

                // 2. Tickets
                else if (name.Contains("TICKET FACTURA A"))
                    prefix = "TKT-A";
                else if (name.Contains("TICKET FACTURA B")) 
                    prefix = "TKT-B";
                else if (name.Contains("TICKET CONSUMIDOR FINAL")) 
                    prefix = "TKT-CF";

                // 3. Notas de Débito
                else if (name.Contains("NOTA DE DÉBITO A") || name.Contains("NOTA DE DEBITO A"))
                    prefix = "ND-A";
                else if (name.Contains("NOTA DE DÉBITO B") || name.Contains("NOTA DE DEBITO B")) 
                    prefix = "ND-B";
                else if (name.Contains("NOTA DE DÉBITO C") || name.Contains("NOTA DE DEBITO C"))
                    prefix = "ND-C";
                else if (name.Contains("NOTA DE DÉBITO M") || name.Contains("NOTA DE DEBITO M"))
                    prefix = "ND-M";

                // 4. Notas de Crédito
                else if (name.Contains("NOTA DE CRÉDITO A") || name.Contains("NOTA DE CREDITO A")) 
                    prefix = "NC-A";
                else if (name.Contains("NOTA DE CRÉDITO B") || name.Contains("NOTA DE CREDITO B")) 
                    prefix = "NC-B";
                else if (name.Contains("NOTA DE CRÉDITO C") || name.Contains("NOTA DE CREDITO C")) 
                    prefix = "NC-C";
                else if (name.Contains("NOTA DE CRÉDITO M") || name.Contains("NOTA DE CREDITO M")) 
                    prefix = "NC-M";

                // 5. Recibos
                else if (name.Contains("RECIBO A")) 
                    prefix = "REC-A";
                else if (name.Contains("RECIBO B"))
                    prefix = "REC-B";
                else if (name.Contains("RECIBO C")) 
                    prefix = "REC-C";

                // 6. Remitos y Presupuestos
                else if (name.Contains("REMITO R")) 
                    prefix = "REM-R";
                else if (name.Contains("REMITO X")) 
                    prefix = "REM-X";
                else if (name.Contains("PRESUPUESTO"))
                    prefix = "PRE";
                else if (name.Contains("COMPROBANTE X"))
                    prefix = "CMP-X";
            }

            long nextValue = 1;
            
            if (!string.IsNullOrWhiteSpace(lastNumber))
            {
                var match = System.Text.RegularExpressions.Regex.Match(lastNumber, @"\d+$");

                if (match.Success && long.TryParse(match.Value, out long lastValue))
                {
                    nextValue = lastValue + 1;
                }
            }

            return $"{prefix}-{nextValue:D8}";
        }
    }
}