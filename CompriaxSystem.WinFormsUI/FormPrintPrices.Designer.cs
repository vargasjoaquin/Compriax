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
            panelHeader = new Panel();
            labelHeaderTitle = new Label();
            panelLabelGeneratorCard = new Panel();
            pictureBoxBarcodePreview = new PictureBox();
            labelSelectedProductName = new Label();
            buttonGenerateLabel = new Button();
            buttonPrintLabel = new Button();
            buttonSaveLabelImage = new Button();
            dataGridViewProducts = new DataGridView();
            panelHeader.SuspendLayout();
            panelLabelGeneratorCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBarcodePreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelHeaderTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1065, 56);
            panelHeader.TabIndex = 0;
            // 
            // labelHeaderTitle
            // 
            labelHeaderTitle.AutoSize = true;
            labelHeaderTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelHeaderTitle.ForeColor = Color.White;
            labelHeaderTitle.Location = new Point(16, 16);
            labelHeaderTitle.Name = "labelHeaderTitle";
            labelHeaderTitle.Size = new Size(723, 30);
            labelHeaderTitle.TabIndex = 0;
            labelHeaderTitle.Text = "GENERADOR DE ETIQUETAS DE GÓNDOLA Y CÓDIGO DE BARRAS";
            // 
            // panelLabelGeneratorCard
            // 
            panelLabelGeneratorCard.BackColor = Color.White;
            panelLabelGeneratorCard.Controls.Add(pictureBoxBarcodePreview);
            panelLabelGeneratorCard.Controls.Add(labelSelectedProductName);
            panelLabelGeneratorCard.Location = new Point(16, 72);
            panelLabelGeneratorCard.Name = "panelLabelGeneratorCard";
            panelLabelGeneratorCard.Size = new Size(663, 271);
            panelLabelGeneratorCard.TabIndex = 1;
            // 
            // pictureBoxBarcodePreview
            // 
            pictureBoxBarcodePreview.BackColor = Color.FromArgb(248, 250, 252);
            pictureBoxBarcodePreview.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxBarcodePreview.Location = new Point(16, 16);
            pictureBoxBarcodePreview.Name = "pictureBoxBarcodePreview";
            pictureBoxBarcodePreview.Size = new Size(632, 172);
            pictureBoxBarcodePreview.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxBarcodePreview.TabIndex = 0;
            pictureBoxBarcodePreview.TabStop = false;
            // 
            // labelSelectedProductName
            // 
            labelSelectedProductName.AutoSize = true;
            labelSelectedProductName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelSelectedProductName.ForeColor = Color.FromArgb(2, 132, 199);
            labelSelectedProductName.Location = new Point(16, 219);
            labelSelectedProductName.Name = "labelSelectedProductName";
            labelSelectedProductName.Size = new Size(246, 21);
            labelSelectedProductName.TabIndex = 1;
            labelSelectedProductName.Text = "Ningún producto seleccionado";
            // 
            // buttonGenerateLabel
            // 
            buttonGenerateLabel.BackColor = Color.FromArgb(2, 132, 199);
            buttonGenerateLabel.FlatAppearance.BorderSize = 0;
            buttonGenerateLabel.FlatStyle = FlatStyle.Flat;
            buttonGenerateLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonGenerateLabel.ForeColor = Color.White;
            buttonGenerateLabel.Location = new Point(695, 72);
            buttonGenerateLabel.Name = "buttonGenerateLabel";
            buttonGenerateLabel.Size = new Size(351, 82);
            buttonGenerateLabel.TabIndex = 2;
            buttonGenerateLabel.Text = "GENERAR CODIGO DE BARRAS";
            buttonGenerateLabel.UseVisualStyleBackColor = false;
            // 
            // buttonPrintLabel
            // 
            buttonPrintLabel.BackColor = Color.FromArgb(16, 185, 129);
            buttonPrintLabel.FlatAppearance.BorderSize = 0;
            buttonPrintLabel.FlatStyle = FlatStyle.Flat;
            buttonPrintLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonPrintLabel.ForeColor = Color.White;
            buttonPrintLabel.Location = new Point(695, 160);
            buttonPrintLabel.Name = "buttonPrintLabel";
            buttonPrintLabel.Size = new Size(351, 95);
            buttonPrintLabel.TabIndex = 3;
            buttonPrintLabel.Text = "IMPRIMIR CODIGO DE BARRAS";
            buttonPrintLabel.UseVisualStyleBackColor = false;
            // 
            // buttonSaveLabelImage
            // 
            buttonSaveLabelImage.FlatStyle = FlatStyle.Flat;
            buttonSaveLabelImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonSaveLabelImage.Location = new Point(695, 261);
            buttonSaveLabelImage.Name = "buttonSaveLabelImage";
            buttonSaveLabelImage.Size = new Size(351, 82);
            buttonSaveLabelImage.TabIndex = 4;
            buttonSaveLabelImage.Text = "GUARDAR CODIGO DE BARRAS";
            buttonSaveLabelImage.UseVisualStyleBackColor = true;
            // 
            // dataGridViewProducts
            // 
            dataGridViewProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewProducts.BackgroundColor = Color.White;
            dataGridViewProducts.BorderStyle = BorderStyle.None;
            dataGridViewProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProducts.Location = new Point(16, 349);
            dataGridViewProducts.Name = "dataGridViewProducts";
            dataGridViewProducts.RowHeadersWidth = 51;
            dataGridViewProducts.Size = new Size(1030, 315);
            dataGridViewProducts.TabIndex = 5;
            // 
            // FormPrintPrices
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1065, 679);
            Controls.Add(dataGridViewProducts);
            Controls.Add(buttonSaveLabelImage);
            Controls.Add(buttonPrintLabel);
            Controls.Add(buttonGenerateLabel);
            Controls.Add(panelLabelGeneratorCard);
            Controls.Add(panelHeader);
            Name = "FormPrintPrices";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Etiquetas de Precio";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelLabelGeneratorCard.ResumeLayout(false);
            panelLabelGeneratorCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBarcodePreview).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeaderTitle;
        private System.Windows.Forms.Panel panelLabelGeneratorCard;
        private System.Windows.Forms.PictureBox pictureBoxBarcodePreview;
        private System.Windows.Forms.Label labelSelectedProductName;
        private System.Windows.Forms.Button buttonGenerateLabel;
        private System.Windows.Forms.Button buttonPrintLabel;
        private System.Windows.Forms.Button buttonSaveLabelImage;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
    }
}