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
            picIconSaveSettings = new PictureBox();
            panelHeader = new Panel();
            labelHeaderTitle = new Label();
            panelStoreProfileForm = new Panel();
            labelCompanyName = new Label();
            textBoxCompanyName = new TextBox();
            labelTaxId = new Label();
            textBoxTaxId = new TextBox();
            labelAddress = new Label();
            textBoxAddress = new TextBox();
            labelPhone = new Label();
            textBoxPhone = new TextBox();
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            pictureBoxStoreLogo = new PictureBox();
            buttonSaveSettings = new Button();
            ((System.ComponentModel.ISupportInitialize)picIconSaveSettings).BeginInit();
            panelHeader.SuspendLayout();
            panelStoreProfileForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxStoreLogo).BeginInit();
            SuspendLayout();
            // 
            // picIconSaveSettings
            // 
            picIconSaveSettings.BackColor = Color.FromArgb(2, 132, 199);
            picIconSaveSettings.Cursor = Cursors.Hand;
            picIconSaveSettings.Image = Resources._077_guardar;
            picIconSaveSettings.Location = new Point(281, 380);
            picIconSaveSettings.Name = "picIconSaveSettings";
            picIconSaveSettings.Size = new Size(54, 52);
            picIconSaveSettings.SizeMode = PictureBoxSizeMode.Zoom;
            picIconSaveSettings.TabIndex = 99;
            picIconSaveSettings.TabStop = false;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelHeaderTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1000, 56);
            panelHeader.TabIndex = 0;
            // 
            // labelHeaderTitle
            // 
            labelHeaderTitle.AutoSize = true;
            labelHeaderTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelHeaderTitle.ForeColor = Color.White;
            labelHeaderTitle.Location = new Point(16, 16);
            labelHeaderTitle.Name = "labelHeaderTitle";
            labelHeaderTitle.Size = new Size(466, 30);
            labelHeaderTitle.TabIndex = 0;
            labelHeaderTitle.Text = "AJUSTES DEL COMERCIO Y DATOS FISCALES";
            // 
            // panelStoreProfileForm
            // 
            panelStoreProfileForm.BackColor = Color.White;
            panelStoreProfileForm.Controls.Add(labelCompanyName);
            panelStoreProfileForm.Controls.Add(textBoxCompanyName);
            panelStoreProfileForm.Controls.Add(labelTaxId);
            panelStoreProfileForm.Controls.Add(textBoxTaxId);
            panelStoreProfileForm.Controls.Add(labelAddress);
            panelStoreProfileForm.Controls.Add(textBoxAddress);
            panelStoreProfileForm.Controls.Add(labelPhone);
            panelStoreProfileForm.Controls.Add(textBoxPhone);
            panelStoreProfileForm.Controls.Add(labelEmail);
            panelStoreProfileForm.Controls.Add(textBoxEmail);
            panelStoreProfileForm.Controls.Add(pictureBoxStoreLogo);
            panelStoreProfileForm.Controls.Add(picIconSaveSettings);
            panelStoreProfileForm.Controls.Add(buttonSaveSettings);
            panelStoreProfileForm.Location = new Point(24, 76);
            panelStoreProfileForm.Name = "panelStoreProfileForm";
            panelStoreProfileForm.Size = new Size(950, 460);
            panelStoreProfileForm.TabIndex = 1;
            // 
            // labelCompanyName
            // 
            labelCompanyName.AutoSize = true;
            labelCompanyName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelCompanyName.Location = new Point(24, 20);
            labelCompanyName.Name = "labelCompanyName";
            labelCompanyName.Size = new Size(158, 21);
            labelCompanyName.TabIndex = 0;
            labelCompanyName.Text = "Nombre Comercial:";
            // 
            // textBoxCompanyName
            // 
            textBoxCompanyName.BorderStyle = BorderStyle.FixedSingle;
            textBoxCompanyName.Font = new Font("Segoe UI", 10.5F);
            textBoxCompanyName.Location = new Point(24, 42);
            textBoxCompanyName.Name = "textBoxCompanyName";
            textBoxCompanyName.Size = new Size(440, 31);
            textBoxCompanyName.TabIndex = 1;
            // 
            // labelTaxId
            // 
            labelTaxId.AutoSize = true;
            labelTaxId.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelTaxId.Location = new Point(24, 85);
            labelTaxId.Name = "labelTaxId";
            labelTaxId.Size = new Size(104, 21);
            labelTaxId.TabIndex = 2;
            labelTaxId.Text = "CUIT Oficial:";
            // 
            // textBoxTaxId
            // 
            textBoxTaxId.BorderStyle = BorderStyle.FixedSingle;
            textBoxTaxId.Font = new Font("Segoe UI", 10.5F);
            textBoxTaxId.Location = new Point(24, 107);
            textBoxTaxId.Name = "textBoxTaxId";
            textBoxTaxId.Size = new Size(440, 31);
            textBoxTaxId.TabIndex = 3;
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelAddress.Location = new Point(24, 150);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(168, 21);
            labelAddress.TabIndex = 4;
            labelAddress.Text = "Dirección Comercial:";
            // 
            // textBoxAddress
            // 
            textBoxAddress.BorderStyle = BorderStyle.FixedSingle;
            textBoxAddress.Font = new Font("Segoe UI", 10.5F);
            textBoxAddress.Location = new Point(24, 172);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(440, 31);
            textBoxAddress.TabIndex = 5;
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelPhone.Location = new Point(24, 215);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(177, 21);
            labelPhone.TabIndex = 6;
            labelPhone.Text = "Teléfono de Contacto:";
            // 
            // textBoxPhone
            // 
            textBoxPhone.BorderStyle = BorderStyle.FixedSingle;
            textBoxPhone.Font = new Font("Segoe UI", 10.5F);
            textBoxPhone.Location = new Point(24, 237);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(440, 31);
            textBoxPhone.TabIndex = 7;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelEmail.Location = new Point(24, 280);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(155, 21);
            labelEmail.TabIndex = 8;
            labelEmail.Text = "Correo Electrónico:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxEmail.Font = new Font("Segoe UI", 10.5F);
            textBoxEmail.Location = new Point(24, 302);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(440, 31);
            textBoxEmail.TabIndex = 9;
            // 
            // pictureBoxStoreLogo
            // 
            pictureBoxStoreLogo.BackColor = Color.FromArgb(248, 250, 252);
            pictureBoxStoreLogo.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxStoreLogo.Location = new Point(540, 45);
            pictureBoxStoreLogo.Name = "pictureBoxStoreLogo";
            pictureBoxStoreLogo.Size = new Size(360, 251);
            pictureBoxStoreLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxStoreLogo.TabIndex = 11;
            pictureBoxStoreLogo.TabStop = false;
            // 
            // buttonSaveSettings
            // 
            buttonSaveSettings.BackColor = Color.FromArgb(2, 132, 199);
            buttonSaveSettings.FlatAppearance.BorderSize = 0;
            buttonSaveSettings.FlatStyle = FlatStyle.Flat;
            buttonSaveSettings.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonSaveSettings.ForeColor = Color.White;
            buttonSaveSettings.Location = new Point(24, 380);
            buttonSaveSettings.Name = "buttonSaveSettings";
            buttonSaveSettings.Size = new Size(876, 52);
            buttonSaveSettings.TabIndex = 13;
            buttonSaveSettings.Text = "GUARDAR CONFIGURACIÓN";
            buttonSaveSettings.UseVisualStyleBackColor = false;
            // 
            // FormSettings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1000, 560);
            Controls.Add(panelStoreProfileForm);
            Controls.Add(panelHeader);
            Name = "FormSettings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Perfil de la Empresa";
            ((System.ComponentModel.ISupportInitialize)picIconSaveSettings).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelStoreProfileForm.ResumeLayout(false);
            panelStoreProfileForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxStoreLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeaderTitle;
        private System.Windows.Forms.Panel panelStoreProfileForm;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.TextBox textBoxCompanyName;
        private System.Windows.Forms.Label labelTaxId;
        private System.Windows.Forms.TextBox textBoxTaxId;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.PictureBox pictureBoxStoreLogo;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.PictureBox picIconSaveSettings;
    }
}
