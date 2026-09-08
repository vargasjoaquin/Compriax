namespace CompriaxSystem.WinFormsUI
{
    partial class FormSelectCashRegister
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlCard = new Panel();
            lblRegister = new Label();
            cboRegister = new ComboBox();
            lblStatusInfo = new Label();
            btnConfirm = new Button();
            btnCancel = new Button();
            pnlHeader.SuspendLayout();
            pnlCard.SuspendLayout();
            SuspendLayout();

            // pnlHeader
            pnlHeader.BackColor = Color.FromArgb(15, 23, 42);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(440, 56);
            pnlHeader.TabIndex = 0;

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(16, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(330, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "SELECCIONAR CAJA DE COBRO";

            // pnlCard
            pnlCard.BackColor = Color.White;
            pnlCard.Controls.Add(lblRegister);
            pnlCard.Controls.Add(cboRegister);
            pnlCard.Controls.Add(lblStatusInfo);
            pnlCard.Controls.Add(btnConfirm);
            pnlCard.Controls.Add(btnCancel);
            pnlCard.Location = new Point(20, 72);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(400, 220);
            pnlCard.TabIndex = 1;

            // lblRegister
            lblRegister.AutoSize = true;
            lblRegister.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblRegister.Location = new Point(20, 16);
            lblRegister.Name = "lblRegister";
            lblRegister.Size = new Size(239, 21);
            lblRegister.TabIndex = 0;
            lblRegister.Text = "Seleccionar Caja / Puesto POS:";

            // cboRegister
            cboRegister.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRegister.Font = new Font("Segoe UI", 10.5F);
            cboRegister.Location = new Point(20, 40);
            cboRegister.Name = "cboRegister";
            cboRegister.Size = new Size(360, 31);
            cboRegister.TabIndex = 1;

            // lblStatusInfo
            lblStatusInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatusInfo.ForeColor = Color.FromArgb(16, 185, 129);
            lblStatusInfo.Location = new Point(20, 80);
            lblStatusInfo.Name = "lblStatusInfo";
            lblStatusInfo.Size = new Size(360, 22);
            lblStatusInfo.TabIndex = 2;
            lblStatusInfo.Text = "Caja disponible";

            // btnConfirm
            btnConfirm.BackColor = Color.FromArgb(16, 185, 129);
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(20, 115);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(360, 44);
            btnConfirm.TabIndex = 3;
            btnConfirm.Text = "INGRESAR A LA CAJA";
            btnConfirm.UseVisualStyleBackColor = false;

            // btnCancel
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancel.Location = new Point(20, 168);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(360, 34);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "CANCELAR";
            btnCancel.UseVisualStyleBackColor = true;

            // FormSelectCashRegister
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(440, 310);
            Controls.Add(pnlCard);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormSelectCashRegister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Selección de Caja";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblRegister;
        private System.Windows.Forms.ComboBox cboRegister;
        private System.Windows.Forms.Label lblStatusInfo;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
    }
}