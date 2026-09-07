namespace CompriaxSystem.WinFormsUI
{
    partial class FormSettings
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
            lblHeaderTitle = new Label();
            groupBoxStore = new Panel();
            lblName = new Label();
            txtName = new TextBox();
            lblTaxId = new Label();
            txtTaxId = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblLogo = new Label();
            picLogo = new PictureBox();
            btnBrowse = new Button();
            btnSave = new Button();
            pnlHeader.SuspendLayout();
            groupBoxStore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(15, 23, 42);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1000, 56);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(16, 16);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(503, 30);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "AJUSTES DEL COMERCIO Y DATOS FISCALES";
            // 
            // groupBoxStore
            // 
            groupBoxStore.BackColor = Color.White;
            groupBoxStore.Controls.Add(lblName);
            groupBoxStore.Controls.Add(txtName);
            groupBoxStore.Controls.Add(lblTaxId);
            groupBoxStore.Controls.Add(txtTaxId);
            groupBoxStore.Controls.Add(lblAddress);
            groupBoxStore.Controls.Add(txtAddress);
            groupBoxStore.Controls.Add(lblPhone);
            groupBoxStore.Controls.Add(txtPhone);
            groupBoxStore.Controls.Add(lblEmail);
            groupBoxStore.Controls.Add(txtEmail);
            groupBoxStore.Controls.Add(lblLogo);
            groupBoxStore.Controls.Add(picLogo);
            groupBoxStore.Controls.Add(btnBrowse);
            groupBoxStore.Controls.Add(btnSave);
            groupBoxStore.Location = new Point(24, 76);
            groupBoxStore.Name = "groupBoxStore";
            groupBoxStore.Size = new Size(950, 460);
            groupBoxStore.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblName.Location = new Point(24, 20);
            lblName.Name = "lblName";
            lblName.Size = new Size(270, 21);
            lblName.TabIndex = 0;
            lblName.Text = "Razón Social / Nombre Comercial:";
            // 
            // txtName
            // 
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 10.5F);
            txtName.Location = new Point(24, 42);
            txtName.Name = "txtName";
            txtName.Size = new Size(440, 31);
            txtName.TabIndex = 1;
            // 
            // lblTaxId
            // 
            lblTaxId.AutoSize = true;
            lblTaxId.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTaxId.Location = new Point(24, 85);
            lblTaxId.Name = "lblTaxId";
            lblTaxId.Size = new Size(104, 21);
            lblTaxId.TabIndex = 2;
            lblTaxId.Text = "CUIT Oficial:";
            // 
            // txtTaxId
            // 
            txtTaxId.BorderStyle = BorderStyle.FixedSingle;
            txtTaxId.Font = new Font("Segoe UI", 10.5F);
            txtTaxId.Location = new Point(24, 107);
            txtTaxId.Name = "txtTaxId";
            txtTaxId.Size = new Size(440, 31);
            txtTaxId.TabIndex = 3;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAddress.Location = new Point(24, 150);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(168, 21);
            lblAddress.TabIndex = 4;
            lblAddress.Text = "Dirección Comercial:";
            // 
            // txtAddress
            // 
            txtAddress.BorderStyle = BorderStyle.FixedSingle;
            txtAddress.Font = new Font("Segoe UI", 10.5F);
            txtAddress.Location = new Point(24, 172);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(440, 31);
            txtAddress.TabIndex = 5;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPhone.Location = new Point(24, 215);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(177, 21);
            lblPhone.TabIndex = 6;
            lblPhone.Text = "Teléfono de Contacto:";
            // 
            // txtPhone
            // 
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Segoe UI", 10.5F);
            txtPhone.Location = new Point(24, 237);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(440, 31);
            txtPhone.TabIndex = 7;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEmail.Location = new Point(24, 280);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(271, 21);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Correo Electrónico de Facturación:";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10.5F);
            txtEmail.Location = new Point(24, 302);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(440, 31);
            txtEmail.TabIndex = 9;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblLogo.Location = new Point(540, 20);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(157, 21);
            lblLogo.TabIndex = 10;
            lblLogo.Text = "Logo del Comercio:";
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.FromArgb(248, 250, 252);
            picLogo.BorderStyle = BorderStyle.FixedSingle;
            picLogo.Location = new Point(540, 45);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(360, 251);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 11;
            picLogo.TabStop = false;
            // 
            // btnBrowse
            // 
            btnBrowse.FlatStyle = FlatStyle.Flat;
            btnBrowse.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBrowse.Location = new Point(540, 302);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(360, 36);
            btnBrowse.TabIndex = 12;
            btnBrowse.Text = "EXAMINAR LOGO...";
            btnBrowse.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(2, 132, 199);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(24, 380);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(876, 52);
            btnSave.TabIndex = 13;
            btnSave.Text = "GUARDAR CONFIGURACIÓN";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // FormSettings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1000, 560);
            Controls.Add(groupBoxStore);
            Controls.Add(pnlHeader);
            Name = "FormSettings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Perfil de la Empresa";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            groupBoxStore.ResumeLayout(false);
            groupBoxStore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel groupBoxStore;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblTaxId;
        private System.Windows.Forms.TextBox txtTaxId;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnSave;
    }
}