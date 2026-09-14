namespace CompriaxSystem.WinFormsUI
{
    partial class FormProducts
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
            btnGenerateLabel = new Button();
            btnPrintStock = new Button();
            pnlMain = new Panel();
            dgvProducts = new DataGridView();
            groupEdit = new Panel();
            picProductImage = new PictureBox();
            btnBrowseImage = new Button();
            btnClearImage = new Button();
            lblBarcode = new Label();
            txtBarcode = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            lblDesc = new Label();
            txtDescription = new TextBox();
            lblCategory = new Label();
            cboCategory = new ComboBox();
            lblBrand = new Label();
            cboBrand = new ComboBox();
            lblBuyPrice = new Label();
            numBuyPrice = new NumericUpDown();
            lblSellPrice = new Label();
            numSellPrice = new NumericUpDown();
            lblStock = new Label();
            numStock = new NumericUpDown();
            btnSave = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            pnlHeader.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            groupEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picProductImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBuyPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSellPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            SuspendLayout();

            // pnlHeader
            pnlHeader.BackColor = Color.FromArgb(15, 23, 42);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnGenerateLabel);
            pnlHeader.Controls.Add(btnPrintStock);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1260, 74);
            pnlHeader.TabIndex = 0;

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(16, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(492, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "CATÁLOGO DE PRODUCTOS E INVENTARIO";

            // btnGenerateLabel
            btnGenerateLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGenerateLabel.BackColor = Color.FromArgb(16, 185, 129);
            btnGenerateLabel.FlatAppearance.BorderSize = 0;
            btnGenerateLabel.FlatStyle = FlatStyle.Flat;
            btnGenerateLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnGenerateLabel.ForeColor = Color.White;
            btnGenerateLabel.Location = new Point(818, 10);
            btnGenerateLabel.Name = "btnGenerateLabel";
            btnGenerateLabel.Size = new Size(200, 54);
            btnGenerateLabel.TabIndex = 1;
            btnGenerateLabel.Text = "IMPRIMIR ETIQUETA";
            btnGenerateLabel.UseVisualStyleBackColor = false;

            // btnPrintStock
            btnPrintStock.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrintStock.BackColor = Color.FromArgb(2, 132, 199);
            btnPrintStock.FlatAppearance.BorderSize = 0;
            btnPrintStock.FlatStyle = FlatStyle.Flat;
            btnPrintStock.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnPrintStock.ForeColor = Color.White;
            btnPrintStock.Location = new Point(1028, 10);
            btnPrintStock.Name = "btnPrintStock";
            btnPrintStock.Size = new Size(202, 58);
            btnPrintStock.TabIndex = 1;
            btnPrintStock.Text = "EXPORTAR PDF";
            btnPrintStock.UseVisualStyleBackColor = false;

            // pnlMain
            pnlMain.BackColor = Color.FromArgb(248, 250, 252);
            pnlMain.Controls.Add(dgvProducts);
            pnlMain.Controls.Add(groupEdit);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 74);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(16, 12, 16, 16);
            pnlMain.Size = new Size(1260, 676);
            pnlMain.TabIndex = 1;

            // dgvProducts
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.BorderStyle = BorderStyle.None;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Location = new Point(16, 262);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.Size = new Size(1228, 398);
            dgvProducts.TabIndex = 1;

            // groupEdit
            groupEdit.BackColor = Color.White;
            groupEdit.Controls.Add(picProductImage);
            groupEdit.Controls.Add(btnBrowseImage);
            groupEdit.Controls.Add(btnClearImage);
            groupEdit.Controls.Add(lblBarcode);
            groupEdit.Controls.Add(txtBarcode);
            groupEdit.Controls.Add(lblName);
            groupEdit.Controls.Add(txtName);
            groupEdit.Controls.Add(lblDesc);
            groupEdit.Controls.Add(txtDescription);
            groupEdit.Controls.Add(lblCategory);
            groupEdit.Controls.Add(cboCategory);
            groupEdit.Controls.Add(lblBrand);
            groupEdit.Controls.Add(cboBrand);
            groupEdit.Controls.Add(lblBuyPrice);
            groupEdit.Controls.Add(numBuyPrice);
            groupEdit.Controls.Add(lblSellPrice);
            groupEdit.Controls.Add(numSellPrice);
            groupEdit.Controls.Add(lblStock);
            groupEdit.Controls.Add(numStock);
            groupEdit.Controls.Add(btnSave);
            groupEdit.Controls.Add(btnEdit);
            groupEdit.Controls.Add(btnDelete);
            groupEdit.Dock = DockStyle.Top;
            groupEdit.Location = new Point(16, 12);
            groupEdit.Name = "groupEdit";
            groupEdit.Size = new Size(1228, 250);
            groupEdit.TabIndex = 0;

            // picProductImage
            picProductImage.BackColor = Color.FromArgb(248, 250, 252);
            picProductImage.BorderStyle = BorderStyle.FixedSingle;
            picProductImage.Location = new Point(11, 16);
            picProductImage.Name = "picProductImage";
            picProductImage.Size = new Size(170, 159);
            picProductImage.SizeMode = PictureBoxSizeMode.Zoom;
            picProductImage.TabIndex = 0;
            picProductImage.TabStop = false;

            // btnBrowseImage
            btnBrowseImage.BackColor = Color.FromArgb(2, 132, 199);
            btnBrowseImage.FlatAppearance.BorderSize = 0;
            btnBrowseImage.FlatStyle = FlatStyle.Flat;
            btnBrowseImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBrowseImage.ForeColor = Color.White;
            btnBrowseImage.Location = new Point(11, 187);
            btnBrowseImage.Name = "btnBrowseImage";
            btnBrowseImage.Size = new Size(95, 48);
            btnBrowseImage.TabIndex = 1;
            btnBrowseImage.Text = "FOTO";
            btnBrowseImage.UseVisualStyleBackColor = false;

            // btnClearImage
            btnClearImage.BackColor = Color.FromArgb(239, 68, 68);
            btnClearImage.FlatAppearance.BorderSize = 0;
            btnClearImage.FlatStyle = FlatStyle.Flat;
            btnClearImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClearImage.ForeColor = Color.White;
            btnClearImage.Location = new Point(112, 187);
            btnClearImage.Name = "btnClearImage";
            btnClearImage.Size = new Size(69, 48);
            btnClearImage.TabIndex = 2;
            btnClearImage.Text = "✕";
            btnClearImage.UseVisualStyleBackColor = false;

            // lblBarcode
            lblBarcode.AutoSize = true;
            lblBarcode.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblBarcode.Location = new Point(187, 13);
            lblBarcode.Name = "lblBarcode";
            lblBarcode.Size = new Size(143, 21);
            lblBarcode.TabIndex = 3;
            lblBarcode.Text = "Código de Barras:";

            // txtBarcode
            txtBarcode.BorderStyle = BorderStyle.FixedSingle;
            txtBarcode.Font = new Font("Segoe UI", 10F);
            txtBarcode.Location = new Point(187, 37);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(289, 30);
            txtBarcode.TabIndex = 4;

            // lblName
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblName.Location = new Point(187, 82);
            lblName.Name = "lblName";
            lblName.Size = new Size(179, 21);
            lblName.TabIndex = 5;
            lblName.Text = "Nombre del Producto:";

            // txtName
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(187, 106);
            txtName.Name = "txtName";
            txtName.Size = new Size(289, 30);
            txtName.TabIndex = 6;

            // lblDesc
            lblDesc.AutoSize = true;
            lblDesc.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDesc.Location = new Point(187, 154);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(104, 21);
            lblDesc.TabIndex = 7;
            lblDesc.Text = "Descripción:";

            // txtDescription
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(187, 178);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(505, 57);
            txtDescription.TabIndex = 8;

            // lblCategory
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCategory.Location = new Point(510, 12);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(88, 21);
            lblCategory.TabIndex = 9;
            lblCategory.Text = "Categoría:";

            // cboCategory
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Font = new Font("Segoe UI", 10F);
            cboCategory.Location = new Point(510, 36);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(200, 31);
            cboCategory.TabIndex = 10;

            // lblBrand
            lblBrand.AutoSize = true;
            lblBrand.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblBrand.Location = new Point(510, 82);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(61, 21);
            lblBrand.TabIndex = 11;
            lblBrand.Text = "Marca:";

            // cboBrand
            cboBrand.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBrand.Font = new Font("Segoe UI", 10F);
            cboBrand.Location = new Point(510, 106);
            cboBrand.Name = "cboBrand";
            cboBrand.Size = new Size(200, 31);
            cboBrand.TabIndex = 12;

            // lblBuyPrice
            lblBuyPrice.AutoSize = true;
            lblBuyPrice.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblBuyPrice.Location = new Point(740, 12);
            lblBuyPrice.Name = "lblBuyPrice";
            lblBuyPrice.Size = new Size(151, 21);
            lblBuyPrice.TabIndex = 13;
            lblBuyPrice.Text = "Precio Compra ($):";

            // numBuyPrice
            numBuyPrice.DecimalPlaces = 2;
            numBuyPrice.Font = new Font("Segoe UI", 10F);
            numBuyPrice.Location = new Point(740, 36);
            numBuyPrice.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numBuyPrice.Name = "numBuyPrice";
            numBuyPrice.Size = new Size(171, 30);
            numBuyPrice.TabIndex = 14;

            // lblSellPrice
            lblSellPrice.AutoSize = true;
            lblSellPrice.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSellPrice.Location = new Point(740, 83);
            lblSellPrice.Name = "lblSellPrice";
            lblSellPrice.Size = new Size(135, 21);
            lblSellPrice.TabIndex = 15;
            lblSellPrice.Text = "Precio Venta ($):";

            // numSellPrice
            numSellPrice.DecimalPlaces = 2;
            numSellPrice.Font = new Font("Segoe UI", 10F);
            numSellPrice.Location = new Point(740, 107);
            numSellPrice.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numSellPrice.Name = "numSellPrice";
            numSellPrice.Size = new Size(171, 30);
            numSellPrice.TabIndex = 16;

            // lblStock
            lblStock.AutoSize = true;
            lblStock.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblStock.Location = new Point(740, 154);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(109, 21);
            lblStock.TabIndex = 17;
            lblStock.Text = "Stock Actual:";

            // numStock
            numStock.Font = new Font("Segoe UI", 10F);
            numStock.Location = new Point(740, 178);
            numStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numStock.Name = "numStock";
            numStock.Size = new Size(171, 30);
            numStock.TabIndex = 18;

            // btnSave
            btnSave.BackColor = Color.FromArgb(16, 185, 129);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(957, 12);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(257, 70);
            btnSave.TabIndex = 19;
            btnSave.Text = "GUARDAR";
            btnSave.UseVisualStyleBackColor = false;

            // btnEdit
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEdit.Location = new Point(957, 88);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(257, 68);
            btnEdit.TabIndex = 20;
            btnEdit.Text = "EDITAR";
            btnEdit.UseVisualStyleBackColor = true;

            // btnDelete
            btnDelete.BackColor = Color.FromArgb(239, 68, 68);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(957, 165);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(257, 70);
            btnDelete.TabIndex = 21;
            btnDelete.Text = "DESACTIVAR";
            btnDelete.UseVisualStyleBackColor = false;

            // FormProducts
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1260, 750);
            Controls.Add(pnlMain);
            Controls.Add(pnlHeader);
            Name = "FormProducts";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administración de Productos";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            groupEdit.ResumeLayout(false);
            groupEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picProductImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBuyPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSellPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnGenerateLabel;
        private System.Windows.Forms.Button btnPrintStock;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel groupEdit;
        private System.Windows.Forms.PictureBox picProductImage;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.Button btnClearImage;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.ComboBox cboBrand;
        private System.Windows.Forms.Label lblBuyPrice;
        private System.Windows.Forms.NumericUpDown numBuyPrice;
        private System.Windows.Forms.Label lblSellPrice;
        private System.Windows.Forms.NumericUpDown numSellPrice;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.NumericUpDown numStock;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvProducts;
    }
}