using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Common;
using CompriaxSystem.Domain.Constants;
using CompriaxSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CompriaxSystem.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }

        // 1. Seguridad y Acceso
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();

        // 2. Catálogo e Inventario
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<UnitsOfMeasure> UnitsOfMeasure => Set<UnitsOfMeasure>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<StockMovement> StockMovements => Set<StockMovement>();
        public DbSet<Promotion> Promotions => Set<Promotion>();

        // 3. Personas y Recursos Humanos
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Supplier> Suppliers => Set<Supplier>();
        public DbSet<Employee> Employees => Set<Employee>();

        // 4. Operaciones, Ventas y Compras
        public DbSet<Sale> Sales => Set<Sale>();
        public DbSet<SaleItem> SaleItems => Set<SaleItem>();
        public DbSet<Purchase> Purchases => Set<Purchase>();
        public DbSet<PurchaseItem> PurchaseItems => Set<PurchaseItem>();

        // 5. Control de Caja y Turnos
        public DbSet<CashShift> CashShifts => Set<CashShift>();
        public DbSet<CashMovement> CashMovements => Set<CashMovement>();
        public DbSet<CashRegister> CashRegisters => Set<CashRegister>();

        // 6. Ajustes y Tablas Maestras
        public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();
        public DbSet<StoreSettings> StoreSettings => Set<StoreSettings>();
        public DbSet<TaxCondition> TaxConditions => Set<TaxCondition>();
        public DbSet<Gender> Genders => Set<Gender>();
        public DbSet<CivilStatus> CivilStatuses => Set<CivilStatus>();
        public DbSet<Position> Positions => Set<Position>();
        public DbSet<DocumentType> DocumentTypes => Set<DocumentType>();

        // 7. Transacciones de pagos mediante Mercado Pago (QR)
        public DbSet<MercadoPagoTransaction> MercadoPagoTransactions => Set<MercadoPagoTransaction>();
        public DbSet<MercadoPagoPaymentStatues> MercadoPagoPaymentStatuses => Set<MercadoPagoPaymentStatues>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =========================================================================
            // 1. CONCURRENCIA OPTIMISTA GLOBAL (RowVersion)
            // =========================================================================
            var entitiesWithRowVersion = modelBuilder.Model.GetEntityTypes()
                .Where(e => typeof(BaseEntity).IsAssignableFrom(e.ClrType));

            foreach (var entity in entitiesWithRowVersion)
            {
                modelBuilder.Entity(entity.ClrType)
                    .Property(nameof(BaseEntity.RowVersion))
                    .IsRowVersion()
                    .IsRequired();
            }

            // =========================================================================
            // 2. SEGURIDAD Y USUARIOS
            // =========================================================================
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(u => u.Id);
                entity.HasIndex(u => u.Username).IsUnique();

                entity.Property(u => u.Username).IsRequired().HasMaxLength(50);
                entity.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(u => u.LastName).IsRequired().HasMaxLength(50);
                entity.Property(u => u.Email).HasMaxLength(100);
                entity.Property(u => u.Password).IsRequired().HasMaxLength(255);
                entity.Property(u => u.Photo).HasColumnType("varbinary(max)").IsRequired(false);

                entity.HasIndex(u => u.RoleId)
                      .IsUnique()
                      .HasFilter($"[RoleId] = {RoleConstants.ADMINISTRATOR_ROLE_ID} AND [IsDeleted] = 0")
                      .HasDatabaseName("UQ_Users_SingleActiveAdmin");

                entity.HasOne(u => u.Role)
                      .WithMany(r => r.Users)
                      .HasForeignKey(u => u.RoleId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Roles");
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Name).IsRequired().HasMaxLength(50);
            });

            // =========================================================================
            // 3. CATÁLOGO E INVENTARIO
            // =========================================================================
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(50);
                entity.Property(c => c.Description).HasMaxLength(250);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brands");
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Name).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<UnitsOfMeasure>(entity =>
            {
                entity.ToTable("UnitsOfMeasure");
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Name).IsRequired().HasMaxLength(50);
                entity.Property(u => u.Abbreviation).IsRequired().HasMaxLength(10);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
                entity.HasKey(p => p.Id);
                entity.HasIndex(p => p.Barcode).IsUnique();

                entity.Property(p => p.Barcode).IsRequired().HasMaxLength(50);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Description).HasMaxLength(250);

                entity.Property(p => p.BuyPrice).HasPrecision(18, 4);
                entity.Property(p => p.SellPrice).HasPrecision(18, 4);
                entity.Property(p => p.Image).HasColumnType("varbinary(max)").IsRequired(false);

                entity.HasOne(p => p.Category)
                      .WithMany(c => c.Products)
                      .HasForeignKey(p => p.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Brand)
                      .WithMany(b => b.Products)
                      .HasForeignKey(p => p.BrandId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.UnitOfMeasure)
                      .WithMany()
                      .HasForeignKey(p => p.UnitOfMeasureId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<StockMovement>(entity =>
            {
                entity.ToTable("StockMovements");
                entity.HasKey(sm => sm.Id);

                entity.Property(sm => sm.MovementType).HasConversion<string>().HasMaxLength(30);
                entity.Property(sm => sm.Remarks).HasMaxLength(250);
                entity.Property(sm => sm.CreatedBy).HasMaxLength(50);

                entity.HasOne(sm => sm.Product)
                      .WithMany()
                      .HasForeignKey(sm => sm.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(sm => sm.User)
                      .WithMany()
                      .HasForeignKey(sm => sm.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.ToTable("Promotions");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Description).HasMaxLength(250);
                entity.Property(p => p.DiscountPercentage).HasPrecision(18, 2);
                entity.Property(p => p.PromotionType).HasConversion<int>();
                entity.Property(p => p.DaysOfWeek).HasMaxLength(50);

                entity.HasOne(p => p.Product)
                      .WithMany()
                      .HasForeignKey(p => p.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Category)
                      .WithMany()
                      .HasForeignKey(p => p.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // =========================================================================
            // 4. PERSONAS Y RECURSOS HUMANOS
            // =========================================================================
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers");
                entity.HasKey(c => c.Id);

                entity.HasIndex(c => c.DocumentNumber)
                      .IsUnique()
                      .HasFilter("[IsDeleted] = 0")
                      .HasDatabaseName("UQ_Customers_ActiveDocumentNumber");

                entity.Property(c => c.DocumentNumber).IsRequired().HasMaxLength(20);
                entity.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(c => c.LastName).IsRequired().HasMaxLength(50);
                entity.Property(c => c.Cuil).HasMaxLength(25);
                entity.Property(c => c.Email).HasMaxLength(100);
                entity.Property(c => c.Phone).HasMaxLength(30);
                entity.Property(c => c.Address).HasMaxLength(150);
                entity.Property(c => c.City).HasMaxLength(80);

                entity.HasOne(c => c.TaxCondition)
                      .WithMany()
                      .HasForeignKey(c => c.TaxConditionId)
                      .IsRequired(false)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Suppliers");
                entity.HasKey(s => s.Id);

                entity.HasIndex(s => s.CUIT)
                      .IsUnique()
                      .HasFilter("[IsDeleted] = 0")
                      .HasDatabaseName("UQ_Suppliers_ActiveCUIT");

                entity.Property(s => s.CUIT).IsRequired().HasMaxLength(25);
                entity.Property(s => s.CompanyName).IsRequired().HasMaxLength(100);
                entity.Property(s => s.ContactName).HasMaxLength(80);
                entity.Property(s => s.Email).HasMaxLength(100);
                entity.Property(s => s.Phone).HasMaxLength(30);
                entity.Property(s => s.Address).HasMaxLength(150);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employees");
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.EmployeeCode)
                      .IsUnique()
                      .HasFilter("[IsDeleted] = 0")
                      .HasDatabaseName("UQ_Employees_ActiveEmployeeCode");

                entity.HasIndex(e => e.DocumentNumber)
                      .IsUnique()
                      .HasFilter("[IsDeleted] = 0")
                      .HasDatabaseName("UQ_Employees_ActiveDocumentNumber");

                entity.Property(e => e.EmployeeCode).IsRequired().HasMaxLength(20);
                entity.Property(e => e.DocumentNumber).IsRequired().HasMaxLength(20);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Cuil).HasMaxLength(25);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Phone).HasMaxLength(30);
                entity.Property(e => e.Address).HasMaxLength(150);
                entity.Property(e => e.Photo).HasColumnType("varbinary(max)").IsRequired(false);

                entity.HasOne(e => e.Position)
                      .WithMany()
                      .HasForeignKey(e => e.PositionId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Gender)
                      .WithMany()
                      .HasForeignKey(e => e.GenderId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.CivilStatus)
                      .WithMany()
                      .HasForeignKey(e => e.CivilStatusId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // =========================================================================
            // 5. VENTAS (SALES)
            // =========================================================================
            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("Sales");
                entity.HasKey(s => s.Id);

                entity.HasIndex(s => new { s.DocumentTypeId, s.PointOfSale, s.DocumentNumber })
                      .IsUnique()
                      .HasDatabaseName("UQ_Sales_DocumentNumber_Per_Type_And_POS");

                entity.Property(s => s.DocumentNumber).IsRequired().HasMaxLength(50);
                entity.Property(s => s.SubTotal).HasPrecision(18, 2);
                entity.Property(s => s.DiscountAmount).HasPrecision(18, 2);
                entity.Property(s => s.TotalAmount).HasPrecision(18, 2);
                entity.Property(s => s.PaymentReceived).HasPrecision(18, 2);
                entity.Property(s => s.PaymentChange).HasPrecision(18, 2);
                entity.Property(s => s.Cae).HasMaxLength(20);
                entity.Property(s => s.AfipQrUrl).HasMaxLength(500);
                entity.Property(s => s.FiscalStatus).HasMaxLength(50);

                entity.HasOne(s => s.DocumentType)
                      .WithMany()
                      .HasForeignKey(s => s.DocumentTypeId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(s => s.Customer)
                      .WithMany()
                      .HasForeignKey(s => s.CustomerId)
                      .IsRequired(false)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(s => s.User)
                      .WithMany()
                      .HasForeignKey(s => s.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(s => s.PaymentMethod)
                      .WithMany()
                      .HasForeignKey(s => s.PaymentMethodId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(s => s.CashShift)
                      .WithMany(cs => cs.Sales)
                      .HasForeignKey(s => s.CashShiftId)
                      .IsRequired(false)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(s => s.SaleItems)
                      .WithOne(si => si.Sale)
                      .HasForeignKey(si => si.SaleId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(s => s.CashRegister)
                      .WithMany(cr => cr.Sales)
                      .HasForeignKey(s => s.CashRegisterId)
                      .IsRequired(false)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<SaleItem>(entity =>
            {
                entity.ToTable("SaleItems");
                entity.HasKey(si => si.Id);

                entity.Property(si => si.UnitPrice).HasPrecision(18, 4);
                entity.Property(si => si.DiscountAmount).HasPrecision(18, 2);
                entity.Property(si => si.CostPrice).HasPrecision(18, 4);
                entity.Property(si => si.SubTotal).HasPrecision(18, 2);

                entity.HasOne(si => si.Product)
                      .WithMany()
                      .HasForeignKey(si => si.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // =========================================================================
            // 6. COMPRAS (PURCHASES)
            // =========================================================================
            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.ToTable("Purchases");
                entity.HasKey(p => p.Id);

                entity.Property(p => p.DocumentNumber).IsRequired().HasMaxLength(50);
                entity.Property(p => p.SubTotal).HasPrecision(18, 2);
                entity.Property(p => p.TaxAmount).HasPrecision(18, 2);
                entity.Property(p => p.TotalAmount).HasPrecision(18, 2);
                entity.Property(p => p.Status).HasMaxLength(20);
                entity.Property(p => p.Remarks).HasMaxLength(250);

                entity.HasOne(p => p.Supplier)
                      .WithMany()
                      .HasForeignKey(p => p.SupplierId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.DocumentType)
                      .WithMany()
                      .HasForeignKey(p => p.DocumentTypeId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.User)
                      .WithMany()
                      .HasForeignKey(p => p.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.PaymentMethod)
                      .WithMany()
                      .HasForeignKey(p => p.PaymentMethodId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(p => p.PurchaseItems)
                      .WithOne(pi => pi.Purchase)
                      .HasForeignKey(pi => pi.PurchaseId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PurchaseItem>(entity =>
            {
                entity.ToTable("PurchaseItems");
                entity.HasKey(pi => pi.Id);

                entity.Property(pi => pi.BuyPrice).HasPrecision(18, 4);
                entity.Property(pi => pi.SubTotal).HasPrecision(18, 2);

                entity.HasOne(pi => pi.Product)
                      .WithMany()
                      .HasForeignKey(pi => pi.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // =========================================================================
            // 7. CONTROL DE CAJA Y TURNOS
            // =========================================================================
            modelBuilder.Entity<CashShift>(entity =>
            {
                entity.ToTable("CashShifts");
                entity.HasKey(cs => cs.Id);

                entity.HasIndex(cs => cs.CashRegisterId)
                      .IsUnique()
                      .HasFilter($"[Status] = '{CashShiftStatusesConstants.OPEN}'")
                      .HasDatabaseName("UQ_CashShifts_SingleActiveShiftPerRegister");

                entity.Property(cs => cs.InitialCash).HasPrecision(18, 2);
                entity.Property(cs => cs.RealCash).HasPrecision(18, 2);
                entity.Property(cs => cs.ExpectedCash).HasPrecision(18, 2);
                entity.Property(cs => cs.Difference).HasPrecision(18, 2);

                entity.Property(cs => cs.TotalCashSales).HasPrecision(18, 2);
                entity.Property(cs => cs.TotalDebitSales).HasPrecision(18, 2);
                entity.Property(cs => cs.TotalCreditSales).HasPrecision(18, 2);
                entity.Property(cs => cs.TotalTransferSales).HasPrecision(18, 2);
                entity.Property(cs => cs.TotalQrSales).HasPrecision(18, 2);

                entity.Property(cs => cs.TotalManualCashIn).HasPrecision(18, 2);
                entity.Property(cs => cs.TotalManualCashOut).HasPrecision(18, 2);

                entity.Property(cs => cs.Status).IsRequired().HasMaxLength(20);
                entity.Property(cs => cs.ClosingNotes).HasMaxLength(250);

                entity.HasOne(cs => cs.User)
                      .WithMany()
                      .HasForeignKey(cs => cs.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(cs => cs.CashMovements)
                      .WithOne(cm => cm.CashShift)
                      .HasForeignKey(cm => cm.CashShiftId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(cs => cs.CashRegister)
                      .WithMany(cr => cr.CashShifts)
                      .HasForeignKey(cs => cs.CashRegisterId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CashMovement>(entity =>
            {
                entity.ToTable("CashMovements");
                entity.HasKey(cm => cm.Id);

                entity.Property(cm => cm.Amount).HasPrecision(18, 2);
                entity.Property(cm => cm.Description).IsRequired().HasMaxLength(200);
                entity.Property(cm => cm.MovementType).HasConversion<int>();

                entity.HasOne(cm => cm.User)
                      .WithMany()
                      .HasForeignKey(cm => cm.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CashRegister>(entity =>
            {
                entity.ToTable("CashRegisters");
                entity.HasKey(cr => cr.Id);
                entity.HasIndex(cr => cr.Number).IsUnique();

                entity.Property(cr => cr.Number).IsRequired();
                entity.Property(cr => cr.Name).IsRequired().HasMaxLength(50);
                entity.Property(cr => cr.Description).HasMaxLength(150);
            });

            // =========================================================================
            // 8. TABLAS MAESTRAS Y AJUSTES
            // =========================================================================
            modelBuilder.Entity<PaymentMethod>().ToTable("PaymentMethods").HasKey(x => x.Id);
            modelBuilder.Entity<TaxCondition>().ToTable("TaxConditions").HasKey(x => x.Id);
            modelBuilder.Entity<Gender>().ToTable("Genders").HasKey(x => x.Id);
            modelBuilder.Entity<CivilStatus>().ToTable("CivilStatuses").HasKey(x => x.Id);
            modelBuilder.Entity<Position>().ToTable("Positions").HasKey(x => x.Id);
            modelBuilder.Entity<DocumentType>().ToTable("DocumentTypes").HasKey(x => x.Id);

            modelBuilder.Entity<StoreSettings>(entity =>
            {
                entity.ToTable("StoreSettings");
                entity.HasKey(st => st.Id);

                entity.Property(st => st.Name).IsRequired().HasMaxLength(100);
                entity.Property(st => st.CUIT).HasMaxLength(25);
                entity.Property(st => st.Address).HasMaxLength(150);
                entity.Property(st => st.Phone).HasMaxLength(30);
                entity.Property(st => st.Email).HasMaxLength(100);
                entity.Property(st => st.TicketFormat).HasMaxLength(20);
                entity.Property(st => st.TicketFooterMessage).HasMaxLength(250);
                entity.Property(st => st.GrossIncomeNumber).HasMaxLength(50);
                entity.Property(st => st.Logo).HasColumnType("varbinary(max)").IsRequired(false);

                entity.HasOne(st => st.TaxCondition)
                      .WithMany()
                      .HasForeignKey(st => st.TaxConditionId)
                      .IsRequired(false)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // =========================================================================
            // 9. TRANSACCIONES DE PAGOS MEDIANTE MERCADO PAGO (QR)
            // =========================================================================
            modelBuilder.Entity<MercadoPagoPaymentStatues>(entity =>
            {
                entity.ToTable("MercadoPagoPaymentStatuses");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<MercadoPagoTransaction>(entity =>
            {
                entity.ToTable("MercadoPagoTransactions");
                entity.HasKey(t => t.Id);

                entity.Property(t => t.Amount).HasPrecision(18, 2);
                entity.Property(t => t.IdempotencyKey).IsRequired().HasMaxLength(100);
                entity.HasIndex(t => t.IdempotencyKey).IsUnique();

                entity.HasOne(t => t.Sale)
                      .WithMany()
                      .HasForeignKey(t => t.SaleId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.Status)
                      .WithMany()
                      .HasForeignKey(t => t.StatusId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // =========================================================================
            // 10. FILTROS GLOBALES DE BORRADO LÓGICO (Soft Delete)
            // =========================================================================
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(AuditableEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(GenerateIsDeletedFilter(entityType.ClrType));
                }
            }
        }

        private static LambdaExpression GenerateIsDeletedFilter(Type type)
        {
            var parameter = Expression.Parameter(type, "it");
            var property = Expression.Property(parameter, nameof(AuditableEntity.IsDeleted));
            var falseConstant = Expression.Constant(false);
            var comparison = Expression.Equal(property, falseConstant);
            return Expression.Lambda(comparison, parameter);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<AuditableEntity>();
            var currentUsername = _currentUserService.CurrentUser?.Username;

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        entry.Entity.CreatedBy = currentUsername;
                        entry.Entity.IsDeleted = false;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastUpdatedAt = DateTime.UtcNow;
                        entry.Entity.LastUpdatedBy = currentUsername;

                        entry.Property(x => x.CreatedAt).IsModified = false;
                        entry.Property(x => x.CreatedBy).IsModified = false;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}