using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompriaxSystem.WinFormsUI.Helpers
{
    public class FormBlindCashCountDialogHelper : Form
    {
        public decimal CountedCash => numRealCash.Value;
        public string Notes => txtNotes.Text.Trim();

        private NumericUpDown numRealCash;
        private TextBox txtNotes;
        private Button btnConfirm, btnCancel;

        public FormBlindCashCountDialogHelper(decimal expectedSystemCash)
        {
            this.Text = "Arqueo y Cierre Definitivo de Caja (Z)";
            this.Size = new Size(480, 320);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.WhiteSmoke;

            var lblHeader = new Label { Text = "🔒 ARQUEO CIEGO DE EFECTIVO", Font = new Font("Segoe UI", 12F, FontStyle.Bold), Location = new Point(20, 15), AutoSize = true };
            var lblInstruct = new Label { Text = "Cuente los billetes y monedas físicos e ingrese el total:", Font = new Font("Segoe UI", 9F), Location = new Point(20, 48), AutoSize = true };

            var lblCash = new Label { Text = "Efectivo Real Contado en Gaveta ($):", Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), Location = new Point(20, 80), AutoSize = true };
            numRealCash = new NumericUpDown { Location = new Point(20, 105), Size = new Size(420, 35), Font = new Font("Segoe UI", 14F, FontStyle.Bold), Maximum = 100000000, DecimalPlaces = 2 };

            var lblNotes = new Label { Text = "Observaciones de Cierre (Opcional):", Location = new Point(20, 155), AutoSize = true };
            txtNotes = new TextBox { Location = new Point(20, 178), Size = new Size(420, 27) };

            btnCancel = new Button { Text = "Cancelar", Location = new Point(180, 225), Size = new Size(120, 40), FlatStyle = FlatStyle.Flat, BackColor = Color.DimGray, ForeColor = Color.White };
            btnConfirm = new Button { Text = "✓ CERRAR CAJA", Location = new Point(310, 225), Size = new Size(130, 40), FlatStyle = FlatStyle.Flat, BackColor = Color.Firebrick, ForeColor = Color.White, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };

            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            btnConfirm.Click += (s, e) => this.DialogResult = DialogResult.OK;

            this.Controls.AddRange(new Control[] { lblHeader, lblInstruct, lblCash, numRealCash, lblNotes, txtNotes, btnCancel, btnConfirm });
        }

        public class FormPromptDialog : Form
        {
            public decimal EnteredAmount => numAmount.Value;
            public string EnteredDescription => txtDesc.Text.Trim();

            private NumericUpDown numAmount;
            private TextBox txtDesc;
            private Button btnOk, btnCancel;

            public FormPromptDialog(string title, string amountLabel)
            {
                this.Text = title;
                this.Size = new Size(420, 280);
                this.StartPosition = FormStartPosition.CenterParent;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                this.MinimizeBox = false;

                var lbl1 = new Label { Text = amountLabel, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), Location = new Point(20, 20), AutoSize = true };
                numAmount = new NumericUpDown { Location = new Point(20, 45), Size = new Size(360, 32), Font = new Font("Segoe UI", 12F, FontStyle.Bold), Maximum = 10000000, DecimalPlaces = 2 };

                var lbl2 = new Label { Text = "Motivo / Descripción:", Location = new Point(20, 95), AutoSize = true };
                txtDesc = new TextBox { Location = new Point(20, 120), Size = new Size(360, 27) };

                btnCancel = new Button { Text = "Cancelar", Location = new Point(140, 180), Size = new Size(110, 38) };
                btnOk = new Button { Text = "Guardar", Location = new Point(260, 180), Size = new Size(120, 38), BackColor = Color.Navy, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };

                btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
                btnOk.Click += (s, e) =>
                {
                    if (numAmount.Value <= 0 || string.IsNullOrWhiteSpace(txtDesc.Text))
                    {
                        MessageBox.Show("Debe ingresar un monto y motivo válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    this.DialogResult = DialogResult.OK;
                };

                this.Controls.AddRange(new Control[] { lbl1, numAmount, lbl2, txtDesc, btnCancel, btnOk });
            }
        }
    }
}
