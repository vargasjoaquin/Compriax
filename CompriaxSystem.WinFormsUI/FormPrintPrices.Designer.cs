namespace CompriaxSystem.WinFormsUI
{
    partial class FormPrintPrices
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
            lblHeader = new Label();
            gbGenerator = new Panel();
            picBarcodePreview = new PictureBox();
            lblSelectedProductName = new Label();
            btnGenerate = new Button();
            btnPrint = new Button();
            btnDownload = new Button();
            dgvProducts = new DataGridView();
            pnlHeader.SuspendLayout();
            gbGenerator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBarcodePreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(15, 23, 42);
            pnlHeader.Controls.Add(lblHeader);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1065, 56);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(16, 16);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(723, 30);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "🏷️ GENERADOR DE ETIQUETAS DE GÓNDOLA Y CÓDIGO DE BARRAS";
            // 
            // gbGenerator
            // 
            gbGenerator.BackColor = Color.White;
            gbGenerator.Controls.Add(picBarcodePreview);
            gbGenerator.Controls.Add(lblSelectedProductName);
            gbGenerator.Location = new Point(16, 72);
            gbGenerator.Name = "gbGenerator";
            gbGenerator.Size = new Size(663, 271);
            gbGenerator.TabIndex = 1;
            // 
            // picBarcodePreview
            // 
            picBarcodePreview.BackColor = Color.FromArgb(248, 250, 252);
            picBarcodePreview.BorderStyle = BorderStyle.FixedSingle;
            picBarcodePreview.Location = new Point(16, 16);
            picBarcodePreview.Name = "picBarcodePreview";
            picBarcodePreview.Size = new Size(632, 172);
            picBarcodePreview.SizeMode = PictureBoxSizeMode.Zoom;
            picBarcodePreview.TabIndex = 0;
            picBarcodePreview.TabStop = false;
            // 
            // lblSelectedProductName
            // 
            lblSelectedProductName.AutoSize = true;
            lblSelectedProductName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSelectedProductName.ForeColor = Color.FromArgb(2, 132, 199);
            lblSelectedProductName.Location = new Point(16, 219);
            lblSelectedProductName.Name = "lblSelectedProductName";
            lblSelectedProductName.Size = new Size(246, 21);
            lblSelectedProductName.TabIndex = 1;
            lblSelectedProductName.Text = "Ningún producto seleccionado";
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = Color.FromArgb(2, 132, 199);
            btnGenerate.FlatAppearance.BorderSize = 0;
            btnGenerate.FlatStyle = FlatStyle.Flat;
            btnGenerate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnGenerate.ForeColor = Color.White;
            btnGenerate.Location = new Point(695, 72);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(351, 82);
            btnGenerate.TabIndex = 2;
            btnGenerate.Text = "🔄 GENERAR CODIGO DE BARRAS";
            btnGenerate.UseVisualStyleBackColor = false;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.FromArgb(16, 185, 129);
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(695, 160);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(351, 95);
            btnPrint.TabIndex = 3;
            btnPrint.Text = "🖨️ IMPRIMIR CODIGO DE BARRAS";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnDownload
            // 
            btnDownload.FlatStyle = FlatStyle.Flat;
            btnDownload.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDownload.Location = new Point(695, 261);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(351, 82);
            btnDownload.TabIndex = 4;
            btnDownload.Text = "💾 GUARDAR CODIGO DE BARRAS";
            btnDownload.UseVisualStyleBackColor = true;
            // 
            // dgvProducts
            // 
            dgvProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.BorderStyle = BorderStyle.None;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(16, 349);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.Size = new Size(1030, 315);
            dgvProducts.TabIndex = 5;
            // 
            // FormPrintPrices
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1065, 679);
            Controls.Add(dgvProducts);
            Controls.Add(btnDownload);
            Controls.Add(btnPrint);
            Controls.Add(btnGenerate);
            Controls.Add(gbGenerator);
            Controls.Add(pnlHeader);
            Name = "FormPrintPrices";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Etiquetas de Precio";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            gbGenerator.ResumeLayout(false);
            gbGenerator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picBarcodePreview).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel gbGenerator;
        private System.Windows.Forms.PictureBox picBarcodePreview;
        private System.Windows.Forms.Label lblSelectedProductName;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.DataGridView dgvProducts;
    }
}