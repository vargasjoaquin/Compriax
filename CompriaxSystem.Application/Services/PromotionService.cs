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
    public class PromotionService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ICurrentUserService currentUser,
        IValidator<PromotionDto> validator) : IPromotionService
    {
        /// <summary>
        /// Obtiene todas las promociones.
        /// </summary>
        /// <returns>Una colección de DTOs de promociones.</returns>
        public async Task<IEnumerable<PromotionDto>> GetAllPromotionsAsync()
        {
            var promos = await unitOfWork.Promotions.GetAllAsync();
            return mapper.Map<IEnumerable<PromotionDto>>(promos);
        }

        /// <summary>
        /// Busca una promoción específica por su id.
        /// </summary>
        /// <param name="id">Id de la promoción.</param>
        /// <returns>Los datos de la promoción o null si no existe.</returns>
        public async Task<PromotionDto?> GetByIdAsync(int id)
        {
            var promo = await unitOfWork.Promotions.GetByIdAsync(id);
            return promo == null ? null : mapper.Map<PromotionDto>(promo);
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
            var itemList = items.Select(x => new SaleItemDto
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                CategoryId = x.CategoryId,
                Quantity = x.Quantity,
                UnitPrice = x.UnitPrice,
                DiscountAmount = 0
            }).ToList();

            decimal grossSubTotal = itemList.Sum(x => x.Quantity * x.UnitPrice);
            var activePromotions = (await unitOfWork.Promotions.GetActivePromotionsAsync(date)).ToList();

            int currentDayOfWeek = (int)date.DayOfWeek;
            
            if (currentDayOfWeek == 0)
                currentDayOfWeek = 7;

            var validPromotions = activePromotions.Where(p =>
                string.IsNullOrWhiteSpace(p.DaysOfWeek) ||
                p.DaysOfWeek.Split(',').Select(d => int.TryParse(d.Trim(), out int n) ? n : 0).Contains(currentDayOfWeek)
            ).ToList();

            var appliedDiscounts = new List<AppliedDiscountDto>();

            // 1. Promociones por Cantidad (NxM) en Productos
            foreach (var promo in validPromotions.Where(p => p.PromotionType == PromotionType.BuyXPayY && p.ProductId.HasValue))
            {
                var item = itemList.FirstOrDefault(i => i.ProductId == promo.ProductId.Value);
                
                if (item != null && promo.RequiredQuantity > 0 && promo.PayQuantity > 0)
                {
                    int groups = item.Quantity / promo.RequiredQuantity.Value;
                    
                    if (groups > 0)
                    {
                        int freeItemsPerGroup = promo.RequiredQuantity.Value - promo.PayQuantity.Value;
                        decimal discount = groups * freeItemsPerGroup * item.UnitPrice;

                        item.DiscountAmount += discount;
                        appliedDiscounts.Add(new AppliedDiscountDto
                        {
                            PromotionId = promo.Id,
                            PromotionName = promo.Name,
                            DiscountAmount = discount,
                            Description = $"Promo {promo.Name}: {groups * freeItemsPerGroup} unidad(es) bonificada(s)"
                        });
                    }
                }
            }

            // 2. Promociones Porcentuales por Producto
            foreach (var promo in validPromotions.Where(p => p.PromotionType == PromotionType.PercentageOnProduct && p.ProductId.HasValue && p.DiscountPercentage.HasValue))
            {
                var item = itemList.FirstOrDefault(i => i.ProductId == promo.ProductId.Value);
                
                if (item != null && item.DiscountAmount == 0)
                {
                    decimal discount = (item.Quantity * item.UnitPrice) * (promo.DiscountPercentage.Value / 100m);
                    item.DiscountAmount += discount;

                    appliedDiscounts.Add(new AppliedDiscountDto
                    {
                        PromotionId = promo.Id,
                        PromotionName = promo.Name,
                        DiscountAmount = discount,
                        Description = $"{promo.Name} ({promo.DiscountPercentage.Value:0.#}% OFF en {item.ProductName})"
                    });
                }
            }

            // 3. Promociones Porcentuales por Categoría
            foreach (var promo in validPromotions.Where(p => p.PromotionType == PromotionType.PercentageOnCategory && p.CategoryId.HasValue && p.DiscountPercentage.HasValue))
            {
                var categoryItems = itemList.Where(i => i.CategoryId == promo.CategoryId.Value && i.DiscountAmount == 0).ToList();

                foreach (var item in categoryItems)
                {
                    decimal discount = (item.Quantity * item.UnitPrice) * (promo.DiscountPercentage.Value / 100m);
                    item.DiscountAmount += discount;

                    appliedDiscounts.Add(new AppliedDiscountDto
                    {
                        PromotionId = promo.Id,
                        PromotionName = promo.Name,
                        DiscountAmount = discount,
                        Description = $"{promo.Name} ({promo.DiscountPercentage.Value:0.#}% OFF en {item.ProductName})"
                    });
                }
            }

            // 4. Promoción Porcentual al Total de la Compra
            decimal intermediateTotal = itemList.Sum(x => x.SubTotal);
            var cartPromo = validPromotions.FirstOrDefault(p => p.PromotionType == PromotionType.PercentageOnTotal && p.DiscountPercentage.HasValue);

            decimal cartDiscount = 0;
            
            if (cartPromo != null && intermediateTotal > 0)
            {
                cartDiscount = intermediateTotal * (cartPromo.DiscountPercentage.Value / 100m);
                appliedDiscounts.Add(new AppliedDiscountDto
                {
                    PromotionId = cartPromo.Id,
                    PromotionName = cartPromo.Name,
                    DiscountAmount = cartDiscount,
                    Description = $"{cartPromo.Name} ({cartPromo.DiscountPercentage.Value:0.#}% OFF en Total del Ticket)"
                });
            }

            decimal totalDiscount = appliedDiscounts.Sum(x => x.DiscountAmount);
            decimal finalTotal = Math.Max(0, grossSubTotal - totalDiscount);

            return new SaleCalculationResultDto
            {
                SubTotal = grossSubTotal,
                TotalDiscount = totalDiscount,
                FinalTotal = finalTotal,
                Discounts = appliedDiscounts,
                CalculatedItems = itemList
            };
        }
    }
}