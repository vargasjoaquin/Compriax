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
    public class SupplyChainService(IUnitOfWork unitOfWork, ICurrentUserService currentUser, IMapper mapper, IValidator<SupplierDto> supplierValidator, IValidator<PurchaseCreateDto> purchaseValidator) : ISupplyChainService
    {
        /// <summary>
        /// Obtiene todos los proveedores.
        /// </summary>
        /// <returns>Colección de DTOs de proveedores.</returns>
        public async Task<IEnumerable<SupplierDto>> GetSuppliersAsync()
        {
            var suppliers = await unitOfWork.Suppliers.GetAllAsync();
            return mapper.Map<IEnumerable<SupplierDto>>(suppliers);
        }

        /// <summary>
        /// Crea un nuevo proveedor o actualiza los datos de uno existente, validando la unicidad del CUIT.
        /// </summary>
        /// <param name="dto">Datos del proveedor.</param>
        /// <returns>Resultado de la persistencia de datos.</returns>
        public async Task<OperationResult> UpsertSupplierAsync(SupplierDto dto)
        {
            var validation = await supplierValidator.ValidateAsync(dto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            string normalizedCuit = dto.CUIT.Trim();

            var allSuppliers = await unitOfWork.Suppliers.GetAllAsync();
            
            bool cuitAlreadyExists = allSuppliers.Any(s => s.CUIT.Equals(normalizedCuit, StringComparison.OrdinalIgnoreCase) && s.Id != dto.Id);

            if (cuitAlreadyExists)
                return OperationResult.Failure($"El CUIT '{normalizedCuit}' ya se encuentra registrado por otro proveedor activo.");

            if (dto.Id == 0)
            {
                var supplier = mapper.Map<Supplier>(dto);
                supplier.CUIT = normalizedCuit;
                
                await unitOfWork.Suppliers.AddAsync(supplier);
            }
            else
            {
                var supplier = await unitOfWork.Suppliers.GetByIdAsync(dto.Id);
                
                if (supplier == null)
                    return OperationResult.Failure("Proveedor no encontrado.");

                mapper.Map(dto, supplier);
                supplier.CUIT = normalizedCuit;
                
                unitOfWork.Suppliers.Update(supplier);
            }

            return await unitOfWork.CompleteAsync()
                ? OperationResult.Ok("Proveedor guardado exitosamente.")
                : OperationResult.Failure("No se realizaron cambios en la base de datos.");
        }

        /// <summary>
        /// Realiza la eliminacion de un proveedor.
        /// </summary>
        /// <param name="id">Id del proveedor.</param>
        /// <returns>Resultado de la eliminación.</returns>
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

        /// <summary>
        /// Registra una compra de mercadería, actualiza los precios de costo y aumenta el stock de los productos.
        /// </summary>
        /// <param name="dto">Datos de la compra y sus ítems.</param>
        /// <returns>Resultado de la transacción de compra e ingreso de stock.</returns>
        public async Task<OperationResult> ProcessPurchaseAsync(PurchaseCreateDto dto)
        {
            var validation = await purchaseValidator.ValidateAsync(dto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            int currentUserId = currentUser.CurrentUser!.UserId;
            
            string currentUsername = !string.IsNullOrWhiteSpace(currentUser.CurrentUser?.Username) ? currentUser.CurrentUser.Username : RoleConstants.DEFAULT_ADMIN_USERNAME;

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
                purchase.Status = PurchaseStatuses.COMPLETED;
                purchase.CreatedAt = DateTime.UtcNow;

                purchase.DocumentType = null!;
                purchase.Supplier = null!;
                purchase.User = null!;
                purchase.PaymentMethod = null!;

                foreach (var purchaseItem in purchase.PurchaseItems)
                {
                    purchaseItem.Product = null!;
                    purchaseItem.Purchase = null!;
                    purchaseItem.SubTotal = purchaseItem.Quantity * purchaseItem.BuyPrice;

                    var product = await unitOfWork.Products.GetByIdAsync(purchaseItem.ProductId);
                    
                    if (product == null)
                        continue;

                    product.CurrentStock += purchaseItem.Quantity;
                    product.BuyPrice = purchaseItem.BuyPrice;
                    product.LastUpdatedAt = DateTime.UtcNow;
                    product.LastUpdatedBy = currentUsername;

                    await unitOfWork.Products.AddMovementAsync(new StockMovement
                    {
                        ProductId = purchaseItem.ProductId,
                        UserId = currentUserId,
                        Quantity = purchaseItem.Quantity,
                        MovementType = MovementType.Purchase,
                        Remarks = $"Compra Nro: {dto.DocumentNumber}",
                        CreatedBy = currentUsername,
                        CreatedAt = DateTime.UtcNow
                    });
                }

                await unitOfWork.Purchases.AddAsync(purchase);
                
                bool operationSucceeded = await unitOfWork.CompleteAsync();

                if (!operationSucceeded)
                    throw new InvalidOperationException("No se detectaron cambios al persistir la compra.");

                await unitOfWork.CommitAsync();

                return OperationResult.Ok($"Compra N.° '{dto.DocumentNumber}' registrada y stock actualizado con éxito.");
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackAsync();
                return OperationResult.Failure($"Fallo crítico en el registro de compra: {ex.Message}");
            }
        }

        /// <summary>
        /// Genera el próximo número de comprobante de compra basándose en el prefijo correspondiente al tipo de documento.
        /// </summary>
        /// <param name="documentTypeId">Id del tipo de documento fiscal.</param>
        /// <returns>Una cadena con el formato de prefijo y número correlativo.</returns>
        public async Task<string> GetNextPurchaseNumberAsync(int documentTypeId)
        {
            var lastDocumentNumber = await unitOfWork.Purchases.GetLastDocumentNumberAsync(documentTypeId);
            var getDocumentTypes = await unitOfWork.GetDocumentTypesAsync();
            var documentsType = getDocumentTypes.FirstOrDefault(x => x.Id == documentTypeId);

            string documentPrefix = "FAC-X";

            if (documentsType != null)
            {
                string documentTypeName = documentsType.Name.ToUpperInvariant();

                // 1. Facturas y Comprobantes Directos
                if (documentTypeName.Contains("CLIENTE CASUAL")) 
                    documentPrefix = "FAC-CAS";
                else if (documentTypeName.Contains("FACTURA A") && !documentTypeName.Contains("TICKET"))
                    documentPrefix = "FAC-A";
                else if (documentTypeName.Contains("FACTURA B") && !documentTypeName.Contains("TICKET")) 
                    documentPrefix = "FAC-B";
                else if (documentTypeName.Contains("FACTURA C")) 
                    documentPrefix = "FAC-C";
                else if (documentTypeName.Contains("FACTURA M")) 
                    documentPrefix = "FAC-M";
                else if (documentTypeName.Contains("EXPORTACIÓN") || documentTypeName.Contains("EXPORTACION"))
                    documentPrefix = "FAC-E";

                // 2. Tickets
                else if (documentTypeName.Contains("TICKET FACTURA A"))
                    documentPrefix = "TKT-A";
                else if (documentTypeName.Contains("TICKET FACTURA B")) 
                    documentPrefix = "TKT-B";
                else if (documentTypeName.Contains("TICKET CONSUMIDOR FINAL")) 
                    documentPrefix = "TKT-CF";

                // 3. Notas de Débito
                else if (documentTypeName.Contains("NOTA DE DÉBITO A") || documentTypeName.Contains("NOTA DE DEBITO A"))
                    documentPrefix = "ND-A";
                else if (documentTypeName.Contains("NOTA DE DÉBITO B") || documentTypeName.Contains("NOTA DE DEBITO B")) 
                    documentPrefix = "ND-B";
                else if (documentTypeName.Contains("NOTA DE DÉBITO C") || documentTypeName.Contains("NOTA DE DEBITO C"))
                    documentPrefix = "ND-C";
                else if (documentTypeName.Contains("NOTA DE DÉBITO M") || documentTypeName.Contains("NOTA DE DEBITO M"))
                    documentPrefix = "ND-M";

                // 4. Notas de Crédito
                else if (documentTypeName.Contains("NOTA DE CRÉDITO A") || documentTypeName.Contains("NOTA DE CREDITO A")) 
                    documentPrefix = "NC-A";
                else if (documentTypeName.Contains("NOTA DE CRÉDITO B") || documentTypeName.Contains("NOTA DE CREDITO B")) 
                    documentPrefix = "NC-B";
                else if (documentTypeName.Contains("NOTA DE CRÉDITO C") || documentTypeName.Contains("NOTA DE CREDITO C")) 
                    documentPrefix = "NC-C";
                else if (documentTypeName.Contains("NOTA DE CRÉDITO M") || documentTypeName.Contains("NOTA DE CREDITO M")) 
                    documentPrefix = "NC-M";

                // 5. Recibos
                else if (documentTypeName.Contains("RECIBO A")) 
                    documentPrefix = "REC-A";
                else if (documentTypeName.Contains("RECIBO B"))
                    documentPrefix = "REC-B";
                else if (documentTypeName.Contains("RECIBO C")) 
                    documentPrefix = "REC-C";

                // 6. Remitos y Presupuestos
                else if (documentTypeName.Contains("REMITO R")) 
                    documentPrefix = "REM-R";
                else if (documentTypeName.Contains("REMITO X")) 
                    documentPrefix = "REM-X";
                else if (documentTypeName.Contains("PRESUPUESTO"))
                    documentPrefix = "PRE";
                else if (documentTypeName.Contains("COMPROBANTE X"))
                    documentPrefix = "CMP-X";
            }

            long nextDocumentNumber = 1;
            
            if (!string.IsNullOrWhiteSpace(lastDocumentNumber))
            {
                var numberMatch = System.Text.RegularExpressions.Regex.Match(lastDocumentNumber, @"\d+$");

                if (numberMatch.Success && long.TryParse(numberMatch.Value, out long lastNumericValue))
                {
                    nextDocumentNumber = lastNumericValue + 1;
                }
            }

            return $"{documentPrefix}-{nextDocumentNumber:D8}";
        }
    }
}