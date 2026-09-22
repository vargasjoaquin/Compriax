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
            picIconCancelPayment = new PictureBox();
            panelHeader = new Panel();
            labelTitle = new Label();
            panelPaymentCard = new Panel();
            labelAmountTitle = new Label();
            labelAmountToPay = new Label();
            pictureBoxQrCode = new PictureBox();
            labelPaymentStatus = new Label();
            buttonCancelPayment = new Button();
            ((System.ComponentModel.ISupportInitialize)picIconCancelPayment).BeginInit();
            panelHeader.SuspendLayout();
            panelPaymentCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQrCode).BeginInit();
            SuspendLayout();
            // 
            // picIconCancelPayment
            // 
            picIconCancelPayment.BackColor = Color.FromArgb(239, 68, 68);
            picIconCancelPayment.Cursor = Cursors.Hand;
            picIconCancelPayment.Image = Resources._093_error;
            picIconCancelPayment.Location = new Point(133, 539);
            picIconCancelPayment.Name = "picIconCancelPayment";
            picIconCancelPayment.Size = new Size(37, 45);
            picIconCancelPayment.SizeMode = PictureBoxSizeMode.Zoom;
            picIconCancelPayment.TabIndex = 99;
            picIconCancelPayment.TabStop = false;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(569, 60);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(20, 16);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(362, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "COBRO CON MERCADO PAGO QR";
            // 
            // panelPaymentCard
            // 
            panelPaymentCard.BackColor = Color.White;
            panelPaymentCard.Controls.Add(labelAmountTitle);
            panelPaymentCard.Controls.Add(labelAmountToPay);
            panelPaymentCard.Controls.Add(pictureBoxQrCode);
            panelPaymentCard.Controls.Add(labelPaymentStatus);
            panelPaymentCard.Controls.Add(picIconCancelPayment);
            panelPaymentCard.Controls.Add(buttonCancelPayment);
            panelPaymentCard.Location = new Point(24, 80);
            panelPaymentCard.Name = "panelPaymentCard";
            panelPaymentCard.Size = new Size(517, 608);
            panelPaymentCard.TabIndex = 1;
            // 
            // labelAmountTitle
            // 
            labelAmountTitle.AutoSize = true;
            labelAmountTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelAmountTitle.ForeColor = Color.FromArgb(100, 116, 139);
            labelAmountTitle.Location = new Point(193, 17);
            labelAmountTitle.Name = "labelAmountTitle";
            labelAmountTitle.Size = new Size(157, 23);
            labelAmountTitle.TabIndex = 0;
            labelAmountTitle.Text = "TOTAL A COBRAR:";
            // 
            // labelAmountToPay
            // 
            labelAmountToPay.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            labelAmountToPay.ForeColor = Color.FromArgb(2, 132, 199);
            labelAmountToPay.Location = new Point(73, 43);
            labelAmountToPay.Name = "labelAmountToPay";
            labelAmountToPay.Size = new Size(392, 50);
            labelAmountToPay.TabIndex = 1;
            labelAmountToPay.Text = "$ 0,00";
            labelAmountToPay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBoxQrCode
            // 
            pictureBoxQrCode.BackColor = Color.White;
            pictureBoxQrCode.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxQrCode.Location = new Point(73, 105);
            pictureBoxQrCode.Name = "pictureBoxQrCode";
            pictureBoxQrCode.Size = new Size(392, 375);
            pictureBoxQrCode.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxQrCode.TabIndex = 2;
            pictureBoxQrCode.TabStop = false;
            // 
            // labelPaymentStatus
            // 
            labelPaymentStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelPaymentStatus.ForeColor = Color.FromArgb(16, 185, 129);
            labelPaymentStatus.Location = new Point(73, 492);
            labelPaymentStatus.Name = "labelPaymentStatus";
            labelPaymentStatus.Size = new Size(392, 35);
            labelPaymentStatus.TabIndex = 3;
            labelPaymentStatus.Text = "Esperando pago...";
            labelPaymentStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonCancelPayment
            // 
            buttonCancelPayment.BackColor = Color.FromArgb(239, 68, 68);
            buttonCancelPayment.FlatAppearance.BorderSize = 0;
            buttonCancelPayment.FlatStyle = FlatStyle.Flat;
            buttonCancelPayment.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonCancelPayment.ForeColor = Color.White;
            buttonCancelPayment.Location = new Point(90, 539);
            buttonCancelPayment.Name = "buttonCancelPayment";
            buttonCancelPayment.Size = new Size(352, 45);
            buttonCancelPayment.TabIndex = 4;
            buttonCancelPayment.Text = "CANCELAR OPERACIÓN";
            buttonCancelPayment.UseVisualStyleBackColor = false;
            // 
            // FormMercadoPagoQrPayment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(569, 711);
            Controls.Add(panelPaymentCard);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormMercadoPagoQrPayment";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cobro con Mercado Pago QR";
            ((System.ComponentModel.ISupportInitialize)picIconCancelPayment).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelPaymentCard.ResumeLayout(false);
            panelPaymentCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQrCode).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelPaymentCard;
        private System.Windows.Forms.Label labelAmountTitle;
        private System.Windows.Forms.Label labelAmountToPay;
        private System.Windows.Forms.PictureBox pictureBoxQrCode;
        private System.Windows.Forms.Label labelPaymentStatus;
        private System.Windows.Forms.Button buttonCancelPayment;
        private System.Windows.Forms.PictureBox picIconCancelPayment;
    }
}
