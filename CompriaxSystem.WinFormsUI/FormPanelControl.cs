using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Constants;
using CompriaxSystem.WinFormsUI.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormPanelControl : Form
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IServiceProvider _serviceProvider;
        private readonly IStoreService _storeService;
        private readonly IBackupService _backupService;
        private readonly ICashShiftService _cashShiftService;
        private FormHome? _dashboardForm;
        private bool _isShuttingDown = false;
        private readonly SemaphoreSlim _appearanceLock = new(1, 1);

        public FormPanelControl(
            ICurrentUserService currentUserService,
            IServiceProvider serviceProvider,
            IStoreService storeService,
            IBackupService backupService,
            ICashShiftService cashShiftService)
        {
            _currentUserService = currentUserService;
            _serviceProvider = serviceProvider;
            _storeService = storeService;
            _backupService = backupService;
            _cashShiftService = cashShiftService;

            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            
            ButtonIconOverlayHelper.BindEvents(this.buttonLogout, this.picIconLogout);
            

            labelClockTime.Text = DateTime.Now.ToString("HH:mm:ss");
            timerSystemClock.Interval = 1000;
            timerSystemClock.Tick -= HoraFecha_Tick;
            timerSystemClock.Tick += HoraFecha_Tick;
            timerSystemClock.Start();

            this.buttonLogout.Click -= btnLogout_Click;
            this.buttonLogout.Click += btnLogout_Click;

            this.FormClosing -= FormPanelControl_FormClosing;
            this.FormClosing += FormPanelControl_FormClosing;

            this.Load += async (s, e) =>
            {
                await ConfigureApplicationAppearanceAndBrandingAsync();
                await LoadEmbeddedDashboardFormAsync();
            };

            LoadAuthenticatedUserDataAndNavigation();
        }
        public async Task ConfigureApplicationAppearanceAndBrandingAsync()
        {
            if (!await _appearanceLock.WaitAsync(0))
                return;

            try
            {
                pictureBoxLogo.Image?.Dispose();
                pictureBoxLogo.Image = null;

                pictureBoxLogo.Image = Resources.logo_compriax;
                pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;

                await RefreshActiveShiftStatusDisplayAsync();
            }
            catch
            {
            }
            finally
            {
                _appearanceLock.Release();
            }
        }

        public async Task RefreshActiveShiftStatusDisplayAsync()
        {
            try
            {
                var currentUser = _currentUserService.CurrentUser;
                bool isAdministratorUser = currentUser != null && currentUser.RoleName.Equals(RoleConstants.ADMINISTRATOR, StringComparison.OrdinalIgnoreCase);
                var ctx = _currentUserService.OperationalContext;

                if (isAdministratorUser && ctx == null)
                {
                    labelShiftStatus.Text = " Modo Supervisor";
                    labelShiftStatus.ImageAlign = ContentAlignment.MiddleLeft;
                    labelShiftStatus.ForeColor = Color.FromArgb(226, 232, 240);
                }
                else
                {
                    var currentActiveShift = await _cashShiftService.GetCurrentActiveShiftAsync();
                    string cashRegisterName = ctx?.CashRegisterName ?? "Caja 01";

                    if (currentActiveShift != null)
                    {
                        DateTime localOpeningDateTime = currentActiveShift.OpeningDate.Kind == DateTimeKind.Utc
                                                ? currentActiveShift.OpeningDate.ToLocalTime()
                                                : currentActiveShift.OpeningDate;

                        labelShiftStatus.Text = $" {cashRegisterName} | Turno #{currentActiveShift.Id} ({localOpeningDateTime:HH:mm})";
                        labelShiftStatus.ImageAlign = ContentAlignment.MiddleLeft;
                        labelShiftStatus.ForeColor = Color.FromArgb(16, 185, 129);
                    }
                    else
                    {
                        labelShiftStatus.Text = $" {cashRegisterName} | Caja Cerrada";
                        labelShiftStatus.ImageAlign = ContentAlignment.MiddleLeft;
                        labelShiftStatus.ForeColor = Color.FromArgb(248, 113, 113);
                    }
                }
            }
            catch { }
        }

        private void LoadAuthenticatedUserDataAndNavigation()
        {
            var currentUser = _currentUserService.CurrentUser;

            if (currentUser == null)
                return;

            labelSessionUser.Text = currentUser.FullName.ToUpper();
            labelRoleName.Text = $"[{currentUser.RoleName.ToUpper()}]";

            bool isAdministratorUser = currentUser.RoleName.Equals(RoleConstants.ADMINISTRATOR, StringComparison.OrdinalIgnoreCase);
            BuildRoleBasedNavigationMenu(isAdministratorUser);
        }

        private void BuildRoleBasedNavigationMenu(bool isAdministratorUser)
        {
            flowLayoutPanelNavigationButtons.SuspendLayout();
            flowLayoutPanelNavigationButtons.Controls.Clear();

            var menuDefinitions = new List<NavMenuItemHelper>
            {
                NavMenuItemHelper.DirectAction("Inicio", "Dashboard Principal", Resources._051_dashboard, async () =>
                {
                    _dashboardForm?.BringToFront();

                    if (_dashboardForm != null)
                        await _dashboardForm.RefreshDashboardMetricsAndTablesAsync();
                }),

                NavMenuItemHelper.Group("Punto de Venta ▾", "Terminal POS y Comprobantes", Resources._052_registrar_venta, new List<NavMenuItemHelper>
                {
                    NavMenuItemHelper.Direct("Punto de venta", "Venta Rápida por Código de Barras", Resources._052_registrar_venta, typeof(FormSales)),
                    NavMenuItemHelper.Direct("Auditoría de Tickets", "Consulta y Reimpresión", Resources._059_detalle_de_venta, typeof(FormSaleDetail)),
                    NavMenuItemHelper.Direct("Historial de Ventas", "Reportes de Facturación", Resources._056_historial_de_ventas, typeof(FormSalesReport), requireAdmin: true),
                    NavMenuItemHelper.Direct("Promociones y Descuentos", "Reglas 2x1 y % OFF", Resources._071_promociones_y_descuentos, typeof(FormPromotions), requireAdmin: true),
                }),

               NavMenuItemHelper.Group("Inventario ▾", "Catálogo, Precios y Stock", Resources._053_gestion_de_productos, new List<NavMenuItemHelper>
               {
                    NavMenuItemHelper.Direct("Catálogo de Productos", "Gestión de Artículos", Resources._053_gestion_de_productos, typeof(FormProducts)),
                    NavMenuItemHelper.Direct("Categorías", "Familias de Productos", Resources._064_gestion_de_categorias, typeof(FormCategories), requireAdmin: true),
                    NavMenuItemHelper.Direct("Etiquetas de Precio", "Generador de Etiquetas de Góndola", Resources._061_codigo_de_barras, typeof(FormProductLabels))
               }),

                NavMenuItemHelper.Group("Caja & Turnos ▾", "Arqueo y Cierres X/Z", Resources._072_caja_y_turnos, new List<NavMenuItemHelper>
                {
                    NavMenuItemHelper.Direct("Control de Caja", "Apertura, Movimientos y Cierre Z", Resources._072_caja_y_turnos, typeof(FormCashShift))
                }),

                NavMenuItemHelper.Group("Abastecimiento ▾", "Compras y Proveedores", Resources._055_gestion_de_proveedores, new List<NavMenuItemHelper>
                {
                    NavMenuItemHelper.Direct("Proveedores", "Cuentas y Datos Comerciales", Resources._055_gestion_de_proveedores, typeof(FormSuppliers), requireAdmin: true),
                    NavMenuItemHelper.Direct("Ingreso de Mercadería", "Recepción de Compras", Resources._065_registro_de_compras, typeof(FormPurchases), requireAdmin: true),
                    NavMenuItemHelper.Direct("Reporte de Compras", "Historial de Abastecimiento", Resources._070_reporte_de_compras, typeof(FormPurchaseReport), requireAdmin: true)
                }, requireAdmin: true),

                NavMenuItemHelper.Direct("Clientes", "Padrón de Clientes", Resources._054_gestion_de_clientes, typeof(FormCustomers)),
                NavMenuItemHelper.Direct("Personal RRHH", "Nómina de Empleados", Resources._060_gestion_de_empleados, typeof(FormEmployees), requireAdmin: true),
                NavMenuItemHelper.Direct("CCTV Seguridad", "Monitoreo de Cámaras", Resources._062_camara_de_seguridad, typeof(FormSecurityCameras)),

                NavMenuItemHelper.Group("Configuración ▾", "Usuarios y Ajustes", Resources._058_configuracion_del_sistema, new List<NavMenuItemHelper>
                {
                    NavMenuItemHelper.Direct("Cajas y Terminales", "Administración de Puestos POS", Resources._073_cajas_y_terminales, typeof(FormCashRegisters), requireAdmin: true),
                    NavMenuItemHelper.Direct("Usuarios del Sistema", "Cuentas de Acceso", Resources._069_administracion_de_usuarios, typeof(FormUsers), requireAdmin: true),
                    NavMenuItemHelper.Direct("Papelera y Restauración", "Recuperación de Registros", Resources._074_papelera_y_restauracion, typeof(FormRestoreRecords), requireAdmin: true),
                    NavMenuItemHelper.Direct("Ajustes del Comercio", "Datos Fiscales y Ticket", Resources._058_configuracion_del_sistema, typeof(FormSettings), requireAdmin: true),
                    NavMenuItemHelper.Direct("Mi Perfil", "Mis Datos y Contraseña", Resources._063_mi_perfil, typeof(FormUserProfile))
                })
            };

            foreach (var item in menuDefinitions)
            {
                if (item.RequireAdmin && !isAdministratorUser)
                    continue;

                var subItemsAuth = item.SubItems.Where(s => !s.RequireAdmin || isAdministratorUser).ToList();

                if (item.HasSubItems && !subItemsAuth.Any())
                    continue;

                var navigationButton = CreateNavigationRibbonButton(item.Title, item.Icon ?? Resources._051_dashboard);

                if (item.HasSubItems)
                {
                    var dropdownContextMenu = CreateModernDropdownContextMenu(subItemsAuth, isAdministratorUser);
                    navigationButton.Click += (s, e) => dropdownContextMenu.Show(navigationButton, 0, navigationButton.Height);
                }
                else if (item.TargetFormType != null)
                {
                    navigationButton.Click += (s, e) => OpenOrFocusChildFormByType(item.TargetFormType);
                }
                else if (item.CustomAction != null)
                {
                    navigationButton.Click += (s, e) => item.CustomAction();
                }

                flowLayoutPanelNavigationButtons.Controls.Add(navigationButton);
            }

            flowLayoutPanelNavigationButtons.ResumeLayout(true);
        }

        private static Button CreateNavigationRibbonButton(string title, Image icon)
        {
            var navigationButton = new Button
            {
                Size = new Size(130, 78),
                Image = ResizeNavigationMenuIcon(icon, 32, 32),
                ImageAlign = ContentAlignment.TopCenter,
                Text = title,
                TextAlign = ContentAlignment.BottomCenter,
                Font = UIThemeHelper.FontBodyBold,
                ForeColor = UIThemeHelper.TextMain,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
                Padding = new Padding(0, 6, 0, 6),
                Margin = new Padding(3, 2, 3, 2)
            };

            navigationButton.FlatAppearance.BorderSize = 0;
            navigationButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(215, 225, 235);

            return navigationButton;
        }

        private ContextMenuStrip CreateModernDropdownContextMenu(List<NavMenuItemHelper> items, bool isAdministratorUser)
        {
            var menu = new ContextMenuStrip
            {
                Renderer = new MenuRendererHelper(),
                Font = UIThemeHelper.FontBody,
                ShowImageMargin = true,
                ImageScalingSize = new Size(22, 22)
            };

            foreach (var item in items)
            {
                if (item.RequireAdmin && !isAdministratorUser)
                    continue;

                var menuItem = new ToolStripMenuItem(item.Title)
                {
                    Image = item.Icon != null ? ResizeNavigationMenuIcon(item.Icon, 20, 20) : null,
                    Padding = new Padding(4, 6, 4, 6)
                };

                if (item.TargetFormType != null)
                    menuItem.Click += (s, e) => OpenOrFocusChildFormByType(item.TargetFormType);
                else if (item.CustomAction != null)
                    menuItem.Click += (s, e) => item.CustomAction();

                menu.Items.Add(menuItem);
            }

            return menu;
        }

        private async Task LoadEmbeddedDashboardFormAsync()
        {
            _dashboardForm = _serviceProvider.GetRequiredService<FormHome>();
            _dashboardForm.TopLevel = false;
            _dashboardForm.FormBorderStyle = FormBorderStyle.None;
            _dashboardForm.Dock = DockStyle.Fill;

            panelMainContainer.Controls.Add(_dashboardForm);
            _dashboardForm.Show();

            await _dashboardForm.RefreshDashboardMetricsAndTablesAsync();
        }

        private void OpenOrFocusChildFormByType(Type formType)
        {
            Form? existingOpenForm = System.Windows.Forms.Application.OpenForms
                .Cast<Form>()
                .FirstOrDefault(f => f.GetType() == formType);

            if (existingOpenForm != null)
            {
                existingOpenForm.WindowState = FormWindowState.Normal;
                existingOpenForm.BringToFront();
                existingOpenForm.Focus();
                return;
            }

            var newFormInstance = (Form)_serviceProvider.GetRequiredService(formType);
            newFormInstance.Show();
        }

        private static Image ResizeNavigationMenuIcon(Image original, int width, int height)
        {
            var resized = new Bitmap(width, height);
            using var g = Graphics.FromImage(resized);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(original, 0, 0, width, height);
            return resized;
        }

        private void btnLogout_Click(object? sender, EventArgs e) => this.Close();

        private async void FormPanelControl_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_isShuttingDown)
                return;

            bool confirm = UIHelper.ConfirmMessage(
                "¿Está seguro de que desea cerrar la sesión y salir del sistema?",
                "Cerrar Sesión");

            if (!confirm)
            {
                e.Cancel = true;
                return;
            }

            e.Cancel = true;
            _isShuttingDown = true;
            this.Enabled = false;

            try
            {
                using (new WaitCursorHelper(this))
                {
                    await _backupService.ExecuteAutomaticBackupAsync();
                }
            }
            catch
            {
            }
            finally
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void HoraFecha_Tick(object? sender, EventArgs e)
        {
            labelClockTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}











