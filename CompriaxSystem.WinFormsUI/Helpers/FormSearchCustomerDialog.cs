namespace CompriaxSystem.WinFormsUI.Helpers
{
    public partial class FormSearchCustomerDialog : Form
    {
        /// <summary>
        /// Obtiene el número de documento / DNI ingresado por el usuario.
        /// </summary>
        public string EnteredDocumentNumber => textBoxDocumentNumber.Text.Trim();

        /// <summary>
        /// Alias de compatibilidad para el documento ingresado.
        /// </summary>
        public string EnteredDocument => EnteredDocumentNumber;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FormSearchCustomerDialog"/>.
        /// </summary>
        public FormSearchCustomerDialog()
        {
            InitializeComponent();
            UIThemeHelper.ApplyFormStyle(this);

            ButtonIconOverlayHelper.BindEvents(this.buttonSearch, this.picIconSearch);
            ButtonIconOverlayHelper.BindEvents(this.buttonCancel, this.picIconCancel);

            this.buttonCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            this.buttonSearch.Click += (s, e) => ExecuteConfirmCustomerSearch();

            this.textBoxDocumentNumber.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            };

            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) ExecuteConfirmCustomerSearch();
                if (e.KeyCode == Keys.Escape) this.DialogResult = DialogResult.Cancel;
            };

            this.Shown += (s, e) => textBoxDocumentNumber.Focus();
        }

        /// <summary>
        /// Valida el formato del documento ingresado y confirma la selección.
        /// </summary>
        private void ExecuteConfirmCustomerSearch()
        {
            string documentNumber = textBoxDocumentNumber.Text.Trim();

            if (string.IsNullOrWhiteSpace(documentNumber))
            {
                MessageBox.Show("Por favor, ingrese el número de DNI del cliente.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxDocumentNumber.Focus();
                return;
            }

            if (documentNumber.Length < 7)
            {
                MessageBox.Show("El DNI debe contener al menos 7 u 8 dígitos numéricos.", "DNI Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxDocumentNumber.Focus();
                return;
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}

