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
            this.picIconClearSearch = new System.Windows.Forms.PictureBox();
            this.picIconCloseDialog = new System.Windows.Forms.PictureBox();
            panelHeader = new Panel();
            labelHeaderTitle = new Label();
            labelHeaderSubtitle = new Label();
            panelSearchCard = new Panel();
            labelSearchPrompt = new Label();
            quickSearchBox = new Controls.QuickSearchProductBox();
            // 
            // picIconClearSearch
            // 
            this.picIconClearSearch.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconClearSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconClearSearch.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconClearSearch.Location = new System.Drawing.Point(688, 49);
            this.picIconClearSearch.Name = "picIconClearSearch";
            this.picIconClearSearch.Size = new System.Drawing.Size(20, 20);
            this.picIconClearSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconClearSearch.TabIndex = 99;
            this.picIconClearSearch.TabStop = false;

            // 
            // picIconCloseDialog
            // 
            this.picIconCloseDialog.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCloseDialog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCloseDialog.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCloseDialog.Location = new System.Drawing.Point(772, 17);
            this.picIconCloseDialog.Name = "picIconCloseDialog";
            this.picIconCloseDialog.Size = new System.Drawing.Size(16, 16);
            this.picIconCloseDialog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCloseDialog.TabIndex = 99;
            this.picIconCloseDialog.TabStop = false;
            buttonClearSearch = new Button();
            panelDetailsCard = new Panel();
            pictureBoxProduct = new PictureBox();
            labelProductName = new Label();
            labelPriceTitle = new Label();
            labelPriceValue = new Label();
            tableLayoutPanelInfoGrid = new TableLayoutPanel();
            labelBarcodeTitle = new Label();
            labelBarcodeValue = new Label();
            labelCategoryTitle = new Label();
            labelCategoryValue = new Label();
            labelBrandTitle = new Label();
            labelBrandValue = new Label();
            labelStockTitle = new Label();
            labelStockValue = new Label();
            labelStockBadge = new Label();
            panelFooter = new Panel();
            labelHelpShortcuts = new Label();
            buttonCloseDialog = new Button();
            panelHeader.SuspendLayout();
            panelSearchCard.SuspendLayout();
            panelDetailsCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProduct).BeginInit();
            tableLayoutPanelInfoGrid.SuspendLayout();
            panelFooter.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelHeaderTitle);
            panelHeader.Controls.Add(labelHeaderSubtitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(892, 68);
            panelHeader.TabIndex = 0;
            // 
            // labelHeaderTitle
            // 
            labelHeaderTitle.AutoSize = true;
            labelHeaderTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelHeaderTitle.ForeColor = Color.White;
            labelHeaderTitle.Location = new Point(20, 12);
            labelHeaderTitle.Name = "labelHeaderTitle";
            labelHeaderTitle.Size = new Size(342, 30);
            labelHeaderTitle.TabIndex = 0;
            labelHeaderTitle.Text = "CONSULTA RÁPIDA DE PRECIOS";
            // 
            // labelHeaderSubtitle
            // 
            labelHeaderSubtitle.AutoSize = true;
            labelHeaderSubtitle.Font = new Font("Segoe UI", 8.5F);
            labelHeaderSubtitle.ForeColor = Color.FromArgb(148, 163, 184);
            labelHeaderSubtitle.Location = new Point(22, 40);
            labelHeaderSubtitle.Name = "labelHeaderSubtitle";
            labelHeaderSubtitle.Size = new Size(428, 20);
            labelHeaderSubtitle.TabIndex = 1;
            labelHeaderSubtitle.Text = "Escanee un código de barras o comience a escribir para buscar.";
            // 
            // panelSearchCard
            // 
            panelSearchCard.BackColor = Color.White;
            panelSearchCard.Controls.Add(labelSearchPrompt);
            panelSearchCard.Controls.Add(quickSearchBox);
panelSearchCard.Controls.Add(this.picIconClearSearch);
            panelSearchCard.Controls.Add(buttonClearSearch);
            panelSearchCard.Location = new Point(20, 80);
            panelSearchCard.Name = "panelSearchCard";
            panelSearchCard.Padding = new Padding(16);
            panelSearchCard.Size = new Size(858, 113);
            panelSearchCard.TabIndex = 1;
            // 
            // labelSearchPrompt
            // 
            labelSearchPrompt.AutoSize = true;
            labelSearchPrompt.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelSearchPrompt.Location = new Point(16, 8);
            labelSearchPrompt.Name = "labelSearchPrompt";
            labelSearchPrompt.Size = new Size(129, 21);
            labelSearchPrompt.TabIndex = 0;
            labelSearchPrompt.Text = "Buscar Artículo:";
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
            // picIconClearSearch
            // 
            this.picIconClearSearch.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconClearSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconClearSearch.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconClearSearch.Location = new System.Drawing.Point(688, 49);
            this.picIconClearSearch.Name = "picIconClearSearch";
            this.picIconClearSearch.Size = new System.Drawing.Size(20, 20);
            this.picIconClearSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconClearSearch.TabIndex = 99;
            this.picIconClearSearch.TabStop = false;

            // 
            // picIconCloseDialog
            // 
            this.picIconCloseDialog.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCloseDialog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCloseDialog.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCloseDialog.Location = new System.Drawing.Point(772, 17);
            this.picIconCloseDialog.Name = "picIconCloseDialog";
            this.picIconCloseDialog.Size = new System.Drawing.Size(16, 16);
            this.picIconCloseDialog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCloseDialog.TabIndex = 99;
            this.picIconCloseDialog.TabStop = false;





            // 
            // buttonClearSearch
            // 
            // picIconClearSearch
            // 
            this.picIconClearSearch.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconClearSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconClearSearch.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconClearSearch.Location = new System.Drawing.Point(688, 49);
            this.picIconClearSearch.Name = "picIconClearSearch";
            this.picIconClearSearch.Size = new System.Drawing.Size(20, 20);
            this.picIconClearSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconClearSearch.TabIndex = 99;
            this.picIconClearSearch.TabStop = false;

            // 
            // picIconCloseDialog
            // 
            this.picIconCloseDialog.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCloseDialog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCloseDialog.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCloseDialog.Location = new System.Drawing.Point(772, 17);
            this.picIconCloseDialog.Name = "picIconCloseDialog";
            this.picIconCloseDialog.Size = new System.Drawing.Size(16, 16);
            this.picIconCloseDialog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCloseDialog.TabIndex = 99;
            this.picIconCloseDialog.TabStop = false;
            // 
            buttonClearSearch.FlatStyle = FlatStyle.Flat;
            // 
            // picIconClearSearch
            // 
            this.picIconClearSearch.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconClearSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconClearSearch.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconClearSearch.Location = new System.Drawing.Point(688, 49);
            this.picIconClearSearch.Name = "picIconClearSearch";
            this.picIconClearSearch.Size = new System.Drawing.Size(20, 20);
            this.picIconClearSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconClearSearch.TabIndex = 99;
            this.picIconClearSearch.TabStop = false;

            // 
            // picIconCloseDialog
            // 
            this.picIconCloseDialog.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCloseDialog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCloseDialog.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCloseDialog.Location = new System.Drawing.Point(772, 17);
            this.picIconCloseDialog.Name = "picIconCloseDialog";
            this.picIconCloseDialog.Size = new System.Drawing.Size(16, 16);
            this.picIconCloseDialog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCloseDialog.TabIndex = 99;
            this.picIconCloseDialog.TabStop = false;
            buttonClearSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            // 
            // picIconClearSearch
            // 
            this.picIconClearSearch.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconClearSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconClearSearch.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconClearSearch.Location = new System.Drawing.Point(688, 49);
            this.picIconClearSearch.Name = "picIconClearSearch";
            this.picIconClearSearch.Size = new System.Drawing.Size(20, 20);
            this.picIconClearSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconClearSearch.TabIndex = 99;
            this.picIconClearSearch.TabStop = false;

            // 
            // picIconCloseDialog
            // 
            this.picIconCloseDialog.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCloseDialog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCloseDialog.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCloseDialog.Location = new System.Drawing.Point(772, 17);
            this.picIconCloseDialog.Name = "picIconCloseDialog";
            this.picIconCloseDialog.Size = new System.Drawing.Size(16, 16);
            this.picIconCloseDialog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCloseDialog.TabIndex = 99;
            this.picIconCloseDialog.TabStop = false;
            buttonClearSearch.Location = new Point(676, 32);
            // 
            // picIconClearSearch
            // 
            this.picIconClearSearch.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconClearSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconClearSearch.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconClearSearch.Location = new System.Drawing.Point(688, 49);
            this.picIconClearSearch.Name = "picIconClearSearch";
            this.picIconClearSearch.Size = new System.Drawing.Size(20, 20);
            this.picIconClearSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconClearSearch.TabIndex = 99;
            this.picIconClearSearch.TabStop = false;

            // 
            // picIconCloseDialog
            // 
            this.picIconCloseDialog.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCloseDialog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCloseDialog.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCloseDialog.Location = new System.Drawing.Point(772, 17);
            this.picIconCloseDialog.Name = "picIconCloseDialog";
            this.picIconCloseDialog.Size = new System.Drawing.Size(16, 16);
            this.picIconCloseDialog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCloseDialog.TabIndex = 99;
            this.picIconCloseDialog.TabStop = false;
            buttonClearSearch.Name = "buttonClearSearch";
            // 
            // picIconClearSearch
            // 
            this.picIconClearSearch.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconClearSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconClearSearch.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconClearSearch.Location = new System.Drawing.Point(688, 49);
            this.picIconClearSearch.Name = "picIconClearSearch";
            this.picIconClearSearch.Size = new System.Drawing.Size(20, 20);
            this.picIconClearSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconClearSearch.TabIndex = 99;
            this.picIconClearSearch.TabStop = false;

            // 
            // picIconCloseDialog
            // 
            this.picIconCloseDialog.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCloseDialog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCloseDialog.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCloseDialog.Location = new System.Drawing.Point(772, 17);
            this.picIconCloseDialog.Name = "picIconCloseDialog";
            this.picIconCloseDialog.Size = new System.Drawing.Size(16, 16);
            this.picIconCloseDialog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCloseDialog.TabIndex = 99;
            this.picIconCloseDialog.TabStop = false;
            buttonClearSearch.Size = new Size(146, 54);
            // 
            // picIconClearSearch
            // 
            this.picIconClearSearch.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconClearSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconClearSearch.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconClearSearch.Location = new System.Drawing.Point(688, 49);
            this.picIconClearSearch.Name = "picIconClearSearch";
            this.picIconClearSearch.Size = new System.Drawing.Size(20, 20);
            this.picIconClearSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconClearSearch.TabIndex = 99;
            this.picIconClearSearch.TabStop = false;

            // 
            // picIconCloseDialog
            // 
            this.picIconCloseDialog.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCloseDialog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCloseDialog.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCloseDialog.Location = new System.Drawing.Point(772, 17);
            this.picIconCloseDialog.Name = "picIconCloseDialog";
            this.picIconCloseDialog.Size = new System.Drawing.Size(16, 16);
            this.picIconCloseDialog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCloseDialog.TabIndex = 99;
            this.picIconCloseDialog.TabStop = false;
            buttonClearSearch.TabIndex = 2;
            // 
            // picIconClearSearch
            // 
            this.picIconClearSearch.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconClearSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconClearSearch.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconClearSearch.Location = new System.Drawing.Point(688, 49);
            this.picIconClearSearch.Name = "picIconClearSearch";
            this.picIconClearSearch.Size = new System.Drawing.Size(20, 20);
            this.picIconClearSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconClearSearch.TabIndex = 99;
            this.picIconClearSearch.TabStop = false;

            // 
            // picIconCloseDialog
            // 
            this.picIconCloseDialog.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCloseDialog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCloseDialog.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCloseDialog.Location = new System.Drawing.Point(772, 17);
            this.picIconCloseDialog.Name = "picIconCloseDialog";
            this.picIconCloseDialog.Size = new System.Drawing.Size(16, 16);
            this.picIconCloseDialog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCloseDialog.TabIndex = 99;
            this.picIconCloseDialog.TabStop = false;
            buttonClearSearch.Text = "LIMPIAR";
            // 
            // picIconClearSearch
            // 
            this.picIconClearSearch.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconClearSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconClearSearch.Image = global::CompriaxSystem.WinFormsUI.Resources._079_eliminar;
            this.picIconClearSearch.Location = new System.Drawing.Point(688, 49);
            this.picIconClearSearch.Name = "picIconClearSearch";
            this.picIconClearSearch.Size = new System.Drawing.Size(20, 20);
            this.picIconClearSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconClearSearch.TabIndex = 99;
            this.picIconClearSearch.TabStop = false;

            // 
            // picIconCloseDialog
            // 
            this.picIconCloseDialog.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCloseDialog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCloseDialog.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCloseDialog.Location = new System.Drawing.Point(772, 17);
            this.picIconCloseDialog.Name = "picIconCloseDialog";
            this.picIconCloseDialog.Size = new System.Drawing.Size(16, 16);
            this.picIconCloseDialog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCloseDialog.TabIndex = 99;
            this.picIconCloseDialog.TabStop = false;
            buttonClearSearch.UseVisualStyleBackColor = true;
            // 
            // panelDetailsCard
            // 
            panelDetailsCard.BackColor = Color.White;
            panelDetailsCard.Controls.Add(labelCategoryTitle);
            panelDetailsCard.Controls.Add(labelBrandTitle);
            panelDetailsCard.Controls.Add(labelStockTitle);
            panelDetailsCard.Controls.Add(labelBarcodeTitle);
            panelDetailsCard.Controls.Add(pictureBoxProduct);
            panelDetailsCard.Controls.Add(labelProductName);
            panelDetailsCard.Controls.Add(labelPriceTitle);
            panelDetailsCard.Controls.Add(labelPriceValue);
            panelDetailsCard.Controls.Add(tableLayoutPanelInfoGrid);
            panelDetailsCard.Location = new Point(20, 199);
            panelDetailsCard.Name = "panelDetailsCard";
            panelDetailsCard.Padding = new Padding(20);
            panelDetailsCard.Size = new Size(858, 490);
            panelDetailsCard.TabIndex = 2;
            // 
            // pictureBoxProduct
            // 
            pictureBoxProduct.BackColor = Color.FromArgb(248, 250, 252);
            pictureBoxProduct.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxProduct.Location = new Point(20, 20);
            pictureBoxProduct.Name = "pictureBoxProduct";
            pictureBoxProduct.Size = new Size(186, 195);
            pictureBoxProduct.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxProduct.TabIndex = 0;
            pictureBoxProduct.TabStop = false;
            // 
            // labelProductName
            // 
            labelProductName.AutoEllipsis = true;
            labelProductName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelProductName.ForeColor = Color.FromArgb(15, 23, 42);
            labelProductName.Location = new Point(210, 20);
            labelProductName.Name = "labelProductName";
            labelProductName.Size = new Size(574, 38);
            labelProductName.TabIndex = 1;
            labelProductName.Text = "NOMBRE DEL ARTÍCULO";
            // 
            // labelPriceTitle
            // 
            labelPriceTitle.AutoSize = true;
            labelPriceTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelPriceTitle.ForeColor = Color.FromArgb(100, 116, 139);
            labelPriceTitle.Location = new Point(213, 67);
            labelPriceTitle.Name = "labelPriceTitle";
            labelPriceTitle.Size = new Size(160, 23);
            labelPriceTitle.TabIndex = 2;
            labelPriceTitle.Text = "PRECIO DE VENTA:";
            // 
            // labelPriceValue
            // 
            labelPriceValue.AutoSize = true;
            labelPriceValue.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            labelPriceValue.ForeColor = Color.FromArgb(2, 132, 199);
            labelPriceValue.Location = new Point(212, 105);
            labelPriceValue.Name = "labelPriceValue";
            labelPriceValue.Size = new Size(161, 62);
            labelPriceValue.TabIndex = 3;
            labelPriceValue.Text = "$ 0,00";
            // 
            // tableLayoutPanelInfoGrid
            // 
            tableLayoutPanelInfoGrid.ColumnCount = 4;
            tableLayoutPanelInfoGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelInfoGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelInfoGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelInfoGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanelInfoGrid.Controls.Add(labelCategoryValue, 1, 1);
            tableLayoutPanelInfoGrid.Controls.Add(labelBrandValue, 2, 1);
            tableLayoutPanelInfoGrid.Controls.Add(labelStockValue, 3, 1);
            tableLayoutPanelInfoGrid.Controls.Add(labelStockBadge, 3, 2);
            tableLayoutPanelInfoGrid.Controls.Add(labelBarcodeValue, 0, 1);
            tableLayoutPanelInfoGrid.Location = new Point(23, 278);
            tableLayoutPanelInfoGrid.Name = "tableLayoutPanelInfoGrid";
            tableLayoutPanelInfoGrid.RowCount = 3;
            tableLayoutPanelInfoGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tableLayoutPanelInfoGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanelInfoGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tableLayoutPanelInfoGrid.Size = new Size(818, 187);
            tableLayoutPanelInfoGrid.TabIndex = 4;
            // 
            // labelBarcodeTitle
            // 
            labelBarcodeTitle.AutoSize = true;
            labelBarcodeTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelBarcodeTitle.ForeColor = Color.FromArgb(100, 116, 139);
            labelBarcodeTitle.Location = new Point(23, 255);
            labelBarcodeTitle.Name = "labelBarcodeTitle";
            labelBarcodeTitle.Size = new Size(132, 20);
            labelBarcodeTitle.TabIndex = 0;
            labelBarcodeTitle.Text = "Código de Barras:";
            // 
            // labelBarcodeValue
            // 
            labelBarcodeValue.AutoEllipsis = true;
            labelBarcodeValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelBarcodeValue.Location = new Point(3, 24);
            labelBarcodeValue.Name = "labelBarcodeValue";
            labelBarcodeValue.Size = new Size(184, 25);
            labelBarcodeValue.TabIndex = 1;
            labelBarcodeValue.Text = "-";
            // 
            // labelCategoryTitle
            // 
            labelCategoryTitle.AutoSize = true;
            labelCategoryTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelCategoryTitle.ForeColor = Color.FromArgb(100, 116, 139);
            labelCategoryTitle.Location = new Point(230, 255);
            labelCategoryTitle.Name = "labelCategoryTitle";
            labelCategoryTitle.Size = new Size(80, 20);
            labelCategoryTitle.TabIndex = 2;
            labelCategoryTitle.Text = "Categoría:";
            // 
            // labelCategoryValue
            // 
            labelCategoryValue.AutoEllipsis = true;
            labelCategoryValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelCategoryValue.Location = new Point(207, 24);
            labelCategoryValue.Name = "labelCategoryValue";
            labelCategoryValue.Size = new Size(184, 25);
            labelCategoryValue.TabIndex = 3;
            labelCategoryValue.Text = "-";
            // 
            // labelBrandTitle
            // 
            labelBrandTitle.AutoSize = true;
            labelBrandTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelBrandTitle.ForeColor = Color.FromArgb(100, 116, 139);
            labelBrandTitle.Location = new Point(434, 255);
            labelBrandTitle.Name = "labelBrandTitle";
            labelBrandTitle.Size = new Size(56, 20);
            labelBrandTitle.TabIndex = 4;
            labelBrandTitle.Text = "Marca:";
            // 
            // labelBrandValue
            // 
            labelBrandValue.AutoEllipsis = true;
            labelBrandValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelBrandValue.Location = new Point(411, 24);
            labelBrandValue.Name = "labelBrandValue";
            labelBrandValue.Size = new Size(184, 25);
            labelBrandValue.TabIndex = 5;
            labelBrandValue.Text = "-";
            // 
            // labelStockTitle
            // 
            labelStockTitle.AutoSize = true;
            labelStockTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelStockTitle.ForeColor = Color.FromArgb(100, 116, 139);
            labelStockTitle.Location = new Point(638, 255);
            labelStockTitle.Name = "labelStockTitle";
            labelStockTitle.Size = new Size(100, 20);
            labelStockTitle.TabIndex = 6;
            labelStockTitle.Text = "Stock Actual:";
            // 
            // labelStockValue
            // 
            labelStockValue.AutoEllipsis = true;
            labelStockValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelStockValue.ForeColor = Color.FromArgb(16, 185, 129);
            labelStockValue.Location = new Point(615, 24);
            labelStockValue.Name = "labelStockValue";
            labelStockValue.Size = new Size(184, 25);
            labelStockValue.TabIndex = 7;
            labelStockValue.Text = "-";
            // 
            // labelStockBadge
            // 
            labelStockBadge.AutoSize = true;
            labelStockBadge.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            labelStockBadge.ForeColor = Color.FromArgb(16, 185, 129);
            labelStockBadge.Location = new Point(615, 54);
            labelStockBadge.Name = "labelStockBadge";
            labelStockBadge.Size = new Size(0, 20);
            labelStockBadge.TabIndex = 8;
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.FromArgb(241, 245, 249);
            panelFooter.Controls.Add(labelHelpShortcuts);
panelFooter.Controls.Add(this.picIconCloseDialog);
            panelFooter.Controls.Add(buttonCloseDialog);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 695);
            panelFooter.Name = "panelFooter";
            panelFooter.Padding = new Padding(20, 10, 20, 10);
            panelFooter.Size = new Size(892, 52);
            panelFooter.TabIndex = 3;
            // 
            // labelHelpShortcuts
            // 
            labelHelpShortcuts.AutoSize = true;
            labelHelpShortcuts.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelHelpShortcuts.ForeColor = Color.FromArgb(100, 116, 139);
            labelHelpShortcuts.Location = new Point(20, 16);
            labelHelpShortcuts.Name = "labelHelpShortcuts";
            labelHelpShortcuts.Size = new Size(391, 20);
            labelHelpShortcuts.TabIndex = 0;
            labelHelpShortcuts.Text = "Atajos: [F2/F6] Buscar  |  [ESC] Cerrar  |  Pistola lectora";
            // 
            // buttonCloseDialog
            // 
            buttonCloseDialog.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonCloseDialog.FlatStyle = FlatStyle.Flat;
            buttonCloseDialog.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonCloseDialog.Location = new Point(764, 10);
            buttonCloseDialog.Name = "buttonCloseDialog";
            buttonCloseDialog.Size = new Size(108, 32);
            buttonCloseDialog.TabIndex = 1;
            buttonCloseDialog.Text = "CERRAR";
            buttonCloseDialog.UseVisualStyleBackColor = true;





            // 
            // FormPriceCheck
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(892, 747);
            Controls.Add(panelFooter);
            Controls.Add(panelDetailsCard);
            Controls.Add(panelSearchCard);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormPriceCheck";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ver Precio de Artículo";
