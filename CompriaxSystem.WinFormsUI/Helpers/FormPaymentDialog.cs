using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.WinFormsUI.Helpers
{
    public partial class FormPaymentDialog : Form
    {
        /// <summary>
        /// Obtiene el importe total a cobrar en la venta.
        /// </summary>
        public decimal TotalAmount { get; private set; }

        /// <summary>
        /// Obtiene el importe en efectivo o digital entregado por el cliente.
        /// </summary>
        public decimal AmountPaid => numericUpDownAmountPaid.Value;

        /// <summary>
        /// Obtiene el importe correspondiente al cambio o vuelto a entregar al cliente.
        /// </summary>
        public decimal ChangeAmount => Math.Max(0, AmountPaid - TotalAmount);

        /// <summary>
        /// Alias de compatibilidad para el cambio.
        /// </summary>
        public decimal Change => ChangeAmount;

        /// <summary>
        /// Obtiene el identificador del medio de pago seleccionado.
        /// </summary>
        public int SelectedPaymentMethodId => (int)(comboBoxPaymentMethod.SelectedValue ?? 1);

        /// <summary>
        /// Obtiene el nombre del medio de pago seleccionado.
        /// </summary>
        public string SelectedPaymentMethodName => comboBoxPaymentMethod.Text;

        /// <summary>
        /// Constructor sin parámetros para soporte de previsualización en el Diseñador Visual de Visual Studio.
        /// </summary>
        public FormPaymentDialog() : this(0, Enumerable.Empty<PaymentMethod>())
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FormPaymentDialog"/> con el total a cobrar y los medios de pago disponibles.
        /// </summary>
        /// <param name="totalAmount">Monto total facturado.</param>
        /// <param name="paymentMethods">Catálogo de medios de pago activos.</param>
        public FormPaymentDialog(decimal totalAmount, IEnumerable<PaymentMethod> paymentMethods)
        {
            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);
            TotalAmount = totalAmount;

            ButtonIconOverlayHelper.BindEvents(this.buttonConfirmPayment, this.picIconConfirmPayment);
            ButtonIconOverlayHelper.BindEvents(this.buttonCancel, this.picIconCancel);

            labelTotalValue.Text = totalAmount.ToString("C2");
            numericUpDownAmountPaid.Value = totalAmount;

            var methodsList = paymentMethods.ToList();
            if (methodsList.Any())
            {
                comboBoxPaymentMethod.DataSource = methodsList;
                comboBoxPaymentMethod.DisplayMember = "Name";
                comboBoxPaymentMethod.ValueMember = "Id";
                comboBoxPaymentMethod.SelectedIndex = 0;
            }

            // Atajos de botones de billetes rápidos
            this.buttonAdd1000.Click += (s, e) => numericUpDownAmountPaid.Value += 1000;
            this.buttonAdd2000.Click += (s, e) => numericUpDownAmountPaid.Value += 2000;
            this.buttonAdd5000.Click += (s, e) => numericUpDownAmountPaid.Value += 5000;
            this.buttonAdd10000.Click += (s, e) => numericUpDownAmountPaid.Value += 10000;
            this.buttonAdd20000.Click += (s, e) => numericUpDownAmountPaid.Value += 20000;
            this.buttonExactAmount.Click += (s, e) => numericUpDownAmountPaid.Value = TotalAmount;

            this.buttonConfirmPayment.Click += (s, e) => ExecuteConfirmPayment();
            this.buttonCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            this.numericUpDownAmountPaid.ValueChanged += (s, e) => UpdatePaymentChangeCalculation();
            this.numericUpDownAmountPaid.KeyUp += (s, e) => UpdatePaymentChangeCalculation();

            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) ExecuteConfirmPayment();
                if (e.KeyCode == Keys.Escape) this.DialogResult = DialogResult.Cancel;
            };

            this.Shown += (s, e) =>
            {
                numericUpDownAmountPaid.Focus();
                numericUpDownAmountPaid.Select(0, numericUpDownAmountPaid.Text.Length);
            };
        }

        /// <summary>
        /// Actualiza el importe visual del vuelto según el monto abonado por el cliente.
        /// </summary>
        private void UpdatePaymentChangeCalculation()
        {
            decimal difference = numericUpDownAmountPaid.Value - TotalAmount;
            labelChangeAmount.Text = (difference >= 0 ? difference : 0).ToString("C2");
            labelChangeAmount.ForeColor = difference >= 0 ? Color.FromArgb(16, 185, 129) : Color.FromArgb(239, 68, 68);
        }

        /// <summary>
        /// Valida que el pago sea suficiente y confirma la operación.
        /// </summary>
        private void ExecuteConfirmPayment()
        {
            if (numericUpDownAmountPaid.Value < TotalAmount)
            {
                MessageBox.Show(
                    $"El monto recibido (${numericUpDownAmountPaid.Value:N2}) es menor al total a pagar (${TotalAmount:N2}).",
                    "Pago Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDownAmountPaid.Focus();
                return;
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}

