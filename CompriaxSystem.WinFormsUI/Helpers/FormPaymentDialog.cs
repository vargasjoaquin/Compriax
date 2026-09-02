namespace CompriaxSystem.WinFormsUI.Helpers
{
    public class FormPaymentDialog : Form
    {
        public decimal TotalAmount { get; }
        public decimal AmountPaid => numAmountPaid.Value;
        public decimal Change => Math.Max(0, AmountPaid - TotalAmount);
        public int SelectedPaymentMethodId => (int)(cboPaymentMethod.SelectedValue ?? 1);
        public string SelectedPaymentMethodName => cboPaymentMethod.Text;

        private readonly NumericUpDown numAmountPaid;
        private readonly ComboBox cboPaymentMethod;
        private readonly Label lblChangeAmount;
        private readonly Button btnConfirm;

        public FormPaymentDialog(decimal totalAmount, IEnumerable<PaymentMethod> paymentMethods)
        {
            TotalAmount = totalAmount;

            this.Text = "Cobro de Venta";
            this.Size = new Size(520, 560);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = UIThemeHelper.Background;
            this.KeyPreview = true;

            var pnlTotal = new Panel
            {
                Dock = DockStyle.Top,
                Height = 110,
                BackColor = UIThemeHelper.SidebarBackground
            };

            var lblTotalTitle = new Label
            {
                Text = "TOTAL A COBRAR",
                Font = UIThemeHelper.FontSubHeader,
                ForeColor = UIThemeHelper.TextMuted,
                Location = new Point(20, 15),
                AutoSize = true
            };

            var lblTotalValue = new Label
            {
                Text = totalAmount.ToString("C2"),
                Font = UIThemeHelper.FontDisplayLarge,
                ForeColor = Color.White,
                Location = new Point(20, 40),
                AutoSize = true
            };

            pnlTotal.Controls.AddRange(new Control[] { lblTotalTitle, lblTotalValue });

            var lblMethod = new Label
            {
                Text = "Medio de Pago:",
                Font = UIThemeHelper.FontBodyBold,
                Location = new Point(25, 130),
                AutoSize = true
            };

            cboPaymentMethod = new ComboBox
            {
                Location = new Point(25, 155),
                Size = new Size(450, 32),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 11F),
                DataSource = paymentMethods.ToList(),
                DisplayMember = "Name",
                ValueMember = "Id"
            };

            var lblPaid = new Label
            {
                Text = "Monto Recibido del Cliente ($):",
                Font = UIThemeHelper.FontBodyBold,
                Location = new Point(25, 205),
                AutoSize = true
            };

            numAmountPaid = new NumericUpDown
            {
                Location = new Point(25, 230),
                Size = new Size(450, 38),
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                Maximum = 100000000,
                DecimalPlaces = 2,
                Value = totalAmount
            };

            var pnlQuickBills = new FlowLayoutPanel
            {
                Location = new Point(25, 280),
                Size = new Size(450, 80),
                BackColor = Color.Transparent
            };

            int[] quickValues = { 1000, 2000, 5000, 10000, 20000 };
            foreach (var val in quickValues)
            {
                var btnBill = new Button
                {
                    Text = $"+${val:N0}",
                    Size = new Size(82, 34),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = UIThemeHelper.Surface,
                    Font = UIThemeHelper.FontBodyBold,
                    Cursor = Cursors.Hand
                };
                btnBill.FlatAppearance.BorderColor = UIThemeHelper.Border;
                btnBill.Click += (s, e) => numAmountPaid.Value += val;
                pnlQuickBills.Controls.Add(btnBill);
            }

            var btnExact = new Button
            {
                Text = "EXACTO",
                Size = new Size(170, 34),
                FlatStyle = FlatStyle.Flat,
                BackColor = UIThemeHelper.PrimaryLight,
                ForeColor = UIThemeHelper.PrimaryDark,
                Font = UIThemeHelper.FontBodyBold,
                Cursor = Cursors.Hand
            };
            btnExact.FlatAppearance.BorderSize = 0;
            btnExact.Click += (s, e) => numAmountPaid.Value = totalAmount;
            pnlQuickBills.Controls.Add(btnExact);

            var pnlChange = new Panel
            {
                Location = new Point(25, 370),
                Size = new Size(450, 65),
                BackColor = UIThemeHelper.Surface
            };
            UIThemeHelper.ApplyCardStyle(pnlChange);

            var lblChangeTitle = new Label
            {
                Text = "SU VUELTO:",
                Font = UIThemeHelper.FontBodyBold,
                Location = new Point(15, 22),
                AutoSize = true
            };

            lblChangeAmount = new Label
            {
                Text = "$ 0.00",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = UIThemeHelper.Success,
                Location = new Point(150, 15),
                Size = new Size(280, 35),
                TextAlign = ContentAlignment.MiddleRight
            };

            pnlChange.Controls.AddRange(new Control[] { lblChangeTitle, lblChangeAmount });

            btnConfirm = new Button
            {
                Text = "✓ CONFIRMAR PAGO (ENTER)",
                Location = new Point(225, 455),
                Size = new Size(250, 48)
            };
            UIThemeHelper.ApplyButtonSuccess(btnConfirm);

            var btnCancel = new Button
            {
                Text = "CANCELAR (ESC)",
                Location = new Point(25, 455),
                Size = new Size(185, 48)
            };
            UIThemeHelper.ApplyButtonDanger(btnCancel);

            btnConfirm.Click += (s, e) => TryConfirm();
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            numAmountPaid.ValueChanged += (s, e) => UpdateChange();
            numAmountPaid.KeyUp += (s, e) => UpdateChange();

            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) TryConfirm();
                if (e.KeyCode == Keys.Escape) this.DialogResult = DialogResult.Cancel;
            };

            this.Controls.AddRange(new Control[] {
                pnlTotal, lblMethod, cboPaymentMethod, lblPaid, numAmountPaid,
                pnlQuickBills, pnlChange, btnCancel, btnConfirm
            });

            this.Shown += (s, e) =>
            {
                numAmountPaid.Focus();
                numAmountPaid.Select(0, numAmountPaid.Text.Length);
            };
        }

        private void UpdateChange()
        {
            decimal diff = numAmountPaid.Value - TotalAmount;
            lblChangeAmount.Text = (diff >= 0 ? diff : 0).ToString("C2");
            lblChangeAmount.ForeColor = diff >= 0 ? UIThemeHelper.Success : UIThemeHelper.Danger;
        }

        private void TryConfirm()
        {
            if (numAmountPaid.Value < TotalAmount)
            {
                MessageBox.Show(
                    $"El monto recibido (${numAmountPaid.Value:N2}) es menor al total a pagar (${TotalAmount:N2}).",
                    "Pago Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numAmountPaid.Focus();
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

    }
}
