namespace CompriaxSystem.WinFormsUI.Helpers
{
    public class FormSearchCustomerDialog : Form
    {
        public string EnteredDocument => txtDocument.Text.Trim();

        private readonly TextBox txtDocument;
        private readonly Button btnSearch;
        private readonly Button btnCancel;

        public FormSearchCustomerDialog()
        {
            this.Text = "Asociar Cliente a la Venta";
            this.Size = new Size(440, 220);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = UIThemeHelper.Background;
            this.KeyPreview = true;

            var lblTitle = new Label
            {
                Text = "🔍 BÚSQUEDA DE CLIENTE POR DNI",
                Font = UIThemeHelper.FontHeader,
                ForeColor = UIThemeHelper.Primary,
                Location = new Point(20, 16),
                AutoSize = true
            };

            var lblPrompt = new Label
            {
                Text = "Ingrese el número de DNI del Cliente (hasta 8 dígitos):",
                Font = UIThemeHelper.FontBodyBold,
                ForeColor = UIThemeHelper.TextMain,
                Location = new Point(20, 50),
                AutoSize = true
            };

            txtDocument = new TextBox
            {
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Location = new Point(20, 78),
                Size = new Size(385, 34),
                MaxLength = 8
            };

            txtDocument.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            };

            btnCancel = new Button
            {
                Text = "CANCELAR (ESC)",
                Location = new Point(20, 126),
                Size = new Size(180, 38),
                Font = UIThemeHelper.FontBodyBold,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            btnSearch = new Button
            {
                Text = "✓ ASOCIAR (ENTER)",
                Location = new Point(215, 126),
                Size = new Size(190, 38)
            };
            btnSearch.Click += (s, e) => ConfirmSearch();

            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) ConfirmSearch();
                if (e.KeyCode == Keys.Escape) this.DialogResult = DialogResult.Cancel;
            };

            this.Controls.AddRange(new Control[] { lblTitle, lblPrompt, txtDocument, btnCancel, btnSearch });

            this.Shown += (s, e) => txtDocument.Focus();
        }

        private void ConfirmSearch()
        {
            string dni = txtDocument.Text.Trim();

            if (string.IsNullOrWhiteSpace(dni))
            {
                MessageBox.Show("Por favor, ingrese el número de DNI del cliente.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocument.Focus();
                return;
            }

            if (dni.Length < 7)
            {
                MessageBox.Show("El DNI debe tener al menos 7 u 8 dígitos.", "DNI Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocument.Focus();
                return;
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}