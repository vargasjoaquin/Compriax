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
using CompriaxSystem.WinFormsUI.Helpers;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace CompriaxSystem.WinFormsUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var host = CreateHostBuilder().Build();

            ApplicationConfiguration.Initialize();

            Process? MercadoPagoProcess = null;

            try
            {
                using (var startupScope = host.Services.CreateScope())
                {
                    var services = startupScope.ServiceProvider;

                    try
                    {
                        var db = services.GetRequiredService<ApplicationDbContext>();

                        if (!db.Database.CanConnect())
                        {
                            throw new InvalidOperationException("No se pudo conectar a SQL Server. Verifique que la base de datos 'Compriax' exista y el servicio esté en ejecución.");
                        }
                    }
                    catch (Exception ex)
                    {
                        string realError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                        MessageBox.Show(
                            $"Error al conectar con la base de datos SQL Server:\n\n{realError}",
                            "Error de Base de Datos",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    var licenseService = services.GetRequiredService<ILicenseManagerService>();
                    var licenseValidation = licenseService.ValidateInstalledLicenseAsync().GetAwaiter().GetResult();

                    if (!licenseValidation.Success || licenseService.CurrentLicense == null || !licenseService.CurrentLicense.IsValid || licenseService.CurrentLicense.IsExpired)
                    {
                        // Licencia no instalada, alterada o expirada -> Bloqueo y diálogo de activación
                        string failureMessage = licenseValidation.Message;

                        using var activationForm = new FormLicenseActivation(licenseService, failureMessage);

                        if (activationForm.ShowDialog() != DialogResult.OK)
                        {
                            return;
                        }
                    }
                    else if (licenseService.CurrentLicense.IsExpiredSoon)
                    {
                        // Licencia válida pero próxima a vencer (<= 7 días) -> Mostrar aviso diario
                        using var warningDialog = new FormLicenseWarningDialog(licenseService.CurrentLicense, licenseService);

                        warningDialog.ShowDialog();
                    }

                    string MercadoPagoExecutablePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MercadoPago", "CompriaxSystem.MercadoPago.Api.exe");

                    if (File.Exists(MercadoPagoExecutablePath))
                    {
                        try
                        {
                            MercadoPagoProcess = Process.Start(new ProcessStartInfo
                            {
                                FileName = MercadoPagoExecutablePath,
                                WorkingDirectory = Path.GetDirectoryName(MercadoPagoExecutablePath)!,
                                CreateNoWindow = true,
                                UseShellExecute = false,
                                WindowStyle = ProcessWindowStyle.Hidden
                            });
                        }
                        catch
                        {
                        }
                    }

                    try
                    {
                        var recordingService = services.GetRequiredService<ISecurityRecordingService>();
                        recordingService.Start();
                    }
                    catch
                    {
                    }
                }

                var loginForm = host.Services.GetRequiredService<FormLogin>();
                System.Windows.Forms.Application.Run(loginForm);
            }
            finally
            {
                if (MercadoPagoProcess != null && !MercadoPagoProcess.HasExited)
                {
                    try
                    {
                        MercadoPagoProcess.Kill(entireProcessTree: true);
                        MercadoPagoProcess.Dispose();
                    }
                    catch
                    {
                    }
                }
            }
        }

        static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((host, config) =>
            {
                if (host.HostingEnvironment.IsDevelopment() || Debugger.IsAttached)
                {
                    config.AddUserSecrets<FormLogin>();
                }
            })
            .ConfigureServices((context, services) =>
            {
                services.AddAutoMapper(typeof(MappingProfile).Assembly);

                // 1. Persistencia e Infraestructura
                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    string connectionString = context.Configuration.GetConnectionString("DefaultConnection")
                        ?? "Server=.;Database=Compriax;Integrated Security=True;TrustServerCertificate=True";

                    options.UseSqlServer(connectionString)
                           .ConfigureWarnings(warnings =>
                               warnings.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
                });

                services.AddValidatorsFromAssembly(typeof(ProductCreateValidator).Assembly);

                services.Configure<SecurityRecordingSettings>(context.Configuration.GetSection("SecurityRecording"));
                services.Configure<EmailSettings>(context.Configuration.GetSection("EmailSettings"));
                services.Configure<CloudinarySettings>(context.Configuration.GetSection("Cloudinary"));
                services.Configure<DatabaseBackupSettings>(context.Configuration.GetSection("DatabaseBackup"));
                services.Configure<AfipSettings>(context.Configuration.GetSection("AfipFiscal"));
                services.Configure<MercadoPagoSettings>(context.Configuration.GetSection("MercadoPago"));

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
                services.AddScoped<IEmailService, EmailService>();
                services.AddSingleton<ITicketTemplateService, TicketTemplateService>();
                services.AddSingleton<ITicketPrinter, TicketPrinter>();
                services.AddScoped<IAfipService, AfipService>();
                services.AddScoped<IMercadoPagoQrClient, MercadoPagoQrClient>();

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
                services.AddTransient<FormMercadoPagoQrPayment>();
                services.AddTransient<FormPriceCheck>();
                services.AddTransient<FormProductLabels>();
            });
    }
}