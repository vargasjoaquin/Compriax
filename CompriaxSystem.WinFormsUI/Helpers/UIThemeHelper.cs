using System.Runtime.InteropServices;

namespace CompriaxSystem.WinFormsUI.Helpers
{
    public static class UIThemeHelper
    {
        // ==========================================
        // 1. PALETA DE COLORES (Tailwind/Slate Palette)
        // ==========================================
        public static readonly Color Primary = Color.FromArgb(2, 132, 199);
        public static readonly Color PrimaryDark = Color.FromArgb(3, 105, 161);
        public static readonly Color PrimaryLight = Color.FromArgb(224, 242, 254);

        public static readonly Color SidebarBackground = Color.FromArgb(15, 23, 42);
        public static readonly Color SidebarHover = Color.FromArgb(30, 41, 59);
        public static readonly Color SidebarText = Color.FromArgb(226, 232, 240);

        public static readonly Color Background = Color.FromArgb(248, 250, 252);
        public static readonly Color Surface = Color.White;
        public static readonly Color Border = Color.FromArgb(226, 232, 240);

        public static readonly Color Success = Color.FromArgb(16, 185, 129);
        public static readonly Color SuccessLight = Color.FromArgb(209, 250, 229);
        public static readonly Color Danger = Color.FromArgb(239, 68, 68);
        public static readonly Color DangerLight = Color.FromArgb(254, 226, 226);

        public static readonly Color TextMain = Color.FromArgb(15, 23, 42);
        public static readonly Color TextMuted = Color.FromArgb(100, 116, 139);

        // ==========================================
        // 2. TIPOGRAFÍAS
        // ==========================================
        public static readonly Font FontDisplayLarge = new("Segoe UI", 24F, FontStyle.Bold);
        public static readonly Font FontDisplayMedium = new("Segoe UI", 18F, FontStyle.Bold);
        public static readonly Font FontHeader = new("Segoe UI", 13F, FontStyle.Bold);
        public static readonly Font FontSubHeader = new("Segoe UI", 11F, FontStyle.Bold);
        public static readonly Font FontBodyBold = new("Segoe UI", 9.5F, FontStyle.Bold);
        public static readonly Font FontBody = new("Segoe UI", 9.5F, FontStyle.Regular);
        public static readonly Font FontSmall = new("Segoe UI", 8.5F, FontStyle.Regular);
        public static readonly Font FontMonospace = new("Consolas", 10F, FontStyle.Regular);

        // ==========================================
        // 3. ATAJOS DE TECLADO CENTRALIZADOS (POS)
        // ==========================================
        public static class Shortcuts
        {
            public const Keys SearchProduct = Keys.F2;
            public const Keys SelectCustomer = Keys.F3;
            public const Keys ChangeQuantity = Keys.F4;
            public const Keys OpenPromotions = Keys.F5;
            public const Keys CheckPrice = Keys.F6;
            public const Keys Checkout = Keys.F8;
            public const Keys DeleteItem = Keys.Delete;
            public const Keys ClearOrCancel = Keys.Escape;
        }

        // ==========================================
        // 4. GESTIÓN DEL ICONO OFICIAL
        // ==========================================
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool DestroyIcon(IntPtr handle);

        private static Icon? _cachedAppIcon = null;

        /// <summary>
        /// Obtiene el icono oficial de la aplicación generado en memoria a partir del recurso institucional.
        /// </summary>
        public static Icon? GetAppIcon()
        {
            if (_cachedAppIcon != null)
                return _cachedAppIcon;

            try
            {
                if (Resources.logo_compriax != null)
                {
                    IntPtr hIcon = Resources.logo_compriax.GetHicon();
                    using var tempIcon = Icon.FromHandle(hIcon);
                    _cachedAppIcon = (Icon)tempIcon.Clone();
                    DestroyIcon(hIcon);
                    return _cachedAppIcon;
                }
            }
            catch
            {
            }

            return null;
        }

        // ==========================================
        // 5. ESTILIZADO GLOBAL DE FORMULARIOS
        // ==========================================
        /// <summary>
        /// Aplica fondo, tipografía institucional e icono oficial de ventana a cualquier formulario.
        /// </summary>
        public static void ApplyFormStyle(Form form)
        {
            form.BackColor = Background;
            form.Font = FontBody;

            var appIcon = GetAppIcon();
            if (appIcon != null)
            {
                form.Icon = appIcon;
                form.ShowIcon = true;
            }
        }

        public static void ApplyCardStyle(Panel pnl)
        {
            pnl.BackColor = Surface;
            pnl.BorderStyle = BorderStyle.None;
        }

        public static void ApplyButtonSuccess(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Success;
            btn.ForeColor = Color.White;
            btn.Font = FontHeader;
            btn.Cursor = Cursors.Hand;
        }

        public static void ApplyButtonDanger(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Danger;
            btn.ForeColor = Color.White;
            btn.Font = FontBodyBold;
            btn.Cursor = Cursors.Hand;
        }
    }
}
