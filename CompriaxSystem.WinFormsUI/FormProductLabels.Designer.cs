namespace CompriaxSystem.WinFormsUI
{
    partial class FormProductLabels
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
            lblSubtitle = new Label();
            pnlConfigCard = new Panel();
            lblSearch = new Label();
            quickSearchBox = new CompriaxSystem.WinFormsUI.Controls.QuickSearchProductBox();
            lblSelectedInfo = new Label();
            lblDescTitle = new Label();
            txtShortDescription = new TextBox();
            lblPriceTitle = new Label();
            numPrice = new NumericUpDown();
            lblQtyTitle = new Label();
            numQuantity = new NumericUpDown();
            chkShowStore = new CheckBox();
            chkShowDate = new CheckBox();
            btnGenerate = new Button();
            btnClear = new Button();
            pnlPreviewCard = new Panel();
            lblPreviewHeader = new Label();
            picLabelPreview = new PictureBox();
            lblPreviewStatus = new Label();
            btnPrint = new Button();
            btnDownload = new Button();
            pnlHeader.SuspendLayout();
            pnlConfigCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            pnlPreviewCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLabelPreview).BeginInit();
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
            pnlHeader.Size = new Size(1200, 74);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 23);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(688, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "CREADOR E IMPRESIÓN DE ETIQUETAS DE GÓNDOLA Y CÓDIGOS";
            // 
            // lblSubtitle
            // 
            lblSubtitle.Location = new Point(0, 0);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(100, 23);
            lblSubtitle.TabIndex = 1;
            // 
            // pnlConfigCard
            // 
            pnlConfigCard.BackColor = Color.White;
            pnlConfigCard.Controls.Add(lblSearch);
            pnlConfigCard.Controls.Add(quickSearchBox);
            pnlConfigCard.Controls.Add(lblSelectedInfo);
            pnlConfigCard.Controls.Add(lblDescTitle);
            pnlConfigCard.Controls.Add(txtShortDescription);
            pnlConfigCard.Controls.Add(lblPriceTitle);
            pnlConfigCard.Controls.Add(numPrice);
            pnlConfigCard.Controls.Add(lblQtyTitle);
            pnlConfigCard.Controls.Add(numQuantity);
            pnlConfigCard.Controls.Add(chkShowStore);
            pnlConfigCard.Controls.Add(chkShowDate);
            pnlConfigCard.Controls.Add(btnGenerate);
            pnlConfigCard.Controls.Add(btnClear);
            pnlConfigCard.Location = new Point(20, 80);
            pnlConfigCard.Name = "pnlConfigCard";
            pnlConfigCard.Padding = new Padding(16);
            pnlConfigCard.Size = new Size(520, 560);
            pnlConfigCard.TabIndex = 1;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSearch.Location = new Point(16, 12);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(138, 21);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Buscar Producto:";
            // 
            // quickSearchBox
            // 
            quickSearchBox.BackColor = Color.White;
            quickSearchBox.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            quickSearchBox.Location = new Point(16, 38);
            quickSearchBox.Name = "quickSearchBox";
            quickSearchBox.PlaceholderText = "Escriba nombre o pase el lector de código [F2]...";
            quickSearchBox.Size = new Size(488, 47);
            quickSearchBox.TabIndex = 1;
            // 
            // lblSelectedInfo
            // 
            lblSelectedInfo.AutoEllipsis = true;
            lblSelectedInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSelectedInfo.ForeColor = Color.FromArgb(100, 116, 139);
            lblSelectedInfo.Location = new Point(16, 90);
            lblSelectedInfo.Name = "lblSelectedInfo";
            lblSelectedInfo.Size = new Size(227, 22);
            lblSelectedInfo.TabIndex = 2;
            lblSelectedInfo.Text = "Ningún producto seleccionado";
            // 
            // lblDescTitle
            // 
            lblDescTitle.AutoSize = true;
            lblDescTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDescTitle.Location = new Point(13, 124);
            lblDescTitle.Name = "lblDescTitle";
            lblDescTitle.Size = new Size(213, 21);
            lblDescTitle.TabIndex = 3;
            lblDescTitle.Text = "Descripción de la etiqueta:";
            // 
            // txtShortDescription
            // 
            txtShortDescription.BorderStyle = BorderStyle.FixedSingle;
            txtShortDescription.Font = new Font("Segoe UI", 10F);
            txtShortDescription.Location = new Point(13, 147);
            txtShortDescription.MaxLength = 60;
            txtShortDescription.Name = "txtShortDescription";
            txtShortDescription.PlaceholderText = "Ej: Coca-Cola 2.25L Original";
            txtShortDescription.Size = new Size(488, 30);
            txtShortDescription.TabIndex = 4;
            // 
            // lblPriceTitle
            // 
            lblPriceTitle.AutoSize = true;
            lblPriceTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPriceTitle.Location = new Point(13, 197);
            lblPriceTitle.Name = "lblPriceTitle";
            lblPriceTitle.Size = new Size(163, 21);
            lblPriceTitle.TabIndex = 5;
            lblPriceTitle.Text = "Precio a Mostrar ($):";
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            numPrice.Location = new Point(13, 220);
            numPrice.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(230, 32);
            numPrice.TabIndex = 6;
            // 
            // lblQtyTitle
            // 
            lblQtyTitle.AutoSize = true;
            lblQtyTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblQtyTitle.Location = new Point(271, 197);
            lblQtyTitle.Name = "lblQtyTitle";
            lblQtyTitle.Size = new Size(181, 21);
            lblQtyTitle.TabIndex = 7;
            lblQtyTitle.Text = "Cantidad de Etiquetas:";
            // 
            // numQuantity
            // 
            numQuantity.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            numQuantity.Location = new Point(271, 220);
            numQuantity.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(230, 32);
            numQuantity.TabIndex = 8;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // chkShowStore
            // 
            chkShowStore.AutoSize = true;
            chkShowStore.Checked = true;
            chkShowStore.CheckState = CheckState.Checked;
            chkShowStore.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            chkShowStore.Location = new Point(11, 271);
            chkShowStore.Name = "chkShowStore";
            chkShowStore.Size = new Size(232, 24);
            chkShowStore.TabIndex = 9;
            chkShowStore.Text = "Incluir Nombre del Comercio";
            chkShowStore.UseVisualStyleBackColor = true;
            // 
            // chkShowDate
            // 
            chkShowDate.AutoSize = true;
            chkShowDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            chkShowDate.Location = new Point(269, 271);
            chkShowDate.Name = "chkShowDate";
            chkShowDate.Size = new Size(223, 24);
            chkShowDate.TabIndex = 10;
            chkShowDate.Text = "Incluir Fecha de Generación";
            chkShowDate.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = Color.FromArgb(2, 132, 199);
            btnGenerate.FlatAppearance.BorderSize = 0;
            btnGenerate.FlatStyle = FlatStyle.Flat;
            btnGenerate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGenerate.ForeColor = Color.White;
            btnGenerate.Location = new Point(13, 319);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(488, 99);
            btnGenerate.TabIndex = 11;
            btnGenerate.Text = "ACTUALIZAR VISTA PREVIA";
            btnGenerate.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClear.Location = new Point(13, 445);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(488, 96);
            btnClear.TabIndex = 12;
            btnClear.Text = "LIMPIAR CAMPOS";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // pnlPreviewCard
            // 
            pnlPreviewCard.BackColor = Color.White;
            pnlPreviewCard.Controls.Add(lblPreviewHeader);
            pnlPreviewCard.Controls.Add(picLabelPreview);
            pnlPreviewCard.Controls.Add(lblPreviewStatus);
            pnlPreviewCard.Controls.Add(btnPrint);
            pnlPreviewCard.Controls.Add(btnDownload);
            pnlPreviewCard.Location = new Point(560, 80);
            pnlPreviewCard.Name = "pnlPreviewCard";
            pnlPreviewCard.Padding = new Padding(16);
            pnlPreviewCard.Size = new Size(620, 560);
            pnlPreviewCard.TabIndex = 2;
            // 
            // lblPreviewHeader
            // 
            lblPreviewHeader.AutoSize = true;
            lblPreviewHeader.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPreviewHeader.ForeColor = Color.FromArgb(15, 23, 42);
            lblPreviewHeader.Location = new Point(16, 12);
            lblPreviewHeader.Name = "lblPreviewHeader";
            lblPreviewHeader.Size = new Size(231, 23);
            lblPreviewHeader.TabIndex = 0;
            lblPreviewHeader.Text = "VISTA PREVIA DE ETIQUETA";
            // 
            // picLabelPreview
            // 
            picLabelPreview.BackColor = Color.FromArgb(248, 250, 252);
            picLabelPreview.BorderStyle = BorderStyle.FixedSingle;
            picLabelPreview.Location = new Point(16, 38);
            picLabelPreview.Name = "picLabelPreview";
            picLabelPreview.Size = new Size(588, 290);
            picLabelPreview.SizeMode = PictureBoxSizeMode.Zoom;
            picLabelPreview.TabIndex = 1;
            picLabelPreview.TabStop = false;
            // 
            // lblPreviewStatus
            // 
            lblPreviewStatus.AutoEllipsis = true;
            lblPreviewStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPreviewStatus.ForeColor = Color.FromArgb(16, 185, 129);
            lblPreviewStatus.Location = new Point(16, 336);
            lblPreviewStatus.Name = "lblPreviewStatus";
            lblPreviewStatus.Size = new Size(588, 22);
            lblPreviewStatus.TabIndex = 2;
            lblPreviewStatus.Text = "Seleccione un producto para previsualizar.";
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.FromArgb(16, 185, 129);
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(16, 371);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(588, 79);
            btnPrint.TabIndex = 3;
            btnPrint.Text = "IMPRIMIR ETIQUETA(S)";
            btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnDownload
            // 
            btnDownload.FlatStyle = FlatStyle.Flat;
            btnDownload.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDownload.Location = new Point(16, 465);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(588, 76);
            btnDownload.TabIndex = 4;
            btnDownload.Text = "GUARDAR COMO IMAGEN PNG";
            btnDownload.UseVisualStyleBackColor = true;
            // 
            // FormProductLabels
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1200, 660);
            Controls.Add(pnlPreviewCard);
            Controls.Add(pnlConfigCard);
            Controls.Add(pnlHeader);
            KeyPreview = true;
            Name = "FormProductLabels";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión e Impresión de Etiquetas - CompriaxSystem";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlConfigCard.ResumeLayout(false);
            pnlConfigCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            pnlPreviewCard.ResumeLayout(false);
            pnlPreviewCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLabelPreview).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlConfigCard;
        private System.Windows.Forms.Label lblSearch;
        private Controls.QuickSearchProductBox quickSearchBox;
        private System.Windows.Forms.Label lblSelectedInfo;
        private System.Windows.Forms.Label lblDescTitle;
        private System.Windows.Forms.TextBox txtShortDescription;
        private System.Windows.Forms.Label lblPriceTitle;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Label lblQtyTitle;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.CheckBox chkShowStore;
        private System.Windows.Forms.CheckBox chkShowDate;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlPreviewCard;
        private System.Windows.Forms.Label lblPreviewHeader;
        private System.Windows.Forms.PictureBox picLabelPreview;
        private System.Windows.Forms.Label lblPreviewStatus;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnDownload;
    }
}