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
            panelKeyBoxes = new Panel();
            textBoxKey1 = new TextBox();
            labelHyphen1 = new Label();
            textBoxKey2 = new TextBox();
            labelHyphen2 = new Label();
            textBoxKey3 = new TextBox();
            labelHyphen3 = new Label();
            textBoxKey4 = new TextBox();
            labelStatus = new Label();
            buttonActivate = new Button();
            buttonExit = new Button();
            panelCard.SuspendLayout();
            panelKeyBoxes.SuspendLayout();
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
            panelCard.Controls.Add(panelKeyBoxes);
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
            labelTitle.Text = "COMPRIAX — ACTIVACIÓN / RENOVACIÓN";
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
            textBoxCuit.Font = new Font("Consolas", 11F);
            textBoxCuit.Location = new Point(30, 120);
            textBoxCuit.MaxLength = 13;
            textBoxCuit.Name = "textBoxCuit";
            textBoxCuit.PlaceholderText = "XX-XXXXXXXX-X";
            textBoxCuit.Size = new Size(440, 29);
            textBoxCuit.TabIndex = 3;
            // 
            // labelKey
            // 
            labelKey.AutoSize = true;
            labelKey.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelKey.Location = new Point(30, 160);
            labelKey.Name = "labelKey";
            labelKey.Size = new Size(145, 21);
            labelKey.TabIndex = 4;
            labelKey.Text = "Clave de Licencia:";
            // 
            // panelKeyBoxes
            // 
            panelKeyBoxes.Controls.Add(textBoxKey1);
            panelKeyBoxes.Controls.Add(labelHyphen1);
            panelKeyBoxes.Controls.Add(textBoxKey2);
            panelKeyBoxes.Controls.Add(labelHyphen2);
            panelKeyBoxes.Controls.Add(textBoxKey3);
            panelKeyBoxes.Controls.Add(labelHyphen3);
            panelKeyBoxes.Controls.Add(textBoxKey4);
            panelKeyBoxes.Location = new Point(30, 185);
            panelKeyBoxes.Name = "panelKeyBoxes";
            panelKeyBoxes.Size = new Size(440, 40);
            panelKeyBoxes.TabIndex = 5;
            // 
            // textBoxKey1
            // 
            textBoxKey1.Font = new Font("Consolas", 12F, FontStyle.Bold);
            textBoxKey1.Location = new Point(0, 4);
            textBoxKey1.MaxLength = 29;
            textBoxKey1.Name = "textBoxKey1";
            textBoxKey1.Size = new Size(95, 31);
            textBoxKey1.TabIndex = 0;
            textBoxKey1.TextAlign = HorizontalAlignment.Center;
            // 
            // labelHyphen1
            // 
            labelHyphen1.AutoSize = true;
            labelHyphen1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelHyphen1.ForeColor = Color.FromArgb(100, 116, 139);
            labelHyphen1.Location = new Point(102, 5);
            labelHyphen1.Name = "labelHyphen1";
            labelHyphen1.Size = new Size(20, 28);
            labelHyphen1.TabIndex = 1;
            labelHyphen1.Text = "-";
            // 
            // textBoxKey2
            // 
            textBoxKey2.Font = new Font("Consolas", 12F, FontStyle.Bold);
            textBoxKey2.Location = new Point(125, 4);
            textBoxKey2.MaxLength = 29;
            textBoxKey2.Name = "textBoxKey2";
            textBoxKey2.Size = new Size(95, 31);
            textBoxKey2.TabIndex = 2;
            textBoxKey2.TextAlign = HorizontalAlignment.Center;
            // 
            // labelHyphen2
            // 
            labelHyphen2.AutoSize = true;
            labelHyphen2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelHyphen2.ForeColor = Color.FromArgb(100, 116, 139);
            labelHyphen2.Location = new Point(227, 5);
            labelHyphen2.Name = "labelHyphen2";
            labelHyphen2.Size = new Size(20, 28);
            labelHyphen2.TabIndex = 3;
            labelHyphen2.Text = "-";
            // 
            // textBoxKey3
            // 
            textBoxKey3.Font = new Font("Consolas", 12F, FontStyle.Bold);
            textBoxKey3.Location = new Point(250, 4);
            textBoxKey3.MaxLength = 29;
            textBoxKey3.Name = "textBoxKey3";
            textBoxKey3.Size = new Size(95, 31);
            textBoxKey3.TabIndex = 4;
            textBoxKey3.TextAlign = HorizontalAlignment.Center;
            // 
            // labelHyphen3
            // 
            labelHyphen3.AutoSize = true;
            labelHyphen3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelHyphen3.ForeColor = Color.FromArgb(100, 116, 139);
            labelHyphen3.Location = new Point(352, 5);
            labelHyphen3.Name = "labelHyphen3";
            labelHyphen3.Size = new Size(20, 28);
            labelHyphen3.TabIndex = 5;
            labelHyphen3.Text = "-";
            // 
            // textBoxKey4
            // 
            textBoxKey4.Font = new Font("Consolas", 12F, FontStyle.Bold);
            textBoxKey4.Location = new Point(375, 4);
            textBoxKey4.MaxLength = 29;
            textBoxKey4.Name = "textBoxKey4";
            textBoxKey4.Size = new Size(65, 31);
            textBoxKey4.TabIndex = 6;
            textBoxKey4.TextAlign = HorizontalAlignment.Center;
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
            panelKeyBoxes.ResumeLayout(false);
            panelKeyBoxes.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelReason;
        private System.Windows.Forms.Label labelCuit;
        private System.Windows.Forms.TextBox textBoxCuit;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.Panel panelKeyBoxes;
        private System.Windows.Forms.TextBox textBoxKey1;
        private System.Windows.Forms.Label labelHyphen1;
        private System.Windows.Forms.TextBox textBoxKey2;
        private System.Windows.Forms.Label labelHyphen2;
        private System.Windows.Forms.TextBox textBoxKey3;
        private System.Windows.Forms.Label labelHyphen3;
        private System.Windows.Forms.TextBox textBoxKey4;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonActivate;
        private System.Windows.Forms.Button buttonExit;
    }
}