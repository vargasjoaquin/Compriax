namespace CompriaxSystem.WinFormsUI
{
    partial class FormMercadoPagoQrPayment
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
            lblAmountTitle = new Label();
            lblAmount = new Label();
            picQr = new PictureBox();
            lblStatus = new Label();
            btnCancel = new Button();
            pnlHeader.SuspendLayout();
            pnlCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picQr).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(15, 23, 42);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(569, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(362, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "COBRO CON MERCADO PAGO QR";
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.Controls.Add(lblAmountTitle);
            pnlCard.Controls.Add(lblAmount);
            pnlCard.Controls.Add(picQr);
            pnlCard.Controls.Add(lblStatus);
            pnlCard.Controls.Add(btnCancel);
            pnlCard.Location = new Point(24, 80);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(517, 608);
            pnlCard.TabIndex = 1;
            // 
            // lblAmountTitle
            // 
            lblAmountTitle.AutoSize = true;
            lblAmountTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAmountTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblAmountTitle.Location = new Point(193, 17);
            lblAmountTitle.Name = "lblAmountTitle";
            lblAmountTitle.Size = new Size(157, 23);
            lblAmountTitle.TabIndex = 0;
            lblAmountTitle.Text = "TOTAL A COBRAR:";
            // 
            // lblAmount
            // 
            lblAmount.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblAmount.ForeColor = Color.FromArgb(2, 132, 199);
            lblAmount.Location = new Point(73, 43);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(392, 50);
            lblAmount.TabIndex = 1;
            lblAmount.Text = "$ 0,00";
            lblAmount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picQr
            // 
            picQr.BackColor = Color.White;
            picQr.BorderStyle = BorderStyle.FixedSingle;
            picQr.Location = new Point(73, 105);
            picQr.Name = "picQr";
            picQr.Size = new Size(392, 375);
            picQr.SizeMode = PictureBoxSizeMode.Zoom;
            picQr.TabIndex = 2;
            picQr.TabStop = false;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(16, 185, 129);
            lblStatus.Location = new Point(73, 492);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(392, 35);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Esperando pago...";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(239, 68, 68);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(90, 539);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(352, 45);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "CANCELAR OPERACIÓN";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // FormMercadoPagoQrPayment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(569, 711);
            Controls.Add(pnlCard);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormMercadoPagoQrPayment";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cobro con Mercado Pago QR";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picQr).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblAmountTitle;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.PictureBox picQr;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnCancel;
    }
}