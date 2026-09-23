namespace CompriaxSystem.WinFormsUI.Helpers
{
    partial class FormLicenseWarningDialog
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
            labelHeader = new Label();
            labelWarningTitle = new Label();
            labelDetails = new Label();
            buttonRenew = new Button();
            buttonContinue = new Button();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(217, 119, 6);
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(648, 60);
            panelHeader.TabIndex = 0;
            // 
            // labelHeader
            // 
            labelHeader.AutoSize = true;
            labelHeader.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelHeader.ForeColor = Color.White;
            labelHeader.Location = new Point(16, 16);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new Size(369, 28);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "AVISO DE VENCIMIENTO DE LICENCIA";
            // 
            // labelWarningTitle
            // 
            labelWarningTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelWarningTitle.ForeColor = Color.FromArgb(180, 83, 9);
            labelWarningTitle.Location = new Point(24, 80);
            labelWarningTitle.Name = "labelWarningTitle";
            labelWarningTitle.Size = new Size(470, 28);
            labelWarningTitle.TabIndex = 1;
            labelWarningTitle.Text = "¡ATENCIÓN! Su licencia está próxima a vencer.";
            // 
            // labelDetails
            // 
            labelDetails.Font = new Font("Segoe UI", 9.5F);
            labelDetails.ForeColor = Color.FromArgb(51, 65, 85);
            labelDetails.Location = new Point(24, 115);
            labelDetails.Name = "labelDetails";
            labelDetails.Size = new Size(470, 110);
            labelDetails.TabIndex = 2;
            labelDetails.Text = "Detalles de la licencia...";
            // 
            // buttonRenew
            // 
            buttonRenew.Cursor = Cursors.Hand;
            buttonRenew.FlatStyle = FlatStyle.Flat;
            buttonRenew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonRenew.Location = new Point(70, 309);
            buttonRenew.Name = "buttonRenew";
            buttonRenew.Size = new Size(200, 42);
            buttonRenew.TabIndex = 3;
            buttonRenew.Text = "RENOVAR CLAVE";
            buttonRenew.UseVisualStyleBackColor = true;
            // 
            // buttonContinue
            // 
            buttonContinue.BackColor = Color.FromArgb(2, 132, 199);
            buttonContinue.Cursor = Cursors.Hand;
            buttonContinue.FlatAppearance.BorderSize = 0;
            buttonContinue.FlatStyle = FlatStyle.Flat;
            buttonContinue.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonContinue.ForeColor = Color.White;
            buttonContinue.Location = new Point(334, 309);
            buttonContinue.Name = "buttonContinue";
            buttonContinue.Size = new Size(249, 42);
            buttonContinue.TabIndex = 4;
            buttonContinue.Text = "CONTINUAR AL SISTEMA";
            buttonContinue.UseVisualStyleBackColor = false;
            // 
            // FormLicenseWarningDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(648, 375);
            Controls.Add(buttonContinue);
            Controls.Add(buttonRenew);
            Controls.Add(labelDetails);
            Controls.Add(labelWarningTitle);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLicenseWarningDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Aviso de Vencimiento de Licencia";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Label labelWarningTitle;
        private System.Windows.Forms.Label labelDetails;
        private System.Windows.Forms.Button buttonRenew;
        private System.Windows.Forms.Button buttonContinue;
    }
}
