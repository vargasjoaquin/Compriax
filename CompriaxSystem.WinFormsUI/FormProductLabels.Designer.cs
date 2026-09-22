namespace CompriaxSystem.WinFormsUI
{
    partial class FormProductLabels
    {
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            picIconAddLabelToQueue = new PictureBox();
            picIconRemoveSelected = new PictureBox();
            picIconClearQueue = new PictureBox();
            picIconPrintSheet = new PictureBox();
            picIconExportSheetPng = new PictureBox();
            panelHeader = new Panel();
            labelTitle = new Label();
            panelLeftConfiguration = new Panel();
            labelSearchPrompt = new Label();
            quickSearchBox = new CompriaxSystem.WinFormsUI.Controls.QuickSearchProductBox();
            labelSelectedProductInfo = new Label();
            labelDescriptionPrompt = new Label();
            textBoxShortDescription = new TextBox();
            labelPricePrompt = new Label();
            numericUpDownPrice = new NumericUpDown();
            labelQuantityPrompt = new Label();
            numericUpDownQuantity = new NumericUpDown();
            buttonAddLabelToQueue = new Button();
            labelQueueTitle = new Label();
            dataGridViewLabelQueue = new DataGridView();
            buttonRemoveSelectedFromQueue = new Button();
            buttonClearQueue = new Button();
            labelTotalSummary = new Label();
            panelRightPreviewCard = new Panel();
            labelPreviewHeader = new Label();
            pictureBoxSheetPreview = new PictureBox();
            panelPagination = new Panel();
            buttonPreviousPage = new Button();
            labelPageIndicator = new Label();
            buttonNextPage = new Button();
            buttonPrintSheet = new Button();
            buttonExportSheetPng = new Button();
            ((System.ComponentModel.ISupportInitialize)picIconAddLabelToQueue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconRemoveSelected).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconClearQueue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconPrintSheet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconExportSheetPng).BeginInit();
            panelHeader.SuspendLayout();
            panelLeftConfiguration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLabelQueue).BeginInit();
            panelRightPreviewCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSheetPreview).BeginInit();
            panelPagination.SuspendLayout();
            SuspendLayout();
            // 
            // picIconAddLabelToQueue
            // 
            picIconAddLabelToQueue.BackColor = Color.FromArgb(2, 132, 199);
            picIconAddLabelToQueue.Cursor = Cursors.Hand;
            picIconAddLabelToQueue.Image = Resources._075_ingreso_manual;
            picIconAddLabelToQueue.Location = new Point(355, 199);
            picIconAddLabelToQueue.Name = "picIconAddLabelToQueue";
            picIconAddLabelToQueue.Size = new Size(42, 38);
            picIconAddLabelToQueue.SizeMode = PictureBoxSizeMode.Zoom;
            picIconAddLabelToQueue.TabIndex = 99;
            picIconAddLabelToQueue.TabStop = false;
            // 
            // picIconRemoveSelected
            // 
            picIconRemoveSelected.BackColor = Color.FromArgb(239, 68, 68);
            picIconRemoveSelected.Cursor = Cursors.Hand;
            picIconRemoveSelected.Image = Resources._079_eliminar;
            picIconRemoveSelected.Location = new Point(24, 654);
            picIconRemoveSelected.Name = "picIconRemoveSelected";
            picIconRemoveSelected.Size = new Size(41, 32);
            picIconRemoveSelected.SizeMode = PictureBoxSizeMode.Zoom;
            picIconRemoveSelected.TabIndex = 99;
            picIconRemoveSelected.TabStop = false;
            // 
            // picIconClearQueue
            // 
            picIconClearQueue.BackColor = Color.FromArgb(255, 255, 255);
            picIconClearQueue.Cursor = Cursors.Hand;
            picIconClearQueue.Image = Resources._093_error;
            picIconClearQueue.Location = new Point(187, 655);
            picIconClearQueue.Name = "picIconClearQueue";
            picIconClearQueue.Size = new Size(31, 31);
            picIconClearQueue.SizeMode = PictureBoxSizeMode.Zoom;
            picIconClearQueue.TabIndex = 99;
            picIconClearQueue.TabStop = false;
            // 
            // picIconPrintSheet
            // 
            picIconPrintSheet.BackColor = Color.FromArgb(16, 185, 129);
            picIconPrintSheet.Cursor = Cursors.Hand;
            picIconPrintSheet.Image = Resources._082_imprimir;
            picIconPrintSheet.Location = new Point(51, 640);
            picIconPrintSheet.Name = "picIconPrintSheet";
            picIconPrintSheet.Size = new Size(45, 46);
            picIconPrintSheet.SizeMode = PictureBoxSizeMode.Zoom;
            picIconPrintSheet.TabIndex = 99;
            picIconPrintSheet.TabStop = false;
            // 
            // picIconExportSheetPng
            // 
            picIconExportSheetPng.BackColor = Color.FromArgb(255, 255, 255);
            picIconExportSheetPng.Cursor = Cursors.Hand;
            picIconExportSheetPng.Image = Resources._085_exportar_pdf;
            picIconExportSheetPng.Location = new Point(431, 642);
            picIconExportSheetPng.Name = "picIconExportSheetPng";
            picIconExportSheetPng.Size = new Size(36, 44);
            picIconExportSheetPng.SizeMode = PictureBoxSizeMode.Zoom;
            picIconExportSheetPng.TabIndex = 99;
            picIconExportSheetPng.TabStop = false;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1280, 68);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(20, 19);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(432, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "GENERADOR/IMPRESIÓN DE ETIQUETAS";
            // 
            // panelLeftConfiguration
            // 
            panelLeftConfiguration.BackColor = Color.White;
            panelLeftConfiguration.Controls.Add(labelSearchPrompt);
            panelLeftConfiguration.Controls.Add(quickSearchBox);
            panelLeftConfiguration.Controls.Add(labelSelectedProductInfo);
            panelLeftConfiguration.Controls.Add(labelDescriptionPrompt);
            panelLeftConfiguration.Controls.Add(textBoxShortDescription);
            panelLeftConfiguration.Controls.Add(labelPricePrompt);
            panelLeftConfiguration.Controls.Add(numericUpDownPrice);
            panelLeftConfiguration.Controls.Add(labelQuantityPrompt);
            panelLeftConfiguration.Controls.Add(numericUpDownQuantity);
            panelLeftConfiguration.Controls.Add(picIconAddLabelToQueue);
            panelLeftConfiguration.Controls.Add(buttonAddLabelToQueue);
            panelLeftConfiguration.Controls.Add(labelQueueTitle);
            panelLeftConfiguration.Controls.Add(dataGridViewLabelQueue);
            panelLeftConfiguration.Controls.Add(picIconRemoveSelected);
            panelLeftConfiguration.Controls.Add(buttonRemoveSelectedFromQueue);
            panelLeftConfiguration.Controls.Add(picIconClearQueue);
            panelLeftConfiguration.Controls.Add(buttonClearQueue);
            panelLeftConfiguration.Controls.Add(labelTotalSummary);
            panelLeftConfiguration.Location = new Point(20, 80);
            panelLeftConfiguration.Name = "panelLeftConfiguration";
            panelLeftConfiguration.Padding = new Padding(16);
            panelLeftConfiguration.Size = new Size(600, 742);
            panelLeftConfiguration.TabIndex = 1;
            // 
            // labelSearchPrompt
            // 
            labelSearchPrompt.AutoSize = true;
            labelSearchPrompt.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelSearchPrompt.Location = new Point(16, 10);
            labelSearchPrompt.Name = "labelSearchPrompt";
            labelSearchPrompt.Size = new Size(138, 21);
            labelSearchPrompt.TabIndex = 0;
            labelSearchPrompt.Text = "Buscar Producto:";
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
            // labelSelectedProductInfo
            // 
            labelSelectedProductInfo.AutoEllipsis = true;
            labelSelectedProductInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelSelectedProductInfo.ForeColor = Color.FromArgb(100, 116, 139);
            labelSelectedProductInfo.Location = new Point(16, 88);
            labelSelectedProductInfo.Name = "labelSelectedProductInfo";
            labelSelectedProductInfo.Size = new Size(568, 20);
            labelSelectedProductInfo.TabIndex = 2;
            labelSelectedProductInfo.Text = "Ningún producto seleccionado";
            // 
            // labelDescriptionPrompt
            // 
            labelDescriptionPrompt.AutoSize = true;
            labelDescriptionPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelDescriptionPrompt.Location = new Point(16, 118);
            labelDescriptionPrompt.Name = "labelDescriptionPrompt";
            labelDescriptionPrompt.Size = new Size(165, 20);
            labelDescriptionPrompt.TabIndex = 3;
            labelDescriptionPrompt.Text = "Texto para la Etiqueta:";
            // 
            // textBoxShortDescription
            // 
            textBoxShortDescription.BorderStyle = BorderStyle.FixedSingle;
            textBoxShortDescription.Font = new Font("Segoe UI", 9.5F);
            textBoxShortDescription.Location = new Point(13, 141);
            textBoxShortDescription.MaxLength = 50;
            textBoxShortDescription.Name = "textBoxShortDescription";
            textBoxShortDescription.Size = new Size(568, 29);
            textBoxShortDescription.TabIndex = 4;
            // 
            // labelPricePrompt
            // 
            labelPricePrompt.AutoSize = true;
            labelPricePrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelPricePrompt.Location = new Point(16, 182);
            labelPricePrompt.Name = "labelPricePrompt";
            labelPricePrompt.Size = new Size(81, 20);
            labelPricePrompt.TabIndex = 5;
            labelPricePrompt.Text = "Precio ($):";
            // 
            // numericUpDownPrice
            // 
            numericUpDownPrice.DecimalPlaces = 2;
            numericUpDownPrice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            numericUpDownPrice.Location = new Point(16, 205);
            numericUpDownPrice.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericUpDownPrice.Name = "numericUpDownPrice";
            numericUpDownPrice.Size = new Size(150, 30);
            numericUpDownPrice.TabIndex = 6;
            // 
            // labelQuantityPrompt
            // 
            labelQuantityPrompt.AutoSize = true;
            labelQuantityPrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelQuantityPrompt.Location = new Point(180, 182);
            labelQuantityPrompt.Name = "labelQuantityPrompt";
            labelQuantityPrompt.Size = new Size(75, 20);
            labelQuantityPrompt.TabIndex = 7;
            labelQuantityPrompt.Text = "Cantidad:";
            // 
            // numericUpDownQuantity
            // 
            numericUpDownQuantity.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            numericUpDownQuantity.Location = new Point(180, 205);
            numericUpDownQuantity.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownQuantity.Name = "numericUpDownQuantity";
            numericUpDownQuantity.Size = new Size(100, 30);
            numericUpDownQuantity.TabIndex = 8;
            numericUpDownQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // buttonAddLabelToQueue
            // 
            buttonAddLabelToQueue.BackColor = Color.FromArgb(2, 132, 199);
            buttonAddLabelToQueue.FlatAppearance.BorderSize = 0;
            buttonAddLabelToQueue.FlatStyle = FlatStyle.Flat;
            buttonAddLabelToQueue.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonAddLabelToQueue.ForeColor = Color.White;
            buttonAddLabelToQueue.Location = new Point(325, 199);
            buttonAddLabelToQueue.Name = "buttonAddLabelToQueue";
            buttonAddLabelToQueue.Size = new Size(221, 38);
            buttonAddLabelToQueue.TabIndex = 9;
            buttonAddLabelToQueue.Text = "AGREGAR";
            buttonAddLabelToQueue.UseVisualStyleBackColor = false;
            // 
            // labelQueueTitle
            // 
            labelQueueTitle.AutoSize = true;
            labelQueueTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelQueueTitle.ForeColor = Color.FromArgb(15, 23, 42);
            labelQueueTitle.Location = new Point(16, 266);
            labelQueueTitle.Name = "labelQueueTitle";
            labelQueueTitle.Size = new Size(300, 21);
            labelQueueTitle.TabIndex = 10;
            labelQueueTitle.Text = "Lista de Productos a Imprimir en Hoja:";
            // 
            // dataGridViewLabelQueue
            // 
            dataGridViewLabelQueue.BackgroundColor = Color.White;
            dataGridViewLabelQueue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLabelQueue.Location = new Point(16, 300);
            dataGridViewLabelQueue.Name = "dataGridViewLabelQueue";
            dataGridViewLabelQueue.RowHeadersWidth = 30;
            dataGridViewLabelQueue.Size = new Size(568, 330);
            dataGridViewLabelQueue.TabIndex = 11;
            // 
            // buttonRemoveSelectedFromQueue
            // 
            buttonRemoveSelectedFromQueue.BackColor = Color.FromArgb(239, 68, 68);
            buttonRemoveSelectedFromQueue.FlatAppearance.BorderSize = 0;
            buttonRemoveSelectedFromQueue.FlatStyle = FlatStyle.Flat;
            buttonRemoveSelectedFromQueue.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            buttonRemoveSelectedFromQueue.ForeColor = Color.White;
            buttonRemoveSelectedFromQueue.Location = new Point(16, 654);
            buttonRemoveSelectedFromQueue.Name = "buttonRemoveSelectedFromQueue";
            buttonRemoveSelectedFromQueue.Size = new Size(165, 32);
            buttonRemoveSelectedFromQueue.TabIndex = 12;
            buttonRemoveSelectedFromQueue.Text = "QUITAR";
            buttonRemoveSelectedFromQueue.UseVisualStyleBackColor = false;
            // 
            // buttonClearQueue
            // 
            buttonClearQueue.FlatStyle = FlatStyle.Flat;
            buttonClearQueue.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            buttonClearQueue.Location = new Point(187, 654);
            buttonClearQueue.Name = "buttonClearQueue";
            buttonClearQueue.Size = new Size(166, 32);
            buttonClearQueue.TabIndex = 13;
            buttonClearQueue.Text = "VACIAR LISTA";
            buttonClearQueue.UseVisualStyleBackColor = true;
            // 
            // labelTotalSummary
            // 
            labelTotalSummary.AutoEllipsis = true;
            labelTotalSummary.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelTotalSummary.ForeColor = Color.FromArgb(2, 132, 199);
            labelTotalSummary.Location = new Point(13, 694);
            labelTotalSummary.Name = "labelTotalSummary";
            labelTotalSummary.Size = new Size(568, 22);
            labelTotalSummary.TabIndex = 14;
            labelTotalSummary.Text = "Productos: 0  |  Total Etiquetas: 0  (0 hoja/s)";
            // 
            // panelRightPreviewCard
            // 
            panelRightPreviewCard.BackColor = Color.White;
            panelRightPreviewCard.Controls.Add(labelPreviewHeader);
            panelRightPreviewCard.Controls.Add(pictureBoxSheetPreview);
            panelRightPreviewCard.Controls.Add(panelPagination);
            panelRightPreviewCard.Controls.Add(picIconPrintSheet);
            panelRightPreviewCard.Controls.Add(buttonPrintSheet);
            panelRightPreviewCard.Controls.Add(picIconExportSheetPng);
            panelRightPreviewCard.Controls.Add(buttonExportSheetPng);
            panelRightPreviewCard.Location = new Point(640, 80);
            panelRightPreviewCard.Name = "panelRightPreviewCard";
            panelRightPreviewCard.Padding = new Padding(16);
            panelRightPreviewCard.Size = new Size(620, 742);
            panelRightPreviewCard.TabIndex = 2;
            // 
            // labelPreviewHeader
            // 
            labelPreviewHeader.AutoSize = true;
            labelPreviewHeader.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelPreviewHeader.ForeColor = Color.FromArgb(15, 23, 42);
            labelPreviewHeader.Location = new Point(16, 10);
            labelPreviewHeader.Name = "labelPreviewHeader";
            labelPreviewHeader.Size = new Size(246, 23);
            labelPreviewHeader.TabIndex = 0;
            labelPreviewHeader.Text = "VISTA PREVIA DE PLANTILLA:";
            // 
            // pictureBoxSheetPreview
            // 
            pictureBoxSheetPreview.BackColor = Color.FromArgb(248, 250, 252);
            pictureBoxSheetPreview.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxSheetPreview.Location = new Point(16, 36);
            pictureBoxSheetPreview.Name = "pictureBoxSheetPreview";
            pictureBoxSheetPreview.Size = new Size(588, 506);
            pictureBoxSheetPreview.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxSheetPreview.TabIndex = 1;
            pictureBoxSheetPreview.TabStop = false;
            // 
            // panelPagination
            // 
            panelPagination.Controls.Add(buttonPreviousPage);
            panelPagination.Controls.Add(labelPageIndicator);
            panelPagination.Controls.Add(buttonNextPage);
            panelPagination.Location = new Point(16, 562);
            panelPagination.Name = "panelPagination";
            panelPagination.Size = new Size(588, 33);
            panelPagination.TabIndex = 2;
            // 
            // buttonPreviousPage
            // 
            buttonPreviousPage.FlatStyle = FlatStyle.Flat;
            buttonPreviousPage.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            buttonPreviousPage.Location = new Point(150, 2);
            buttonPreviousPage.Name = "buttonPreviousPage";
            buttonPreviousPage.Size = new Size(80, 28);
            buttonPreviousPage.TabIndex = 0;
            buttonPreviousPage.Text = "◀ ANTERIOR";
            buttonPreviousPage.UseVisualStyleBackColor = true;
            // 
            // labelPageIndicator
            // 
            labelPageIndicator.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelPageIndicator.ForeColor = Color.FromArgb(100, 116, 139);
            labelPageIndicator.Location = new Point(235, 2);
            labelPageIndicator.Name = "labelPageIndicator";
            labelPageIndicator.Size = new Size(120, 28);
            labelPageIndicator.TabIndex = 1;
            labelPageIndicator.Text = "Página 1 de 1";
            labelPageIndicator.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonNextPage
            // 
            buttonNextPage.FlatStyle = FlatStyle.Flat;
            buttonNextPage.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            buttonNextPage.Location = new Point(360, 2);
            buttonNextPage.Name = "buttonNextPage";
            buttonNextPage.Size = new Size(114, 28);
            buttonNextPage.TabIndex = 2;
            buttonNextPage.Text = "SIGUIENTE ▶";
            buttonNextPage.UseVisualStyleBackColor = true;
            // 
            // buttonPrintSheet
            // 
            buttonPrintSheet.BackColor = Color.FromArgb(16, 185, 129);
            buttonPrintSheet.FlatAppearance.BorderSize = 0;
            buttonPrintSheet.FlatStyle = FlatStyle.Flat;
            buttonPrintSheet.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonPrintSheet.ForeColor = Color.White;
            buttonPrintSheet.Location = new Point(18, 611);
            buttonPrintSheet.Name = "buttonPrintSheet";
            buttonPrintSheet.Size = new Size(380, 105);
            buttonPrintSheet.TabIndex = 3;
            buttonPrintSheet.Text = "IMPRIMIR PLANTILLA(S)";
            buttonPrintSheet.UseVisualStyleBackColor = false;
            // 
            // buttonExportSheetPng
            // 
            buttonExportSheetPng.FlatStyle = FlatStyle.Flat;
            buttonExportSheetPng.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonExportSheetPng.Location = new Point(404, 611);
            buttonExportSheetPng.Name = "buttonExportSheetPng";
            buttonExportSheetPng.Size = new Size(200, 105);
            buttonExportSheetPng.TabIndex = 4;
            buttonExportSheetPng.Text = "GUARDAR";
            buttonExportSheetPng.UseVisualStyleBackColor = true;
            // 
            // FormProductLabels
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1280, 837);
            Controls.Add(panelRightPreviewCard);
            Controls.Add(panelLeftConfiguration);
            Controls.Add(panelHeader);
            KeyPreview = true;
            Name = "FormProductLabels";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Generador de Etiquetas de Precio";
            ((System.ComponentModel.ISupportInitialize)picIconAddLabelToQueue).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconRemoveSelected).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconClearQueue).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconPrintSheet).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconExportSheetPng).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelLeftConfiguration.ResumeLayout(false);
            panelLeftConfiguration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLabelQueue).EndInit();
            panelRightPreviewCard.ResumeLayout(false);
            panelRightPreviewCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSheetPreview).EndInit();
            panelPagination.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelLeftConfiguration;
        private System.Windows.Forms.Label labelSearchPrompt;
        private Controls.QuickSearchProductBox quickSearchBox;
        private System.Windows.Forms.Label labelSelectedProductInfo;
        private System.Windows.Forms.Label labelDescriptionPrompt;
        private System.Windows.Forms.TextBox textBoxShortDescription;
        private System.Windows.Forms.Label labelPricePrompt;
        private System.Windows.Forms.NumericUpDown numericUpDownPrice;
        private System.Windows.Forms.Label labelQuantityPrompt;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.Button buttonAddLabelToQueue;
        private System.Windows.Forms.Label labelQueueTitle;
        private System.Windows.Forms.DataGridView dataGridViewLabelQueue;
        private System.Windows.Forms.Button buttonRemoveSelectedFromQueue;
        private System.Windows.Forms.Button buttonClearQueue;
        private System.Windows.Forms.Label labelTotalSummary;
        private System.Windows.Forms.Panel panelRightPreviewCard;
        private System.Windows.Forms.Label labelPreviewHeader;
        private System.Windows.Forms.PictureBox pictureBoxSheetPreview;
        private System.Windows.Forms.Panel panelPagination;
        private System.Windows.Forms.Button buttonPreviousPage;
        private System.Windows.Forms.Label labelPageIndicator;
        private System.Windows.Forms.Button buttonNextPage;
        private System.Windows.Forms.Button buttonPrintSheet;
        private System.Windows.Forms.Button buttonExportSheetPng;
        private System.Windows.Forms.PictureBox picIconAddLabelToQueue;
        private System.Windows.Forms.PictureBox picIconRemoveSelected;
        private System.Windows.Forms.PictureBox picIconClearQueue;
        private System.Windows.Forms.PictureBox picIconPrintSheet;
        private System.Windows.Forms.PictureBox picIconExportSheetPng;
    }
}
