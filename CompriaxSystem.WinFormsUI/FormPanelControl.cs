using CompriaxSystem.Application.Interfaces.Services;
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

            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            HoraFecha.Interval = 1000;
            HoraFecha.Tick -= HoraFecha_Tick;
            HoraFecha.Tick += HoraFecha_Tick;
            HoraFecha.Start();

            this.btnLogout.Click -= btnLogout_Click;
            this.btnLogout.Click += btnLogout_Click;

            this.FormClosing -= FormPanelControl_FormClosing;
            this.FormClosing += FormPanelControl_FormClosing;

            this.Load += async (s, e) =>
            {
                await SetupAppearanceAsync();
                await LoadDashboardAsync();
            };

            LoadUserData();
        }
        public async Task SetupAppearanceAsync()
        {
            if (!await _appearanceLock.WaitAsync(0))
                return;

            try
            {
                picLogo.Image?.Dispose();
                picLogo.Image = null;

                picLogo.Image = Resources.logo_compriax;
                picLogo.SizeMode = PictureBoxSizeMode.Zoom;

                await RefreshShiftStatusAsync();
            }
            catch
            {
            }
            finally
            {
                _appearanceLock.Release();
            }
        }

        public async Task RefreshShiftStatusAsync()
        {
            try
            {
                var user = _currentUserService.CurrentUser;
                bool isAdmin = user != null && user.RoleName.Equals("Administrador", StringComparison.OrdinalIgnoreCase);
                var ctx = _currentUserService.OperationalContext;

                if (isAdmin && ctx == null)
                {
                    lblShiftStatus.Text = " Modo Supervisor (Vista Global)";
                    lblShiftStatus.ImageAlign = ContentAlignment.MiddleLeft;
                    lblShiftStatus.ForeColor = Color.FromArgb(226, 232, 240);
                }
                else
                {
                    var activeShift = await _cashShiftService.GetCurrentActiveShiftAsync();
                    string regName = ctx?.CashRegisterName ?? "Caja 01";

                    if (activeShift != null)
                    {
                        DateTime localOpening = activeShift.OpeningDate.Kind == DateTimeKind.Utc
                                                ? activeShift.OpeningDate.ToLocalTime()
                                                : activeShift.OpeningDate;

                        lblShiftStatus.Text = $" {regName} | Turno #{activeShift.Id} ({localOpening:HH:mm})";
                        lblShiftStatus.ImageAlign = ContentAlignment.MiddleLeft;
                        lblShiftStatus.ForeColor = Color.FromArgb(16, 185, 129);
                    }
                    else
                    {
                        lblShiftStatus.Text = $" {regName} | Caja Cerrada";
                        lblShiftStatus.ImageAlign = ContentAlignment.MiddleLeft;
                        lblShiftStatus.ForeColor = Color.FromArgb(248, 113, 113);
                    }
                }
            }
            catch { }
        }

        private void LoadUserData()
        {
            var user = _currentUserService.CurrentUser;

            if (user == null)
                return;

            lblSessionUser.Text = user.FullName.ToUpper();
            lblRoleName.Text = $"[{user.RoleName.ToUpper()}]";

            bool isAdmin = user.RoleName.Equals("Administrador", StringComparison.OrdinalIgnoreCase);
            BuildNavigationMenu(isAdmin);
        }

        private void BuildNavigationMenu(bool isAdmin)
        {
            flowLayoutButtons.SuspendLayout();
            flowLayoutButtons.Controls.Clear();

            var menuDefinitions = new List<NavMenuItemHelper>
            {
                NavMenuItemHelper.DirectAction("Inicio", "Dashboard Principal", Resources._051_dashboard, async () =>
                {
                    _dashboardForm?.BringToFront();

                    if (_dashboardForm != null)
                        await _dashboardForm.RefreshDashboardAsync();
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
                    NavMenuItemHelper.Direct("Etiquetas de Precio", "Impresión con Código de Barras", Resources._061_codigo_de_barras, typeof(FormPrintPrices))
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
                if (item.RequireAdmin && !isAdmin)
                    continue;

                var subItemsAuth = item.SubItems.Where(s => !s.RequireAdmin || isAdmin).ToList();

                if (item.HasSubItems && !subItemsAuth.Any())
                    continue;

                var btn = CreateNavButton(item.Title, item.Icon ?? Resources._051_dashboard);

                if (item.HasSubItems)
                {
                    var ctxMenu = CreateModernContextMenu(subItemsAuth, isAdmin);
                    btn.Click += (s, e) => ctxMenu.Show(btn, 0, btn.Height);
                }
                else if (item.TargetFormType != null)
                {
                    btn.Click += (s, e) => OpenWindowByType(item.TargetFormType);
                }
                else if (item.CustomAction != null)
                {
                    btn.Click += (s, e) => item.CustomAction();
                }

                flowLayoutButtons.Controls.Add(btn);
            }

            flowLayoutButtons.ResumeLayout(true);
        }

        private static Button CreateNavButton(string title, Image icon)
        {
            var btn = new Button
            {
                Size = new Size(130, 78),
                Image = ResizeImage(icon, 32, 32),
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

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(215, 225, 235);

            return btn;
        }

        private ContextMenuStrip CreateModernContextMenu(List<NavMenuItemHelper> items, bool isAdmin)
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
                if (item.RequireAdmin && !isAdmin)
                    continue;

                var menuItem = new ToolStripMenuItem(item.Title)
                {
                    Image = item.Icon != null ? ResizeImage(item.Icon, 20, 20) : null,
                    Padding = new Padding(4, 6, 4, 6)
                };

                if (item.TargetFormType != null)
                    menuItem.Click += (s, e) => OpenWindowByType(item.TargetFormType);
                else if (item.CustomAction != null)
                    menuItem.Click += (s, e) => item.CustomAction();

                menu.Items.Add(menuItem);
            }

            return menu;
        }

        private async Task LoadDashboardAsync()
        {
            _dashboardForm = _serviceProvider.GetRequiredService<FormHome>();
            _dashboardForm.TopLevel = false;
            _dashboardForm.FormBorderStyle = FormBorderStyle.None;
            _dashboardForm.Dock = DockStyle.Fill;

            panelContenedor.Controls.Add(_dashboardForm);
            _dashboardForm.Show();

            await _dashboardForm.RefreshDashboardAsync();
        }

        private void OpenWindowByType(Type formType)
        {
            Form? existing = System.Windows.Forms.Application.OpenForms
                .Cast<Form>()
                .FirstOrDefault(f => f.GetType() == formType);

            if (existing != null)
            {
                existing.WindowState = FormWindowState.Normal;
                existing.BringToFront();
                existing.Focus();
                return;
            }

            var newForm = (Form)_serviceProvider.GetRequiredService(formType);
            newForm.Show();
        }

        private static Image ResizeImage(Image original, int width, int height)
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
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}