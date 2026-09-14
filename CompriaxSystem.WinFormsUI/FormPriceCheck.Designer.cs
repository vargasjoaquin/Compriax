namespace CompriaxSystem.WinFormsUI
{
    partial class FormPriceCheck
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
            lblHeaderTitle = new Label();
            lblHeaderSubtitle = new Label();
            pnlSearchCard = new Panel();
            lblSearchPrompt = new Label();
            quickSearchBox = new Controls.QuickSearchProductBox();
            btnClear = new Button();
            pnlDetailsCard = new Panel();
            picProduct = new PictureBox();
            lblProductName = new Label();
            lblPriceTitle = new Label();
            lblPrice = new Label();
            pnlInfoGrid = new TableLayoutPanel();
            lblBarcodeTitle = new Label();
            lblBarcodeVal = new Label();
            lblCategoryTitle = new Label();
            lblCategoryVal = new Label();
            lblBrandTitle = new Label();
            lblBrandVal = new Label();
            lblStockTitle = new Label();
            lblStockVal = new Label();
            lblStockBadge = new Label();
            pnlFooter = new Panel();
            lblHelp = new Label();
            btnClose = new Button();
            pnlHeader.SuspendLayout();
            pnlSearchCard.SuspendLayout();
            pnlDetailsCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picProduct).BeginInit();
            pnlInfoGrid.SuspendLayout();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(15, 23, 42);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Controls.Add(lblHeaderSubtitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(892, 68);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(20, 12);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(342, 30);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "CONSULTA RÁPIDA DE PRECIOS";
            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 8.5F);
            lblHeaderSubtitle.ForeColor = Color.FromArgb(148, 163, 184);
            lblHeaderSubtitle.Location = new Point(22, 40);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(428, 20);
            lblHeaderSubtitle.TabIndex = 1;
            lblHeaderSubtitle.Text = "Escanee un código de barras o comience a escribir para buscar.";
            // 
            // pnlSearchCard
            // 
            pnlSearchCard.BackColor = Color.White;
            pnlSearchCard.Controls.Add(lblSearchPrompt);
            pnlSearchCard.Controls.Add(quickSearchBox);
            pnlSearchCard.Controls.Add(btnClear);
            pnlSearchCard.Location = new Point(20, 80);
            pnlSearchCard.Name = "pnlSearchCard";
            pnlSearchCard.Padding = new Padding(16);
            pnlSearchCard.Size = new Size(858, 113);
            pnlSearchCard.TabIndex = 1;
            // 
            // lblSearchPrompt
            // 
            lblSearchPrompt.AutoSize = true;
            lblSearchPrompt.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSearchPrompt.Location = new Point(16, 8);
            lblSearchPrompt.Name = "lblSearchPrompt";
            lblSearchPrompt.Size = new Size(129, 21);
            lblSearchPrompt.TabIndex = 0;
            lblSearchPrompt.Text = "Buscar Artículo:";
            // 
            // quickSearchBox
            // 
            quickSearchBox.BackColor = Color.White;
            quickSearchBox.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            quickSearchBox.Location = new Point(16, 32);
            quickSearchBox.Name = "quickSearchBox";
            quickSearchBox.Padding = new Padding(8, 6, 8, 6);
            quickSearchBox.PlaceholderText = "Escriba nombre o pase el lector de código de barras...";
            quickSearchBox.Size = new Size(650, 54);
            quickSearchBox.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClear.Location = new Point(676, 32);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(146, 54);
            btnClear.TabIndex = 2;
            btnClear.Text = "LIMPIAR";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // pnlDetailsCard
            // 
            pnlDetailsCard.BackColor = Color.White;
            pnlDetailsCard.Controls.Add(lblCategoryTitle);
            pnlDetailsCard.Controls.Add(lblBrandTitle);
            pnlDetailsCard.Controls.Add(lblStockTitle);
            pnlDetailsCard.Controls.Add(lblBarcodeTitle);
            pnlDetailsCard.Controls.Add(picProduct);
            pnlDetailsCard.Controls.Add(lblProductName);
            pnlDetailsCard.Controls.Add(lblPriceTitle);
            pnlDetailsCard.Controls.Add(lblPrice);
            pnlDetailsCard.Controls.Add(pnlInfoGrid);
            pnlDetailsCard.Location = new Point(20, 199);
            pnlDetailsCard.Name = "pnlDetailsCard";
            pnlDetailsCard.Padding = new Padding(20);
            pnlDetailsCard.Size = new Size(858, 490);
            pnlDetailsCard.TabIndex = 2;
            // 
            // picProduct
            // 
            picProduct.BackColor = Color.FromArgb(248, 250, 252);
            picProduct.BorderStyle = BorderStyle.FixedSingle;
            picProduct.Location = new Point(20, 20);
            picProduct.Name = "picProduct";
            picProduct.Size = new Size(186, 195);
            picProduct.SizeMode = PictureBoxSizeMode.Zoom;
            picProduct.TabIndex = 0;
            picProduct.TabStop = false;
            // 
            // lblProductName
            // 
            lblProductName.AutoEllipsis = true;
            lblProductName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblProductName.ForeColor = Color.FromArgb(15, 23, 42);
            lblProductName.Location = new Point(210, 20);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(574, 38);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "NOMBRE DEL ARTÍCULO";
            // 
            // lblPriceTitle
            // 
            lblPriceTitle.AutoSize = true;
            lblPriceTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPriceTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblPriceTitle.Location = new Point(213, 67);
            lblPriceTitle.Name = "lblPriceTitle";
            lblPriceTitle.Size = new Size(160, 23);
            lblPriceTitle.TabIndex = 2;
            lblPriceTitle.Text = "PRECIO DE VENTA:";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblPrice.ForeColor = Color.FromArgb(2, 132, 199);
            lblPrice.Location = new Point(212, 105);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(161, 62);
            lblPrice.TabIndex = 3;
            lblPrice.Text = "$ 0,00";
            // 
            // pnlInfoGrid
            // 
            pnlInfoGrid.ColumnCount = 4;
            pnlInfoGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlInfoGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlInfoGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlInfoGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlInfoGrid.Controls.Add(lblCategoryVal, 1, 1);
            pnlInfoGrid.Controls.Add(lblBrandVal, 2, 1);
            pnlInfoGrid.Controls.Add(lblStockVal, 3, 1);
            pnlInfoGrid.Controls.Add(lblStockBadge, 3, 2);
            pnlInfoGrid.Controls.Add(lblBarcodeVal, 0, 1);
            pnlInfoGrid.Location = new Point(23, 278);
            pnlInfoGrid.Name = "pnlInfoGrid";
            pnlInfoGrid.RowCount = 3;
            pnlInfoGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            pnlInfoGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            pnlInfoGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            pnlInfoGrid.Size = new Size(818, 187);
            pnlInfoGrid.TabIndex = 4;
            // 
            // lblBarcodeTitle
            // 
            lblBarcodeTitle.AutoSize = true;
            lblBarcodeTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblBarcodeTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblBarcodeTitle.Location = new Point(23, 255);
            lblBarcodeTitle.Name = "lblBarcodeTitle";
            lblBarcodeTitle.Size = new Size(132, 20);
            lblBarcodeTitle.TabIndex = 0;
            lblBarcodeTitle.Text = "Código de Barras:";
            // 
            // lblBarcodeVal
            // 
            lblBarcodeVal.AutoEllipsis = true;
            lblBarcodeVal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBarcodeVal.Location = new Point(3, 24);
            lblBarcodeVal.Name = "lblBarcodeVal";
            lblBarcodeVal.Size = new Size(184, 25);
            lblBarcodeVal.TabIndex = 1;
            lblBarcodeVal.Text = "-";
            // 
            // lblCategoryTitle
            // 
            lblCategoryTitle.AutoSize = true;
            lblCategoryTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblCategoryTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblCategoryTitle.Location = new Point(230, 255);
            lblCategoryTitle.Name = "lblCategoryTitle";
            lblCategoryTitle.Size = new Size(80, 20);
            lblCategoryTitle.TabIndex = 2;
            lblCategoryTitle.Text = "Categoría:";
            // 
            // lblCategoryVal
            // 
            lblCategoryVal.AutoEllipsis = true;
            lblCategoryVal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCategoryVal.Location = new Point(207, 24);
            lblCategoryVal.Name = "lblCategoryVal";
            lblCategoryVal.Size = new Size(184, 25);
            lblCategoryVal.TabIndex = 3;
            lblCategoryVal.Text = "-";
            // 
            // lblBrandTitle
            // 
            lblBrandTitle.AutoSize = true;
            lblBrandTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblBrandTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblBrandTitle.Location = new Point(434, 255);
            lblBrandTitle.Name = "lblBrandTitle";
            lblBrandTitle.Size = new Size(56, 20);
            lblBrandTitle.TabIndex = 4;
            lblBrandTitle.Text = "Marca:";
            // 
            // lblBrandVal
            // 
            lblBrandVal.AutoEllipsis = true;
            lblBrandVal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBrandVal.Location = new Point(411, 24);
            lblBrandVal.Name = "lblBrandVal";
            lblBrandVal.Size = new Size(184, 25);
            lblBrandVal.TabIndex = 5;
            lblBrandVal.Text = "-";
            // 
            // lblStockTitle
            // 
            lblStockTitle.AutoSize = true;
            lblStockTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblStockTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblStockTitle.Location = new Point(638, 255);
            lblStockTitle.Name = "lblStockTitle";
            lblStockTitle.Size = new Size(100, 20);
            lblStockTitle.TabIndex = 6;
            lblStockTitle.Text = "Stock Actual:";
            // 
            // lblStockVal
            // 
            lblStockVal.AutoEllipsis = true;
            lblStockVal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblStockVal.ForeColor = Color.FromArgb(16, 185, 129);
            lblStockVal.Location = new Point(615, 24);
            lblStockVal.Name = "lblStockVal";
            lblStockVal.Size = new Size(184, 25);
            lblStockVal.TabIndex = 7;
            lblStockVal.Text = "-";
            // 
            // lblStockBadge
            // 
            lblStockBadge.AutoSize = true;
            lblStockBadge.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblStockBadge.ForeColor = Color.FromArgb(16, 185, 129);
            lblStockBadge.Location = new Point(615, 54);
            lblStockBadge.Name = "lblStockBadge";
            lblStockBadge.Size = new Size(0, 20);
            lblStockBadge.TabIndex = 8;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(241, 245, 249);
            pnlFooter.Controls.Add(lblHelp);
            pnlFooter.Controls.Add(btnClose);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 695);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Padding = new Padding(20, 10, 20, 10);
            pnlFooter.Size = new Size(892, 52);
            pnlFooter.TabIndex = 3;
            // 
            // lblHelp
            // 
            lblHelp.AutoSize = true;
            lblHelp.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHelp.ForeColor = Color.FromArgb(100, 116, 139);
            lblHelp.Location = new Point(20, 16);
            lblHelp.Name = "lblHelp";
            lblHelp.Size = new Size(391, 20);
            lblHelp.TabIndex = 0;
            lblHelp.Text = "Atajos: [F2/F6] Buscar  |  [ESC] Cerrar  |  Pistola lectora";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClose.Location = new Point(764, 10);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(108, 32);
            btnClose.TabIndex = 1;
            btnClose.Text = "CERRAR";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // FormPriceCheck
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(892, 747);
            Controls.Add(pnlFooter);
            Controls.Add(pnlDetailsCard);
            Controls.Add(pnlSearchCard);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormPriceCheck";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ver Precio de Artículo";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlSearchCard.ResumeLayout(false);
            pnlSearchCard.PerformLayout();
            pnlDetailsCard.ResumeLayout(false);
            pnlDetailsCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picProduct).EndInit();
            pnlInfoGrid.ResumeLayout(false);
            pnlInfoGrid.PerformLayout();
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblHeaderTitle;
        private Label lblHeaderSubtitle;
        private Panel pnlSearchCard;
        private Label lblSearchPrompt;
        private Controls.QuickSearchProductBox quickSearchBox;
        private Button btnClear;
        private Panel pnlDetailsCard;
        private PictureBox picProduct;
        private Label lblProductName;
        private Label lblPriceTitle;
        private Label lblPrice;
        private TableLayoutPanel pnlInfoGrid;
        private Label lblBarcodeTitle;
        private Label lblBarcodeVal;
        private Label lblCategoryTitle;
        private Label lblCategoryVal;
        private Label lblBrandTitle;
        private Label lblBrandVal;
        private Label lblStockTitle;
        private Label lblStockVal;
        private Label lblStockBadge;
        private Panel pnlFooter;
        private Label lblHelp;
        private Button btnClose;
    }
}