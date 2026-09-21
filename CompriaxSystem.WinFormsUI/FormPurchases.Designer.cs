namespace CompriaxSystem.WinFormsUI
{
    partial class FormPurchases
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.picIconSearchSupplier = new System.Windows.Forms.PictureBox();
            this.picIconSearchProduct = new System.Windows.Forms.PictureBox();
            this.picIconAddPurchaseItem = new System.Windows.Forms.PictureBox();
            this.picIconRemovePurchaseItem = new System.Windows.Forms.PictureBox();
            this.picIconRegisterPurchase = new System.Windows.Forms.PictureBox();
            this.picIconToggleScannerCamera = new System.Windows.Forms.PictureBox();
            panelHeader = new Panel();
            labelTitle = new Label();
            panelLeftWork = new Panel();
            dataGridViewPurchaseCart = new DataGridView();
            panelScannerItemBar = new Panel();
            labelBarcodePrompt = new Label();
            textBoxProductBarcode = new TextBox();
            buttonSearchProduct = new Button();
            labelProductName = new Label();
            textBoxProductName = new TextBox();
            labelBuyPrice = new Label();
            textBoxBuyPrice = new TextBox();
            labelQuantityPrompt = new Label();
            numericUpDownQuantity = new NumericUpDown();
            buttonAddPurchaseItem = new Button();
            buttonRemovePurchaseItem = new Button();
            panelPurchaseHeaderInfo = new Panel();
            labelDate = new Label();
            textBoxDate = new TextBox();
            labelDocumentType = new Label();
            comboBoxDocumentType = new ComboBox();
            labelInvoiceNumber = new Label();
            textBoxInvoiceNumber = new TextBox();
            labelSupplierTaxId = new Label();
            textBoxSupplierTaxId = new TextBox();
            // 
            // picIconSearchSupplier
            // 
            this.picIconSearchSupplier.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSearchSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSearchSupplier.Image = global::CompriaxSystem.WinFormsUI.Resources._080_buscar;
            this.picIconSearchSupplier.Location = new System.Drawing.Point(557, 37);
            this.picIconSearchSupplier.Name = "picIconSearchSupplier";
            this.picIconSearchSupplier.Size = new System.Drawing.Size(22, 22);
            this.picIconSearchSupplier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSearchSupplier.TabIndex = 99;
            this.picIconSearchSupplier.TabStop = false;

            // 
            // picIconSearchProduct
            // 
            this.picIconSearchProduct.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSearchProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSearchProduct.Image = global::CompriaxSystem.WinFormsUI.Resources._080_buscar;
            this.picIconSearchProduct.Location = new System.Drawing.Point(178, 48);
            this.picIconSearchProduct.Name = "picIconSearchProduct";
            this.picIconSearchProduct.Size = new System.Drawing.Size(22, 22);
            this.picIconSearchProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSearchProduct.TabIndex = 99;
            this.picIconSearchProduct.TabStop = false;

            // 
            // picIconAddPurchaseItem
            // 
            this.picIconAddPurchaseItem.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconAddPurchaseItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconAddPurchaseItem.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconAddPurchaseItem.Location = new System.Drawing.Point(673, 42);
            this.picIconAddPurchaseItem.Name = "picIconAddPurchaseItem";
            this.picIconAddPurchaseItem.Size = new System.Drawing.Size(22, 22);
            this.picIconAddPurchaseItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconAddPurchaseItem.TabIndex = 99;
            this.picIconAddPurchaseItem.TabStop = false;

            // 
            // picIconRemovePurchaseItem
            // 
            this.picIconRemovePurchaseItem.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconRemovePurchaseItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconRemovePurchaseItem.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconRemovePurchaseItem.Location = new System.Drawing.Point(815, 42);
            this.picIconRemovePurchaseItem.Name = "picIconRemovePurchaseItem";
            this.picIconRemovePurchaseItem.Size = new System.Drawing.Size(22, 22);
            this.picIconRemovePurchaseItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconRemovePurchaseItem.TabIndex = 99;
            this.picIconRemovePurchaseItem.TabStop = false;

            // 
            // picIconRegisterPurchase
            // 
            this.picIconRegisterPurchase.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconRegisterPurchase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconRegisterPurchase.Image = global::CompriaxSystem.WinFormsUI.Resources._092_exito;
            this.picIconRegisterPurchase.Location = new System.Drawing.Point(28, 219);
            this.picIconRegisterPurchase.Name = "picIconRegisterPurchase";
            this.picIconRegisterPurchase.Size = new System.Drawing.Size(22, 22);
            this.picIconRegisterPurchase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconRegisterPurchase.TabIndex = 99;
            this.picIconRegisterPurchase.TabStop = false;

            // 
            // picIconToggleScannerCamera
            // 
            this.picIconToggleScannerCamera.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconToggleScannerCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconToggleScannerCamera.Image = global::CompriaxSystem.WinFormsUI.Resources._087_camara_encender;
            this.picIconToggleScannerCamera.Location = new System.Drawing.Point(26, 458);
            this.picIconToggleScannerCamera.Name = "picIconToggleScannerCamera";
            this.picIconToggleScannerCamera.Size = new System.Drawing.Size(18, 18);
            this.picIconToggleScannerCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconToggleScannerCamera.TabIndex = 99;
            this.picIconToggleScannerCamera.TabStop = false;
            buttonSearchSupplier = new Button();
            labelSupplierName = new Label();
            textBoxSupplierName = new TextBox();
            textBoxSupplierIdHidden = new TextBox();
            panelRightSummary = new Panel();
            labelSummaryTitle = new Label();
            labelPaymentMethod = new Label();
            comboBoxPaymentMethod = new ComboBox();
            labelTotalPrompt = new Label();
            textBoxTotalAmount = new TextBox();
            buttonRegisterPurchase = new Button();
            pictureBoxWebcamPreview = new PictureBox();
            buttonToggleScannerCamera = new Button();
            panelHeader.SuspendLayout();
            panelLeftWork.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPurchaseCart).BeginInit();
            panelScannerItemBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).BeginInit();
            panelPurchaseHeaderInfo.SuspendLayout();
            panelRightSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxWebcamPreview).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1350, 56);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 16);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(551, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "INGRESO DE MERCADERÍA / COMPRA DE STOCK";
            // 
            // panelLeftWork
            // 
            panelLeftWork.BackColor = Color.FromArgb(248, 250, 252);
            panelLeftWork.Controls.Add(dataGridViewPurchaseCart);
            panelLeftWork.Controls.Add(panelScannerItemBar);
            panelLeftWork.Controls.Add(panelPurchaseHeaderInfo);
            panelLeftWork.Dock = DockStyle.Fill;
            panelLeftWork.Location = new Point(0, 56);
            panelLeftWork.Name = "panelLeftWork";
            panelLeftWork.Padding = new Padding(16, 12, 8, 16);
            panelLeftWork.Size = new Size(990, 694);
            panelLeftWork.TabIndex = 1;
            // 
            // dataGridViewPurchaseCart
            // 
            dataGridViewPurchaseCart.BackgroundColor = Color.White;
            dataGridViewPurchaseCart.BorderStyle = BorderStyle.None;
            dataGridViewPurchaseCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPurchaseCart.Dock = DockStyle.Fill;
            dataGridViewPurchaseCart.Location = new Point(16, 198);
            dataGridViewPurchaseCart.Name = "dataGridViewPurchaseCart";
            dataGridViewPurchaseCart.RowHeadersWidth = 51;
            dataGridViewPurchaseCart.Size = new Size(966, 480);
            dataGridViewPurchaseCart.TabIndex = 2;
            // 
            // panelScannerItemBar
            // 
            panelScannerItemBar.BackColor = Color.White;
            panelScannerItemBar.Controls.Add(labelBarcodePrompt);
            panelScannerItemBar.Controls.Add(textBoxProductBarcode);
panelScannerItemBar.Controls.Add(this.picIconSearchProduct);
            panelScannerItemBar.Controls.Add(buttonSearchProduct);
            panelScannerItemBar.Controls.Add(labelProductName);
            panelScannerItemBar.Controls.Add(textBoxProductName);
            panelScannerItemBar.Controls.Add(labelBuyPrice);
            panelScannerItemBar.Controls.Add(textBoxBuyPrice);
            panelScannerItemBar.Controls.Add(labelQuantityPrompt);
            panelScannerItemBar.Controls.Add(numericUpDownQuantity);
panelScannerItemBar.Controls.Add(this.picIconAddPurchaseItem);
            panelScannerItemBar.Controls.Add(buttonAddPurchaseItem);
panelScannerItemBar.Controls.Add(this.picIconRemovePurchaseItem);
            panelScannerItemBar.Controls.Add(buttonRemovePurchaseItem);
            panelScannerItemBar.Dock = DockStyle.Top;
            panelScannerItemBar.Location = new Point(16, 97);
            panelScannerItemBar.Name = "panelScannerItemBar";
            panelScannerItemBar.Size = new Size(966, 101);
            panelScannerItemBar.TabIndex = 1;
            // 
            // labelBarcodePrompt
            // 
            labelBarcodePrompt.AutoSize = true;
            labelBarcodePrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelBarcodePrompt.Location = new Point(10, 22);
            labelBarcodePrompt.Name = "labelBarcodePrompt";
            labelBarcodePrompt.Size = new Size(93, 20);
            labelBarcodePrompt.TabIndex = 0;
            labelBarcodePrompt.Text = "Cod. Barras:";
            // 
            // textBoxProductBarcode
            // 
            textBoxProductBarcode.BorderStyle = BorderStyle.FixedSingle;
            textBoxProductBarcode.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            textBoxProductBarcode.Location = new Point(10, 45);
            textBoxProductBarcode.Name = "textBoxProductBarcode";
            textBoxProductBarcode.Size = new Size(150, 30);
            textBoxProductBarcode.TabIndex = 1;
            // 
            // buttonSearchProduct
            // 
            buttonSearchProduct.FlatStyle = FlatStyle.Flat;
            buttonSearchProduct.Location = new Point(166, 36);
            buttonSearchProduct.Name = "buttonSearchProduct";
            buttonSearchProduct.Size = new Size(47, 47);
            buttonSearchProduct.TabIndex = 2;
            buttonSearchProduct.Text = "";
            buttonSearchProduct.UseVisualStyleBackColor = true;
            // 
            // labelProductName
            // 
            labelProductName.AutoSize = true;
            labelProductName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelProductName.Location = new Point(219, 22);
            labelProductName.Name = "labelProductName";
            labelProductName.Size = new Size(77, 20);
            labelProductName.TabIndex = 3;
            labelProductName.Text = "Producto:";
            // 
            // textBoxProductName
            // 
            textBoxProductName.BorderStyle = BorderStyle.FixedSingle;
            textBoxProductName.Font = new Font("Segoe UI", 10F);
            textBoxProductName.Location = new Point(219, 45);
            textBoxProductName.Name = "textBoxProductName";
            textBoxProductName.ReadOnly = true;
            textBoxProductName.Size = new Size(200, 30);
            textBoxProductName.TabIndex = 4;
            // 
            // labelBuyPrice
            // 
            labelBuyPrice.AutoSize = true;
            labelBuyPrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelBuyPrice.Location = new Point(424, 22);
            labelBuyPrice.Name = "labelBuyPrice";
            labelBuyPrice.Size = new Size(125, 20);
            labelBuyPrice.TabIndex = 5;
            labelBuyPrice.Text = "$ Costo Compra:";
            // 
            // textBoxBuyPrice
            // 
            textBoxBuyPrice.BorderStyle = BorderStyle.FixedSingle;
            textBoxBuyPrice.Font = new Font("Segoe UI", 10F);
            textBoxBuyPrice.Location = new Point(425, 45);
            textBoxBuyPrice.Name = "textBoxBuyPrice";
            textBoxBuyPrice.Size = new Size(126, 30);
            textBoxBuyPrice.TabIndex = 6;
            // 
            // labelQuantityPrompt
            // 
            labelQuantityPrompt.AutoSize = true;
            labelQuantityPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelQuantityPrompt.Location = new Point(575, 22);
            labelQuantityPrompt.Name = "labelQuantityPrompt";
            labelQuantityPrompt.Size = new Size(75, 20);
            labelQuantityPrompt.TabIndex = 7;
            labelQuantityPrompt.Text = "Cantidad:";
            // 
            // numericUpDownQuantity
            // 
            numericUpDownQuantity.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            numericUpDownQuantity.Location = new Point(575, 45);
            numericUpDownQuantity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownQuantity.Name = "numericUpDownQuantity";
            numericUpDownQuantity.Size = new Size(80, 30);
            numericUpDownQuantity.TabIndex = 8;
            numericUpDownQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // buttonAddPurchaseItem
            // 
            buttonAddPurchaseItem.BackColor = Color.FromArgb(2, 132, 199);
            buttonAddPurchaseItem.FlatAppearance.BorderSize = 0;
            buttonAddPurchaseItem.FlatStyle = FlatStyle.Flat;
            buttonAddPurchaseItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonAddPurchaseItem.ForeColor = Color.White;
            buttonAddPurchaseItem.Location = new Point(665, 25);
            buttonAddPurchaseItem.Name = "buttonAddPurchaseItem";
            buttonAddPurchaseItem.Size = new Size(136, 56);
            buttonAddPurchaseItem.TabIndex = 9;
            buttonAddPurchaseItem.Text = "AGREGAR";
            buttonAddPurchaseItem.UseVisualStyleBackColor = false;
            // 
            // buttonRemovePurchaseItem
            // 
            buttonRemovePurchaseItem.BackColor = Color.FromArgb(239, 68, 68);
            buttonRemovePurchaseItem.FlatAppearance.BorderSize = 0;
            buttonRemovePurchaseItem.FlatStyle = FlatStyle.Flat;
            buttonRemovePurchaseItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonRemovePurchaseItem.ForeColor = Color.White;
            buttonRemovePurchaseItem.Location = new Point(807, 25);
            buttonRemovePurchaseItem.Name = "buttonRemovePurchaseItem";
            buttonRemovePurchaseItem.Size = new Size(141, 56);
            buttonRemovePurchaseItem.TabIndex = 10;
            buttonRemovePurchaseItem.Text = "QUITAR [SUPR]";
            buttonRemovePurchaseItem.UseVisualStyleBackColor = false;
            // 
            // panelPurchaseHeaderInfo
            // 
            panelPurchaseHeaderInfo.BackColor = Color.White;
            panelPurchaseHeaderInfo.Controls.Add(labelDate);
            panelPurchaseHeaderInfo.Controls.Add(textBoxDate);
            panelPurchaseHeaderInfo.Controls.Add(labelDocumentType);
            panelPurchaseHeaderInfo.Controls.Add(comboBoxDocumentType);
            panelPurchaseHeaderInfo.Controls.Add(labelInvoiceNumber);
            panelPurchaseHeaderInfo.Controls.Add(textBoxInvoiceNumber);
            panelPurchaseHeaderInfo.Controls.Add(labelSupplierTaxId);
            panelPurchaseHeaderInfo.Controls.Add(textBoxSupplierTaxId);
panelPurchaseHeaderInfo.Controls.Add(this.picIconSearchSupplier);
            panelPurchaseHeaderInfo.Controls.Add(buttonSearchSupplier);
            panelPurchaseHeaderInfo.Controls.Add(labelSupplierName);
            panelPurchaseHeaderInfo.Controls.Add(textBoxSupplierName);
            panelPurchaseHeaderInfo.Controls.Add(textBoxSupplierIdHidden);
            panelPurchaseHeaderInfo.Dock = DockStyle.Top;
            panelPurchaseHeaderInfo.Location = new Point(16, 12);
            panelPurchaseHeaderInfo.Name = "panelPurchaseHeaderInfo";
            panelPurchaseHeaderInfo.Size = new Size(966, 85);
            panelPurchaseHeaderInfo.TabIndex = 0;
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelDate.Location = new Point(12, 12);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(53, 20);
            labelDate.TabIndex = 0;
            labelDate.Text = "Fecha:";
            // 
            // textBoxDate
            // 
            textBoxDate.BorderStyle = BorderStyle.FixedSingle;
            textBoxDate.Font = new Font("Segoe UI", 10F);
            textBoxDate.Location = new Point(12, 32);
            textBoxDate.Name = "textBoxDate";
            textBoxDate.ReadOnly = true;
            textBoxDate.Size = new Size(100, 30);
            textBoxDate.TabIndex = 1;
            // 
            // labelDocumentType
            // 
            labelDocumentType.AutoSize = true;
            labelDocumentType.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelDocumentType.Location = new Point(122, 12);
            labelDocumentType.Name = "labelDocumentType";
            labelDocumentType.Size = new Size(75, 20);
            labelDocumentType.TabIndex = 2;
            labelDocumentType.Text = "Tipo Doc:";
            // 
            // comboBoxDocumentType
            // 
            comboBoxDocumentType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDocumentType.Font = new Font("Segoe UI", 10F);
            comboBoxDocumentType.Location = new Point(122, 32);
            comboBoxDocumentType.Name = "comboBoxDocumentType";
            comboBoxDocumentType.Size = new Size(120, 31);
            comboBoxDocumentType.TabIndex = 3;
            // 
            // labelInvoiceNumber
            // 
            labelInvoiceNumber.AutoSize = true;
            labelInvoiceNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelInvoiceNumber.Location = new Point(252, 12);
            labelInvoiceNumber.Name = "labelInvoiceNumber";
            labelInvoiceNumber.Size = new Size(87, 20);
            labelInvoiceNumber.TabIndex = 4;
            labelInvoiceNumber.Text = "N° Factura:";
            // 
            // textBoxInvoiceNumber
            // 
            textBoxInvoiceNumber.BorderStyle = BorderStyle.FixedSingle;
            textBoxInvoiceNumber.Font = new Font("Segoe UI", 10F);
            textBoxInvoiceNumber.Location = new Point(252, 32);
            textBoxInvoiceNumber.Name = "textBoxInvoiceNumber";
            textBoxInvoiceNumber.Size = new Size(130, 30);
            textBoxInvoiceNumber.TabIndex = 5;
            // 
            // labelSupplierTaxId
            // 
            labelSupplierTaxId.AutoSize = true;
            labelSupplierTaxId.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelSupplierTaxId.Location = new Point(395, 12);
            labelSupplierTaxId.Name = "labelSupplierTaxId";
            labelSupplierTaxId.Size = new Size(124, 20);
            labelSupplierTaxId.TabIndex = 6;
            labelSupplierTaxId.Text = "CUIT Proveedor:";
            // 
            // textBoxSupplierTaxId
            // 
            textBoxSupplierTaxId.BorderStyle = BorderStyle.FixedSingle;
            textBoxSupplierTaxId.Font = new Font("Segoe UI", 10F);
            textBoxSupplierTaxId.Location = new Point(395, 32);
            textBoxSupplierTaxId.Name = "textBoxSupplierTaxId";
            textBoxSupplierTaxId.Size = new Size(130, 30);
            textBoxSupplierTaxId.TabIndex = 7;
            // 
            // picIconSearchSupplier
            // 
            this.picIconSearchSupplier.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSearchSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSearchSupplier.Image = global::CompriaxSystem.WinFormsUI.Resources._080_buscar;
            this.picIconSearchSupplier.Location = new System.Drawing.Point(557, 37);
            this.picIconSearchSupplier.Name = "picIconSearchSupplier";
            this.picIconSearchSupplier.Size = new System.Drawing.Size(22, 22);
            this.picIconSearchSupplier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSearchSupplier.TabIndex = 99;
            this.picIconSearchSupplier.TabStop = false;

            // 
            // picIconSearchProduct
            // 
            this.picIconSearchProduct.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSearchProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSearchProduct.Image = global::CompriaxSystem.WinFormsUI.Resources._080_buscar;
            this.picIconSearchProduct.Location = new System.Drawing.Point(178, 48);
            this.picIconSearchProduct.Name = "picIconSearchProduct";
            this.picIconSearchProduct.Size = new System.Drawing.Size(22, 22);
            this.picIconSearchProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSearchProduct.TabIndex = 99;
            this.picIconSearchProduct.TabStop = false;

            // 
            // picIconAddPurchaseItem
            // 
            this.picIconAddPurchaseItem.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconAddPurchaseItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconAddPurchaseItem.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconAddPurchaseItem.Location = new System.Drawing.Point(673, 42);
            this.picIconAddPurchaseItem.Name = "picIconAddPurchaseItem";
            this.picIconAddPurchaseItem.Size = new System.Drawing.Size(22, 22);
            this.picIconAddPurchaseItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconAddPurchaseItem.TabIndex = 99;
            this.picIconAddPurchaseItem.TabStop = false;

            // 
            // picIconRemovePurchaseItem
            // 
            this.picIconRemovePurchaseItem.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconRemovePurchaseItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconRemovePurchaseItem.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconRemovePurchaseItem.Location = new System.Drawing.Point(815, 42);
            this.picIconRemovePurchaseItem.Name = "picIconRemovePurchaseItem";
            this.picIconRemovePurchaseItem.Size = new System.Drawing.Size(22, 22);
            this.picIconRemovePurchaseItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconRemovePurchaseItem.TabIndex = 99;
            this.picIconRemovePurchaseItem.TabStop = false;

            // 
            // picIconRegisterPurchase
            // 
            this.picIconRegisterPurchase.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconRegisterPurchase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconRegisterPurchase.Image = global::CompriaxSystem.WinFormsUI.Resources._092_exito;
            this.picIconRegisterPurchase.Location = new System.Drawing.Point(28, 219);
            this.picIconRegisterPurchase.Name = "picIconRegisterPurchase";
            this.picIconRegisterPurchase.Size = new System.Drawing.Size(22, 22);
            this.picIconRegisterPurchase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconRegisterPurchase.TabIndex = 99;
            this.picIconRegisterPurchase.TabStop = false;

            // 
            // picIconToggleScannerCamera
            // 
            this.picIconToggleScannerCamera.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconToggleScannerCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconToggleScannerCamera.Image = global::CompriaxSystem.WinFormsUI.Resources._087_camara_encender;
            this.picIconToggleScannerCamera.Location = new System.Drawing.Point(26, 458);
            this.picIconToggleScannerCamera.Name = "picIconToggleScannerCamera";
            this.picIconToggleScannerCamera.Size = new System.Drawing.Size(18, 18);
            this.picIconToggleScannerCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconToggleScannerCamera.TabIndex = 99;
            this.picIconToggleScannerCamera.TabStop = false;





            // 
            // buttonSearchSupplier
            // 
            // picIconSearchSupplier
            // 
            this.picIconSearchSupplier.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSearchSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSearchSupplier.Image = global::CompriaxSystem.WinFormsUI.Resources._080_buscar;
            this.picIconSearchSupplier.Location = new System.Drawing.Point(557, 37);
            this.picIconSearchSupplier.Name = "picIconSearchSupplier";
            this.picIconSearchSupplier.Size = new System.Drawing.Size(22, 22);
            this.picIconSearchSupplier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSearchSupplier.TabIndex = 99;
            this.picIconSearchSupplier.TabStop = false;

            // 
            // picIconSearchProduct
            // 
            this.picIconSearchProduct.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSearchProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSearchProduct.Image = global::CompriaxSystem.WinFormsUI.Resources._080_buscar;
            this.picIconSearchProduct.Location = new System.Drawing.Point(178, 48);
            this.picIconSearchProduct.Name = "picIconSearchProduct";
            this.picIconSearchProduct.Size = new System.Drawing.Size(22, 22);
            this.picIconSearchProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSearchProduct.TabIndex = 99;
            this.picIconSearchProduct.TabStop = false;

            // 
            // picIconAddPurchaseItem
            // 
            this.picIconAddPurchaseItem.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconAddPurchaseItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconAddPurchaseItem.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconAddPurchaseItem.Location = new System.Drawing.Point(673, 42);
            this.picIconAddPurchaseItem.Name = "picIconAddPurchaseItem";
            this.picIconAddPurchaseItem.Size = new System.Drawing.Size(22, 22);
            this.picIconAddPurchaseItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconAddPurchaseItem.TabIndex = 99;
            this.picIconAddPurchaseItem.TabStop = false;

            // 
            // picIconRemovePurchaseItem
            // 
            this.picIconRemovePurchaseItem.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconRemovePurchaseItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconRemovePurchaseItem.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconRemovePurchaseItem.Location = new System.Drawing.Point(815, 42);
            this.picIconRemovePurchaseItem.Name = "picIconRemovePurchaseItem";
            this.picIconRemovePurchaseItem.Size = new System.Drawing.Size(22, 22);
            this.picIconRemovePurchaseItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconRemovePurchaseItem.TabIndex = 99;
            this.picIconRemovePurchaseItem.TabStop = false;

            // 
            // picIconRegisterPurchase
            // 
            this.picIconRegisterPurchase.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconRegisterPurchase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconRegisterPurchase.Image = global::CompriaxSystem.WinFormsUI.Resources._092_exito;
            this.picIconRegisterPurchase.Location = new System.Drawing.Point(28, 219);
            this.picIconRegisterPurchase.Name = "picIconRegisterPurchase";
            this.picIconRegisterPurchase.Size = new System.Drawing.Size(22, 22);
            this.picIconRegisterPurchase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconRegisterPurchase.TabIndex = 99;
            this.picIconRegisterPurchase.TabStop = false;

            // 
            // picIconToggleScannerCamera
            // 
            this.picIconToggleScannerCamera.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconToggleScannerCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconToggleScannerCamera.Image = global::CompriaxSystem.WinFormsUI.Resources._087_camara_encender;
            this.picIconToggleScannerCamera.Location = new System.Drawing.Point(26, 458);
            this.picIconToggleScannerCamera.Name = "picIconToggleScannerCamera";
            this.picIconToggleScannerCamera.Size = new System.Drawing.Size(18, 18);
            this.picIconToggleScannerCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconToggleScannerCamera.TabIndex = 99;
            this.picIconToggleScannerCamera.TabStop = false;
            // 
            buttonSearchSupplier.FlatStyle = FlatStyle.Flat;
            // 
            // picIconSearchSupplier
            // 
            this.picIconSearchSupplier.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSearchSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSearchSupplier.Image = global::CompriaxSystem.WinFormsUI.Resources._080_buscar;
            this.picIconSearchSupplier.Location = new System.Drawing.Point(557, 37);
            this.picIconSearchSupplier.Name = "picIconSearchSupplier";
            this.picIconSearchSupplier.Size = new System.Drawing.Size(22, 22);
            this.picIconSearchSupplier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSearchSupplier.TabIndex = 99;
            this.picIconSearchSupplier.TabStop = false;

            // 
            // picIconSearchProduct
            // 
            this.picIconSearchProduct.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSearchProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSearchProduct.Image = global::CompriaxSystem.WinFormsUI.Resources._080_buscar;
            this.picIconSearchProduct.Location = new System.Drawing.Point(178, 48);
            this.picIconSearchProduct.Name = "picIconSearchProduct";
            this.picIconSearchProduct.Size = new System.Drawing.Size(22, 22);
            this.picIconSearchProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSearchProduct.TabIndex = 99;
            this.picIconSearchProduct.TabStop = false;

            // 
            // picIconAddPurchaseItem
            // 
            this.picIconAddPurchaseItem.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconAddPurchaseItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconAddPurchaseItem.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconAddPurchaseItem.Location = new System.Drawing.Point(673, 42);
            this.picIconAddPurchaseItem.Name = "picIconAddPurchaseItem";
            this.picIconAddPurchaseItem.Size = new System.Drawing.Size(22, 22);
            this.picIconAddPurchaseItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconAddPurchaseItem.TabIndex = 99;
            this.picIconAddPurchaseItem.TabStop = false;

            // 
            // picIconRemovePurchaseItem
            // 
            this.picIconRemovePurchaseItem.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconRemovePurchaseItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconRemovePurchaseItem.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconRemovePurchaseItem.Location = new System.Drawing.Point(815, 42);
            this.picIconRemovePurchaseItem.Name = "picIconRemovePurchaseItem";
            this.picIconRemovePurchaseItem.Size = new System.Drawing.Size(22, 22);
            this.picIconRemovePurchaseItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconRemovePurchaseItem.TabIndex = 99;
            this.picIconRemovePurchaseItem.TabStop = false;

            // 
            // picIconRegisterPurchase
            // 
            this.picIconRegisterPurchase.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconRegisterPurchase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconRegisterPurchase.Image = global::CompriaxSystem.WinFormsUI.Resources._092_exito;
            this.picIconRegisterPurchase.Location = new System.Drawing.Point(28, 219);
            this.picIconRegisterPurchase.Name = "picIconRegisterPurchase";
            this.picIconRegisterPurchase.Size = new System.Drawing.Size(22, 22);
            this.picIconRegisterPurchase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconRegisterPurchase.TabIndex = 99;
            this.picIconRegisterPurchase.TabStop = false;

            // 
            // picIconToggleScannerCamera
            // 
            this.picIconToggleScannerCamera.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconToggleScannerCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconToggleScannerCamera.Image = global::CompriaxSystem.WinFormsUI.Resources._087_camara_encender;
            this.picIconToggleScannerCamera.Location = new System.Drawing.Point(26, 458);
            this.picIconToggleScannerCamera.Name = "picIconToggleScannerCamera";
            this.picIconToggleScannerCamera.Size = new System.Drawing.Size(18, 18);
            this.picIconToggleScannerCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconToggleScannerCamera.TabIndex = 99;
            this.picIconToggleScannerCamera.TabStop = false;
            buttonSearchSupplier.Location = new Point(531, 26);
            // 
            // picIconSearchSupplier
            // 
            this.picIconSearchSupplier.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSearchSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSearchSupplier.Image = global::CompriaxSystem.WinFormsUI.Resources._080_buscar;
            this.picIconSearchSupplier.Location = new System.Drawing.Point(557, 37);
            this.picIconSearchSupplier.Name = "picIconSearchSupplier";
            this.picIconSearchSupplier.Size = new System.Drawing.Size(22, 22);
            this.picIconSearchSupplier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSearchSupplier.TabIndex = 99;
            this.picIconSearchSupplier.TabStop = false;

            // 
            // picIconSearchProduct
            // 
            this.picIconSearchProduct.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSearchProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSearchProduct.Image = global::CompriaxSystem.WinFormsUI.Resources._080_buscar;
            this.picIconSearchProduct.Location = new System.Drawing.Point(178, 48);
            this.picIconSearchProduct.Name = "picIconSearchProduct";
            this.picIconSearchProduct.Size = new System.Drawing.Size(22, 22);
            this.picIconSearchProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSearchProduct.TabIndex = 99;
            this.picIconSearchProduct.TabStop = false;

            // 
            // picIconAddPurchaseItem
            // 
            this.picIconAddPurchaseItem.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconAddPurchaseItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconAddPurchaseItem.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconAddPurchaseItem.Location = new System.Drawing.Point(673, 42);
            this.picIconAddPurchaseItem.Name = "picIconAddPurchaseItem";
            this.picIconAddPurchaseItem.Size = new System.Drawing.Size(22, 22);
            this.picIconAddPurchaseItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconAddPurchaseItem.TabIndex = 99;
            this.picIconAddPurchaseItem.TabStop = false;

            // 
            // picIconRemovePurchaseItem
            // 
            this.picIconRemovePurchaseItem.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconRemovePurchaseItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconRemovePurchaseItem.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconRemovePurchaseItem.Location = new System.Drawing.Point(815, 42);
            this.picIconRemovePurchaseItem.Name = "picIconRemovePurchaseItem";
            this.picIconRemovePurchaseItem.Size = new System.Drawing.Size(22, 22);
            this.picIconRemovePurchaseItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconRemovePurchaseItem.TabIndex = 99;
            this.picIconRemovePurchaseItem.TabStop = false;

            // 
            // picIconRegisterPurchase
            // 
            this.picIconRegisterPurchase.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconRegisterPurchase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconRegisterPurchase.Image = global::CompriaxSystem.WinFormsUI.Resources._092_exito;
            this.picIconRegisterPurchase.Location = new System.Drawing.Point(28, 219);
            this.picIconRegisterPurchase.Name = "picIconRegisterPurchase";
            this.picIconRegisterPurchase.Size = new System.Drawing.Size(22, 22);
            this.picIconRegisterPurchase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconRegisterPurchase.TabIndex = 99;
            this.picIconRegisterPurchase.TabStop = false;

            // 
            // picIconToggleScannerCamera
            // 
            this.picIconToggleScannerCamera.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconToggleScannerCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconToggleScannerCamera.Image = global::CompriaxSystem.WinFormsUI.Resources._087_camara_encender;
            this.picIconToggleScannerCamera.Location = new System.Drawing.Point(26, 458);
            this.picIconToggleScannerCamera.Name = "picIconToggleScannerCamera";
            this.picIconToggleScannerCamera.Size = new System.Drawing.Size(18, 18);
            this.picIconToggleScannerCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconToggleScannerCamera.TabIndex = 99;
            this.picIconToggleScannerCamera.TabStop = false;
            buttonSearchSupplier.Name = "buttonSearchSupplier";
            // 
            // picIconSearchSupplier
            // 
            this.picIconSearchSupplier.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSearchSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSearchSupplier.Image = global::CompriaxSystem.WinFormsUI.Resources._080_buscar;
            this.picIconSearchSupplier.Location = new System.Drawing.Point(557, 37);
            this.picIconSearchSupplier.Name = "picIconSearchSupplier";
            this.picIconSearchSupplier.Size = new System.Drawing.Size(22, 22);
            this.picIconSearchSupplier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSearchSupplier.TabIndex = 99;
            this.picIconSearchSupplier.TabStop = false;

            // 
            // picIconSearchProduct
            // 
            this.picIconSearchProduct.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSearchProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSearchProduct.Image = global::CompriaxSystem.WinFormsUI.Resources._080_buscar;
            this.picIconSearchProduct.Location = new System.Drawing.Point(178, 48);
            this.picIconSearchProduct.Name = "picIconSearchProduct";
            this.picIconSearchProduct.Size = new System.Drawing.Size(22, 22);
            this.picIconSearchProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSearchProduct.TabIndex = 99;
            this.picIconSearchProduct.TabStop = false;

            // 
            // picIconAddPurchaseItem
            // 
            this.picIconAddPurchaseItem.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconAddPurchaseItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconAddPurchaseItem.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconAddPurchaseItem.Location = new System.Drawing.Point(673, 42);
            this.picIconAddPurchaseItem.Name = "picIconAddPurchaseItem";
            this.picIconAddPurchaseItem.Size = new System.Drawing.Size(22, 22);
            this.picIconAddPurchaseItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconAddPurchaseItem.TabIndex = 99;
            this.picIconAddPurchaseItem.TabStop = false;

            // 
            // picIconRemovePurchaseItem
            // 
            this.picIconRemovePurchaseItem.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconRemovePurchaseItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconRemovePurchaseItem.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconRemovePurchaseItem.Location = new System.Drawing.Point(815, 42);
            this.picIconRemovePurchaseItem.Name = "picIconRemovePurchaseItem";
            this.picIconRemovePurchaseItem.Size = new System.Drawing.Size(22, 22);
            this.picIconRemovePurchaseItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconRemovePurchaseItem.TabIndex = 99;
            this.picIconRemovePurchaseItem.TabStop = false;

            // 
            // picIconRegisterPurchase
            // 
            this.picIconRegisterPurchase.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconRegisterPurchase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconRegisterPurchase.Image = global::CompriaxSystem.WinFormsUI.Resources._092_exito;
            this.picIconRegisterPurchase.Location = new System.Drawing.Point(28, 219);
            this.picIconRegisterPurchase.Name = "picIconRegisterPurchase";
            this.picIconRegisterPurchase.Size = new System.Drawing.Size(22, 22);
            this.picIconRegisterPurchase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconRegisterPurchase.TabIndex = 99;
            this.picIconRegisterPurchase.TabStop = false;

            // 
            // picIconToggleScannerCamera
            // 
            this.picIconToggleScannerCamera.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconToggleScannerCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconToggleScannerCamera.Image = global::CompriaxSystem.WinFormsUI.Resources._087_camara_encender;
            this.picIconToggleScannerCamera.Location = new System.Drawing.Point(26, 458);
            this.picIconToggleScannerCamera.Name = "picIconToggleScannerCamera";
            this.picIconToggleScannerCamera.Size = new System.Drawing.Size(18, 18);
            this.picIconToggleScannerCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconToggleScannerCamera.TabIndex = 99;
            this.picIconToggleScannerCamera.TabStop = false;
            buttonSearchSupplier.Size = new Size(76, 43);
            // 
            // picIconSearchSupplier
            // 
            this.picIconSearchSupplier.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSearchSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSearchSupplier.Image = global::CompriaxSystem.WinFormsUI.Resources._080_buscar;
            this.picIconSearchSupplier.Location = new System.Drawing.Point(557, 37);
            this.picIconSearchSupplier.Name = "picIconSearchSupplier";
            this.picIconSearchSupplier.Size = new System.Drawing.Size(22, 22);
            this.picIconSearchSupplier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSearchSupplier.TabIndex = 99;
            this.picIconSearchSupplier.TabStop = false;

            // 
            // picIconSearchProduct
            // 
            this.picIconSearchProduct.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSearchProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSearchProduct.Image = global::CompriaxSystem.WinFormsUI.Resources._080_buscar;
            this.picIconSearchProduct.Location = new System.Drawing.Point(178, 48);
            this.picIconSearchProduct.Name = "picIconSearchProduct";
            this.picIconSearchProduct.Size = new System.Drawing.Size(22, 22);
            this.picIconSearchProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSearchProduct.TabIndex = 99;
            this.picIconSearchProduct.TabStop = false;

            // 
            // picIconAddPurchaseItem
            // 
            this.picIconAddPurchaseItem.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconAddPurchaseItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconAddPurchaseItem.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconAddPurchaseItem.Location = new System.Drawing.Point(673, 42);
            this.picIconAddPurchaseItem.Name = "picIconAddPurchaseItem";
            this.picIconAddPurchaseItem.Size = new System.Drawing.Size(22, 22);
            this.picIconAddPurchaseItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconAddPurchaseItem.TabIndex = 99;
            this.picIconAddPurchaseItem.TabStop = false;

            // 
            // picIconRemovePurchaseItem
            // 
            this.picIconRemovePurchaseItem.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconRemovePurchaseItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconRemovePurchaseItem.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconRemovePurchaseItem.Location = new System.Drawing.Point(815, 42);
            this.picIconRemovePurchaseItem.Name = "picIconRemovePurchaseItem";
            this.picIconRemovePurchaseItem.Size = new System.Drawing.Size(22, 22);
            this.picIconRemovePurchaseItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconRemovePurchaseItem.TabIndex = 99;
            this.picIconRemovePurchaseItem.TabStop = false;

            // 
            // picIconRegisterPurchase
            // 
            this.picIconRegisterPurchase.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconRegisterPurchase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconRegisterPurchase.Image = global::CompriaxSystem.WinFormsUI.Resources._092_exito;
            this.picIconRegisterPurchase.Location = new System.Drawing.Point(28, 219);
            this.picIconRegisterPurchase.Name = "picIconRegisterPurchase";
            this.picIconRegisterPurchase.Size = new System.Drawing.Size(22, 22);
            this.picIconRegisterPurchase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconRegisterPurchase.TabIndex = 99;
            this.picIconRegisterPurchase.TabStop = false;

            // 
            // picIconToggleScannerCamera
            // 
            this.picIconToggleScannerCamera.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconToggleScannerCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconToggleScannerCamera.Image = global::CompriaxSystem.WinFormsUI.Resources._087_camara_encender;
            this.picIconToggleScannerCamera.Location = new System.Drawing.Point(26, 458);
            this.picIconToggleScannerCamera.Name = "picIconToggleScannerCamera";
            this.picIconToggleScannerCamera.Size = new System.Drawing.Size(18, 18);
            this.picIconToggleScannerCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconToggleScannerCamera.TabIndex = 99;
            this.picIconToggleScannerCamera.TabStop = false;
            buttonSearchSupplier.TabIndex = 8;
            // 
            // picIconSearchSupplier
            // 
            this.picIconSearchSupplier.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSearchSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSearchSupplier.Image = global::CompriaxSystem.WinFormsUI.Resources._080_buscar;
            this.picIconSearchSupplier.Location = new System.Drawing.Point(557, 37);
            this.picIconSearchSupplier.Name = "picIconSearchSupplier";
            this.picIconSearchSupplier.Size = new System.Drawing.Size(22, 22);
            this.picIconSearchSupplier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSearchSupplier.TabIndex = 99;
            this.picIconSearchSupplier.TabStop = false;

            // 
            // picIconSearchProduct
            // 
            this.picIconSearchProduct.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSearchProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSearchProduct.Image = global::CompriaxSystem.WinFormsUI.Resources._080_buscar;
            this.picIconSearchProduct.Location = new System.Drawing.Point(178, 48);
            this.picIconSearchProduct.Name = "picIconSearchProduct";
            this.picIconSearchProduct.Size = new System.Drawing.Size(22, 22);
            this.picIconSearchProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSearchProduct.TabIndex = 99;
            this.picIconSearchProduct.TabStop = false;

            // 
            // picIconAddPurchaseItem
            // 
            this.picIconAddPurchaseItem.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconAddPurchaseItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconAddPurchaseItem.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconAddPurchaseItem.Location = new System.Drawing.Point(673, 42);
            this.picIconAddPurchaseItem.Name = "picIconAddPurchaseItem";
            this.picIconAddPurchaseItem.Size = new System.Drawing.Size(22, 22);
            this.picIconAddPurchaseItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconAddPurchaseItem.TabIndex = 99;
            this.picIconAddPurchaseItem.TabStop = false;

            // 
            // picIconRemovePurchaseItem
            // 
            this.picIconRemovePurchaseItem.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconRemovePurchaseItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconRemovePurchaseItem.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconRemovePurchaseItem.Location = new System.Drawing.Point(815, 42);
            this.picIconRemovePurchaseItem.Name = "picIconRemovePurchaseItem";
            this.picIconRemovePurchaseItem.Size = new System.Drawing.Size(22, 22);
            this.picIconRemovePurchaseItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconRemovePurchaseItem.TabIndex = 99;
            this.picIconRemovePurchaseItem.TabStop = false;

            // 
            // picIconRegisterPurchase
            // 
            this.picIconRegisterPurchase.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconRegisterPurchase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconRegisterPurchase.Image = global::CompriaxSystem.WinFormsUI.Resources._092_exito;
            this.picIconRegisterPurchase.Location = new System.Drawing.Point(28, 219);
            this.picIconRegisterPurchase.Name = "picIconRegisterPurchase";
            this.picIconRegisterPurchase.Size = new System.Drawing.Size(22, 22);
            this.picIconRegisterPurchase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconRegisterPurchase.TabIndex = 99;
            this.picIconRegisterPurchase.TabStop = false;

            // 
            // picIconToggleScannerCamera
            // 
            this.picIconToggleScannerCamera.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconToggleScannerCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconToggleScannerCamera.Image = global::CompriaxSystem.WinFormsUI.Resources._087_camara_encender;
            this.picIconToggleScannerCamera.Location = new System.Drawing.Point(26, 458);
            this.picIconToggleScannerCamera.Name = "picIconToggleScannerCamera";
            this.picIconToggleScannerCamera.Size = new System.Drawing.Size(18, 18);
            this.picIconToggleScannerCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconToggleScannerCamera.TabIndex = 99;
            this.picIconToggleScannerCamera.TabStop = false;
            buttonSearchSupplier.Text = "";
            // 
            // picIconSearchSupplier
            // 
            this.picIconSearchSupplier.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSearchSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSearchSupplier.Image = global::CompriaxSystem.WinFormsUI.Resources._080_buscar;
            this.picIconSearchSupplier.Location = new System.Drawing.Point(557, 37);
            this.picIconSearchSupplier.Name = "picIconSearchSupplier";
            this.picIconSearchSupplier.Size = new System.Drawing.Size(22, 22);
            this.picIconSearchSupplier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSearchSupplier.TabIndex = 99;
            this.picIconSearchSupplier.TabStop = false;

            // 
            // picIconSearchProduct
            // 
            this.picIconSearchProduct.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconSearchProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSearchProduct.Image = global::CompriaxSystem.WinFormsUI.Resources._080_buscar;
            this.picIconSearchProduct.Location = new System.Drawing.Point(178, 48);
            this.picIconSearchProduct.Name = "picIconSearchProduct";
            this.picIconSearchProduct.Size = new System.Drawing.Size(22, 22);
            this.picIconSearchProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSearchProduct.TabIndex = 99;
            this.picIconSearchProduct.TabStop = false;

            // 
            // picIconAddPurchaseItem
            // 
            this.picIconAddPurchaseItem.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconAddPurchaseItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconAddPurchaseItem.Image = global::CompriaxSystem.WinFormsUI.Resources._077_guardar;
            this.picIconAddPurchaseItem.Location = new System.Drawing.Point(673, 42);
            this.picIconAddPurchaseItem.Name = "picIconAddPurchaseItem";
            this.picIconAddPurchaseItem.Size = new System.Drawing.Size(22, 22);
            this.picIconAddPurchaseItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconAddPurchaseItem.TabIndex = 99;
            this.picIconAddPurchaseItem.TabStop = false;

            // 
            // picIconRemovePurchaseItem
            // 
            this.picIconRemovePurchaseItem.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.picIconRemovePurchaseItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconRemovePurchaseItem.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconRemovePurchaseItem.Location = new System.Drawing.Point(815, 42);
            this.picIconRemovePurchaseItem.Name = "picIconRemovePurchaseItem";
            this.picIconRemovePurchaseItem.Size = new System.Drawing.Size(22, 22);
            this.picIconRemovePurchaseItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconRemovePurchaseItem.TabIndex = 99;
            this.picIconRemovePurchaseItem.TabStop = false;

            // 
            // picIconRegisterPurchase
            // 
            this.picIconRegisterPurchase.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.picIconRegisterPurchase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconRegisterPurchase.Image = global::CompriaxSystem.WinFormsUI.Resources._092_exito;
            this.picIconRegisterPurchase.Location = new System.Drawing.Point(28, 219);
            this.picIconRegisterPurchase.Name = "picIconRegisterPurchase";
            this.picIconRegisterPurchase.Size = new System.Drawing.Size(22, 22);
            this.picIconRegisterPurchase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconRegisterPurchase.TabIndex = 99;
            this.picIconRegisterPurchase.TabStop = false;

            // 
            // picIconToggleScannerCamera
            // 
            this.picIconToggleScannerCamera.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconToggleScannerCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconToggleScannerCamera.Image = global::CompriaxSystem.WinFormsUI.Resources._087_camara_encender;
            this.picIconToggleScannerCamera.Location = new System.Drawing.Point(26, 458);
            this.picIconToggleScannerCamera.Name = "picIconToggleScannerCamera";
            this.picIconToggleScannerCamera.Size = new System.Drawing.Size(18, 18);
            this.picIconToggleScannerCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconToggleScannerCamera.TabIndex = 99;
            this.picIconToggleScannerCamera.TabStop = false;
            buttonSearchSupplier.UseVisualStyleBackColor = true;
            // 
            // labelSupplierName
            // 
            labelSupplierName.AutoSize = true;
            labelSupplierName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelSupplierName.Location = new Point(613, 12);
            labelSupplierName.Name = "labelSupplierName";
            labelSupplierName.Size = new Size(100, 20);
            labelSupplierName.TabIndex = 9;
            labelSupplierName.Text = "Razón Social:";
            // 
            // textBoxSupplierName
            // 
            textBoxSupplierName.BorderStyle = BorderStyle.FixedSingle;
            textBoxSupplierName.Font = new Font("Segoe UI", 10F);
            textBoxSupplierName.Location = new Point(613, 34);
            textBoxSupplierName.Name = "textBoxSupplierName";
            textBoxSupplierName.ReadOnly = true;
            textBoxSupplierName.Size = new Size(306, 30);
            textBoxSupplierName.TabIndex = 10;
            // 
            // textBoxSupplierIdHidden
            // 
            textBoxSupplierIdHidden.Location = new Point(894, 4);
            textBoxSupplierIdHidden.Name = "textBoxSupplierIdHidden";
            textBoxSupplierIdHidden.Size = new Size(25, 27);
            textBoxSupplierIdHidden.TabIndex = 11;
            textBoxSupplierIdHidden.Visible = false;
            // 
            // panelRightSummary
            // 
            panelRightSummary.BackColor = Color.White;
            panelRightSummary.Controls.Add(labelSummaryTitle);
            panelRightSummary.Controls.Add(labelPaymentMethod);
            panelRightSummary.Controls.Add(comboBoxPaymentMethod);
            panelRightSummary.Controls.Add(labelTotalPrompt);
            panelRightSummary.Controls.Add(textBoxTotalAmount);
panelRightSummary.Controls.Add(this.picIconRegisterPurchase);
            panelRightSummary.Controls.Add(buttonRegisterPurchase);
            panelRightSummary.Controls.Add(pictureBoxWebcamPreview);
panelRightSummary.Controls.Add(this.picIconToggleScannerCamera);
            panelRightSummary.Controls.Add(buttonToggleScannerCamera);
            panelRightSummary.Dock = DockStyle.Right;
            panelRightSummary.Location = new Point(990, 56);
            panelRightSummary.Name = "panelRightSummary";
            panelRightSummary.Padding = new Padding(16);
            panelRightSummary.Size = new Size(360, 694);
            panelRightSummary.TabIndex = 2;
            // 
            // labelSummaryTitle
            // 
            labelSummaryTitle.AutoSize = true;
            labelSummaryTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelSummaryTitle.Location = new Point(16, 16);
            labelSummaryTitle.Name = "labelSummaryTitle";
            labelSummaryTitle.Size = new Size(245, 30);
            labelSummaryTitle.TabIndex = 0;
            labelSummaryTitle.Text = "TOTAL DE LA COMPRA";
            // 
            // labelPaymentMethod
            // 
            labelPaymentMethod.AutoSize = true;
            labelPaymentMethod.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelPaymentMethod.Location = new Point(16, 56);
            labelPaymentMethod.Name = "labelPaymentMethod";
            labelPaymentMethod.Size = new Size(117, 20);
            labelPaymentMethod.TabIndex = 1;
            labelPaymentMethod.Text = "Medio de Pago:";
            // 
            // comboBoxPaymentMethod
            // 
            comboBoxPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPaymentMethod.Font = new Font("Segoe UI", 10F);
            comboBoxPaymentMethod.Location = new Point(16, 76);
            comboBoxPaymentMethod.Name = "comboBoxPaymentMethod";
            comboBoxPaymentMethod.Size = new Size(328, 31);
            comboBoxPaymentMethod.TabIndex = 2;
            // 
            // labelTotalPrompt
            // 
            labelTotalPrompt.AutoSize = true;
            labelTotalPrompt.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelTotalPrompt.Location = new Point(16, 120);
            labelTotalPrompt.Name = "labelTotalPrompt";
            labelTotalPrompt.Size = new Size(153, 21);
            labelTotalPrompt.TabIndex = 3;
            labelTotalPrompt.Text = "Total de la Factura:";
            // 
            // textBoxTotalAmount
            // 
            textBoxTotalAmount.BackColor = Color.FromArgb(248, 250, 252);
            textBoxTotalAmount.BorderStyle = BorderStyle.FixedSingle;
            textBoxTotalAmount.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            textBoxTotalAmount.ForeColor = Color.FromArgb(16, 185, 129);
            textBoxTotalAmount.Location = new Point(16, 142);
            textBoxTotalAmount.Name = "textBoxTotalAmount";
            textBoxTotalAmount.ReadOnly = true;
            textBoxTotalAmount.Size = new Size(328, 47);
            textBoxTotalAmount.TabIndex = 4;
            textBoxTotalAmount.Text = "$ 0,00";
            textBoxTotalAmount.TextAlign = HorizontalAlignment.Right;
            // 
            // buttonRegisterPurchase
            // 
            buttonRegisterPurchase.BackColor = Color.FromArgb(16, 185, 129);
            buttonRegisterPurchase.FlatAppearance.BorderSize = 0;
            buttonRegisterPurchase.FlatStyle = FlatStyle.Flat;
            buttonRegisterPurchase.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            buttonRegisterPurchase.ForeColor = Color.White;
            buttonRegisterPurchase.Location = new Point(16, 200);
            buttonRegisterPurchase.Name = "buttonRegisterPurchase";
            buttonRegisterPurchase.Size = new Size(328, 60);
            buttonRegisterPurchase.TabIndex = 5;
            buttonRegisterPurchase.Text = "REGISTRAR COMPRA";
            buttonRegisterPurchase.UseVisualStyleBackColor = false;
            // 
            // pictureBoxWebcamPreview
            // 
            pictureBoxWebcamPreview.BackColor = Color.Black;
            pictureBoxWebcamPreview.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxWebcamPreview.Location = new Point(16, 280);
            pictureBoxWebcamPreview.Name = "pictureBoxWebcamPreview";
            pictureBoxWebcamPreview.Size = new Size(328, 160);
            pictureBoxWebcamPreview.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxWebcamPreview.TabIndex = 6;
            pictureBoxWebcamPreview.TabStop = false;
            // 
            // buttonToggleScannerCamera
            // 
            buttonToggleScannerCamera.FlatStyle = FlatStyle.Flat;
            buttonToggleScannerCamera.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonToggleScannerCamera.Location = new Point(16, 450);
            buttonToggleScannerCamera.Name = "buttonToggleScannerCamera";
            buttonToggleScannerCamera.Size = new Size(328, 36);
            buttonToggleScannerCamera.TabIndex = 7;
            buttonToggleScannerCamera.Text = "ENCENDER CÁMARA";
            buttonToggleScannerCamera.UseVisualStyleBackColor = true;





            // 
            // FormPurchases
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1350, 750);
            Controls.Add(panelLeftWork);
            Controls.Add(panelRightSummary);
            Controls.Add(panelHeader);
            Name = "FormPurchases";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de Compras";