ResumeLayout(false);
            panelHeader.PerformLayout();
ResumeLayout(false);
            panelSearchCard.PerformLayout();
ResumeLayout(false);
            panelDetailsCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProduct).EndInit();
ResumeLayout(false);
            tableLayoutPanelInfoGrid.PerformLayout();
ResumeLayout(false);
            panelFooter.PerformLayout();

            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelHeaderTitle;
        private Label labelHeaderSubtitle;
        private Panel panelSearchCard;
        private Label labelSearchPrompt;
        private Controls.QuickSearchProductBox quickSearchBox;
        private Button buttonClearSearch;
        private Panel panelDetailsCard;
        private PictureBox pictureBoxProduct;
        private Label labelProductName;
        private Label labelPriceTitle;
        private Label labelPriceValue;
        private TableLayoutPanel tableLayoutPanelInfoGrid;
        private Label labelBarcodeTitle;
        private Label labelBarcodeValue;
        private Label labelCategoryTitle;
        private Label labelCategoryValue;
        private Label labelBrandTitle;
        private Label labelBrandValue;
        private Label labelStockTitle;
        private Label labelStockValue;
        private Label labelStockBadge;
        private Panel panelFooter;
        private Label labelHelpShortcuts;
        private Button buttonCloseDialog;
        private System.Windows.Forms.PictureBox picIconClearSearch;
        private System.Windows.Forms.PictureBox picIconCloseDialog;
    }
}
