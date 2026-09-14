namespace CompriaxSystem.WinFormsUI
{
    partial class FormProductLabels
    {
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            pnlLeftConfig = new Panel();
            lblSearch = new Label();
            quickSearchBox = new CompriaxSystem.WinFormsUI.Controls.QuickSearchProductBox();
            lblSelectedInfo = new Label();
            lblDescTitle = new Label();
            txtShortDescription = new TextBox();
            lblPriceTitle = new Label();
            numPrice = new NumericUpDown();
            lblQtyTitle = new Label();
            numQuantity = new NumericUpDown();
            btnAddItem = new Button();
            lblQueueTitle = new Label();
            dgvQueue = new DataGridView();
            btnRemoveItem = new Button();
            btnClearQueue = new Button();
            lblTotalSummary = new Label();
            pnlRightPreview = new Panel();
            lblPreviewHeader = new Label();
            picSheetPreview = new PictureBox();
            pnlPagination = new Panel();
            btnPrevPage = new Button();
            lblPageIndicator = new Label();
            btnNextPage = new Button();
            btnPrint = new Button();
            btnExportImage = new Button();
            pnlHeader.SuspendLayout();
            pnlLeftConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvQueue).BeginInit();
            pnlRightPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSheetPreview).BeginInit();
            pnlPagination.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(15, 23, 42);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1280, 68);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(438, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "IMPRESIÓN DE ETIQUETAS DE GÓNDOLA";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 8.5F);
            lblSubtitle.ForeColor = Color.FromArgb(148, 163, 184);
            lblSubtitle.Location = new Point(22, 40);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(578, 20);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Agregue múltiples productos e imprima todas las etiquetas en una sola hoja continua.";
            // 
            // pnlLeftConfig
            // 
            pnlLeftConfig.BackColor = Color.White;
            pnlLeftConfig.Controls.Add(lblSearch);
            pnlLeftConfig.Controls.Add(quickSearchBox);
            pnlLeftConfig.Controls.Add(lblSelectedInfo);
            pnlLeftConfig.Controls.Add(lblDescTitle);
            pnlLeftConfig.Controls.Add(txtShortDescription);
            pnlLeftConfig.Controls.Add(lblPriceTitle);
            pnlLeftConfig.Controls.Add(numPrice);
            pnlLeftConfig.Controls.Add(lblQtyTitle);
            pnlLeftConfig.Controls.Add(numQuantity);
            pnlLeftConfig.Controls.Add(btnAddItem);
            pnlLeftConfig.Controls.Add(lblQueueTitle);
            pnlLeftConfig.Controls.Add(dgvQueue);
            pnlLeftConfig.Controls.Add(btnRemoveItem);
            pnlLeftConfig.Controls.Add(btnClearQueue);
            pnlLeftConfig.Controls.Add(lblTotalSummary);
            pnlLeftConfig.Location = new Point(20, 80);
            pnlLeftConfig.Name = "pnlLeftConfig";
            pnlLeftConfig.Padding = new Padding(16);
            pnlLeftConfig.Size = new Size(600, 742);
            pnlLeftConfig.TabIndex = 1;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSearch.Location = new Point(16, 10);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(138, 21);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Buscar Producto:";
            // 
            // quickSearchBox
            // 
            quickSearchBox.BackColor = Color.White;
            quickSearchBox.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            quickSearchBox.Location = new Point(19, 37);
            quickSearchBox.Name = "quickSearchBox";
            quickSearchBox.PlaceholderText = "Escriba nombre o código de barras [F2]...";
            quickSearchBox.Size = new Size(568, 48);
            quickSearchBox.TabIndex = 1;
            // 
            // lblSelectedInfo
            // 
            lblSelectedInfo.AutoEllipsis = true;
            lblSelectedInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSelectedInfo.ForeColor = Color.FromArgb(100, 116, 139);
            lblSelectedInfo.Location = new Point(16, 88);
            lblSelectedInfo.Name = "lblSelectedInfo";
            lblSelectedInfo.Size = new Size(568, 20);
            lblSelectedInfo.TabIndex = 2;
            lblSelectedInfo.Text = "Ningún producto seleccionado";
            // 
            // lblDescTitle
            // 
            lblDescTitle.AutoSize = true;
            lblDescTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDescTitle.Location = new Point(16, 118);
            lblDescTitle.Name = "lblDescTitle";
            lblDescTitle.Size = new Size(165, 20);
            lblDescTitle.TabIndex = 3;
            lblDescTitle.Text = "Texto para la Etiqueta:";
            // 
            // txtShortDescription
            // 
            txtShortDescription.BorderStyle = BorderStyle.FixedSingle;
            txtShortDescription.Font = new Font("Segoe UI", 9.5F);
            txtShortDescription.Location = new Point(13, 141);
            txtShortDescription.MaxLength = 50;
            txtShortDescription.Name = "txtShortDescription";
            txtShortDescription.Size = new Size(568, 29);
            txtShortDescription.TabIndex = 4;
            // 
            // lblPriceTitle
            // 
            lblPriceTitle.AutoSize = true;
            lblPriceTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPriceTitle.Location = new Point(16, 182);
            lblPriceTitle.Name = "lblPriceTitle";
            lblPriceTitle.Size = new Size(81, 20);
            lblPriceTitle.TabIndex = 5;
            lblPriceTitle.Text = "Precio ($):";
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            numPrice.Location = new Point(16, 205);
            numPrice.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(150, 30);
            numPrice.TabIndex = 6;
            // 
            // lblQtyTitle
            // 
            lblQtyTitle.AutoSize = true;
            lblQtyTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblQtyTitle.Location = new Point(180, 182);
            lblQtyTitle.Name = "lblQtyTitle";
            lblQtyTitle.Size = new Size(75, 20);
            lblQtyTitle.TabIndex = 7;
            lblQtyTitle.Text = "Cantidad:";
            // 
            // numQuantity
            // 
            numQuantity.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            numQuantity.Location = new Point(180, 205);
            numQuantity.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(100, 30);
            numQuantity.TabIndex = 8;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAddItem
            // 
            btnAddItem.BackColor = Color.FromArgb(2, 132, 199);
            btnAddItem.FlatAppearance.BorderSize = 0;
            btnAddItem.FlatStyle = FlatStyle.Flat;
            btnAddItem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAddItem.ForeColor = Color.White;
            btnAddItem.Location = new Point(300, 199);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(284, 38);
            btnAddItem.TabIndex = 9;
            btnAddItem.Text = "+ AGREGAR A LA PLANTILLA";
            btnAddItem.UseVisualStyleBackColor = false;
            // 
            // lblQueueTitle
            // 
            lblQueueTitle.AutoSize = true;
            lblQueueTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblQueueTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblQueueTitle.Location = new Point(16, 266);
            lblQueueTitle.Name = "lblQueueTitle";
            lblQueueTitle.Size = new Size(300, 21);
            lblQueueTitle.TabIndex = 10;
            lblQueueTitle.Text = "Lista de Productos a Imprimir en Hoja:";
            // 
            // dgvQueue
            // 
            dgvQueue.BackgroundColor = Color.White;
            dgvQueue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvQueue.Location = new Point(16, 300);
            dgvQueue.Name = "dgvQueue";
            dgvQueue.RowHeadersWidth = 30;
            dgvQueue.Size = new Size(568, 330);
            dgvQueue.TabIndex = 11;
            // 
            // btnRemoveItem
            // 
            btnRemoveItem.BackColor = Color.FromArgb(239, 68, 68);
            btnRemoveItem.FlatAppearance.BorderSize = 0;
            btnRemoveItem.FlatStyle = FlatStyle.Flat;
            btnRemoveItem.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnRemoveItem.ForeColor = Color.White;
            btnRemoveItem.Location = new Point(16, 654);
            btnRemoveItem.Name = "btnRemoveItem";
            btnRemoveItem.Size = new Size(160, 32);
            btnRemoveItem.TabIndex = 12;
            btnRemoveItem.Text = "QUITAR SELECCIÓN";
            btnRemoveItem.UseVisualStyleBackColor = false;
            // 
            // btnClearQueue
            // 
            btnClearQueue.FlatStyle = FlatStyle.Flat;
            btnClearQueue.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnClearQueue.Location = new Point(182, 654);
            btnClearQueue.Name = "btnClearQueue";
            btnClearQueue.Size = new Size(140, 32);
            btnClearQueue.TabIndex = 13;
            btnClearQueue.Text = "VACIAR LISTA";
            btnClearQueue.UseVisualStyleBackColor = true;
            // 
            // lblTotalSummary
            // 
            lblTotalSummary.AutoEllipsis = true;
            lblTotalSummary.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalSummary.ForeColor = Color.FromArgb(2, 132, 199);
            lblTotalSummary.Location = new Point(16, 694);
            lblTotalSummary.Name = "lblTotalSummary";
            lblTotalSummary.Size = new Size(568, 22);
            lblTotalSummary.TabIndex = 14;
            lblTotalSummary.Text = "Productos: 0  |  Total Etiquetas: 0  (0 hoja/s)";
            // 
            // pnlRightPreview
            // 
            pnlRightPreview.BackColor = Color.White;
            pnlRightPreview.Controls.Add(lblPreviewHeader);
            pnlRightPreview.Controls.Add(picSheetPreview);
            pnlRightPreview.Controls.Add(pnlPagination);
            pnlRightPreview.Controls.Add(btnPrint);
            pnlRightPreview.Controls.Add(btnExportImage);
            pnlRightPreview.Location = new Point(640, 80);
            pnlRightPreview.Name = "pnlRightPreview";
            pnlRightPreview.Padding = new Padding(16);
            pnlRightPreview.Size = new Size(620, 742);
            pnlRightPreview.TabIndex = 2;
            // 
            // lblPreviewHeader
            // 
            lblPreviewHeader.AutoSize = true;
            lblPreviewHeader.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPreviewHeader.ForeColor = Color.FromArgb(15, 23, 42);
            lblPreviewHeader.Location = new Point(16, 10);
            lblPreviewHeader.Name = "lblPreviewHeader";
            lblPreviewHeader.Size = new Size(246, 23);
            lblPreviewHeader.TabIndex = 0;
            lblPreviewHeader.Text = "VISTA PREVIA DE PLANTILLA:";
            // 
            // picSheetPreview
            // 
            picSheetPreview.BackColor = Color.FromArgb(248, 250, 252);
            picSheetPreview.BorderStyle = BorderStyle.FixedSingle;
            picSheetPreview.Location = new Point(16, 36);
            picSheetPreview.Name = "picSheetPreview";
            picSheetPreview.Size = new Size(588, 506);
            picSheetPreview.SizeMode = PictureBoxSizeMode.Zoom;
            picSheetPreview.TabIndex = 1;
            picSheetPreview.TabStop = false;
            // 
            // pnlPagination
            // 
            pnlPagination.Controls.Add(btnPrevPage);
            pnlPagination.Controls.Add(lblPageIndicator);
            pnlPagination.Controls.Add(btnNextPage);
            pnlPagination.Location = new Point(16, 562);
            pnlPagination.Name = "pnlPagination";
            pnlPagination.Size = new Size(588, 33);
            pnlPagination.TabIndex = 2;
            // 
            // btnPrevPage
            // 
            btnPrevPage.FlatStyle = FlatStyle.Flat;
            btnPrevPage.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnPrevPage.Location = new Point(150, 2);
            btnPrevPage.Name = "btnPrevPage";
            btnPrevPage.Size = new Size(80, 28);
            btnPrevPage.TabIndex = 0;
            btnPrevPage.Text = "◀ ANTERIOR";
            btnPrevPage.UseVisualStyleBackColor = true;
            // 
            // lblPageIndicator
            // 
            lblPageIndicator.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPageIndicator.ForeColor = Color.FromArgb(100, 116, 139);
            lblPageIndicator.Location = new Point(235, 2);
            lblPageIndicator.Name = "lblPageIndicator";
            lblPageIndicator.Size = new Size(120, 28);
            lblPageIndicator.TabIndex = 1;
            lblPageIndicator.Text = "Página 1 de 1";
            lblPageIndicator.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnNextPage
            // 
            btnNextPage.FlatStyle = FlatStyle.Flat;
            btnNextPage.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnNextPage.Location = new Point(360, 2);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(114, 28);
            btnNextPage.TabIndex = 2;
            btnNextPage.Text = "SIGUIENTE ▶";
            btnNextPage.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.FromArgb(16, 185, 129);
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(18, 611);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(380, 105);
            btnPrint.TabIndex = 3;
            btnPrint.Text = "IMPRIMIR PLANTILLA(S)";
            btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnExportImage
            // 
            btnExportImage.FlatStyle = FlatStyle.Flat;
            btnExportImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExportImage.Location = new Point(404, 611);
            btnExportImage.Name = "btnExportImage";
            btnExportImage.Size = new Size(200, 105);
            btnExportImage.TabIndex = 4;
            btnExportImage.Text = "GUARDAR PNG";
            btnExportImage.UseVisualStyleBackColor = true;
            // 
            // FormProductLabels
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1280, 837);
            Controls.Add(pnlRightPreview);
            Controls.Add(pnlLeftConfig);
            Controls.Add(pnlHeader);
            KeyPreview = true;
            Name = "FormProductLabels";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Generador de Plancha de Etiquetas - CompriaxSystem";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlLeftConfig.ResumeLayout(false);
            pnlLeftConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvQueue).EndInit();
            pnlRightPreview.ResumeLayout(false);
            pnlRightPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picSheetPreview).EndInit();
            pnlPagination.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlLeftConfig;
        private System.Windows.Forms.Label lblSearch;
        private Controls.QuickSearchProductBox quickSearchBox;
        private System.Windows.Forms.Label lblSelectedInfo;
        private System.Windows.Forms.Label lblDescTitle;
        private System.Windows.Forms.TextBox txtShortDescription;
        private System.Windows.Forms.Label lblPriceTitle;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Label lblQtyTitle;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Label lblQueueTitle;
        private System.Windows.Forms.DataGridView dgvQueue;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnClearQueue;
        private System.Windows.Forms.Label lblTotalSummary;
        private System.Windows.Forms.Panel pnlRightPreview;
        private System.Windows.Forms.Label lblPreviewHeader;
        private System.Windows.Forms.PictureBox picSheetPreview;
        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Label lblPageIndicator;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExportImage;
    }
}