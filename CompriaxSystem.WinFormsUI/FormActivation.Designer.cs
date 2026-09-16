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
            panelHeader = new Panel();
            pictureBoxHeaderIcon = new PictureBox();
            labelTitle = new Label();
            panelCard = new Panel();
            labelInstructions = new Label();
            labelTaxId = new Label();
            textBoxTaxId = new TextBox();
            labelLicenseKey = new Label();
            textBoxLicenseKeyPart1 = new TextBox();
            labelSeparator1 = new Label();
            textBoxLicenseKeyPart2 = new TextBox();
            labelSeparator2 = new Label();
            textBoxLicenseKeyPart3 = new TextBox();
            labelSeparator3 = new Label();
            textBoxLicenseKeyPart4 = new TextBox();
            labelStatusMessage = new Label();
            buttonActivate = new Button();
            buttonExit = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHeaderIcon).BeginInit();
            panelCard.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(pictureBoxHeaderIcon);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(520, 56);
            panelHeader.TabIndex = 0;
            // 
            // pictureBoxHeaderIcon
            // 
            pictureBoxHeaderIcon.BackColor = Color.Transparent;
            pictureBoxHeaderIcon.Image = Resources._097_activacion_supervisor;
            pictureBoxHeaderIcon.Location = new Point(16, 14);
            pictureBoxHeaderIcon.Name = "pictureBoxHeaderIcon";
            pictureBoxHeaderIcon.Size = new Size(28, 28);
            pictureBoxHeaderIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxHeaderIcon.TabIndex = 1;
            pictureBoxHeaderIcon.TabStop = false;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(50, 16);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(289, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "ACTIVACIÓN DEL SISTEMA";
            // 
            // panelCard
            // 
            panelCard.BackColor = Color.White;
            panelCard.Controls.Add(labelInstructions);
            panelCard.Controls.Add(labelTaxId);
            panelCard.Controls.Add(textBoxTaxId);
            panelCard.Controls.Add(labelLicenseKey);
            panelCard.Controls.Add(textBoxLicenseKeyPart1);
            panelCard.Controls.Add(labelSeparator1);
            panelCard.Controls.Add(textBoxLicenseKeyPart2);
            panelCard.Controls.Add(labelSeparator2);
            panelCard.Controls.Add(textBoxLicenseKeyPart3);
            panelCard.Controls.Add(labelSeparator3);
            panelCard.Controls.Add(textBoxLicenseKeyPart4);
            panelCard.Controls.Add(labelStatusMessage);
            panelCard.Controls.Add(buttonActivate);
            panelCard.Controls.Add(buttonExit);
            panelCard.Location = new Point(24, 76);
            panelCard.Name = "panelCard";
            panelCard.Size = new Size(472, 330);
            panelCard.TabIndex = 1;
            // 
            // labelInstructions
            // 
            labelInstructions.Font = new Font("Segoe UI", 9F);
            labelInstructions.ForeColor = Color.FromArgb(100, 116, 139);
            labelInstructions.Location = new Point(24, 16);
            labelInstructions.Name = "labelInstructions";
            labelInstructions.Size = new Size(424, 34);
            labelInstructions.TabIndex = 0;
            labelInstructions.Text = "Ingrese los datos de su comercio para autorizar la instalación en este equipo:";
            // 
            // labelTaxId
            // 
            labelTaxId.AutoSize = true;
            labelTaxId.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelTaxId.Location = new Point(24, 56);
            labelTaxId.Name = "labelTaxId";
            labelTaxId.Size = new Size(155, 21);
            labelTaxId.TabIndex = 1;
            labelTaxId.Text = "CUIT del Comercio:";
            // 
            // textBoxTaxId
            // 
            textBoxTaxId.BorderStyle = BorderStyle.FixedSingle;
            textBoxTaxId.Font = new Font("Consolas", 11F);
            textBoxTaxId.Location = new Point(24, 78);
            textBoxTaxId.MaxLength = 13;
            textBoxTaxId.Name = "textBoxTaxId";
            textBoxTaxId.PlaceholderText = "30-XXXXXXXX-X";
            textBoxTaxId.Size = new Size(424, 29);
            textBoxTaxId.TabIndex = 2;
            // 
            // labelLicenseKey
            // 
            labelLicenseKey.AutoSize = true;
            labelLicenseKey.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelLicenseKey.Location = new Point(24, 118);
            labelLicenseKey.Name = "labelLicenseKey";
            labelLicenseKey.Size = new Size(245, 21);
            labelLicenseKey.TabIndex = 3;
            labelLicenseKey.Text = "License Key / Número de Serie:";
            // 
            // textBoxLicenseKeyPart1
            // 
            textBoxLicenseKeyPart1.BorderStyle = BorderStyle.FixedSingle;
            textBoxLicenseKeyPart1.Font = new Font("Consolas", 12F, FontStyle.Bold);
            textBoxLicenseKeyPart1.Location = new Point(24, 147);
            textBoxLicenseKeyPart1.MaxLength = 4;
            textBoxLicenseKeyPart1.Name = "textBoxLicenseKeyPart1";
            textBoxLicenseKeyPart1.Size = new Size(88, 31);
            textBoxLicenseKeyPart1.TabIndex = 4;
            textBoxLicenseKeyPart1.TextAlign = HorizontalAlignment.Center;
            // 
            // labelSeparator1
            // 
            labelSeparator1.AutoSize = true;
            labelSeparator1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelSeparator1.ForeColor = Color.FromArgb(100, 116, 139);
            labelSeparator1.Location = new Point(119, 144);
            labelSeparator1.Name = "labelSeparator1";
            labelSeparator1.Size = new Size(20, 28);
            labelSeparator1.TabIndex = 5;
            labelSeparator1.Text = "-";
            // 
            // textBoxLicenseKeyPart2
            // 
            textBoxLicenseKeyPart2.BorderStyle = BorderStyle.FixedSingle;
            textBoxLicenseKeyPart2.Font = new Font("Consolas", 12F, FontStyle.Bold);
            textBoxLicenseKeyPart2.Location = new Point(142, 147);
            textBoxLicenseKeyPart2.MaxLength = 4;
            textBoxLicenseKeyPart2.Name = "textBoxLicenseKeyPart2";
            textBoxLicenseKeyPart2.Size = new Size(88, 31);
            textBoxLicenseKeyPart2.TabIndex = 6;
            textBoxLicenseKeyPart2.TextAlign = HorizontalAlignment.Center;
            // 
            // labelSeparator2
            // 
            labelSeparator2.AutoSize = true;
            labelSeparator2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelSeparator2.ForeColor = Color.FromArgb(100, 116, 139);
            labelSeparator2.Location = new Point(236, 144);
            labelSeparator2.Name = "labelSeparator2";
            labelSeparator2.Size = new Size(20, 28);
            labelSeparator2.TabIndex = 7;
            labelSeparator2.Text = "-";
            // 
            // textBoxLicenseKeyPart3
            // 
            textBoxLicenseKeyPart3.BorderStyle = BorderStyle.FixedSingle;
            textBoxLicenseKeyPart3.Font = new Font("Consolas", 12F, FontStyle.Bold);
            textBoxLicenseKeyPart3.Location = new Point(259, 147);
            textBoxLicenseKeyPart3.MaxLength = 4;
            textBoxLicenseKeyPart3.Name = "textBoxLicenseKeyPart3";
            textBoxLicenseKeyPart3.Size = new Size(88, 31);
            textBoxLicenseKeyPart3.TabIndex = 8;
            textBoxLicenseKeyPart3.TextAlign = HorizontalAlignment.Center;
            // 
            // labelSeparator3
            // 
            labelSeparator3.AutoSize = true;
            labelSeparator3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelSeparator3.ForeColor = Color.FromArgb(100, 116, 139);
            labelSeparator3.Location = new Point(353, 144);
            labelSeparator3.Name = "labelSeparator3";
            labelSeparator3.Size = new Size(20, 28);
            labelSeparator3.TabIndex = 9;
            labelSeparator3.Text = "-";
            // 
            // textBoxLicenseKeyPart4
            // 
            textBoxLicenseKeyPart4.BorderStyle = BorderStyle.FixedSingle;
            textBoxLicenseKeyPart4.Font = new Font("Consolas", 12F, FontStyle.Bold);
            textBoxLicenseKeyPart4.Location = new Point(375, 147);
            textBoxLicenseKeyPart4.MaxLength = 4;
            textBoxLicenseKeyPart4.Name = "textBoxLicenseKeyPart4";
            textBoxLicenseKeyPart4.Size = new Size(82, 31);
            textBoxLicenseKeyPart4.TabIndex = 10;
            textBoxLicenseKeyPart4.TextAlign = HorizontalAlignment.Center;
            // 
            // labelStatusMessage
            // 
            labelStatusMessage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelStatusMessage.ForeColor = Color.FromArgb(239, 68, 68);
            labelStatusMessage.Location = new Point(24, 182);
            labelStatusMessage.Name = "labelStatusMessage";
            labelStatusMessage.Size = new Size(424, 38);
            labelStatusMessage.TabIndex = 11;
            labelStatusMessage.Visible = false;
            // 
            // buttonActivate
            // 
            buttonActivate.BackColor = Color.FromArgb(16, 185, 129);
            buttonActivate.FlatAppearance.BorderSize = 0;
            buttonActivate.FlatStyle = FlatStyle.Flat;
            buttonActivate.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            buttonActivate.ForeColor = Color.White;
            buttonActivate.Location = new Point(24, 230);
            buttonActivate.Name = "buttonActivate";
            buttonActivate.Padding = new Padding(25, 0, 0, 0);
            buttonActivate.Size = new Size(424, 44);
            buttonActivate.TabIndex = 6;
            buttonActivate.Text = "ACTIVAR SISTEMA";
            buttonActivate.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonActivate.UseVisualStyleBackColor = false;
            // 
            // buttonExit
            // 
            buttonExit.FlatStyle = FlatStyle.Flat;
            buttonExit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonExit.Location = new Point(24, 282);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(424, 32);
            buttonExit.TabIndex = 13;
            buttonExit.Text = "SALIR";
            buttonExit.UseVisualStyleBackColor = true;
            // 
            // FormActivation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(520, 430);
            Controls.Add(panelCard);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormActivation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Activación de Licencia";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHeaderIcon).EndInit();
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxHeaderIcon;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Label labelInstructions;
        private System.Windows.Forms.Label labelTaxId;
        private System.Windows.Forms.TextBox textBoxTaxId;
        private System.Windows.Forms.Label labelLicenseKey;
        private System.Windows.Forms.TextBox textBoxLicenseKeyPart1;
        private System.Windows.Forms.Label labelSeparator1;
        private System.Windows.Forms.TextBox textBoxLicenseKeyPart2;
        private System.Windows.Forms.Label labelSeparator2;
        private System.Windows.Forms.TextBox textBoxLicenseKeyPart3;
        private System.Windows.Forms.Label labelSeparator3;
        private System.Windows.Forms.TextBox textBoxLicenseKeyPart4;
        private System.Windows.Forms.Label labelStatusMessage;
        private System.Windows.Forms.Button buttonActivate;
        private System.Windows.Forms.Button buttonExit;
    }
}