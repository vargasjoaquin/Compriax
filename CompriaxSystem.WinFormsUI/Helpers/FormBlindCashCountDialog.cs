namespace CompriaxSystem.WinFormsUI.Helpers
{
    public partial class FormBlindCashCountDialog : Form
    {
        /// <summary>
        /// Obtiene el importe físico total de dinero contado en la gaveta.
        /// </summary>
        public decimal CountedCash => numericUpDownRealCash.Value;

        /// <summary>
        /// Obtiene las observaciones o notas de cierre registradas por el cajero.
        /// </summary>
        public string Notes => textBoxNotes.Text.Trim();

        /// <summary>
        /// Constructor sin parámetros para soporte en el Diseñador Visual de Visual Studio.
        /// </summary>
        public FormBlindCashCountDialog() : this(0)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FormBlindCashCountDialog"/> con el efectivo esperado en el sistema.
        /// </summary>
        /// <param name="expectedSystemCash">Efectivo calculado por el sistema en gaveta.</param>
        public FormBlindCashCountDialog(decimal expectedSystemCash)
        {
            InitializeComponent();

            ButtonIconOverlayHelper.BindEvents(this.buttonConfirmClose, this.picIconConfirmClose);
            ButtonIconOverlayHelper.BindEvents(this.buttonCancel, this.picIconCancel);

            this.buttonCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            this.buttonConfirmClose.Click += (s, e) => this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Diálogo secundario modal para registrar movimientos manuales de caja (ingresos o retiros).
        /// </summary>
        public class FormPromptDialog : Form
        {
            /// <summary>
            /// Obtiene el monto ingresado para el movimiento de caja.
            /// </summary>
            public decimal EnteredAmount => numericUpDownAmount.Value;

            /// <summary>
            /// Obtiene la descripción o motivo del movimiento.
            /// </summary>
            public string EnteredDescription => textBoxDescription.Text.Trim();

            private System.Windows.Forms.NumericUpDown numericUpDownAmount;
            private System.Windows.Forms.TextBox textBoxDescription;
            private System.Windows.Forms.Button buttonConfirm;
            private System.Windows.Forms.Button buttonCancel;

            /// <summary>
            /// Constructor por defecto de <see cref="FormPromptDialog"/>.
            /// </summary>
            public FormPromptDialog() : this("Movimiento de Caja", "Monto ($):")
            {
            }

            /// <summary>
            /// Inicializa una nueva instancia de <see cref="FormPromptDialog"/> con título y etiqueta personalizados.
            /// </summary>
            /// <param name="dialogTitle">Título de la ventana.</param>
            /// <param name="amountPromptLabel">Etiqueta indicadora del monto.</param>
            public FormPromptDialog(string dialogTitle, string amountPromptLabel)
            {
                this.Text = dialogTitle;
                this.Size = new Size(420, 280);
                this.StartPosition = FormStartPosition.CenterParent;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.BackColor = Color.FromArgb(248, 250, 252);

                var labelAmountPrompt = new Label
                {
                    Text = amountPromptLabel,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    Location = new Point(20, 20),
                    AutoSize = true
                };

                numericUpDownAmount = new NumericUpDown
                {
                    Location = new Point(20, 45),
                    Size = new Size(360, 32),
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    Maximum = 10000000,
                    DecimalPlaces = 2
                };

                var labelDescriptionPrompt = new Label
                {
                    Text = "Motivo / Descripción:",
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    Location = new Point(20, 95),
                    AutoSize = true
                };

                textBoxDescription = new TextBox
                {
                    Location = new Point(20, 120),
                    Size = new Size(360, 27),
                    Font = new Font("Segoe UI", 10F)
                };

                buttonCancel = new Button
                {
                    Text = "Cancelar",
                    Location = new Point(140, 180),
                    Size = new Size(110, 38),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                };

                buttonConfirm = new Button
                {
                    Text = "Guardar",
                    Location = new Point(260, 180),
                    Size = new Size(120, 38),
                    BackColor = Color.FromArgb(2, 132, 199),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                };

                buttonCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
                buttonConfirm.Click += (s, e) =>
                {
                    if (numericUpDownAmount.Value <= 0 || string.IsNullOrWhiteSpace(textBoxDescription.Text))
                    {
                        MessageBox.Show("Debe ingresar un monto y motivo válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    this.DialogResult = DialogResult.OK;
                };

                this.Controls.AddRange(new Control[] { labelAmountPrompt, numericUpDownAmount, labelDescriptionPrompt, textBoxDescription, buttonCancel, buttonConfirm });
            }
        }
    }
}
