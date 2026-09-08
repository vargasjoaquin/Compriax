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
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlLeftWork = new Panel();
            dgvCart = new DataGridView();
            pnlScannerBar = new Panel();
            lblCodProd = new Label();
            txtProductCode = new TextBox();
            btnSearchProduct = new Button();
            lblProdName = new Label();
            txtProductName = new TextBox();
            lblPreCom = new Label();
            txtPriceBuy = new TextBox();
            lblCant = new Label();
            numQuantity = new NumericUpDown();
            btnAddItem = new Button();
            btnRemoveItem = new Button();
            gbSaleInfo = new Panel();
            lblFecha = new Label();
            txtDate = new TextBox();
            lblTipoDoc = new Label();
            cboDocType = new ComboBox();
            lblInvoice = new Label();
            txtInvoiceNumber = new TextBox();
            lblDni = new Label();
            txtSupplierDoc = new TextBox();
            btnSearchSupplier = new Button();
            lblRazonSocial = new Label();
            txtSupplierName = new TextBox();
            txtIdProveedor = new TextBox();
            pnlRightSummary = new Panel();
            lblSummaryTitle = new Label();
            lblPaymentMethod = new Label();
            cboPaymentMethod = new ComboBox();
            lblTotalLabel = new Label();
            txtTotalPay = new TextBox();
            btnRegister = new Button();
            picWebcam = new PictureBox();
            btnToggleCam = new Button();
            pnlHeader.SuspendLayout();
            pnlLeftWork.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            pnlScannerBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            gbSaleInfo.SuspendLayout();
            pnlRightSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picWebcam).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(15, 23, 42);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1350, 56);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(16, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(551, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "INGRESO DE MERCADERÍA / COMPRA DE STOCK";
            // 
            // pnlLeftWork
            // 
            pnlLeftWork.BackColor = Color.FromArgb(248, 250, 252);
            pnlLeftWork.Controls.Add(dgvCart);
            pnlLeftWork.Controls.Add(pnlScannerBar);
            pnlLeftWork.Controls.Add(gbSaleInfo);
            pnlLeftWork.Dock = DockStyle.Fill;
            pnlLeftWork.Location = new Point(0, 56);
            pnlLeftWork.Name = "pnlLeftWork";
            pnlLeftWork.Padding = new Padding(16, 12, 8, 16);
            pnlLeftWork.Size = new Size(990, 694);
            pnlLeftWork.TabIndex = 1;
            // 
            // dgvCart
            // 
            dgvCart.BackgroundColor = Color.White;
            dgvCart.BorderStyle = BorderStyle.None;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Dock = DockStyle.Fill;
            dgvCart.Location = new Point(16, 198);
            dgvCart.Name = "dgvCart";
            dgvCart.RowHeadersWidth = 51;
            dgvCart.Size = new Size(966, 480);
            dgvCart.TabIndex = 2;
            // 
            // pnlScannerBar
            // 
            pnlScannerBar.BackColor = Color.White;
            pnlScannerBar.Controls.Add(lblCodProd);
            pnlScannerBar.Controls.Add(txtProductCode);
            pnlScannerBar.Controls.Add(btnSearchProduct);
            pnlScannerBar.Controls.Add(lblProdName);
            pnlScannerBar.Controls.Add(txtProductName);
            pnlScannerBar.Controls.Add(lblPreCom);
            pnlScannerBar.Controls.Add(txtPriceBuy);
            pnlScannerBar.Controls.Add(lblCant);
            pnlScannerBar.Controls.Add(numQuantity);
            pnlScannerBar.Controls.Add(btnAddItem);
            pnlScannerBar.Controls.Add(btnRemoveItem);
            pnlScannerBar.Dock = DockStyle.Top;
            pnlScannerBar.Location = new Point(16, 97);
            pnlScannerBar.Name = "pnlScannerBar";
            pnlScannerBar.Size = new Size(966, 101);
            pnlScannerBar.TabIndex = 1;
            // 
            // lblCodProd
            // 
            lblCodProd.AutoSize = true;
            lblCodProd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCodProd.Location = new Point(10, 22);
            lblCodProd.Name = "lblCodProd";
            lblCodProd.Size = new Size(93, 20);
            lblCodProd.TabIndex = 0;
            lblCodProd.Text = "Cod. Barras:";
            // 
            // txtProductCode
            // 
            txtProductCode.BorderStyle = BorderStyle.FixedSingle;
            txtProductCode.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtProductCode.Location = new Point(10, 45);
            txtProductCode.Name = "txtProductCode";
            txtProductCode.Size = new Size(150, 30);
            txtProductCode.TabIndex = 1;
            // 
            // btnSearchProduct
            // 
            btnSearchProduct.FlatStyle = FlatStyle.Flat;
            btnSearchProduct.Location = new Point(166, 36);
            btnSearchProduct.Name = "btnSearchProduct";
            btnSearchProduct.Size = new Size(47, 47);
            btnSearchProduct.TabIndex = 2;
            btnSearchProduct.Text = "";
            btnSearchProduct.UseVisualStyleBackColor = true;
            // 
            // lblProdName
            // 
            lblProdName.AutoSize = true;
            lblProdName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProdName.Location = new Point(219, 22);
            lblProdName.Name = "lblProdName";
            lblProdName.Size = new Size(77, 20);
            lblProdName.TabIndex = 3;
            lblProdName.Text = "Producto:";
            // 
            // txtProductName
            // 
            txtProductName.BorderStyle = BorderStyle.FixedSingle;
            txtProductName.Font = new Font("Segoe UI", 10F);
            txtProductName.Location = new Point(219, 45);
            txtProductName.Name = "txtProductName";
            txtProductName.ReadOnly = true;
            txtProductName.Size = new Size(200, 30);
            txtProductName.TabIndex = 4;
            // 
            // lblPreCom
            // 
            lblPreCom.AutoSize = true;
            lblPreCom.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPreCom.Location = new Point(424, 22);
            lblPreCom.Name = "lblPreCom";
            lblPreCom.Size = new Size(125, 20);
            lblPreCom.TabIndex = 5;
            lblPreCom.Text = "$ Costo Compra:";
            // 
            // txtPriceBuy
            // 
            txtPriceBuy.BorderStyle = BorderStyle.FixedSingle;
            txtPriceBuy.Font = new Font("Segoe UI", 10F);
            txtPriceBuy.Location = new Point(425, 45);
            txtPriceBuy.Name = "txtPriceBuy";
            txtPriceBuy.Size = new Size(126, 30);
            txtPriceBuy.TabIndex = 6;
            // 
            // lblCant
            // 
            lblCant.AutoSize = true;
            lblCant.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCant.Location = new Point(575, 22);
            lblCant.Name = "lblCant";
            lblCant.Size = new Size(75, 20);
            lblCant.TabIndex = 7;
            lblCant.Text = "Cantidad:";
            // 
            // numQuantity
            // 
            numQuantity.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            numQuantity.Location = new Point(575, 45);
            numQuantity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(80, 30);
            numQuantity.TabIndex = 8;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAddItem
            // 
            btnAddItem.BackColor = Color.FromArgb(2, 132, 199);
            btnAddItem.FlatAppearance.BorderSize = 0;
            btnAddItem.FlatStyle = FlatStyle.Flat;
            btnAddItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddItem.ForeColor = Color.White;
            btnAddItem.Location = new Point(665, 25);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(136, 56);
            btnAddItem.TabIndex = 9;
            btnAddItem.Text = "AGREGAR";
            btnAddItem.UseVisualStyleBackColor = false;
            // 
            // btnRemoveItem
            // 
            btnRemoveItem.BackColor = Color.FromArgb(239, 68, 68);
            btnRemoveItem.FlatAppearance.BorderSize = 0;
            btnRemoveItem.FlatStyle = FlatStyle.Flat;
            btnRemoveItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRemoveItem.ForeColor = Color.White;
            btnRemoveItem.Location = new Point(807, 25);
            btnRemoveItem.Name = "btnRemoveItem";
            btnRemoveItem.Size = new Size(141, 56);
            btnRemoveItem.TabIndex = 10;
            btnRemoveItem.Text = "QUITAR [SUPR]";
            btnRemoveItem.UseVisualStyleBackColor = false;
            // 
            // gbSaleInfo
            // 
            gbSaleInfo.BackColor = Color.White;
            gbSaleInfo.Controls.Add(lblFecha);
            gbSaleInfo.Controls.Add(txtDate);
            gbSaleInfo.Controls.Add(lblTipoDoc);
            gbSaleInfo.Controls.Add(cboDocType);
            gbSaleInfo.Controls.Add(lblInvoice);
            gbSaleInfo.Controls.Add(txtInvoiceNumber);
            gbSaleInfo.Controls.Add(lblDni);
            gbSaleInfo.Controls.Add(txtSupplierDoc);
            gbSaleInfo.Controls.Add(btnSearchSupplier);
            gbSaleInfo.Controls.Add(lblRazonSocial);
            gbSaleInfo.Controls.Add(txtSupplierName);
            gbSaleInfo.Controls.Add(txtIdProveedor);
            gbSaleInfo.Dock = DockStyle.Top;
            gbSaleInfo.Location = new Point(16, 12);
            gbSaleInfo.Name = "gbSaleInfo";
            gbSaleInfo.Size = new Size(966, 85);
            gbSaleInfo.TabIndex = 0;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFecha.Location = new Point(12, 12);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(53, 20);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "Fecha:";
            // 
            // txtDate
            // 
            txtDate.BorderStyle = BorderStyle.FixedSingle;
            txtDate.Font = new Font("Segoe UI", 10F);
            txtDate.Location = new Point(12, 32);
            txtDate.Name = "txtDate";
            txtDate.ReadOnly = true;
            txtDate.Size = new Size(100, 30);
            txtDate.TabIndex = 1;
            // 
            // lblTipoDoc
            // 
            lblTipoDoc.AutoSize = true;
            lblTipoDoc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTipoDoc.Location = new Point(122, 12);
            lblTipoDoc.Name = "lblTipoDoc";
            lblTipoDoc.Size = new Size(75, 20);
            lblTipoDoc.TabIndex = 2;
            lblTipoDoc.Text = "Tipo Doc:";
            // 
            // cboDocType
            // 
            cboDocType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDocType.Font = new Font("Segoe UI", 10F);
            cboDocType.Location = new Point(122, 32);
            cboDocType.Name = "cboDocType";
            cboDocType.Size = new Size(120, 31);
            cboDocType.TabIndex = 3;
            // 
            // lblInvoice
            // 
            lblInvoice.AutoSize = true;
            lblInvoice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblInvoice.Location = new Point(252, 12);
            lblInvoice.Name = "lblInvoice";
            lblInvoice.Size = new Size(87, 20);
            lblInvoice.TabIndex = 4;
            lblInvoice.Text = "N° Factura:";
            // 
            // txtInvoiceNumber
            // 
            txtInvoiceNumber.BorderStyle = BorderStyle.FixedSingle;
            txtInvoiceNumber.Font = new Font("Segoe UI", 10F);
            txtInvoiceNumber.Location = new Point(252, 32);
            txtInvoiceNumber.Name = "txtInvoiceNumber";
            txtInvoiceNumber.Size = new Size(130, 30);
            txtInvoiceNumber.TabIndex = 5;
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDni.Location = new Point(395, 12);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(124, 20);
            lblDni.TabIndex = 6;
            lblDni.Text = "CUIT Proveedor:";
            // 
            // txtSupplierDoc
            // 
            txtSupplierDoc.BorderStyle = BorderStyle.FixedSingle;
            txtSupplierDoc.Font = new Font("Segoe UI", 10F);
            txtSupplierDoc.Location = new Point(395, 32);
            txtSupplierDoc.Name = "txtSupplierDoc";
            txtSupplierDoc.Size = new Size(130, 30);
            txtSupplierDoc.TabIndex = 7;
            // 
            // btnSearchSupplier
            // 
            btnSearchSupplier.FlatStyle = FlatStyle.Flat;
            btnSearchSupplier.Location = new Point(531, 26);
            btnSearchSupplier.Name = "btnSearchSupplier";
            btnSearchSupplier.Size = new Size(76, 43);
            btnSearchSupplier.TabIndex = 8;
            btnSearchSupplier.Text = "";
            btnSearchSupplier.UseVisualStyleBackColor = true;
            // 
            // lblRazonSocial
            // 
            lblRazonSocial.AutoSize = true;
            lblRazonSocial.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRazonSocial.Location = new Point(613, 12);
            lblRazonSocial.Name = "lblRazonSocial";
            lblRazonSocial.Size = new Size(100, 20);
            lblRazonSocial.TabIndex = 9;
            lblRazonSocial.Text = "Razón Social:";
            // 
            // txtSupplierName
            // 
            txtSupplierName.BorderStyle = BorderStyle.FixedSingle;
            txtSupplierName.Font = new Font("Segoe UI", 10F);
            txtSupplierName.Location = new Point(613, 34);
            txtSupplierName.Name = "txtSupplierName";
            txtSupplierName.ReadOnly = true;
            txtSupplierName.Size = new Size(306, 30);
            txtSupplierName.TabIndex = 10;
            // 
            // txtIdProveedor
            // 
            txtIdProveedor.Location = new Point(894, 4);
            txtIdProveedor.Name = "txtIdProveedor";
            txtIdProveedor.Size = new Size(25, 27);
            txtIdProveedor.TabIndex = 11;
            txtIdProveedor.Visible = false;
            // 
            // pnlRightSummary
            // 
            pnlRightSummary.BackColor = Color.White;
            pnlRightSummary.Controls.Add(lblSummaryTitle);
            pnlRightSummary.Controls.Add(lblPaymentMethod);
            pnlRightSummary.Controls.Add(cboPaymentMethod);
            pnlRightSummary.Controls.Add(lblTotalLabel);
            pnlRightSummary.Controls.Add(txtTotalPay);
            pnlRightSummary.Controls.Add(btnRegister);
            pnlRightSummary.Controls.Add(picWebcam);
            pnlRightSummary.Controls.Add(btnToggleCam);
            pnlRightSummary.Dock = DockStyle.Right;
            pnlRightSummary.Location = new Point(990, 56);
            pnlRightSummary.Name = "pnlRightSummary";
            pnlRightSummary.Padding = new Padding(16);
            pnlRightSummary.Size = new Size(360, 694);
            pnlRightSummary.TabIndex = 2;
            // 
            // lblSummaryTitle
            // 
            lblSummaryTitle.AutoSize = true;
            lblSummaryTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblSummaryTitle.Location = new Point(16, 16);
            lblSummaryTitle.Name = "lblSummaryTitle";
            lblSummaryTitle.Size = new Size(245, 30);
            lblSummaryTitle.TabIndex = 0;
            lblSummaryTitle.Text = "TOTAL DE LA COMPRA";
            // 
            // lblPaymentMethod
            // 
            lblPaymentMethod.AutoSize = true;
            lblPaymentMethod.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPaymentMethod.Location = new Point(16, 56);
            lblPaymentMethod.Name = "lblPaymentMethod";
            lblPaymentMethod.Size = new Size(117, 20);
            lblPaymentMethod.TabIndex = 1;
            lblPaymentMethod.Text = "Medio de Pago:";
            // 
            // cboPaymentMethod
            // 
            cboPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaymentMethod.Font = new Font("Segoe UI", 10F);
            cboPaymentMethod.Location = new Point(16, 76);
            cboPaymentMethod.Name = "cboPaymentMethod";
            cboPaymentMethod.Size = new Size(328, 31);
            cboPaymentMethod.TabIndex = 2;
            // 
            // lblTotalLabel
            // 
            lblTotalLabel.AutoSize = true;
            lblTotalLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTotalLabel.Location = new Point(16, 120);
            lblTotalLabel.Name = "lblTotalLabel";
            lblTotalLabel.Size = new Size(153, 21);
            lblTotalLabel.TabIndex = 3;
            lblTotalLabel.Text = "Total de la Factura:";
            // 
            // txtTotalPay
            // 
            txtTotalPay.BackColor = Color.FromArgb(248, 250, 252);
            txtTotalPay.BorderStyle = BorderStyle.FixedSingle;
            txtTotalPay.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            txtTotalPay.ForeColor = Color.FromArgb(16, 185, 129);
            txtTotalPay.Location = new Point(16, 142);
            txtTotalPay.Name = "txtTotalPay";
            txtTotalPay.ReadOnly = true;
            txtTotalPay.Size = new Size(328, 47);
            txtTotalPay.TabIndex = 4;
            txtTotalPay.Text = "$ 0,00";
            txtTotalPay.TextAlign = HorizontalAlignment.Right;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(16, 185, 129);
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(16, 200);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(328, 60);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "REGISTRAR COMPRA";
            btnRegister.UseVisualStyleBackColor = false;
            // 
            // picWebcam
            // 
            picWebcam.BackColor = Color.Black;
            picWebcam.BorderStyle = BorderStyle.FixedSingle;
            picWebcam.Location = new Point(16, 280);
            picWebcam.Name = "picWebcam";
            picWebcam.Size = new Size(328, 160);
            picWebcam.SizeMode = PictureBoxSizeMode.Zoom;
            picWebcam.TabIndex = 6;
            picWebcam.TabStop = false;
            // 
            // btnToggleCam
            // 
            btnToggleCam.FlatStyle = FlatStyle.Flat;
            btnToggleCam.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnToggleCam.Location = new Point(16, 450);
            btnToggleCam.Name = "btnToggleCam";
            btnToggleCam.Size = new Size(328, 36);
            btnToggleCam.TabIndex = 7;
            btnToggleCam.Text = "ENCENDER CÁMARA";
            btnToggleCam.UseVisualStyleBackColor = true;
            // 
            // FormPurchases
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1350, 750);
            Controls.Add(pnlLeftWork);
            Controls.Add(pnlRightSummary);
            Controls.Add(pnlHeader);
            Name = "FormPurchases";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de Compras";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlLeftWork.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            pnlScannerBar.ResumeLayout(false);
            pnlScannerBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            gbSaleInfo.ResumeLayout(false);
            gbSaleInfo.PerformLayout();
            pnlRightSummary.ResumeLayout(false);
            pnlRightSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picWebcam).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlLeftWork;
        private System.Windows.Forms.Panel gbSaleInfo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.ComboBox cboDocType;
        private System.Windows.Forms.Label lblInvoice;
        private System.Windows.Forms.TextBox txtInvoiceNumber;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtSupplierDoc;
        private System.Windows.Forms.Button btnSearchSupplier;
        private System.Windows.Forms.Label lblRazonSocial;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.TextBox txtIdProveedor;
        private System.Windows.Forms.Panel pnlScannerBar;
        private System.Windows.Forms.Label lblCodProd;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Button btnSearchProduct;
        private System.Windows.Forms.Label lblProdName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblPreCom;
        private System.Windows.Forms.TextBox txtPriceBuy;
        private System.Windows.Forms.Label lblCant;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Panel pnlRightSummary;
        private System.Windows.Forms.Label lblSummaryTitle;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.ComboBox cboPaymentMethod;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.TextBox txtTotalPay;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.PictureBox picWebcam;
        private System.Windows.Forms.Button btnToggleCam;
    }
}