namespace CompriaxSystem.WinFormsUI
{
    partial class FormActivation
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
            lblInstruct = new Label();
            lblCuit = new Label();
            txtCuit = new TextBox();
            lblKey = new Label();
            txtLicenseKey = new TextBox();
            lblStatusMessage = new Label();
            btnActivate = new Button();
            btnExit = new Button();
            pnlHeader.SuspendLayout();
            pnlCard.SuspendLayout();
            SuspendLayout();

            // pnlHeader
            pnlHeader.BackColor = Color.FromArgb(15, 23, 42);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(520, 56);
            pnlHeader.TabIndex = 0;

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(16, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(330, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🛡️ ACTIVACIÓN DEL SISTEMA";

            // pnlCard
            pnlCard.BackColor = Color.White;
            pnlCard.Controls.Add(lblInstruct);
            pnlCard.Controls.Add(lblCuit);
            pnlCard.Controls.Add(txtCuit);
            pnlCard.Controls.Add(lblKey);
            pnlCard.Controls.Add(txtLicenseKey);
            pnlCard.Controls.Add(lblStatusMessage);
            pnlCard.Controls.Add(btnActivate);
            pnlCard.Controls.Add(btnExit);
            pnlCard.Location = new Point(24, 76);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(472, 330);
            pnlCard.TabIndex = 1;

            // lblInstruct
            lblInstruct.Font = new Font("Segoe UI", 9F);
            lblInstruct.ForeColor = Color.FromArgb(100, 116, 139);
            lblInstruct.Location = new Point(24, 16);
            lblInstruct.Name = "lblInstruct";
            lblInstruct.Size = new Size(424, 34);
            lblInstruct.TabIndex = 0;
            lblInstruct.Text = "Ingrese el CUIT del comercio y su License Key de 16 caracteres para autorizar esta terminal.";

            // lblCuit
            lblCuit.AutoSize = true;
            lblCuit.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCuit.Location = new Point(24, 60);
            lblCuit.Name = "lblCuit";
            lblCuit.Size = new Size(157, 21);
            lblCuit.TabIndex = 1;
            lblCuit.Text = "CUIT del Comercio:";

            // txtCuit
            txtCuit.BorderStyle = BorderStyle.FixedSingle;
            txtCuit.Font = new Font("Segoe UI", 11F);
            txtCuit.Location = new Point(24, 82);
            txtCuit.Name = "txtCuit";
            txtCuit.PlaceholderText = "30-XXXXXXXX-X";
            txtCuit.Size = new Size(424, 32);
            txtCuit.TabIndex = 2;

            // lblKey
            lblKey.AutoSize = true;
            lblKey.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblKey.Location = new Point(24, 125);
            lblKey.Name = "lblKey";
            lblKey.Size = new Size(103, 21);
            lblKey.TabIndex = 3;
            lblKey.Text = "License Key:";

            // txtLicenseKey
            txtLicenseKey.BorderStyle = BorderStyle.FixedSingle;
            txtLicenseKey.Font = new Font("Segoe UI", 11F);
            txtLicenseKey.Location = new Point(24, 147);
            txtLicenseKey.Name = "txtLicenseKey";
            txtLicenseKey.PlaceholderText = "XXXX-XXXX-XXXX-XXXX";
            txtLicenseKey.Size = new Size(424, 32);
            txtLicenseKey.TabIndex = 4;

            // lblStatusMessage
            lblStatusMessage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatusMessage.ForeColor = Color.FromArgb(239, 68, 68);
            lblStatusMessage.Location = new Point(24, 185);
            lblStatusMessage.Name = "lblStatusMessage";
            lblStatusMessage.Size = new Size(424, 38);
            lblStatusMessage.TabIndex = 5;
            lblStatusMessage.Visible = false;

            // btnActivate
            btnActivate.BackColor = Color.FromArgb(16, 185, 129);
            btnActivate.FlatAppearance.BorderSize = 0;
            btnActivate.FlatStyle = FlatStyle.Flat;
            btnActivate.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnActivate.ForeColor = Color.White;
            btnActivate.Location = new Point(24, 230);
            btnActivate.Name = "btnActivate";
            btnActivate.Size = new Size(424, 44);
            btnActivate.TabIndex = 6;
            btnActivate.Text = "✓ ACTIVAR SISTEMA";
            btnActivate.UseVisualStyleBackColor = false;

            // btnExit
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExit.Location = new Point(24, 282);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(424, 32);
            btnExit.TabIndex = 7;
            btnExit.Text = "SALIR";
            btnExit.UseVisualStyleBackColor = true;

            // FormActivation
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(520, 430);
            Controls.Add(pnlCard);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormActivation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Activación de Licencia";
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
        private System.Windows.Forms.Label lblInstruct;
        private System.Windows.Forms.Label lblCuit;
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.TextBox txtLicenseKey;
        private System.Windows.Forms.Label lblStatusMessage;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.Button btnExit;
    }
}