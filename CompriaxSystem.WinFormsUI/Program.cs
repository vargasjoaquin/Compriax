using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CompriaxSystem.Application.Configuration;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Application.Mappings;
using CompriaxSystem.Application.Services;
using CompriaxSystem.Application.Validations;
using CompriaxSystem.Infrastructure.Persistence;
using CompriaxSystem.Infrastructure.Repositories;
using CompriaxSystem.Infrastructure.Security;
using CompriaxSystem.Infrastructure.Services;

namespace CompriaxSystem.WinFormsUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var host = CreateHostBuilder().Build();

            ApplicationConfiguration.Initialize();

            using (var startupScope = host.Services.CreateScope())
            {
                var services = startupScope.ServiceProvider;
                
                /*
                // 1. Verificación de Licencia Criptográfica
                var licenseService = services.GetRequiredService<ILicenseManagerService>();
                var validation = licenseService.ValidateInstalledLicenseAsync().GetAwaiter().GetResult();

                if (!validation.Success)
                {
                    var activationForm = services.GetRequiredService<FormActivation>();
                    if (activationForm.ShowDialog() != DialogResult.OK)
                    {
                        MessageBox.Show(
                            $"El sistema no puede iniciar:\n\n{validation.Message}\n\nComuníquese con el proveedor del software para activar este puesto.",
                            "Licencia Requerida",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Stop);
                        return;
                    }
                }
                */

                var db = services.GetRequiredService<ApplicationDbContext>();
                db.Database.EnsureCreated();

                var recordingService = services.GetRequiredService<ISecurityRecordingService>();
                recordingService.Start();
            }

            var loginForm = host.Services.GetRequiredService<FormLogin>();
            System.Windows.Forms.Application.Run(loginForm);
        }

        static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddAutoMapper(typeof(MappingProfile).Assembly);

                    // 1. Persistencia e Infraestructura
                    services.AddDbContext<ApplicationDbContext>(options =>
                         options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")
                             ?? "Server=.;Database=Supermarket;Integrated Security=True;TrustServerCertificate=True"));

                    services.AddValidatorsFromAssembly(typeof(ProductCreateValidator).Assembly);

                    services.Configure<SecurityRecordingSettings>(context.Configuration.GetSection("SecurityRecording"));
                    services.Configure<CloudinarySettings>(context.Configuration.GetSection("Cloudinary"));
                    services.Configure<DatabaseBackupSettings>(context.Configuration.GetSection("DatabaseBackup"));
                    services.Configure<AfipSettings>(context.Configuration.GetSection("AfipFiscal"));

                    // 2. Licenciamiento & Seguridad
                    services.AddHttpClient();
                    services.AddSingleton<ILicenseManagerService, LicenseManagerService>();
                    services.AddSingleton<IPasswordHasher, PasswordHasher>();

                    // 3. Repositorios y Unit of Work
                    services.AddScoped<IUnitOfWork, UnitOfWork>();
                    services.AddScoped<ICashRegisterRepository, CashRegisterRepository>();
                    services.AddScoped<IPromotionRepository, PromotionRepository>();
                    services.AddScoped<ICashShiftRepository, CashShiftRepository>();

                    // 4. Servicios Periféricos de Infraestructura
                    services.AddSingleton<ISecurityRecordingService, SecurityRecordingService>();
                    services.AddScoped<IDocumentService, DocumentService>();
                    services.AddScoped<IExcelService, ExcelService>();
                    services.AddScoped<IBarcodeService, BarcodeService>();
                    services.AddScoped<ICameraService, CameraService>();
                    services.AddScoped<IFileStorageService, CloudinaryStorageService>();
                    services.AddScoped<IWhatsappService, WhatsappService>();
                    services.AddScoped<IBackupService, BackupService>();
                    services.AddSingleton<ITicketTemplateService, TicketTemplateService>();
                    services.AddSingleton<ITicketPrinter, TicketPrinter>();
                    services.AddScoped<IAfipService, AfipService>();

                    // 5. Servicios de Aplicación (Casos de Uso)
                    services.AddSingleton<ICurrentUserService, CurrentUserService>();
                    services.AddScoped<IAuthService, AuthService>();
                    services.AddScoped<IUserService, UserService>();
                    services.AddScoped<ICatalogService, CatalogService>();
                    services.AddScoped<ICustomerService, CustomerService>();
                    services.AddScoped<IInventoryService, InventoryService>();
                    services.AddScoped<IProductService, ProductService>();
                    services.AddScoped<ISaleService, SaleService>();
                    services.AddScoped<ISupplyChainService, SupplyChainService>();
                    services.AddScoped<IReportService, ReportService>();
                    services.AddScoped<IStoreService, StoreService>();
                    services.AddScoped<IEmployeeService, EmployeeService>();
                    services.AddScoped<ILookupService, LookupService>();
                    services.AddScoped<IRestoreService, RestoreService>();
                    services.AddScoped<IPromotionService, PromotionService>();
                    services.AddScoped<ICashShiftService, CashShiftService>();
                    services.AddScoped<ICashRegisterService, CashRegisterService>();
                    services.AddScoped<ITicketDataBuilder, TicketDataBuilder>();

                    // 6. Formularios WinForms
                    services.AddTransient<FormLogin>();
                    services.AddTransient<FormPanelControl>();
                    services.AddTransient<FormSelectCashRegister>();
                    services.AddTransient<FormHome>();
                    services.AddTransient<FormProducts>();
                    services.AddTransient<FormCategories>();
                    services.AddTransient<FormCustomers>();
                    services.AddTransient<FormUsers>();
                    services.AddTransient<FormSales>();
                    services.AddTransient<FormPurchases>();
                    services.AddTransient<FormSuppliers>();
                    services.AddTransient<FormSettings>();
                    services.AddTransient<FormSalesReport>();
                    services.AddTransient<FormPurchaseReport>();
                    services.AddTransient<FormSaleDetail>();
                    services.AddTransient<FormEmployees>();
                    services.AddTransient<FormPrintPrices>();
                    services.AddTransient<FormSecurityCameras>();
                    services.AddTransient<FormUserProfile>();
                    services.AddTransient<FormRecoverPassword>();
                    services.AddTransient<FormRestoreRecords>();
                    services.AddTransient<FormTicketPreview>();
                    services.AddTransient<FormPromotions>();
                    services.AddTransient<FormCashShift>();
                    services.AddTransient<FormCashRegisters>();
                });
    }
}