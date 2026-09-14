namespace CompriaxSystem.WinFormsUI
{
    partial class FormSales
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
            pnlTopStatus = new Panel();
            lblPosTitle = new Label();
            lblCashierBadge = new Label();
            lblShiftBadge = new Label();
            pnlLeftWork = new Panel();
            dgvCart = new DataGridView();
            pnlBarcodeBar = new Panel();
            quickSearchBox = new CompriaxSystem.WinFormsUI.Controls.QuickSearchProductBox();
            numQuantity = new NumericUpDown();
            btnRemove = new Button();
            pnlShortcutsFooter = new Panel();
            lblShortcuts = new Label();
            pnlRightSummary = new Panel();
            pnlVoucherCard = new Panel();
            lblVoucherHeader = new Label();
            lblVoucherLetter = new Label();
            cboDocType = new ComboBox();
            lblVoucherNumber = new Label();
            lblClientNameVal = new Label();
            lblClientDocVal = new Label();
            lblClientTaxVal = new Label();
            btnSelectCustomer = new Button();
            lblSubTotal = new Label();
            lblDiscount = new Label();
            lblTotalTitle = new Label();
            lblTotalDisplay = new Label();
            btnRegister = new Button();
            picWebcam = new PictureBox();
            btnToggleCam = new Button();
            pnlTopStatus.SuspendLayout();
            pnlLeftWork.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            pnlBarcodeBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            pnlShortcutsFooter.SuspendLayout();
            pnlRightSummary.SuspendLayout();
            pnlVoucherCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picWebcam).BeginInit();
            SuspendLayout();
            // 
            // pnlTopStatus
            // 
            pnlTopStatus.BackColor = Color.FromArgb(15, 23, 42);
            pnlTopStatus.Controls.Add(lblPosTitle);
            pnlTopStatus.Controls.Add(lblCashierBadge);
            pnlTopStatus.Controls.Add(lblShiftBadge);
            pnlTopStatus.Dock = DockStyle.Top;
            pnlTopStatus.Location = new Point(0, 0);
            pnlTopStatus.Name = "pnlTopStatus";
            pnlTopStatus.Size = new Size(1409, 58);
            pnlTopStatus.TabIndex = 0;
            // 
            // lblPosTitle
            // 
            lblPosTitle.AutoSize = true;
            lblPosTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblPosTitle.ForeColor = Color.White;
            lblPosTitle.Location = new Point(16, 14);
            lblPosTitle.Name = "lblPosTitle";
            lblPosTitle.Size = new Size(310, 30);
            lblPosTitle.TabIndex = 0;
            lblPosTitle.Text = "TERMINAL DE VENTAS";
            // 
            // lblCashierBadge
            // 
            lblCashierBadge.AutoSize = true;
            lblCashierBadge.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCashierBadge.ForeColor = Color.FromArgb(226, 232, 240);
            lblCashierBadge.Location = new Point(360, 18);
            lblCashierBadge.Name = "lblCashierBadge";
            lblCashierBadge.Size = new Size(79, 21);
            lblCashierBadge.TabIndex = 1;
            lblCashierBadge.Text = "Cajero: --";
            // 
            // lblShiftBadge
            // 
            lblShiftBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblShiftBadge.AutoSize = true;
            lblShiftBadge.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblShiftBadge.ForeColor = Color.FromArgb(16, 185, 129);
            lblShiftBadge.Location = new Point(1171, 18);
            lblShiftBadge.Name = "lblShiftBadge";
            lblShiftBadge.Size = new Size(197, 21);
            lblShiftBadge.TabIndex = 2;
            lblShiftBadge.Text = "TURNO DE CAJA ACTIVO";
            // 
            // pnlLeftWork
            // 
            pnlLeftWork.BackColor = Color.FromArgb(248, 250, 252);
            pnlLeftWork.Controls.Add(dgvCart);
            pnlLeftWork.Controls.Add(pnlBarcodeBar);
            pnlLeftWork.Controls.Add(pnlShortcutsFooter);
            pnlLeftWork.Dock = DockStyle.Fill;
            pnlLeftWork.Location = new Point(0, 58);
            pnlLeftWork.Name = "pnlLeftWork";
            pnlLeftWork.Padding = new Padding(16, 12, 8, 12);
            pnlLeftWork.Size = new Size(1029, 696);
            pnlLeftWork.TabIndex = 1;
            // 
            // dgvCart
            // 
            dgvCart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCart.BackgroundColor = Color.White;
            dgvCart.BorderStyle = BorderStyle.None;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(16, 90);
            dgvCart.Name = "dgvCart";
            dgvCart.RowHeadersWidth = 51;
            dgvCart.Size = new Size(1005, 548);
            dgvCart.TabIndex = 1;
            // 
            // pnlBarcodeBar
            // 
            pnlBarcodeBar.BackColor = Color.White;
            pnlBarcodeBar.Controls.Add(quickSearchBox);
            pnlBarcodeBar.Controls.Add(numQuantity);
            pnlBarcodeBar.Controls.Add(btnRemove);
            pnlBarcodeBar.Dock = DockStyle.Top;
            pnlBarcodeBar.Location = new Point(16, 12);
            pnlBarcodeBar.Name = "pnlBarcodeBar";
            pnlBarcodeBar.Size = new Size(1005, 72);
            pnlBarcodeBar.TabIndex = 0;
            // 
            // quickSearchBox
            // 
            quickSearchBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            quickSearchBox.BackColor = Color.White;
            quickSearchBox.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            quickSearchBox.Location = new Point(8, 8);
            quickSearchBox.Name = "quickSearchBox";
            quickSearchBox.Padding = new Padding(8, 6, 8, 6);
            quickSearchBox.PlaceholderText = "Buscar por nombre, código de barras o descripción [F2]...";
            quickSearchBox.Size = new Size(735, 53);
            quickSearchBox.TabIndex = 0;
            // 
            // numQuantity
            // 
            numQuantity.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numQuantity.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            numQuantity.Location = new Point(757, 18);
            numQuantity.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(85, 34);
            numQuantity.TabIndex = 1;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnRemove
            // 
            btnRemove.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemove.BackColor = Color.FromArgb(239, 68, 68);
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRemove.ForeColor = Color.White;
            btnRemove.Location = new Point(848, 14);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(148, 47);
            btnRemove.TabIndex = 2;
            btnRemove.Text = "QUITAR [SUPR]";
            btnRemove.UseVisualStyleBackColor = false;
            // 
            // pnlShortcutsFooter
            // 
            pnlShortcutsFooter.Controls.Add(lblShortcuts);
            pnlShortcutsFooter.Dock = DockStyle.Bottom;
            pnlShortcutsFooter.Location = new Point(16, 648);
            pnlShortcutsFooter.Name = "pnlShortcutsFooter";
            pnlShortcutsFooter.Size = new Size(1005, 36);
            pnlShortcutsFooter.TabIndex = 2;
            // 
            // lblShortcuts
            // 
            lblShortcuts.Dock = DockStyle.Fill;
            lblShortcuts.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblShortcuts.ForeColor = Color.FromArgb(100, 116, 139);
            lblShortcuts.Location = new Point(0, 0);
            lblShortcuts.Name = "lblShortcuts";
            lblShortcuts.Size = new Size(1005, 36);
            lblShortcuts.TabIndex = 0;
            lblShortcuts.Text = "ATAJOS: [F2] Buscar | [F3] Cliente | [F4] Cantidad | [F6] Ver Precio | [F8] Cobrar | [SUPR] Quitar | [ESC] Cancelar";
            lblShortcuts.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlRightSummary
            // 
            pnlRightSummary.BackColor = Color.White;
            pnlRightSummary.Controls.Add(pnlVoucherCard);
            pnlRightSummary.Controls.Add(lblSubTotal);
            pnlRightSummary.Controls.Add(lblDiscount);
            pnlRightSummary.Controls.Add(lblTotalTitle);
            pnlRightSummary.Controls.Add(lblTotalDisplay);
            pnlRightSummary.Controls.Add(btnRegister);
            pnlRightSummary.Controls.Add(picWebcam);
            pnlRightSummary.Controls.Add(btnToggleCam);
            pnlRightSummary.Dock = DockStyle.Right;
            pnlRightSummary.Location = new Point(1029, 58);
            pnlRightSummary.Name = "pnlRightSummary";
            pnlRightSummary.Padding = new Padding(16);
            pnlRightSummary.Size = new Size(380, 696);
            pnlRightSummary.TabIndex = 2;
            // 
            // pnlVoucherCard
            // 
            pnlVoucherCard.BackColor = Color.FromArgb(248, 250, 252);
            pnlVoucherCard.Controls.Add(lblVoucherHeader);
            pnlVoucherCard.Controls.Add(lblVoucherLetter);
            pnlVoucherCard.Controls.Add(cboDocType);
            pnlVoucherCard.Controls.Add(lblVoucherNumber);
            pnlVoucherCard.Controls.Add(lblClientNameVal);
            pnlVoucherCard.Controls.Add(lblClientDocVal);
            pnlVoucherCard.Controls.Add(lblClientTaxVal);
            pnlVoucherCard.Controls.Add(btnSelectCustomer);
            pnlVoucherCard.Location = new Point(16, 12);
            pnlVoucherCard.Name = "pnlVoucherCard";
            pnlVoucherCard.Padding = new Padding(10);
            pnlVoucherCard.Size = new Size(348, 198);
            pnlVoucherCard.TabIndex = 0;
            // 
            // lblVoucherHeader
            // 
            lblVoucherHeader.AutoSize = true;
            lblVoucherHeader.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblVoucherHeader.ForeColor = Color.FromArgb(15, 23, 42);
            lblVoucherHeader.Location = new Point(10, 8);
            lblVoucherHeader.Name = "lblVoucherHeader";
            lblVoucherHeader.Size = new Size(219, 21);
            lblVoucherHeader.TabIndex = 0;
            lblVoucherHeader.Text = "DATOS DEL COMPROBANTE";
            // 
            // lblVoucherLetter
            // 
            lblVoucherLetter.BackColor = Color.FromArgb(15, 23, 42);
            lblVoucherLetter.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblVoucherLetter.ForeColor = Color.White;
            lblVoucherLetter.Location = new Point(10, 34);
            lblVoucherLetter.Name = "lblVoucherLetter";
            lblVoucherLetter.Size = new Size(42, 40);
            lblVoucherLetter.TabIndex = 1;
            lblVoucherLetter.Text = "B";
            lblVoucherLetter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cboDocType
            // 
            cboDocType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDocType.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            cboDocType.Location = new Point(58, 38);
            cboDocType.Name = "cboDocType";
            cboDocType.Size = new Size(280, 31);
            cboDocType.TabIndex = 2;
            // 
            // lblVoucherNumber
            // 
            lblVoucherNumber.AutoSize = true;
            lblVoucherNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblVoucherNumber.ForeColor = Color.FromArgb(2, 132, 199);
            lblVoucherNumber.Location = new Point(10, 78);
            lblVoucherNumber.Name = "lblVoucherNumber";
            lblVoucherNumber.Size = new Size(192, 20);
            lblVoucherNumber.TabIndex = 3;
            lblVoucherNumber.Text = "P.V.: 0001 - N.°: 00000001";
            // 
            // lblClientNameVal
            // 
            lblClientNameVal.AutoEllipsis = true;
            lblClientNameVal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblClientNameVal.ForeColor = Color.FromArgb(15, 23, 42);
            lblClientNameVal.Location = new Point(10, 111);
            lblClientNameVal.Name = "lblClientNameVal";
            lblClientNameVal.Size = new Size(230, 20);
            lblClientNameVal.TabIndex = 4;
            lblClientNameVal.Text = "CONSUMIDOR FINAL";
            // 
            // lblClientDocVal
            // 
            lblClientDocVal.AutoEllipsis = true;
            lblClientDocVal.Font = new Font("Segoe UI", 8.5F);
            lblClientDocVal.ForeColor = Color.FromArgb(100, 116, 139);
            lblClientDocVal.Location = new Point(10, 133);
            lblClientDocVal.Name = "lblClientDocVal";
            lblClientDocVal.Size = new Size(230, 18);
            lblClientDocVal.TabIndex = 5;
            lblClientDocVal.Text = "DOC: S/D";
            // 
            // lblClientTaxVal
            // 
            lblClientTaxVal.AutoEllipsis = true;
            lblClientTaxVal.Font = new Font("Segoe UI", 8.5F);
            lblClientTaxVal.ForeColor = Color.FromArgb(100, 116, 139);
            lblClientTaxVal.Location = new Point(10, 153);
            lblClientTaxVal.Name = "lblClientTaxVal";
            lblClientTaxVal.Size = new Size(230, 18);
            lblClientTaxVal.TabIndex = 6;
            lblClientTaxVal.Text = "IVA: Consumidor Final";
            // 
            // btnSelectCustomer
            // 
            btnSelectCustomer.FlatStyle = FlatStyle.Flat;
            btnSelectCustomer.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnSelectCustomer.Location = new Point(246, 112);
            btnSelectCustomer.Name = "btnSelectCustomer";
            btnSelectCustomer.Size = new Size(92, 60);
            btnSelectCustomer.TabIndex = 7;
            btnSelectCustomer.Text = "CLIENTE\r\n[F3]";
            btnSelectCustomer.UseVisualStyleBackColor = true;
            // 
            // lblSubTotal
            // 
            lblSubTotal.Font = new Font("Segoe UI", 10.5F);
            lblSubTotal.Location = new Point(16, 222);
            lblSubTotal.Name = "lblSubTotal";
            lblSubTotal.Size = new Size(348, 25);
            lblSubTotal.TabIndex = 1;
            lblSubTotal.Text = "Subtotal: $ 0,00";
            lblSubTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblDiscount
            // 
            lblDiscount.Font = new Font("Segoe UI", 10.5F);
            lblDiscount.ForeColor = Color.FromArgb(239, 68, 68);
            lblDiscount.Location = new Point(16, 250);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(348, 25);
            lblDiscount.TabIndex = 2;
            lblDiscount.Text = "Descuentos: -$ 0,00";
            lblDiscount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.AutoSize = true;
            lblTotalTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotalTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblTotalTitle.Location = new Point(16, 290);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(154, 25);
            lblTotalTitle.TabIndex = 3;
            lblTotalTitle.Text = "TOTAL A PAGAR";
            // 
            // lblTotalDisplay
            // 
            lblTotalDisplay.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTotalDisplay.ForeColor = Color.FromArgb(16, 185, 129);
            lblTotalDisplay.Location = new Point(16, 312);
            lblTotalDisplay.Name = "lblTotalDisplay";
            lblTotalDisplay.Size = new Size(348, 55);
            lblTotalDisplay.TabIndex = 4;
            lblTotalDisplay.Text = "$ 0,00";
            lblTotalDisplay.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(16, 185, 129);
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(16, 375);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(348, 64);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "COBRAR (F8)";
            btnRegister.UseVisualStyleBackColor = false;
            // 
            // picWebcam
            // 
            picWebcam.BackColor = Color.Black;
            picWebcam.BorderStyle = BorderStyle.FixedSingle;
            picWebcam.Location = new Point(16, 452);
            picWebcam.Name = "picWebcam";
            picWebcam.Size = new Size(348, 120);
            picWebcam.SizeMode = PictureBoxSizeMode.Zoom;
            picWebcam.TabIndex = 6;
            picWebcam.TabStop = false;
            // 
            // btnToggleCam
            // 
            btnToggleCam.FlatStyle = FlatStyle.Flat;
            btnToggleCam.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnToggleCam.Location = new Point(16, 580);
            btnToggleCam.Name = "btnToggleCam";
            btnToggleCam.Size = new Size(348, 34);
            btnToggleCam.TabIndex = 7;
            btnToggleCam.Text = "CÁMARA ESCÁNER";
            btnToggleCam.UseVisualStyleBackColor = true;
            // 
            // FormSales
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1409, 754);
            Controls.Add(pnlLeftWork);
            Controls.Add(pnlRightSummary);
            Controls.Add(pnlTopStatus);
            KeyPreview = true;
            Name = "FormSales";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Punto de Venta POS - CompriaxSystem";
            pnlTopStatus.ResumeLayout(false);
            pnlTopStatus.PerformLayout();
            pnlLeftWork.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            pnlBarcodeBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            pnlShortcutsFooter.ResumeLayout(false);
            pnlRightSummary.ResumeLayout(false);
            pnlRightSummary.PerformLayout();
            pnlVoucherCard.ResumeLayout(false);
            pnlVoucherCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picWebcam).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTopStatus;
        private System.Windows.Forms.Label lblPosTitle;
        private System.Windows.Forms.Label lblCashierBadge;
        private System.Windows.Forms.Label lblShiftBadge;
        private System.Windows.Forms.Panel pnlLeftWork;
        private System.Windows.Forms.Panel pnlBarcodeBar;
        private Controls.QuickSearchProductBox quickSearchBox;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Panel pnlShortcutsFooter;
        private System.Windows.Forms.Label lblShortcuts;
        private System.Windows.Forms.Panel pnlRightSummary;
        private System.Windows.Forms.Panel pnlVoucherCard;
        private System.Windows.Forms.Label lblVoucherHeader;
        private System.Windows.Forms.Label lblVoucherLetter;
        private System.Windows.Forms.ComboBox cboDocType;
        private System.Windows.Forms.Label lblVoucherNumber;
        private System.Windows.Forms.Label lblClientNameVal;
        private System.Windows.Forms.Label lblClientDocVal;
        private System.Windows.Forms.Label lblClientTaxVal;
        private System.Windows.Forms.Button btnSelectCustomer;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Label lblTotalDisplay;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.PictureBox picWebcam;
        private System.Windows.Forms.Button btnToggleCam;
    }
}