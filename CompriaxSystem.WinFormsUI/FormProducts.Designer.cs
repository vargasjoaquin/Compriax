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
            picIconOpenLabelDesigner = new PictureBox();
            picIconExportPdf = new PictureBox();
            picIconBrowsePhoto = new PictureBox();
            picIconSave = new PictureBox();
            picIconEdit = new PictureBox();
            picIconDelete = new PictureBox();
            panelHeader = new Panel();
            labelTitle = new Label();
            buttonOpenLabelDesigner = new Button();
            buttonExportPdf = new Button();
            panelMain = new Panel();
            dataGridViewProducts = new DataGridView();
            panelProductForm = new Panel();
            pictureBoxProductPhoto = new PictureBox();
            buttonBrowsePhoto = new Button();
            buttonClearPhoto = new Button();
            labelBarcode = new Label();
            textBoxBarcode = new TextBox();
            labelProductName = new Label();
            textBoxProductName = new TextBox();
            labelDescription = new Label();
            textBoxDescription = new TextBox();
            labelCategory = new Label();
            comboBoxCategory = new ComboBox();
            labelBrand = new Label();
            comboBoxBrand = new ComboBox();
            labelBuyPrice = new Label();
            numericUpDownBuyPrice = new NumericUpDown();
            labelSellPrice = new Label();
            numericUpDownSellPrice = new NumericUpDown();
            labelCurrentStock = new Label();
            numericUpDownCurrentStock = new NumericUpDown();
            buttonSave = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)picIconOpenLabelDesigner).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconExportPdf).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconBrowsePhoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconSave).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconEdit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconDelete).BeginInit();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).BeginInit();
            panelProductForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProductPhoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownBuyPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSellPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCurrentStock).BeginInit();
            SuspendLayout();
            // 
            // picIconOpenLabelDesigner
            // 
            picIconOpenLabelDesigner.BackColor = Color.FromArgb(16, 185, 129);
            picIconOpenLabelDesigner.Cursor = Cursors.Hand;
            picIconOpenLabelDesigner.Image = Resources._082_imprimir;
            picIconOpenLabelDesigner.Location = new Point(790, 10);
            picIconOpenLabelDesigner.Name = "picIconOpenLabelDesigner";
            picIconOpenLabelDesigner.Size = new Size(35, 54);
            picIconOpenLabelDesigner.SizeMode = PictureBoxSizeMode.Zoom;
            picIconOpenLabelDesigner.TabIndex = 99;
            picIconOpenLabelDesigner.TabStop = false;
            // 
            // picIconExportPdf
            // 
            picIconExportPdf.BackColor = Color.FromArgb(2, 132, 199);
            picIconExportPdf.Cursor = Cursors.Hand;
            picIconExportPdf.Image = Resources._085_exportar_pdf;
            picIconExportPdf.Location = new Point(1028, 10);
            picIconExportPdf.Name = "picIconExportPdf";
            picIconExportPdf.Size = new Size(42, 58);
            picIconExportPdf.SizeMode = PictureBoxSizeMode.Zoom;
            picIconExportPdf.TabIndex = 99;
            picIconExportPdf.TabStop = false;
            // 
            // picIconBrowsePhoto
            // 
            picIconBrowsePhoto.BackColor = Color.FromArgb(2, 132, 199);
            picIconBrowsePhoto.Cursor = Cursors.Hand;
            picIconBrowsePhoto.Image = Resources._086_capturar_foto;
            picIconBrowsePhoto.Location = new Point(11, 187);
            picIconBrowsePhoto.Name = "picIconBrowsePhoto";
            picIconBrowsePhoto.Size = new Size(28, 48);
            picIconBrowsePhoto.SizeMode = PictureBoxSizeMode.Zoom;
            picIconBrowsePhoto.TabIndex = 99;
            picIconBrowsePhoto.TabStop = false;
            // 
            // picIconSave
            // 
            picIconSave.BackColor = Color.FromArgb(16, 185, 129);
            picIconSave.Cursor = Cursors.Hand;
            picIconSave.Image = Resources._077_guardar;
            picIconSave.Location = new Point(995, 12);
            picIconSave.Name = "picIconSave";
            picIconSave.Size = new Size(44, 70);
            picIconSave.SizeMode = PictureBoxSizeMode.Zoom;
            picIconSave.TabIndex = 99;
            picIconSave.TabStop = false;
            // 
            // picIconEdit
            // 
            picIconEdit.BackColor = Color.FromArgb(255, 255, 255);
            picIconEdit.Cursor = Cursors.Hand;
            picIconEdit.Image = Resources._078_editar;
            picIconEdit.Location = new Point(1012, 99);
            picIconEdit.Name = "picIconEdit";
            picIconEdit.Size = new Size(47, 49);
            picIconEdit.SizeMode = PictureBoxSizeMode.Zoom;
            picIconEdit.TabIndex = 99;
            picIconEdit.TabStop = false;
            // 
            // picIconDelete
            // 
            picIconDelete.BackColor = Color.FromArgb(239, 68, 68);
            picIconDelete.Cursor = Cursors.Hand;
            picIconDelete.Image = Resources._079_eliminar;
            picIconDelete.Location = new Point(1003, 178);
            picIconDelete.Name = "picIconDelete";
            picIconDelete.Size = new Size(43, 45);
            picIconDelete.SizeMode = PictureBoxSizeMode.Zoom;
            picIconDelete.TabIndex = 99;
            picIconDelete.TabStop = false;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Controls.Add(picIconOpenLabelDesigner);
            panelHeader.Controls.Add(buttonOpenLabelDesigner);
            panelHeader.Controls.Add(picIconExportPdf);
            panelHeader.Controls.Add(buttonExportPdf);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1260, 74);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 22);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(455, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "GESTIÓN DE PRODUCTOS E INVENTARIO";
            // 
            // buttonOpenLabelDesigner
            // 
            buttonOpenLabelDesigner.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonOpenLabelDesigner.BackColor = Color.FromArgb(16, 185, 129);
            buttonOpenLabelDesigner.FlatAppearance.BorderSize = 0;
            buttonOpenLabelDesigner.FlatStyle = FlatStyle.Flat;
            buttonOpenLabelDesigner.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonOpenLabelDesigner.ForeColor = Color.White;
            buttonOpenLabelDesigner.Location = new Point(790, 10);
            buttonOpenLabelDesigner.Name = "buttonOpenLabelDesigner";
            buttonOpenLabelDesigner.Size = new Size(228, 54);
            buttonOpenLabelDesigner.TabIndex = 1;
            buttonOpenLabelDesigner.Text = "IMPRIMIR ETIQUETA";
            buttonOpenLabelDesigner.UseVisualStyleBackColor = false;
            // 
            // buttonExportPdf
            // 
            buttonExportPdf.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonExportPdf.BackColor = Color.FromArgb(2, 132, 199);
            buttonExportPdf.FlatAppearance.BorderSize = 0;
            buttonExportPdf.FlatStyle = FlatStyle.Flat;
            buttonExportPdf.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonExportPdf.ForeColor = Color.White;
            buttonExportPdf.Location = new Point(1028, 10);
            buttonExportPdf.Name = "buttonExportPdf";
            buttonExportPdf.Size = new Size(202, 58);
            buttonExportPdf.TabIndex = 1;
            buttonExportPdf.Text = "EXPORTAR PDF";
            buttonExportPdf.UseVisualStyleBackColor = false;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(248, 250, 252);
            panelMain.Controls.Add(dataGridViewProducts);
            panelMain.Controls.Add(panelProductForm);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 74);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(16, 12, 16, 16);
            panelMain.Size = new Size(1260, 676);
            panelMain.TabIndex = 1;
            // 
            // dataGridViewProducts
            // 
            dataGridViewProducts.BackgroundColor = Color.White;
            dataGridViewProducts.BorderStyle = BorderStyle.None;
            dataGridViewProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProducts.Dock = DockStyle.Fill;
            dataGridViewProducts.Location = new Point(16, 262);
            dataGridViewProducts.Name = "dataGridViewProducts";
            dataGridViewProducts.RowHeadersWidth = 51;
            dataGridViewProducts.Size = new Size(1228, 398);
            dataGridViewProducts.TabIndex = 1;
            // 
            // panelProductForm
            // 
            panelProductForm.BackColor = Color.White;
            panelProductForm.Controls.Add(pictureBoxProductPhoto);
            panelProductForm.Controls.Add(picIconBrowsePhoto);
            panelProductForm.Controls.Add(buttonBrowsePhoto);
            panelProductForm.Controls.Add(buttonClearPhoto);
            panelProductForm.Controls.Add(labelBarcode);
            panelProductForm.Controls.Add(textBoxBarcode);
            panelProductForm.Controls.Add(labelProductName);
            panelProductForm.Controls.Add(textBoxProductName);
            panelProductForm.Controls.Add(labelDescription);
            panelProductForm.Controls.Add(textBoxDescription);
            panelProductForm.Controls.Add(labelCategory);
            panelProductForm.Controls.Add(comboBoxCategory);
            panelProductForm.Controls.Add(labelBrand);
            panelProductForm.Controls.Add(comboBoxBrand);
            panelProductForm.Controls.Add(labelBuyPrice);
            panelProductForm.Controls.Add(numericUpDownBuyPrice);
            panelProductForm.Controls.Add(labelSellPrice);
            panelProductForm.Controls.Add(numericUpDownSellPrice);
            panelProductForm.Controls.Add(labelCurrentStock);
            panelProductForm.Controls.Add(numericUpDownCurrentStock);
            panelProductForm.Controls.Add(picIconSave);
            panelProductForm.Controls.Add(buttonSave);
            panelProductForm.Controls.Add(picIconEdit);
            panelProductForm.Controls.Add(buttonEdit);
            panelProductForm.Controls.Add(picIconDelete);
            panelProductForm.Controls.Add(buttonDelete);
            panelProductForm.Dock = DockStyle.Top;
            panelProductForm.Location = new Point(16, 12);
            panelProductForm.Name = "panelProductForm";
            panelProductForm.Size = new Size(1228, 250);
            panelProductForm.TabIndex = 0;
            // 
            // pictureBoxProductPhoto
            // 
            pictureBoxProductPhoto.BackColor = Color.FromArgb(248, 250, 252);
            pictureBoxProductPhoto.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxProductPhoto.Location = new Point(11, 16);
            pictureBoxProductPhoto.Name = "pictureBoxProductPhoto";
            pictureBoxProductPhoto.Size = new Size(170, 159);
            pictureBoxProductPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxProductPhoto.TabIndex = 0;
            pictureBoxProductPhoto.TabStop = false;
            // 
            // buttonBrowsePhoto
            // 
            buttonBrowsePhoto.BackColor = Color.FromArgb(2, 132, 199);
            buttonBrowsePhoto.FlatAppearance.BorderSize = 0;
            buttonBrowsePhoto.FlatStyle = FlatStyle.Flat;
            buttonBrowsePhoto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonBrowsePhoto.ForeColor = Color.White;
            buttonBrowsePhoto.Location = new Point(11, 187);
            buttonBrowsePhoto.Name = "buttonBrowsePhoto";
            buttonBrowsePhoto.Size = new Size(95, 48);
            buttonBrowsePhoto.TabIndex = 1;
            buttonBrowsePhoto.Text = "FOTO";
            buttonBrowsePhoto.UseVisualStyleBackColor = false;
            // 
            // buttonClearPhoto
            // 
            buttonClearPhoto.BackColor = Color.FromArgb(239, 68, 68);
            buttonClearPhoto.FlatAppearance.BorderSize = 0;
            buttonClearPhoto.FlatStyle = FlatStyle.Flat;
            buttonClearPhoto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonClearPhoto.ForeColor = Color.White;
            buttonClearPhoto.Location = new Point(112, 187);
            buttonClearPhoto.Name = "buttonClearPhoto";
            buttonClearPhoto.Size = new Size(69, 48);
            buttonClearPhoto.TabIndex = 2;
            buttonClearPhoto.Text = "✕";
            buttonClearPhoto.UseVisualStyleBackColor = false;
            // 
            // labelBarcode
            // 
            labelBarcode.AutoSize = true;
            labelBarcode.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelBarcode.Location = new Point(187, 13);
            labelBarcode.Name = "labelBarcode";
            labelBarcode.Size = new Size(143, 21);
            labelBarcode.TabIndex = 3;
            labelBarcode.Text = "Código de Barras:";
            // 
            // textBoxBarcode
            // 
            textBoxBarcode.BorderStyle = BorderStyle.FixedSingle;
            textBoxBarcode.Font = new Font("Segoe UI", 10F);
            textBoxBarcode.Location = new Point(187, 37);
            textBoxBarcode.Name = "textBoxBarcode";
            textBoxBarcode.Size = new Size(289, 30);
            textBoxBarcode.TabIndex = 4;
            // 
            // labelProductName
            // 
            labelProductName.AutoSize = true;
            labelProductName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelProductName.Location = new Point(187, 82);
            labelProductName.Name = "labelProductName";
            labelProductName.Size = new Size(179, 21);
            labelProductName.TabIndex = 5;
            labelProductName.Text = "Nombre del Producto:";
            // 
            // textBoxProductName
            // 
            textBoxProductName.BorderStyle = BorderStyle.FixedSingle;
            textBoxProductName.Font = new Font("Segoe UI", 10F);
            textBoxProductName.Location = new Point(187, 106);
            textBoxProductName.Name = "textBoxProductName";
            textBoxProductName.Size = new Size(289, 30);
            textBoxProductName.TabIndex = 6;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelDescription.Location = new Point(187, 154);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(104, 21);
            labelDescription.TabIndex = 7;
            labelDescription.Text = "Descripción:";
            // 
            // textBoxDescription
            // 
            textBoxDescription.BorderStyle = BorderStyle.FixedSingle;
            textBoxDescription.Font = new Font("Segoe UI", 10F);
            textBoxDescription.Location = new Point(187, 178);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(505, 57);
            textBoxDescription.TabIndex = 8;
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelCategory.Location = new Point(510, 12);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(88, 21);
            labelCategory.TabIndex = 9;
            labelCategory.Text = "Categoría:";
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategory.Font = new Font("Segoe UI", 10F);
            comboBoxCategory.Location = new Point(510, 36);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(200, 31);
            comboBoxCategory.TabIndex = 10;
            // 
            // labelBrand
            // 
            labelBrand.AutoSize = true;
            labelBrand.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelBrand.Location = new Point(510, 82);
            labelBrand.Name = "labelBrand";
            labelBrand.Size = new Size(61, 21);
            labelBrand.TabIndex = 11;
            labelBrand.Text = "Marca:";
            // 
            // comboBoxBrand
            // 
            comboBoxBrand.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBrand.Font = new Font("Segoe UI", 10F);
            comboBoxBrand.Location = new Point(510, 106);
            comboBoxBrand.Name = "comboBoxBrand";
            comboBoxBrand.Size = new Size(200, 31);
            comboBoxBrand.TabIndex = 12;
            // 
            // labelBuyPrice
            // 
            labelBuyPrice.AutoSize = true;
            labelBuyPrice.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelBuyPrice.Location = new Point(740, 12);
            labelBuyPrice.Name = "labelBuyPrice";
            labelBuyPrice.Size = new Size(151, 21);
            labelBuyPrice.TabIndex = 13;
            labelBuyPrice.Text = "Precio Compra ($):";
            // 
            // numericUpDownBuyPrice
            // 
            numericUpDownBuyPrice.DecimalPlaces = 2;
            numericUpDownBuyPrice.Font = new Font("Segoe UI", 10F);
            numericUpDownBuyPrice.Location = new Point(740, 36);
            numericUpDownBuyPrice.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericUpDownBuyPrice.Name = "numericUpDownBuyPrice";
            numericUpDownBuyPrice.Size = new Size(171, 30);
            numericUpDownBuyPrice.TabIndex = 14;
            // 
            // labelSellPrice
            // 
            labelSellPrice.AutoSize = true;
            labelSellPrice.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelSellPrice.Location = new Point(740, 83);
            labelSellPrice.Name = "labelSellPrice";
            labelSellPrice.Size = new Size(135, 21);
            labelSellPrice.TabIndex = 15;
            labelSellPrice.Text = "Precio Venta ($):";
            // 
            // numericUpDownSellPrice
            // 
            numericUpDownSellPrice.DecimalPlaces = 2;
            numericUpDownSellPrice.Font = new Font("Segoe UI", 10F);
            numericUpDownSellPrice.Location = new Point(740, 107);
            numericUpDownSellPrice.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericUpDownSellPrice.Name = "numericUpDownSellPrice";
            numericUpDownSellPrice.Size = new Size(171, 30);
            numericUpDownSellPrice.TabIndex = 16;
            // 
            // labelCurrentStock
            // 
            labelCurrentStock.AutoSize = true;
            labelCurrentStock.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelCurrentStock.Location = new Point(740, 154);
            labelCurrentStock.Name = "labelCurrentStock";
            labelCurrentStock.Size = new Size(109, 21);
            labelCurrentStock.TabIndex = 17;
            labelCurrentStock.Text = "Stock Actual:";
            // 
            // numericUpDownCurrentStock
            // 
            numericUpDownCurrentStock.Font = new Font("Segoe UI", 10F);
            numericUpDownCurrentStock.Location = new Point(740, 178);
            numericUpDownCurrentStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownCurrentStock.Name = "numericUpDownCurrentStock";
            numericUpDownCurrentStock.Size = new Size(171, 30);
            numericUpDownCurrentStock.TabIndex = 18;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.FromArgb(16, 185, 129);
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonSave.ForeColor = Color.White;
            buttonSave.Location = new Point(957, 12);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(257, 70);
            buttonSave.TabIndex = 19;
            buttonSave.Text = "GUARDAR";
            buttonSave.UseVisualStyleBackColor = false;
            // 
            // buttonEdit
            // 
            buttonEdit.FlatStyle = FlatStyle.Flat;
            buttonEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonEdit.Location = new Point(957, 88);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(257, 68);
            buttonEdit.TabIndex = 20;
            buttonEdit.Text = "EDITAR";
            buttonEdit.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.FromArgb(239, 68, 68);
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(957, 165);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(257, 70);
            buttonDelete.TabIndex = 21;
            buttonDelete.Text = "ELIMINAR";
            buttonDelete.UseVisualStyleBackColor = false;
            // 
            // FormProducts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1260, 750);
            Controls.Add(panelMain);
            Controls.Add(panelHeader);
            Name = "FormProducts";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Productos";
            ((System.ComponentModel.ISupportInitialize)picIconOpenLabelDesigner).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconExportPdf).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconBrowsePhoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconSave).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconEdit).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconDelete).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).EndInit();
            panelProductForm.ResumeLayout(false);
            panelProductForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProductPhoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownBuyPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSellPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCurrentStock).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonOpenLabelDesigner;
        private System.Windows.Forms.Button buttonExportPdf;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelProductForm;
        private System.Windows.Forms.PictureBox pictureBoxProductPhoto;
        private System.Windows.Forms.Button buttonBrowsePhoto;
        private System.Windows.Forms.Button buttonClearPhoto;
        private System.Windows.Forms.Label labelBarcode;
        private System.Windows.Forms.TextBox textBoxBarcode;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.TextBox textBoxProductName;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Label labelBrand;
        private System.Windows.Forms.ComboBox comboBoxBrand;
        private System.Windows.Forms.Label labelBuyPrice;
        private System.Windows.Forms.NumericUpDown numericUpDownBuyPrice;
        private System.Windows.Forms.Label labelSellPrice;
        private System.Windows.Forms.NumericUpDown numericUpDownSellPrice;
        private System.Windows.Forms.Label labelCurrentStock;
        private System.Windows.Forms.NumericUpDown numericUpDownCurrentStock;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.PictureBox picIconOpenLabelDesigner;
        private System.Windows.Forms.PictureBox picIconExportPdf;
        private System.Windows.Forms.PictureBox picIconBrowsePhoto;
        private System.Windows.Forms.PictureBox picIconSave;
        private System.Windows.Forms.PictureBox picIconEdit;
        private System.Windows.Forms.PictureBox picIconDelete;
    }
}
