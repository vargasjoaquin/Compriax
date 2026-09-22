using CompriaxSystem.Domain.Constants;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace CompriaxSystem.Infrastructure.Persistence
{
    public static class DbInitializer
    {
        /// <summary>
        /// Realiza la siembra inicial de la base de datos (Seed), creando roles, usuario administrador, 
        /// configuraciones de tienda, métodos de pago, catálogos auxiliares y datos de prueba esenciales.
        /// </summary>
        /// <param name="context">Contexto de la base de datos de la aplicación.</param>
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            // =========================================================================
            // 1. ROLES DEL SISTEMA
            // =========================================================================
            Role? administratorRole = await context.Roles.FirstOrDefaultAsync(r => r.Id == RoleConstants.ADMINISTRATOR_ROLE_ID || r.Name == RoleConstants.ADMINISTRATOR);

            if (administratorRole == null)
            {
                administratorRole = new Role { Name = RoleConstants.ADMINISTRATOR };
                var cashierRole = new Role { Name = RoleConstants.CASHIER };

                await context.Roles.AddRangeAsync(administratorRole, cashierRole);
                await context.SaveChangesAsync();
            }

            // =========================================================================
            // 2. USUARIO ADMINISTRADOR
            // =========================================================================
            User? administratorUser = await context.Users.IgnoreQueryFilters().FirstOrDefaultAsync(u => u.Username == RoleConstants.DEFAULT_ADMIN_USERNAME);

            if (administratorUser == null)
            {
                administratorUser = new User
                {
                    Username = "admin",
                    Password = BCrypt.Net.BCrypt.HashPassword("admin123"),
                    FirstName = "Administrador",
                    LastName = "Principal",
                    Email = "admin@supermarket.com",
                    RoleId = administratorRole.Id,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                };

                await context.Users.AddAsync(administratorUser);
                await context.SaveChangesAsync();
            }

            // =========================================================================
            // 3. CAJA / TERMINAL
            // =========================================================================
            CashRegister? defaultCashRegister = await context.CashRegisters.IgnoreQueryFilters().FirstOrDefaultAsync(cr => cr.Number == TaxConstants.DEFAULT_POINT_OF_SALE);

            if (defaultCashRegister == null)
            {
                defaultCashRegister = new CashRegister
                {
                    Number = 1,
                    Name = "Caja 01 - Principal",
                    Description = "Terminal POS Principal de Cobro",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                };

                await context.CashRegisters.AddAsync(defaultCashRegister);
                await context.SaveChangesAsync();
            }

            // =========================================================================
            // 4. MÉTODOS DE PAGO
            // =========================================================================
            PaymentMethod? defaultPaymentMethod = await context.PaymentMethods.FirstOrDefaultAsync(p => p.Id == PaymentMethodConstants.CASH_ID || p.Name == PaymentMethodConstants.CASH);

            if (defaultPaymentMethod == null)
            {
                defaultPaymentMethod = new PaymentMethod { Name = PaymentMethodConstants.CASH, IsActive = true };
                await context.PaymentMethods.AddRangeAsync(
                    defaultPaymentMethod,
                    new PaymentMethod { Name = PaymentMethodConstants.DEBIT_CARD, IsActive = true },
                    new PaymentMethod { Name = PaymentMethodConstants.CREDIT_CARD, IsActive = true },
                    new PaymentMethod { Name = PaymentMethodConstants.BANK_TRANSFER, IsActive = true },
                    new PaymentMethod { Name = PaymentMethodConstants.MERCADO_PAGO_QR, IsActive = true }
                );
                await context.SaveChangesAsync();
            }

            // =========================================================================
            // 5. TIPOS DE COMPROBANTES
            // =========================================================================
            if (!await context.DocumentTypes.AnyAsync())
            {
                using var documentTypesTransaction = await context.Database.BeginTransactionAsync();

                try
                {
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[DocumentTypes] ON;");

                    await context.DocumentTypes.AddRangeAsync(
                        new DocumentType { Id = 1, Name = "Cliente Casual" },
                        new DocumentType { Id = 2, Name = "Factura A" },
                        new DocumentType { Id = 3, Name = "Nota de Débito A" },
                        new DocumentType { Id = 4, Name = "Nota de Crédito A" },
                        new DocumentType { Id = 5, Name = "Recibo A" },
                        new DocumentType { Id = 6, Name = "Factura B" },
                        new DocumentType { Id = 7, Name = "Nota de Débito B" },
                        new DocumentType { Id = 8, Name = "Nota de Crédito B" },
                        new DocumentType { Id = 9, Name = "Recibo B" },
                        new DocumentType { Id = 10, Name = "Factura C" },
                        new DocumentType { Id = 11, Name = "Nota de Débito C" },
                        new DocumentType { Id = 12, Name = "Nota de Crédito C" },
                        new DocumentType { Id = 13, Name = "Recibo C" },
                        new DocumentType { Id = 14, Name = "Factura de Exportación E" },
                        new DocumentType { Id = 15, Name = "Factura M" },
                        new DocumentType { Id = 16, Name = "Nota de Débito M" },
                        new DocumentType { Id = 17, Name = "Nota de Crédito M" },
                        new DocumentType { Id = 18, Name = "Ticket Factura A" },
                        new DocumentType { Id = 19, Name = "Ticket Factura B" },
                        new DocumentType { Id = 20, Name = "Ticket Consumidor Final" },
                        new DocumentType { Id = 21, Name = "Remito R (Oficial)" },
                        new DocumentType { Id = 22, Name = "Remito X (Uso Interno / No Fiscal)" },
                        new DocumentType { Id = 23, Name = "Presupuesto / Cotización" },
                        new DocumentType { Id = 24, Name = "Comprobante X (No Fiscal)" }
                    );

                    await context.SaveChangesAsync();
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[DocumentTypes] OFF;");
                    await documentTypesTransaction.CommitAsync();
                }
                catch
                {
                    await documentTypesTransaction.RollbackAsync();
                    throw;
                }
            }

            // =========================================================================
            // 6. CARGOS / PUESTOS DE PERSONAL
            // =========================================================================
            if (!await context.Positions.AnyAsync())
            {
                await context.Positions.AddRangeAsync(
                    new Position { Name = "Cajero/a" },
                    new Position { Name = "Repositor/a" },
                    new Position { Name = "Gerente" },
                    new Position { Name = "Seguridad" },
                    new Position { Name = "Limpieza" },
                    new Position { Name = "Administrativo" },
                    new Position { Name = "Supervisor/a" },
                    new Position { Name = "Administrador/a" }
                );
                await context.SaveChangesAsync();
            }

            if (!await context.Genders.AnyAsync())
            {
                await context.Genders.AddRangeAsync(
                    new Gender { Name = "Masculino" },
                    new Gender { Name = "Femenino" },
                    new Gender { Name = "Otro / No especifica" }
                );
                await context.SaveChangesAsync();
            }

            if (!await context.CivilStatuses.AnyAsync())
            {
                await context.CivilStatuses.AddRangeAsync(
                    new CivilStatus { Name = "Soltero/a" },
                    new CivilStatus { Name = "Casado/a" },
                    new CivilStatus { Name = "Divorciado/a" },
                    new CivilStatus { Name = "Viudo/a" },
                    new CivilStatus { Name = "Unión Convivencial" }
                );
                await context.SaveChangesAsync();
            }

            // =========================================================================
            // 7. CONDICIONES FISCALES ANTE EL IVA 
            // =========================================================================
            TaxCondition? defaultTaxCondition = await context.TaxConditions.FirstOrDefaultAsync(t => t.Name == TaxConstants.REGISTERED_TAXPAYER);

            if (defaultTaxCondition == null)
            {
                defaultTaxCondition = new TaxCondition { Name = TaxConstants.REGISTERED_TAXPAYER };

                await context.TaxConditions.AddRangeAsync(
                    defaultTaxCondition,
                    new TaxCondition { Name = TaxConstants.TAX_EXEMPT },
                    new TaxCondition { Name = TaxConstants.FINAL_CONSUMER },
                    new TaxCondition { Name = TaxConstants.SIMPLIFIED_REGIME },
                    new TaxCondition { Name = TaxConstants.FOREIGN_SUPPLIER },
                    new TaxCondition { Name = TaxConstants.FOREIGN_CUSTOMER }
                );
                await context.SaveChangesAsync();
            }

            // =========================================================================
            // 8. UNIDADES DE MEDIDA
            // =========================================================================
            UnitsOfMeasure? defaultUnitOfMeasure = await context.UnitsOfMeasure.FirstOrDefaultAsync(u => u.Abbreviation == "UN");

            if (defaultUnitOfMeasure == null)
            {
                defaultUnitOfMeasure = new UnitsOfMeasure { Name = "Unidades", Abbreviation = "UN" };

                await context.UnitsOfMeasure.AddRangeAsync(
                    defaultUnitOfMeasure,
                    new UnitsOfMeasure { Name = "Kilogramos", Abbreviation = "KG" },
                    new UnitsOfMeasure { Name = "Litros", Abbreviation = "LT" },
                    new UnitsOfMeasure { Name = "Gramos", Abbreviation = "GR" },
                    new UnitsOfMeasure { Name = "Packs", Abbreviation = "PK" }
                );
                await context.SaveChangesAsync();
            }

            // =========================================================================
            // 9. CATEGORÍAS Y MARCAS POR DEFECTO
            // =========================================================================
            Category? defaultCategory = await context.Categories.FirstOrDefaultAsync(c => c.Name == "Bebidas y Gaseosas");

            if (defaultCategory == null)
            {
                defaultCategory = new Category { Name = "Bebidas y Gaseosas", Description = "Aguas, gaseosas y jugos", IsActive = true, CreatedAt = DateTime.UtcNow };

                await context.Categories.AddRangeAsync(
                    defaultCategory,
                    new Category { Name = "Almacén y Comestibles", Description = "Alimentos no perecederos de góndola", IsActive = true, CreatedAt = DateTime.UtcNow },
                    new Category { Name = "Lácteos y Fiambrería", Description = "Leches, quesos y fiambres", IsActive = true, CreatedAt = DateTime.UtcNow },
                    new Category { Name = "Limpieza y Perfumería", Description = "Artículos de limpieza y cuidado personal", IsActive = true, CreatedAt = DateTime.UtcNow }
                );
                await context.SaveChangesAsync();
            }

            Brand? defaultBrand = await context.Brands.FirstOrDefaultAsync(b => b.Name == "Coca-Cola");

            if (defaultBrand == null)
            {
                defaultBrand = new Brand { Name = "Coca-Cola", CreatedAt = DateTime.UtcNow };

                await context.Brands.AddRangeAsync(
                    defaultBrand,
                    new Brand { Name = "General / Sin Marca", CreatedAt = DateTime.UtcNow },
                    new Brand { Name = "La Serenísima", CreatedAt = DateTime.UtcNow },
                    new Brand { Name = "Arcor", CreatedAt = DateTime.UtcNow }
                );
                await context.SaveChangesAsync();
            }

            // =========================================================================
            // 10. PROVEEDOR POR DEFECTO
            // =========================================================================
            if (!await context.Suppliers.AnyAsync())
            {
                await context.Suppliers.AddAsync(new Supplier
                {
                    CUIT = "30-11223344-9",
                    CompanyName = "Distribuidora Central de Bebidas S.A.",
                    ContactName = "Martín Rodríguez",
                    Email = "proveedores@distribuidoracentral.com",
                    Phone = "11-4567-8900",
                    Address = "Av. Industrial 2450, Depósito 4",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                });
                await context.SaveChangesAsync();
            }

            // =========================================================================
            // 11. PERFIL DEL COMERCIO
            // =========================================================================
            if (!await context.StoreSettings.AnyAsync())
            {
                await context.StoreSettings.AddAsync(new StoreSettings
                {
                    Name = "Compriax",
                    CUIT = "30-71234567-8",
                    Address = "Av. Rivadavia 5400, CABA",
                    Phone = "0800-444-7873",
                    Email = "contacto@compriax.com",
                    Logo = null,
                    TicketFormat = ThermalPrinterConstants.FORMAT_80MM,
                    TicketFooterMessage = "¡Muchas gracias por su compra! Vuelva pronto.",
                    ShowLogoOnTicket = true,
                    ShowBarcodeOnTicket = true,
                    AutoPrintTicket = false,
                    PointOfSale = 1,
                    GrossIncomeNumber = "901-234567-1",
                    ActivityStartDate = DateTime.Now,
                    TaxConditionId = defaultTaxCondition.Id
                });
                await context.SaveChangesAsync();
            }

            // =========================================================================
            // 12. PRODUCTO DE MUESTRA
            // =========================================================================
            Product? sampleProduct = await context.Products.FirstOrDefaultAsync(p => p.Barcode == ProductConstants.DEFAULT_SAMPLE_BARCODE);

            if (sampleProduct == null)
            {
                sampleProduct = new Product
                {
                    Barcode = ProductConstants.DEFAULT_SAMPLE_BARCODE,
                    Name = "Coca-Cola Original 1.5L",
                    Description = "Gaseosa Coca-Cola botella descartable 1.5 Litros",
                    CategoryId = defaultCategory.Id,
                    BrandId = defaultBrand.Id,
                    UnitOfMeasureId = defaultUnitOfMeasure.Id,
                    BuyPrice = 1200.00m,
                    SellPrice = 1850.00m,
                    CurrentStock = 49,
                    MinimumStock = 10,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = RoleConstants.DEFAULT_ADMIN_USERNAME
                };

                await context.Products.AddAsync(sampleProduct);
                await context.SaveChangesAsync();

                await context.StockMovements.AddAsync(new StockMovement
                {
                    ProductId = sampleProduct.Id,
                    UserId = administratorUser.Id,
                    Quantity = 50,
                    MovementType = MovementType.Initial,
                    Remarks = "Alta inicial de catálogo (Stock de muestra)",
                    CreatedBy = RoleConstants.DEFAULT_ADMIN_USERNAME,
                    CreatedAt = DateTime.UtcNow.AddHours(-2)
                });
                await context.SaveChangesAsync();
            }

            // =========================================================================
            // 13. TURNO Y VENTA HISTÓRICA DE MUESTRA
            // =========================================================================
            if (!await context.Sales.AnyAsync())
            {
                var sampleShift = new CashShift
                {
                    UserId = administratorUser.Id,
                    CashRegisterId = defaultCashRegister.Id,
                    OpeningDate = DateTime.UtcNow.AddHours(-1),
                    ClosingDate = DateTime.UtcNow.AddMinutes(-5),
                    InitialCash = 10000.00m,
                    TotalCashSales = 1850.00m,
                    TotalDebitSales = 0,
                    TotalCreditSales = 0,
                    TotalTransferSales = 0,
                    TotalQrSales = 0,
                    TotalManualCashIn = 0,
                    TotalManualCashOut = 0,
                    ExpectedCash = 11850.00m,
                    RealCash = 11850.00m,
                    Difference = 0,
                    Status = CashShiftStatusesConstants.CLOSED,
                    ClosingNotes = "Turno inicial de verificación (Caja Cuadrada)"
                };

                await context.CashShifts.AddAsync(sampleShift);
                await context.SaveChangesAsync();

                var documentType = await context.DocumentTypes.FirstOrDefaultAsync(d => d.Id == 6 || d.Name.Contains("Factura B"))
                              ?? await context.DocumentTypes.FirstAsync();

                var sampleSale = new Sale
                {
                    UserId = administratorUser.Id,
                    CustomerId = null,
                    CashRegisterId = defaultCashRegister.Id,
                    CashShiftId = sampleShift.Id,
                    DocumentTypeId = documentType.Id,
                    DocumentNumber = "00000001",
                    SubTotal = 1850.00m,
                    DiscountAmount = 0.00m,
                    TotalAmount = 1850.00m,
                    PaymentReceived = 2000.00m,
                    PaymentChange = 150.00m,
                    PaymentMethodId = defaultPaymentMethod.Id,
                    PointOfSale = 1,
                    FiscalStatus = FiscalStatusesContstans.DIGITAL_VOUCHER,
                    CreatedAt = DateTime.UtcNow.AddMinutes(-30),
                    SaleItems = new List<SaleItem>
                    {
                        new SaleItem
                        {
                            ProductId = sampleProduct.Id,
                            Quantity = 1,
                            UnitPrice = 1850.00m,
                            CostPrice = 1200.00m,
                            DiscountAmount = 0,
                            SubTotal = 1850.00m
                        }
                    }
                };

                await context.Sales.AddAsync(sampleSale);

                await context.StockMovements.AddAsync(new StockMovement
                {
                    ProductId = sampleProduct.Id,
                    UserId = administratorUser.Id,
                    Quantity = -1,
                    MovementType = MovementType.Sale,
                    Remarks = "Venta Nro: 00000001 [Caja #1]",
                    CreatedBy = RoleConstants.DEFAULT_ADMIN_USERNAME,
                    CreatedAt = DateTime.UtcNow.AddMinutes(-30)
                });

                await context.SaveChangesAsync();
            }

            // =========================================================================
            // 14. TRANSACCIONES DE PAGOS MEDIANTE MERCADO PAGO (QR)
            // =========================================================================
            if (!await context.MercadoPagoPaymentStatuses.AnyAsync())
            {
                await context.MercadoPagoPaymentStatuses.AddRangeAsync(
                    new MercadoPagoPaymentStatues { Id = 1, Name = "Pending" },
                    new MercadoPagoPaymentStatues { Id = 2, Name = "Approved" },
                    new MercadoPagoPaymentStatues { Id = 3, Name = "Rejected" },
                    new MercadoPagoPaymentStatues { Id = 4, Name = "Cancelled" },
                    new MercadoPagoPaymentStatues { Id = 5, Name = "Expired" }
                );
                await context.SaveChangesAsync();
            }
        }
    }
}
