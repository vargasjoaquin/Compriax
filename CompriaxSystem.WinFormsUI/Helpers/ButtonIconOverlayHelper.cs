namespace CompriaxSystem.WinFormsUI.Helpers
{
    public static class ButtonIconOverlayHelper
    {
        /// <summary>
        /// Vincula un botón con su ícono para que ambos compartan la misma acción,
        /// estados visuales y comportamiento de interacción.
        /// El ícono ejecuta la acción del botón al hacer clic y sincroniza los estados
        /// normal, hover, presionado, visible y habilitado.
        /// </summary>
        public static void BindEvents(Button button, PictureBox icon)
        {
            if (button == null || icon == null)
                return;

            // Clic en el icono ejecuta la acción del botón
            icon.Click += (s, e) => button.PerformClick();

            Color hoverColor = button.FlatAppearance.MouseOverBackColor != Color.Empty 
                ? button.FlatAppearance.MouseOverBackColor 
                : (button.BackColor == Color.White ? Color.FromArgb(241, 245, 249) : ControlPaint.Light(button.BackColor));

            Color pressedColor = button.FlatAppearance.MouseDownBackColor != Color.Empty 
                ? button.FlatAppearance.MouseDownBackColor 
                : ControlPaint.Dark(button.BackColor);

            void UpdateState(Color color)
            {
                icon.BackColor = color;
            }

            void ResetState()
            {
                Point cursorScreen = Cursor.Position;
                Point pBtn = button.PointToClient(cursorScreen);
                Point pIcon = icon.PointToClient(cursorScreen);

                bool isOver = button.ClientRectangle.Contains(pBtn) || icon.ClientRectangle.Contains(pIcon);
                icon.BackColor = isOver ? hoverColor : button.BackColor;
            }

            button.MouseEnter += (s, e) => UpdateState(hoverColor);
            button.MouseLeave += (s, e) => ResetState();
            button.MouseDown += (s, e) => UpdateState(pressedColor);
            button.MouseUp += (s, e) => UpdateState(hoverColor);

            icon.MouseEnter += (s, e) => UpdateState(hoverColor);
            icon.MouseLeave += (s, e) => ResetState();
            icon.MouseDown += (s, e) => UpdateState(pressedColor);
            icon.MouseUp += (s, e) => UpdateState(hoverColor);

            button.EnabledChanged += (s, e) => icon.Visible = button.Visible && button.Enabled;
            button.VisibleChanged += (s, e) => icon.Visible = button.Visible;
        }
    }
}
