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
            panelTopStatusBar = new Panel();
            labelPosTitle = new Label();
            labelCashierBadge = new Label();
            labelShiftBadge = new Label();
            panelLeftWork = new Panel();
            dataGridViewCart = new DataGridView();
            panelBarcodeBar = new Panel();
            quickSearchBox = new CompriaxSystem.WinFormsUI.Controls.QuickSearchProductBox();
            numericUpDownQuantity = new NumericUpDown();
            buttonRemoveItem = new Button();
            panelShortcutsFooter = new Panel();
            labelShortcutsGuide = new Label();
            panelRightSummary = new Panel();
            panelVoucherCard = new Panel();
            labelVoucherHeader = new Label();
            labelVoucherLetter = new Label();
            comboBoxDocumentType = new ComboBox();
            labelVoucherNumber = new Label();
            labelClientNameValue = new Label();
            labelClientDocValue = new Label();
            labelClientTaxValue = new Label();
            buttonSelectCustomer = new Button();
            labelSubTotalValue = new Label();
            labelDiscountValue = new Label();
            labelTotalTitle = new Label();
            labelTotalDisplay = new Label();
            buttonRegisterSale = new Button();
            pictureBoxWebcamPreview = new PictureBox();
            buttonToggleScannerCamera = new Button();
            panelTopStatusBar.SuspendLayout();
            panelLeftWork.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCart).BeginInit();
            panelBarcodeBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).BeginInit();
            panelShortcutsFooter.SuspendLayout();
            panelRightSummary.SuspendLayout();
            panelVoucherCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxWebcamPreview).BeginInit();
            SuspendLayout();
            // 
            // panelTopStatusBar
            // 
            panelTopStatusBar.BackColor = Color.FromArgb(15, 23, 42);
            panelTopStatusBar.Controls.Add(labelPosTitle);
            panelTopStatusBar.Controls.Add(labelCashierBadge);
            panelTopStatusBar.Controls.Add(labelShiftBadge);
            panelTopStatusBar.Dock = DockStyle.Top;
            panelTopStatusBar.Location = new Point(0, 0);
            panelTopStatusBar.Name = "panelTopStatusBar";
            panelTopStatusBar.Size = new Size(1409, 58);
            panelTopStatusBar.TabIndex = 0;
            // 
            // labelPosTitle
            // 
            labelPosTitle.AutoSize = true;
            labelPosTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelPosTitle.ForeColor = Color.White;
            labelPosTitle.Location = new Point(16, 14);
            labelPosTitle.Name = "labelPosTitle";
            labelPosTitle.Size = new Size(310, 30);
            labelPosTitle.TabIndex = 0;
            labelPosTitle.Text = "TERMINAL DE VENTAS";
            // 
            // labelCashierBadge
            // 
            labelCashierBadge.AutoSize = true;
            labelCashierBadge.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelCashierBadge.ForeColor = Color.FromArgb(226, 232, 240);
            labelCashierBadge.Location = new Point(360, 18);
            labelCashierBadge.Name = "labelCashierBadge";
            labelCashierBadge.Size = new Size(79, 21);
            labelCashierBadge.TabIndex = 1;
            labelCashierBadge.Text = "Cajero: --";
            // 
            // labelShiftBadge
            // 
            labelShiftBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelShiftBadge.AutoSize = true;
            labelShiftBadge.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelShiftBadge.ForeColor = Color.FromArgb(16, 185, 129);
            labelShiftBadge.Location = new Point(1171, 18);
            labelShiftBadge.Name = "labelShiftBadge";
            labelShiftBadge.Size = new Size(197, 21);
            labelShiftBadge.TabIndex = 2;
            labelShiftBadge.Text = "TURNO DE CAJA ACTIVO";
            // 
            // panelLeftWork
            // 
            panelLeftWork.BackColor = Color.FromArgb(248, 250, 252);
            panelLeftWork.Controls.Add(dataGridViewCart);
            panelLeftWork.Controls.Add(panelBarcodeBar);
            panelLeftWork.Controls.Add(panelShortcutsFooter);
            panelLeftWork.Dock = DockStyle.Fill;
            panelLeftWork.Location = new Point(0, 58);
            panelLeftWork.Name = "panelLeftWork";
            panelLeftWork.Padding = new Padding(16, 12, 8, 12);
            panelLeftWork.Size = new Size(1029, 696);
            panelLeftWork.TabIndex = 1;
            // 
            // dataGridViewCart
            // 
            dataGridViewCart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCart.BackgroundColor = Color.White;
            dataGridViewCart.BorderStyle = BorderStyle.None;
            dataGridViewCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCart.Location = new Point(16, 90);
            dataGridViewCart.Name = "dataGridViewCart";
            dataGridViewCart.RowHeadersWidth = 51;
            dataGridViewCart.Size = new Size(1005, 548);
            dataGridViewCart.TabIndex = 1;
            // 
            // panelBarcodeBar
            // 
            panelBarcodeBar.BackColor = Color.White;
            panelBarcodeBar.Controls.Add(quickSearchBox);
            panelBarcodeBar.Controls.Add(numericUpDownQuantity);
            panelBarcodeBar.Controls.Add(buttonRemoveItem);
            panelBarcodeBar.Dock = DockStyle.Top;
            panelBarcodeBar.Location = new Point(16, 12);
            panelBarcodeBar.Name = "panelBarcodeBar";
            panelBarcodeBar.Size = new Size(1005, 72);
            panelBarcodeBar.TabIndex = 0;
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
            // numericUpDownQuantity
            // 
            numericUpDownQuantity.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDownQuantity.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            numericUpDownQuantity.Location = new Point(757, 18);
            numericUpDownQuantity.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numericUpDownQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownQuantity.Name = "numericUpDownQuantity";
            numericUpDownQuantity.Size = new Size(85, 34);
            numericUpDownQuantity.TabIndex = 1;
            numericUpDownQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // buttonRemoveItem
            // 
            buttonRemoveItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonRemoveItem.BackColor = Color.FromArgb(239, 68, 68);
            buttonRemoveItem.FlatAppearance.BorderSize = 0;
            buttonRemoveItem.FlatStyle = FlatStyle.Flat;
            buttonRemoveItem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonRemoveItem.ForeColor = Color.White;
            buttonRemoveItem.Location = new Point(848, 14);
            buttonRemoveItem.Name = "buttonRemoveItem";
            buttonRemoveItem.Size = new Size(148, 47);
            buttonRemoveItem.TabIndex = 2;
            buttonRemoveItem.Text = "QUITAR [SUPR]";
            buttonRemoveItem.UseVisualStyleBackColor = false;
            // 
            // panelShortcutsFooter
            // 
            panelShortcutsFooter.Controls.Add(labelShortcutsGuide);
            panelShortcutsFooter.Dock = DockStyle.Bottom;
            panelShortcutsFooter.Location = new Point(16, 648);
            panelShortcutsFooter.Name = "panelShortcutsFooter";
            panelShortcutsFooter.Size = new Size(1005, 36);
            panelShortcutsFooter.TabIndex = 2;
            // 
            // labelShortcutsGuide
            // 
            labelShortcutsGuide.Dock = DockStyle.Fill;
            labelShortcutsGuide.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelShortcutsGuide.ForeColor = Color.FromArgb(100, 116, 139);
            labelShortcutsGuide.Location = new Point(0, 0);
            labelShortcutsGuide.Name = "labelShortcutsGuide";
            labelShortcutsGuide.Size = new Size(1005, 36);
            labelShortcutsGuide.TabIndex = 0;
            labelShortcutsGuide.Text = "ATAJOS: [F2] Buscar | [F3] Cliente | [F4] Cantidad | [F6] Ver Precio | [F8] Cobrar | [SUPR] Quitar | [ESC] Cancelar";
            labelShortcutsGuide.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelRightSummary
            // 
            panelRightSummary.BackColor = Color.White;
            panelRightSummary.Controls.Add(panelVoucherCard);
            panelRightSummary.Controls.Add(labelSubTotalValue);
            panelRightSummary.Controls.Add(labelDiscountValue);
            panelRightSummary.Controls.Add(labelTotalTitle);
            panelRightSummary.Controls.Add(labelTotalDisplay);
            panelRightSummary.Controls.Add(buttonRegisterSale);
            panelRightSummary.Controls.Add(pictureBoxWebcamPreview);
            panelRightSummary.Controls.Add(buttonToggleScannerCamera);
            panelRightSummary.Dock = DockStyle.Right;
            panelRightSummary.Location = new Point(1029, 58);
            panelRightSummary.Name = "panelRightSummary";
            panelRightSummary.Padding = new Padding(16);
            panelRightSummary.Size = new Size(380, 696);
            panelRightSummary.TabIndex = 2;
            // 
            // panelVoucherCard
            // 
            panelVoucherCard.BackColor = Color.FromArgb(248, 250, 252);
            panelVoucherCard.Controls.Add(labelVoucherHeader);
            panelVoucherCard.Controls.Add(labelVoucherLetter);
            panelVoucherCard.Controls.Add(comboBoxDocumentType);
            panelVoucherCard.Controls.Add(labelVoucherNumber);
            panelVoucherCard.Controls.Add(labelClientNameValue);
            panelVoucherCard.Controls.Add(labelClientDocValue);
            panelVoucherCard.Controls.Add(labelClientTaxValue);
            panelVoucherCard.Controls.Add(buttonSelectCustomer);
            panelVoucherCard.Location = new Point(16, 12);
            panelVoucherCard.Name = "panelVoucherCard";
            panelVoucherCard.Padding = new Padding(10);
            panelVoucherCard.Size = new Size(348, 198);
            panelVoucherCard.TabIndex = 0;
            // 
            // labelVoucherHeader
            // 
            labelVoucherHeader.AutoSize = true;
            labelVoucherHeader.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelVoucherHeader.ForeColor = Color.FromArgb(15, 23, 42);
            labelVoucherHeader.Location = new Point(10, 8);
            labelVoucherHeader.Name = "labelVoucherHeader";
            labelVoucherHeader.Size = new Size(219, 21);
            labelVoucherHeader.TabIndex = 0;
            labelVoucherHeader.Text = "DATOS DEL COMPROBANTE";
            // 
            // labelVoucherLetter
            // 
            labelVoucherLetter.BackColor = Color.FromArgb(15, 23, 42);
            labelVoucherLetter.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelVoucherLetter.ForeColor = Color.White;
            labelVoucherLetter.Location = new Point(10, 34);
            labelVoucherLetter.Name = "labelVoucherLetter";
            labelVoucherLetter.Size = new Size(42, 40);
            labelVoucherLetter.TabIndex = 1;
            labelVoucherLetter.Text = "B";
            labelVoucherLetter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBoxDocumentType
            // 
            comboBoxDocumentType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDocumentType.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            comboBoxDocumentType.Location = new Point(58, 38);
            comboBoxDocumentType.Name = "comboBoxDocumentType";
            comboBoxDocumentType.Size = new Size(280, 31);
            comboBoxDocumentType.TabIndex = 2;
            // 
            // labelVoucherNumber
            // 
            labelVoucherNumber.AutoSize = true;
            labelVoucherNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelVoucherNumber.ForeColor = Color.FromArgb(2, 132, 199);
            labelVoucherNumber.Location = new Point(10, 78);
            labelVoucherNumber.Name = "labelVoucherNumber";
            labelVoucherNumber.Size = new Size(192, 20);
            labelVoucherNumber.TabIndex = 3;
            labelVoucherNumber.Text = "P.V.: 0001 - N.°: 00000001";
            // 
            // labelClientNameValue
            // 
            labelClientNameValue.AutoEllipsis = true;
            labelClientNameValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelClientNameValue.ForeColor = Color.FromArgb(15, 23, 42);
            labelClientNameValue.Location = new Point(10, 111);
            labelClientNameValue.Name = "labelClientNameValue";
            labelClientNameValue.Size = new Size(230, 20);
            labelClientNameValue.TabIndex = 4;
            labelClientNameValue.Text = "CONSUMIDOR FINAL";
            // 
            // labelClientDocValue
            // 
            labelClientDocValue.AutoEllipsis = true;
            labelClientDocValue.Font = new Font("Segoe UI", 8.5F);
            labelClientDocValue.ForeColor = Color.FromArgb(100, 116, 139);
            labelClientDocValue.Location = new Point(10, 133);
            labelClientDocValue.Name = "labelClientDocValue";
            labelClientDocValue.Size = new Size(230, 18);
            labelClientDocValue.TabIndex = 5;
            labelClientDocValue.Text = "DOC: S/D";
            // 
            // labelClientTaxValue
            // 
            labelClientTaxValue.AutoEllipsis = true;
            labelClientTaxValue.Font = new Font("Segoe UI", 8.5F);
            labelClientTaxValue.ForeColor = Color.FromArgb(100, 116, 139);
            labelClientTaxValue.Location = new Point(10, 153);
            labelClientTaxValue.Name = "labelClientTaxValue";
            labelClientTaxValue.Size = new Size(230, 18);
            labelClientTaxValue.TabIndex = 6;
            labelClientTaxValue.Text = "IVA: Consumidor Final";
            // 
            // buttonSelectCustomer
            // 
            buttonSelectCustomer.FlatStyle = FlatStyle.Flat;
            buttonSelectCustomer.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            buttonSelectCustomer.Location = new Point(246, 112);
            buttonSelectCustomer.Name = "buttonSelectCustomer";
            buttonSelectCustomer.Size = new Size(92, 60);
            buttonSelectCustomer.TabIndex = 7;
            buttonSelectCustomer.Text = "CLIENTE\r\n[F3]";
            buttonSelectCustomer.UseVisualStyleBackColor = true;
            // 
            // labelSubTotalValue
            // 
            labelSubTotalValue.Font = new Font("Segoe UI", 10.5F);
            labelSubTotalValue.Location = new Point(16, 222);
            labelSubTotalValue.Name = "labelSubTotalValue";
            labelSubTotalValue.Size = new Size(348, 25);
            labelSubTotalValue.TabIndex = 1;
            labelSubTotalValue.Text = "Subtotal: $ 0,00";
            labelSubTotalValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelDiscountValue
            // 
            labelDiscountValue.Font = new Font("Segoe UI", 10.5F);
            labelDiscountValue.ForeColor = Color.FromArgb(239, 68, 68);
            labelDiscountValue.Location = new Point(16, 250);
            labelDiscountValue.Name = "labelDiscountValue";
            labelDiscountValue.Size = new Size(348, 25);
            labelDiscountValue.TabIndex = 2;
            labelDiscountValue.Text = "Descuentos: -$ 0,00";
            labelDiscountValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelTotalTitle
            // 
            labelTotalTitle.AutoSize = true;
            labelTotalTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelTotalTitle.ForeColor = Color.FromArgb(100, 116, 139);
            labelTotalTitle.Location = new Point(16, 290);
            labelTotalTitle.Name = "labelTotalTitle";
            labelTotalTitle.Size = new Size(154, 25);
            labelTotalTitle.TabIndex = 3;
            labelTotalTitle.Text = "TOTAL A PAGAR";
            // 
            // labelTotalDisplay
            // 
            labelTotalDisplay.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            labelTotalDisplay.ForeColor = Color.FromArgb(16, 185, 129);
            labelTotalDisplay.Location = new Point(16, 312);
            labelTotalDisplay.Name = "labelTotalDisplay";
            labelTotalDisplay.Size = new Size(348, 55);
            labelTotalDisplay.TabIndex = 4;
            labelTotalDisplay.Text = "$ 0,00";
            labelTotalDisplay.TextAlign = ContentAlignment.MiddleRight;
            // 
            // buttonRegisterSale
            // 
            buttonRegisterSale.BackColor = Color.FromArgb(16, 185, 129);
            buttonRegisterSale.FlatAppearance.BorderSize = 0;
            buttonRegisterSale.FlatStyle = FlatStyle.Flat;
            buttonRegisterSale.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonRegisterSale.ForeColor = Color.White;
            buttonRegisterSale.Location = new Point(16, 375);
            buttonRegisterSale.Name = "buttonRegisterSale";
            buttonRegisterSale.Size = new Size(348, 64);
            buttonRegisterSale.TabIndex = 5;
            buttonRegisterSale.Text = "COBRAR (F8)";
            buttonRegisterSale.UseVisualStyleBackColor = false;
            // 
            // pictureBoxWebcamPreview
            // 
            pictureBoxWebcamPreview.BackColor = Color.Black;
            pictureBoxWebcamPreview.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxWebcamPreview.Location = new Point(16, 452);
            pictureBoxWebcamPreview.Name = "pictureBoxWebcamPreview";
            pictureBoxWebcamPreview.Size = new Size(348, 120);
            pictureBoxWebcamPreview.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxWebcamPreview.TabIndex = 6;
            pictureBoxWebcamPreview.TabStop = false;
            // 
            // buttonToggleScannerCamera
            // 
            buttonToggleScannerCamera.FlatStyle = FlatStyle.Flat;
            buttonToggleScannerCamera.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonToggleScannerCamera.Location = new Point(16, 580);
            buttonToggleScannerCamera.Name = "buttonToggleScannerCamera";
            buttonToggleScannerCamera.Size = new Size(348, 34);
            buttonToggleScannerCamera.TabIndex = 7;
            buttonToggleScannerCamera.Text = "CÁMARA ESCÁNER";
            buttonToggleScannerCamera.UseVisualStyleBackColor = true;
            // 
            // FormSales
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1409, 754);
            Controls.Add(panelLeftWork);
            Controls.Add(panelRightSummary);
            Controls.Add(panelTopStatusBar);
            KeyPreview = true;
            Name = "FormSales";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Punto de Venta POS - CompriaxSystem";
            panelTopStatusBar.ResumeLayout(false);
            panelTopStatusBar.PerformLayout();
            panelLeftWork.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewCart).EndInit();
            panelBarcodeBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).EndInit();
            panelShortcutsFooter.ResumeLayout(false);
            panelRightSummary.ResumeLayout(false);
            panelRightSummary.PerformLayout();
            panelVoucherCard.ResumeLayout(false);
            panelVoucherCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxWebcamPreview).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTopStatusBar;
        private System.Windows.Forms.Label labelPosTitle;
        private System.Windows.Forms.Label labelCashierBadge;
        private System.Windows.Forms.Label labelShiftBadge;
        private System.Windows.Forms.Panel panelLeftWork;
        private System.Windows.Forms.Panel panelBarcodeBar;
        private Controls.QuickSearchProductBox quickSearchBox;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.Button buttonRemoveItem;
        private System.Windows.Forms.DataGridView dataGridViewCart;
        private System.Windows.Forms.Panel panelShortcutsFooter;
        private System.Windows.Forms.Label labelShortcutsGuide;
        private System.Windows.Forms.Panel panelRightSummary;
        private System.Windows.Forms.Panel panelVoucherCard;
        private System.Windows.Forms.Label labelVoucherHeader;
        private System.Windows.Forms.Label labelVoucherLetter;
        private System.Windows.Forms.ComboBox comboBoxDocumentType;
        private System.Windows.Forms.Label labelVoucherNumber;
        private System.Windows.Forms.Label labelClientNameValue;
        private System.Windows.Forms.Label labelClientDocValue;
        private System.Windows.Forms.Label labelClientTaxValue;
        private System.Windows.Forms.Button buttonSelectCustomer;
        private System.Windows.Forms.Label labelSubTotalValue;
        private System.Windows.Forms.Label labelDiscountValue;
        private System.Windows.Forms.Label labelTotalTitle;
        private System.Windows.Forms.Label labelTotalDisplay;
        private System.Windows.Forms.Button buttonRegisterSale;
        private System.Windows.Forms.PictureBox pictureBoxWebcamPreview;
        private System.Windows.Forms.Button buttonToggleScannerCamera;
    }
}