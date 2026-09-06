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
        public static readonly Font FontHeader = new("Segoe UI", 13F, FontStyle.Bold);
        public static readonly Font FontBodyBold = new("Segoe UI", 9.5F, FontStyle.Bold);
        public static readonly Font FontBody = new("Segoe UI", 9.5F, FontStyle.Regular);

        // ==========================================
        // 3. ATAJOS DE TECLADO CENTRALIZADOS (POS)
        // ==========================================
        public static class Shortcuts
        {
            public const Keys SearchProduct = Keys.F2;
            public const Keys SelectCustomer = Keys.F3;
            public const Keys ChangeQuantity = Keys.F4;
            public const Keys OpenPromotions = Keys.F5;
            public const Keys Checkout = Keys.F8;
            public const Keys DeleteItem = Keys.Delete;
            public const Keys ClearOrCancel = Keys.Escape;
        }

        // ==========================================
        // 4. ESTILIZADO DE CONTROLES
        // ==========================================
        public static void ApplyFormStyle(Form form)
        {
            form.BackColor = Background;
            form.Font = FontBody;
        }

        public static void ApplyCardStyle(Panel pnl)
        {
            pnl.BackColor = Surface;
            pnl.BorderStyle = BorderStyle.None;
        }
    }
}

