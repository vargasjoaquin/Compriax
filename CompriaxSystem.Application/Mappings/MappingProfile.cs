using AutoMapper;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ==========================================
            // 1. USUARIOS Y PERFIL
            // ==========================================
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role != null ? src.Role.Name : string.Empty));

            CreateMap<UserDto, User>()
                .ForMember(dest => dest.Role, opt => opt.Ignore())
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            CreateMap<User, UserSessionDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.LastName}, {src.FirstName}".Trim()))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role != null ? src.Role.Name : string.Empty))
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo))
                .ForMember(dest => dest.LoginTime, opt => opt.Ignore());

            CreateMap<UserCreateDto, User>()
                .ForMember(dest => dest.Role, opt => opt.Ignore())
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Photo))
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            CreateMap<UserProfileUpdateDto, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ForMember(dest => dest.Role, opt => opt.Ignore())
                .ForMember(dest => dest.RoleId, opt => opt.Ignore())
                .ForMember(dest => dest.Username, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            // ==========================================
            // 2. CATEGORÍAS
            // ==========================================
            CreateMap<Category, CategoryDto>().ReverseMap()
                .ForMember(dest => dest.Products, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            // ==========================================
            // 3. CLIENTES
            // ==========================================
            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.TaxConditionName, opt => opt.MapFrom(src => src.TaxCondition != null ? src.TaxCondition.Name : string.Empty))
                .ReverseMap()
                .ForMember(dest => dest.TaxCondition, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            // ==========================================
            // 4. PROVEEDORES
            // ==========================================
            CreateMap<Supplier, SupplierDto>().ReverseMap()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            // ==========================================
            // 5. EMPLEADOS
            // ==========================================
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.Position != null ? src.Position.Name : string.Empty))
                .ForMember(dest => dest.GenderName, opt => opt.MapFrom(src => src.Gender != null ? src.Gender.Name : string.Empty))
                .ForMember(dest => dest.CivilStatusName, opt => opt.MapFrom(src => src.CivilStatus != null ? src.CivilStatus.Name : string.Empty))
                .ReverseMap()
                .ForMember(dest => dest.Position, opt => opt.Ignore())
                .ForMember(dest => dest.Gender, opt => opt.Ignore())
                .ForMember(dest => dest.CivilStatus, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            // ==========================================
            // 6. PRODUCTOS
            // ==========================================
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand != null ? src.Brand.Name : string.Empty))
                .ReverseMap()
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.Brand, opt => opt.Ignore())
                .ForMember(dest => dest.UnitOfMeasure, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            CreateMap<ProductCreateDto, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CurrentStock, opt => opt.MapFrom(src => src.InitialStock))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(_ => true))
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.Brand, opt => opt.Ignore())
                .ForMember(dest => dest.UnitOfMeasure, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            // ==========================================
            // 7. VENTAS (SALES)
            // ==========================================
            CreateMap<Sale, SaleDto>()
                .ForMember(dest => dest.DocumentTypeName, opt => opt.MapFrom(src => src.DocumentType != null ? src.DocumentType.Name : "N/A"))
                .ForMember(dest => dest.PaymentMethodName, opt => opt.MapFrom(src => src.PaymentMethod != null ? src.PaymentMethod.Name : "Efectivo"))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer != null ? $"{src.Customer.LastName}, {src.Customer.FirstName}".Trim() : "Consumidor Final"))
                .ForMember(dest => dest.CustomerDoc, opt => opt.MapFrom(src => src.Customer != null ? src.Customer.DocumentNumber : "S/D"))
                .ForMember(dest => dest.CashierName, opt => opt.MapFrom(src => src.User != null ? src.User.Username : "N/A"))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.SaleItems))
                .ForMember(dest => dest.AppliedDiscounts, opt => opt.Ignore());

            CreateMap<SaleDto, Sale>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DocumentType, opt => opt.Ignore())
                .ForMember(dest => dest.Customer, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.PaymentMethod, opt => opt.Ignore())
                .ForMember(dest => dest.CashShift, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.Date != default ? src.Date : DateTime.UtcNow))
                .ForMember(dest => dest.SaleItems, opt => opt.MapFrom(src => src.Items))
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            CreateMap<SaleItem, SaleItemDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product != null ? src.Product.Name : string.Empty))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Product != null ? src.Product.CategoryId : (int?)null));

            CreateMap<SaleItemDto, SaleItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.SaleId, opt => opt.Ignore())
                .ForMember(dest => dest.Sale, opt => opt.Ignore())
                .ForMember(dest => dest.Product, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            // ==========================================
            // 8. COMPRAS (PURCHASES)
            // ==========================================
            CreateMap<Purchase, PurchaseCreateDto>()
                .ForMember(dest => dest.DocumentTypeName, opt => opt.MapFrom(src => src.DocumentType != null ? src.DocumentType.Name : string.Empty))
                .ForMember(dest => dest.PaymentMethodName, opt => opt.MapFrom(src => src.PaymentMethod != null ? src.PaymentMethod.Name : "Efectivo"))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.PurchaseItems));

            CreateMap<PurchaseCreateDto, Purchase>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DocumentType, opt => opt.Ignore())
                .ForMember(dest => dest.Supplier, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.PaymentMethod, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.PurchaseItems, opt => opt.MapFrom(src => src.Items))
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            CreateMap<PurchaseItem, PurchaseItemCreateDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product != null ? src.Product.Name : string.Empty));

            CreateMap<PurchaseItemCreateDto, PurchaseItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.PurchaseId, opt => opt.Ignore())
                .ForMember(dest => dest.Purchase, opt => opt.Ignore())
                .ForMember(dest => dest.Product, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            // ==========================================
            // 9. AJUSTES DEL COMERCIO (STORE SETTINGS)
            // ==========================================
            CreateMap<StoreSettings, StoreSettingsDto>().ReverseMap()
                .ForMember(dest => dest.TaxCondition, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            // ==========================================
            // 10. PROMOCIONES Y DESCUENTOS
            // ==========================================
            CreateMap<Promotion, PromotionDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product != null ? src.Product.Name : null))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : null))
                .ReverseMap()
                .ForMember(dest => dest.Product, opt => opt.Ignore())
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            // ==========================================
            // 11. TURNOS Y MOVIMIENTOS DE CAJA
            // ==========================================
            CreateMap<CashShift, CashShiftDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? $"{src.User.LastName}, {src.User.FirstName}".Trim() : "Cajero"))
                .ReverseMap()
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Sales, opt => opt.Ignore())
                .ForMember(dest => dest.CashMovements, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            CreateMap<CashMovement, CashMovementDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.Username : "Cajero"))
                .ReverseMap()
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.CashShift, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            CreateMap<CashMovementCreateDto, CashMovement>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CashShiftId, opt => opt.Ignore())
                .ForMember(dest => dest.CashShift, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());
        }
    }
}