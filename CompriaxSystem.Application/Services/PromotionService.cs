using AutoMapper;
using FluentValidation;
using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Domain.Enums;

namespace CompriaxSystem.Application.Services
{
    public class PromotionService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUser, IValidator<PromotionDto> validator) : IPromotionService
    {
        /// <summary>
        /// Obtiene todas las promociones.
        /// </summary>
        /// <returns>Una colección de DTOs de promociones.</returns>
        public async Task<IEnumerable<PromotionDto>> GetAllPromotionsAsync()
        {
            var promotions = await unitOfWork.Promotions.GetAllAsync();
            return mapper.Map<IEnumerable<PromotionDto>>(promotions);
        }

        /// <summary>
        /// Busca una promoción específica por su id.
        /// </summary>
        /// <param name="id">Id de la promoción.</param>
        /// <returns>Los datos de la promoción o null si no existe.</returns>
        public async Task<PromotionDto?> GetByIdAsync(int id)
        {
            var promotions = await unitOfWork.Promotions.GetByIdAsync(id);
            return promotions == null ? null : mapper.Map<PromotionDto>(promotions);
        }

        /// <summary>
        /// Crea una nueva promoción o actualiza una existente, registrando el usuario que realiza la acción.
        /// </summary>
        /// <param name="dto">Datos de la promoción a persistir.</param>
        /// <returns>Resultado de la operación de guardado.</returns>
        public async Task<OperationResult> UpsertPromotionAsync(PromotionDto dto)
        {
            var validation = await validator.ValidateAsync(dto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            string currentUsername = currentUser.CurrentUser!.Username;

            if (dto.Id == 0)
            {
                var promotion = mapper.Map<Promotion>(dto);
                
                promotion.CreatedBy = currentUsername;
                promotion.CreatedAt = DateTime.UtcNow;

                await unitOfWork.Promotions.AddAsync(promotion);
            }
            else
            {
                var promotion = await unitOfWork.Promotions.GetByIdAsync(dto.Id);
                
                if (promotion == null)
                    return OperationResult.Failure("Promoción no encontrada.");

                mapper.Map(dto, promotion);
                promotion.LastUpdatedBy = currentUsername;
                promotion.LastUpdatedAt = DateTime.UtcNow;

                unitOfWork.Promotions.Update(promotion);
            }

            return await unitOfWork.CompleteAsync()
                ? OperationResult.Ok("Promoción guardada exitosamente.")
                : OperationResult.Failure("No se realizaron cambios en la base de datos.");
        }

        /// <summary>
        /// Realiza la eliminación de una promoción marcándola como borrada.
        /// </summary>
        /// <param name="id">Id de la promoción a eliminar.</param>
        /// <returns>Resultado del proceso de eliminación.</returns>
        public async Task<OperationResult> DeletePromotionAsync(int id)
        {
            var promotion = await unitOfWork.Promotions.GetByIdAsync(id);
            
            if (promotion == null)
                return OperationResult.Failure("Promoción no encontrada.");

            promotion.IsDeleted = true;
            promotion.LastUpdatedBy = currentUser.CurrentUser!.Username;
            promotion.LastUpdatedAt = DateTime.UtcNow;

            unitOfWork.Promotions.Update(promotion);
            
            return await unitOfWork.CompleteAsync()
                ? OperationResult.Ok("Promoción eliminada.")
                : OperationResult.Failure("Error al eliminar la promoción.");
        }

        /// <summary>
        /// Alterna el estado de activación (Habilitado/Deshabilitado) de una promoción.
        /// </summary>
        /// <param name="id">Id de la promoción.</param>
        /// <returns>Resultado del cambio de estado.</returns>
        public async Task<OperationResult> ToggleStatusAsync(int id)
        {
            var promotion = await unitOfWork.Promotions.GetByIdAsync(id);
            
            if (promotion == null)
                return OperationResult.Failure("Promoción no encontrada.");

            promotion.IsActive = !promotion.IsActive;
            promotion.LastUpdatedBy = currentUser.CurrentUser!.Username;
            promotion.LastUpdatedAt = DateTime.UtcNow;

            unitOfWork.Promotions.Update(promotion);
            
            return await unitOfWork.CompleteAsync()
                ? OperationResult.Ok($"Promoción {(promotion.IsActive ? "activada" : "desactivada")} correctamente.")
                : OperationResult.Failure("Error al actualizar el estado.");
        }

        /// <summary>
        /// Ejecuta el motor de reglas de promociones para calcular descuentos por NxM, porcentaje por producto, categoría o total general.
        /// </summary>
        /// <param name="items">Lista de productos a evaluar.</param>
        /// <param name="date">Fecha de aplicación para validar vigencia y días de la semana.</param>
        /// <returns>Un objeto con el desglose de descuentos aplicados y los totales calculados.</returns>
        public async Task<SaleCalculationResultDto> CalculateSaleDiscountsAsync(IEnumerable<SaleItemDto> items, DateTime date)
        {
            var saleItems = items.Select(x => new SaleItemDto
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                CategoryId = x.CategoryId,
                Quantity = x.Quantity,
                UnitPrice = x.UnitPrice,
                DiscountAmount = 0
            }).ToList();

            decimal grossSubTotal = saleItems.Sum(x => x.Quantity * x.UnitPrice);
            var activePromotions = (await unitOfWork.Promotions.GetActivePromotionsAsync(date)).ToList();

            int currentDayOfWeekNumber = (int)date.DayOfWeek;

            if (currentDayOfWeekNumber == 0)
                currentDayOfWeekNumber = 7;

            var validPromotions = activePromotions.Where(p => string.IsNullOrWhiteSpace(p.DaysOfWeek) || p.DaysOfWeek.Split(',').Select(d => int.TryParse(d.Trim(), out int n) ? n : 0).Contains(currentDayOfWeekNumber)).ToList();

            var appliedDiscounts = new List<AppliedDiscountDto>();

            // 1. Promociones por Cantidad (NxM) en Productos
            foreach (var promotion in validPromotions.Where(promotion => promotion.PromotionType == PromotionType.BuyXPayY && promotion.ProductId.HasValue))
            {
                var saleItem = saleItems.FirstOrDefault(item => item.ProductId == promotion.ProductId.Value);

                if (saleItem != null && promotion.RequiredQuantity > 0 && promotion.PayQuantity > 0)
                {
                    int promotionGroups = saleItem.Quantity / promotion.RequiredQuantity.Value;

                    if (promotionGroups > 0)
                    {
                        int freeItemsPerGroup = promotion.RequiredQuantity.Value - promotion.PayQuantity.Value;

                        decimal discountAmount = promotionGroups * freeItemsPerGroup * saleItem.UnitPrice;

                        saleItem.DiscountAmount += discountAmount;

                        appliedDiscounts.Add(new AppliedDiscountDto
                        {
                            PromotionId = promotion.Id,
                            PromotionName = promotion.Name,
                            DiscountAmount = discountAmount,
                            Description = $"Promo {promotion.Name}: {promotionGroups * freeItemsPerGroup} unidad(es) bonificada(s)"
                        });
                    }
                }
            }

            // 2. Promociones Porcentuales por Producto
            foreach (var promotion in validPromotions.Where(promotion => promotion.PromotionType == PromotionType.PercentageOnProduct && promotion.ProductId.HasValue && promotion.DiscountPercentage.HasValue))
            {
                var saleItem = saleItems.FirstOrDefault(i => i.ProductId == promotion.ProductId.Value);

                if (saleItem != null && saleItem.DiscountAmount == 0)
                {
                    decimal discountAmount = (saleItem.Quantity * saleItem.UnitPrice) * (promotion.DiscountPercentage.Value / 100m);

                    saleItem.DiscountAmount += discountAmount;

                    appliedDiscounts.Add(new AppliedDiscountDto
                    {
                        PromotionId = promotion.Id,
                        PromotionName = promotion.Name,
                        DiscountAmount = discountAmount,
                        Description = $"{promotion.Name} ({promotion.DiscountPercentage.Value:0.#}% OFF en {saleItem.ProductName})"
                    });
                }
            }

            // 3. Promociones Porcentuales por Categoría
            foreach (var promotion in validPromotions.Where(promotion => promotion.PromotionType == PromotionType.PercentageOnCategory && promotion.CategoryId.HasValue && promotion.DiscountPercentage.HasValue))
            {
                var categoryItems = saleItems.Where(i => i.CategoryId == promotion.CategoryId.Value && i.DiscountAmount == 0).ToList();

                foreach (var saleItem in categoryItems)
                {
                    decimal discountAmount = (saleItem.Quantity * saleItem.UnitPrice) * (promotion.DiscountPercentage.Value / 100m);

                    saleItem.DiscountAmount += discountAmount;

                    appliedDiscounts.Add(new AppliedDiscountDto
                    {
                        PromotionId = promotion.Id,
                        PromotionName = promotion.Name,
                        DiscountAmount = discountAmount,
                        Description = $"{promotion.Name} ({promotion.DiscountPercentage.Value:0.#}% OFF en {saleItem.ProductName})"
                    });
                }
            }

            // 4. Promoción Porcentual al Total de la Compra
            decimal intermediateTotal = saleItems.Sum(x => x.SubTotal);

            var cartPromotion = validPromotions.FirstOrDefault(promotion => promotion.PromotionType == PromotionType.PercentageOnTotal && promotion.DiscountPercentage.HasValue);

            decimal cartDiscountAmount = 0;

            if (cartPromotion != null && intermediateTotal > 0)
            {
                cartDiscountAmount = intermediateTotal * (cartPromotion.DiscountPercentage.Value / 100m);

                appliedDiscounts.Add(new AppliedDiscountDto
                {
                    PromotionId = cartPromotion.Id,
                    PromotionName = cartPromotion.Name,
                    DiscountAmount = cartDiscountAmount,
                    Description = $"{cartPromotion.Name} ({cartPromotion.DiscountPercentage.Value:0.#}% OFF en Total del Ticket)"
                });
            }

            decimal totalDiscountAmount = appliedDiscounts.Sum(x => x.DiscountAmount);
            decimal finalTotal = Math.Max(0, grossSubTotal - totalDiscountAmount);

            return new SaleCalculationResultDto
            {
                SubTotal = grossSubTotal,
                TotalDiscount = totalDiscountAmount,
                FinalTotal = finalTotal,
                Discounts = appliedDiscounts,
                CalculatedItems = saleItems
            };
        }
    }
}