ResumeLayout(false);
            panelHeader.PerformLayout();
ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewPurchaseCart).EndInit();
ResumeLayout(false);
            panelScannerItemBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).EndInit();
ResumeLayout(false);
            panelPurchaseHeaderInfo.PerformLayout();
ResumeLayout(false);
            panelRightSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxWebcamPreview).EndInit();

            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelLeftWork;
        private System.Windows.Forms.Panel panelPurchaseHeaderInfo;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.TextBox textBoxDate;
        private System.Windows.Forms.Label labelDocumentType;
        private System.Windows.Forms.ComboBox comboBoxDocumentType;
        private System.Windows.Forms.Label labelInvoiceNumber;
        private System.Windows.Forms.TextBox textBoxInvoiceNumber;
        private System.Windows.Forms.Label labelSupplierTaxId;
        private System.Windows.Forms.TextBox textBoxSupplierTaxId;
        private System.Windows.Forms.Button buttonSearchSupplier;
        private System.Windows.Forms.Label labelSupplierName;
        private System.Windows.Forms.TextBox textBoxSupplierName;
        private System.Windows.Forms.TextBox textBoxSupplierIdHidden;
        private System.Windows.Forms.Panel panelScannerItemBar;
        private System.Windows.Forms.Label labelBarcodePrompt;
        private System.Windows.Forms.TextBox textBoxProductBarcode;
        private System.Windows.Forms.Button buttonSearchProduct;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.TextBox textBoxProductName;
        private System.Windows.Forms.Label labelBuyPrice;
        private System.Windows.Forms.TextBox textBoxBuyPrice;
        private System.Windows.Forms.Label labelQuantityPrompt;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.Button buttonAddPurchaseItem;
        private System.Windows.Forms.Button buttonRemovePurchaseItem;
        private System.Windows.Forms.DataGridView dataGridViewPurchaseCart;
        private System.Windows.Forms.Panel panelRightSummary;
        private System.Windows.Forms.Label labelSummaryTitle;
        private System.Windows.Forms.Label labelPaymentMethod;
        private System.Windows.Forms.ComboBox comboBoxPaymentMethod;
        private System.Windows.Forms.Label labelTotalPrompt;
        private System.Windows.Forms.TextBox textBoxTotalAmount;
        private System.Windows.Forms.Button buttonRegisterPurchase;
        private System.Windows.Forms.PictureBox pictureBoxWebcamPreview;
        private System.Windows.Forms.Button buttonToggleScannerCamera;
        private System.Windows.Forms.PictureBox picIconSearchSupplier;
        private System.Windows.Forms.PictureBox picIconSearchProduct;
        private System.Windows.Forms.PictureBox picIconAddPurchaseItem;
        private System.Windows.Forms.PictureBox picIconRemovePurchaseItem;
        private System.Windows.Forms.PictureBox picIconRegisterPurchase;
        private System.Windows.Forms.PictureBox picIconToggleScannerCamera;
    }
}
