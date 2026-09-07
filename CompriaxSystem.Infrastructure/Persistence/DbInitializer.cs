using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace CompriaxSystem.Infrastructure.Persistence
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            // =========================================================================
            // 1. ROLES DEL SISTEMA
            // =========================================================================
            Role? adminRole = await context.Roles.FirstOrDefaultAsync(r => r.Name == "Administrador");
            
            if (adminRole == null)
            {
                adminRole = new Role { Name = "Administrador" };
                var cashierRole = new Role { Name = "Cajero" };

                await context.Roles.AddRangeAsync(adminRole, cashierRole);
                await context.SaveChangesAsync();
            }

            // =========================================================================
            // 2. USUARIO ADMINISTRADOR
            // =========================================================================
            User? adminUser = await context.Users.FirstOrDefaultAsync(u => u.Username == "admin");
            
            if (adminUser == null)
            {
                adminUser = new User
                {
                    Username = "admin",
                    Password = BCrypt.Net.BCrypt.HashPassword("admin123"),
                    FirstName = "Administrador",
                    LastName = "Principal",
                    Email = "admin@supermarket.com",
                    RoleId = adminRole.Id,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                };

                await context.Users.AddAsync(adminUser);
                await context.SaveChangesAsync();
            }

            // =========================================================================
            // 3. CAJA / TERMINAL
            // =========================================================================
            CashRegister? defaultRegister = await context.CashRegisters.FirstOrDefaultAsync(cr => cr.Number == 1);
            
            if (defaultRegister == null)
            {
                defaultRegister = new CashRegister
                {
                    Number = 1,
                    Name = "Caja 01 - Principal",
                    Description = "Terminal POS Principal de Cobro",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                };

                await context.CashRegisters.AddAsync(defaultRegister);
                await context.SaveChangesAsync();
            }

            // =========================================================================
            // 4. MÉTODOS DE PAGO
            // =========================================================================
            PaymentMethod? defaultPayment = await context.PaymentMethods.FirstOrDefaultAsync(p => p.Name == "Efectivo");
            
            if (defaultPayment == null)
            {
                defaultPayment = new PaymentMethod { Name = "Efectivo", IsActive = true };
                await context.PaymentMethods.AddRangeAsync(
                    defaultPayment,
                    new PaymentMethod { Name = "Tarjeta de Débito", IsActive = true },
                    new PaymentMethod { Name = "Tarjeta de Crédito", IsActive = true },
                    new PaymentMethod { Name = "Transferencia Bancaria", IsActive = true },
                    new PaymentMethod { Name = "Mercado Pago / QR", IsActive = true }
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

            // =========================================================================
            // 7. CONDICIONES FISCALES ANTE EL IVA 
            // =========================================================================
            TaxCondition? defaultTaxCondition = await context.TaxConditions.FirstOrDefaultAsync(t => t.Name == "IVA Responsable Inscripto");
            
            if (defaultTaxCondition == null)
            {
                defaultTaxCondition = new TaxCondition { Name = "IVA Responsable Inscripto" };
                await context.TaxConditions.AddRangeAsync(
                    defaultTaxCondition,
                    new TaxCondition { Name = "IVA Sujeto Exento" },
                    new TaxCondition { Name = "Consumidor Final" },
                    new TaxCondition { Name = "Responsable Monotributo" },
                    new TaxCondition { Name = "Proveedor del Exterior" },
                    new TaxCondition { Name = "Cliente del Exterior" }
                );
                await context.SaveChangesAsync();
            }

            // =========================================================================
            // 8. UNIDADES DE MEDIDA
            // =========================================================================
            UnitsOfMeasure? defaultUnit = await context.UnitsOfMeasure.FirstOrDefaultAsync(u => u.Abbreviation == "UN");
            
            if (defaultUnit == null)
            {
                defaultUnit = new UnitsOfMeasure { Name = "Unidades", Abbreviation = "UN" };
                await context.UnitsOfMeasure.AddRangeAsync(
                    defaultUnit,
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
                    TicketFormat = "80mm",
                    TicketFooterMessage = "¡Muchas gracias por su compra! Vuelva pronto.",
                    ShowLogoOnTicket = true,
                    ShowBarcodeOnTicket = true,
                    AutoPrintTicket = false,
                    PointOfSale = 1,
                    GrossIncomeNumber = "901-234567-1",
                    ActivityStartDate = new DateTime(2020, 1, 1),
                    TaxConditionId = defaultTaxCondition.Id
                });
                await context.SaveChangesAsync();
            }

            // =========================================================================
            // 12. PRODUCTO DE MUESTRA
            // =========================================================================
            Product? sampleProduct = await context.Products.FirstOrDefaultAsync(p => p.Barcode == "7790895000997");
            
            if (sampleProduct == null)
            {
                sampleProduct = new Product
                {
                    Barcode = "7790895000997",
                    Name = "Coca-Cola Original 1.5L",
                    Description = "Gaseosa Coca-Cola botella descartable 1.5 Litros",
                    CategoryId = defaultCategory.Id,
                    BrandId = defaultBrand.Id,
                    UnitOfMeasureId = defaultUnit.Id,
                    BuyPrice = 1200.00m,
                    SellPrice = 1850.00m,
                    CurrentStock = 49,
                    MinimumStock = 10,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = "admin"
                };

                await context.Products.AddAsync(sampleProduct);
                await context.SaveChangesAsync();

                await context.StockMovements.AddAsync(new StockMovement
                {
                    ProductId = sampleProduct.Id,
                    UserId = adminUser.Id,
                    Quantity = 50,
                    MovementType = MovementType.Initial,
                    Remarks = "Alta inicial de catálogo (Stock de muestra)",
                    CreatedBy = "admin",
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
                    UserId = adminUser.Id,
                    CashRegisterId = defaultRegister.Id,
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
                    Status = "Cerrada",
                    ClosingNotes = "Turno inicial de verificación (Caja Cuadrada)"
                };

                await context.CashShifts.AddAsync(sampleShift);
                await context.SaveChangesAsync();

                var documentType = await context.DocumentTypes.FirstOrDefaultAsync(d => d.Id == 82 || d.Name.Contains("Factura B"))
                              ?? await context.DocumentTypes.FirstAsync();

                var sampleSale = new Sale
                {
                    UserId = adminUser.Id,
                    CustomerId = null,
                    CashRegisterId = defaultRegister.Id,
                    CashShiftId = sampleShift.Id,
                    DocumentTypeId = documentType.Id,
                    DocumentNumber = "00000001",
                    SubTotal = 1850.00m,
                    DiscountAmount = 0.00m,
                    TotalAmount = 1850.00m,
                    PaymentReceived = 2000.00m,
                    PaymentChange = 150.00m,
                    PaymentMethodId = defaultPayment.Id,
                    PointOfSale = 1,
                    FiscalStatus = "Comprobante Fiscal Digital",
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
                    UserId = adminUser.Id,
                    Quantity = -1,
                    MovementType = MovementType.Sale,
                    Remarks = "Venta Nro: 00000001 [Caja #1]",
                    CreatedBy = "admin",
                    CreatedAt = DateTime.UtcNow.AddMinutes(-30)
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
