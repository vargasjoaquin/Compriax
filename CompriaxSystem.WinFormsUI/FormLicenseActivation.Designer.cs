namespace CompriaxSystem.WinFormsUI
{
    partial class FormLicenseActivation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelCard = new Panel();
            labelTitle = new Label();
            labelReason = new Label();
            labelCuit = new Label();
            textBoxCuit = new TextBox();
            labelKey = new Label();
            textBoxLicenseKey = new TextBox();
            labelStatus = new Label();
            buttonActivate = new Button();
            buttonExit = new Button();
            panelCard.SuspendLayout();
            SuspendLayout();
            // 
            // panelCard
            // 
            panelCard.BackColor = Color.White;
            panelCard.Controls.Add(labelTitle);
            panelCard.Controls.Add(labelReason);
            panelCard.Controls.Add(labelCuit);
            panelCard.Controls.Add(textBoxCuit);
            panelCard.Controls.Add(labelKey);
            panelCard.Controls.Add(textBoxLicenseKey);
            panelCard.Controls.Add(labelStatus);
            panelCard.Controls.Add(buttonActivate);
            panelCard.Controls.Add(buttonExit);
            panelCard.Location = new Point(20, 20);
            panelCard.Name = "panelCard";
            panelCard.Size = new Size(500, 380);
            panelCard.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelTitle.ForeColor = Color.FromArgb(2, 132, 199);
            labelTitle.Location = new Point(20, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(460, 25);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "COMPRIAX POS — ACTIVACIÓN / RENOVACIÓN";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelReason
            // 
            labelReason.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelReason.ForeColor = Color.FromArgb(239, 68, 68);
            labelReason.Location = new Point(20, 48);
            labelReason.Name = "labelReason";
            labelReason.Size = new Size(460, 42);
            labelReason.TabIndex = 1;
            labelReason.Text = "Se requiere una clave de licencia activa para poder utilizar el sistema.";
            labelReason.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelCuit
            // 
            labelCuit.AutoSize = true;
            labelCuit.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelCuit.Location = new Point(30, 95);
            labelCuit.Name = "labelCuit";
            labelCuit.Size = new Size(210, 21);
            labelCuit.TabIndex = 2;
            labelCuit.Text = "CUIT del Comercio Titular:";
            // 
            // textBoxCuit
            // 
            textBoxCuit.Font = new Font("Segoe UI", 11F);
            textBoxCuit.Location = new Point(30, 120);
            textBoxCuit.MaxLength = 13;
            textBoxCuit.Name = "textBoxCuit";
            textBoxCuit.PlaceholderText = "XX-XXXXXXXX-X";
            textBoxCuit.Size = new Size(440, 32);
            textBoxCuit.TabIndex = 3;
            // 
            // labelKey
            // 
            labelKey.AutoSize = true;
            labelKey.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelKey.Location = new Point(30, 165);
            labelKey.Name = "labelKey";
            labelKey.Size = new Size(254, 21);
            labelKey.TabIndex = 4;
            labelKey.Text = "Clave de Licencia (License Key):";
            // 
            // textBoxLicenseKey
            // 
            textBoxLicenseKey.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            textBoxLicenseKey.Location = new Point(30, 190);
            textBoxLicenseKey.MaxLength = 25;
            textBoxLicenseKey.Name = "textBoxLicenseKey";
            textBoxLicenseKey.PlaceholderText = "XXXX-XXXX-XXXX-XXXX";
            textBoxLicenseKey.Size = new Size(440, 34);
            textBoxLicenseKey.TabIndex = 5;
            // 
            // labelStatus
            // 
            labelStatus.Font = new Font("Segoe UI", 8.5F);
            labelStatus.ForeColor = Color.FromArgb(100, 116, 139);
            labelStatus.Location = new Point(30, 235);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(440, 35);
            labelStatus.TabIndex = 6;
            labelStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonActivate
            // 
            buttonActivate.BackColor = Color.FromArgb(16, 185, 129);
            buttonActivate.Cursor = Cursors.Hand;
            buttonActivate.FlatAppearance.BorderSize = 0;
            buttonActivate.FlatStyle = FlatStyle.Flat;
            buttonActivate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonActivate.ForeColor = Color.White;
            buttonActivate.Location = new Point(30, 280);
            buttonActivate.Name = "buttonActivate";
            buttonActivate.Size = new Size(440, 45);
            buttonActivate.TabIndex = 7;
            buttonActivate.Text = "ACTIVAR / RENOVAR EN LÍNEA";
            buttonActivate.UseVisualStyleBackColor = false;
            // 
            // buttonExit
            // 
            buttonExit.Cursor = Cursors.Hand;
            buttonExit.FlatStyle = FlatStyle.Flat;
            buttonExit.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            buttonExit.Location = new Point(30, 332);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(440, 32);
            buttonExit.TabIndex = 8;
            buttonExit.Text = "CERRAR SISTEMA";
            buttonExit.UseVisualStyleBackColor = true;
            // 
            // FormLicenseActivation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            ClientSize = new Size(540, 420);
            Controls.Add(panelCard);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormLicenseActivation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Activación y Renovación de Licencia";
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelReason;
        private System.Windows.Forms.Label labelCuit;
        private System.Windows.Forms.TextBox textBoxCuit;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.TextBox textBoxLicenseKey;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonActivate;
        private System.Windows.Forms.Button buttonExit;
    }
}