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

            if (dto.Id == 0)
            {
                var supplier = mapper.Map<Supplier>(dto);
                await unitOfWork.Suppliers.AddAsync(supplier);
            }
            else
            {
                var supplier = await unitOfWork.Suppliers.GetByIdAsync(dto.Id);
                
                if (supplier == null)
                    return OperationResult.Failure("Proveedor no encontrado.");

                mapper.Map(dto, supplier);
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
    }
}