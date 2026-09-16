namespace CompriaxSystem.WinFormsUI
{
    partial class FormSaleDetail
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
            labelTitle = new Label();
            buttonDownloadPdf = new Button();
            panelSearchCard = new Panel();
            labelDocumentNumberPrompt = new Label();
            textBoxSearchDocumentNumber = new TextBox();
            buttonSearch = new Button();
            buttonClearSearch = new Button();
            panelVoucherInfoCard = new Panel();
            labelIssueDate = new Label();
            textBoxIssueDate = new TextBox();
            labelDocumentType = new Label();
            textBoxDocumentType = new TextBox();
            labelCashierName = new Label();
            textBoxCashierName = new TextBox();
            labelCustomerDoc = new Label();
            textBoxCustomerDoc = new TextBox();
            labelCustomerFirstName = new Label();
            textBoxCustomerFirstName = new TextBox();
            labelCustomerLastName = new Label();
            textBoxCustomerLastName = new TextBox();
            dataGridViewSaleItems = new DataGridView();
            panelTotalsCard = new Panel();
            labelTotalPrompt = new Label();
            textBoxTotalAmount = new TextBox();
            labelAmountPaidPrompt = new Label();
            textBoxAmountPaid = new TextBox();
            labelChangePrompt = new Label();
            textBoxChangeAmount = new TextBox();
            panelHeader.SuspendLayout();
            panelSearchCard.SuspendLayout();
            panelVoucherInfoCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSaleItems).BeginInit();
            panelTotalsCard.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Controls.Add(buttonDownloadPdf);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1137, 87);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 25);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(514, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "AUDITORÍA Y CONSULTA DE COMPROBANTE";
            // 
            // buttonDownloadPdf
            // 
            buttonDownloadPdf.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonDownloadPdf.BackColor = Color.FromArgb(2, 132, 199);
            buttonDownloadPdf.FlatAppearance.BorderSize = 0;
            buttonDownloadPdf.FlatStyle = FlatStyle.Flat;
            buttonDownloadPdf.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonDownloadPdf.ForeColor = Color.White;
            buttonDownloadPdf.Location = new Point(911, 12);
            buttonDownloadPdf.Name = "buttonDownloadPdf";
            buttonDownloadPdf.Size = new Size(184, 60);
            buttonDownloadPdf.TabIndex = 1;
            buttonDownloadPdf.Text = "REIMPRIMIR PDF";
            buttonDownloadPdf.UseVisualStyleBackColor = false;
            // 
            // panelSearchCard
            // 
            panelSearchCard.BackColor = Color.White;
            panelSearchCard.Controls.Add(labelDocumentNumberPrompt);
            panelSearchCard.Controls.Add(textBoxSearchDocumentNumber);
            panelSearchCard.Controls.Add(buttonSearch);
            panelSearchCard.Controls.Add(buttonClearSearch);
            panelSearchCard.Location = new Point(16, 93);
            panelSearchCard.Name = "panelSearchCard";
            panelSearchCard.Size = new Size(1068, 51);
            panelSearchCard.TabIndex = 1;
            // 
            // labelDocumentNumberPrompt
            // 
            labelDocumentNumberPrompt.AutoSize = true;
            labelDocumentNumberPrompt.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelDocumentNumberPrompt.Location = new Point(16, 15);
            labelDocumentNumberPrompt.Name = "labelDocumentNumberPrompt";
            labelDocumentNumberPrompt.Size = new Size(209, 21);
            labelDocumentNumberPrompt.TabIndex = 0;
            labelDocumentNumberPrompt.Text = "Número de Comprobante:";
            // 
            // textBoxSearchDocumentNumber
            // 
            textBoxSearchDocumentNumber.BorderStyle = BorderStyle.FixedSingle;
            textBoxSearchDocumentNumber.Font = new Font("Segoe UI", 10F);
            textBoxSearchDocumentNumber.Location = new Point(231, 12);
            textBoxSearchDocumentNumber.Name = "textBoxSearchDocumentNumber";
            textBoxSearchDocumentNumber.Size = new Size(280, 30);
            textBoxSearchDocumentNumber.TabIndex = 1;
            // 
            // buttonSearch
            // 
            buttonSearch.BackColor = Color.FromArgb(2, 132, 199);
            buttonSearch.FlatAppearance.BorderSize = 0;
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonSearch.ForeColor = Color.White;
            buttonSearch.Location = new Point(534, 3);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(130, 41);
            buttonSearch.TabIndex = 2;
            buttonSearch.Text = "BUSCAR";
            buttonSearch.UseVisualStyleBackColor = false;
            // 
            // buttonClearSearch
            // 
            buttonClearSearch.FlatStyle = FlatStyle.Flat;
            buttonClearSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonClearSearch.Location = new Point(670, 3);
            buttonClearSearch.Name = "buttonClearSearch";
            buttonClearSearch.Size = new Size(111, 41);
            buttonClearSearch.TabIndex = 3;
            buttonClearSearch.Text = "LIMPIAR";
            buttonClearSearch.UseVisualStyleBackColor = true;
            // 
            // panelVoucherInfoCard
            // 
            panelVoucherInfoCard.BackColor = Color.White;
            panelVoucherInfoCard.Controls.Add(labelIssueDate);
            panelVoucherInfoCard.Controls.Add(textBoxIssueDate);
            panelVoucherInfoCard.Controls.Add(labelDocumentType);
            panelVoucherInfoCard.Controls.Add(textBoxDocumentType);
            panelVoucherInfoCard.Controls.Add(labelCashierName);
            panelVoucherInfoCard.Controls.Add(textBoxCashierName);
            panelVoucherInfoCard.Controls.Add(labelCustomerDoc);
            panelVoucherInfoCard.Controls.Add(textBoxCustomerDoc);
            panelVoucherInfoCard.Controls.Add(labelCustomerFirstName);
            panelVoucherInfoCard.Controls.Add(textBoxCustomerFirstName);
            panelVoucherInfoCard.Controls.Add(labelCustomerLastName);
            panelVoucherInfoCard.Controls.Add(textBoxCustomerLastName);
            panelVoucherInfoCard.Location = new Point(16, 150);
            panelVoucherInfoCard.Name = "panelVoucherInfoCard";
            panelVoucherInfoCard.Size = new Size(1068, 173);
            panelVoucherInfoCard.TabIndex = 2;
            // 
            // labelIssueDate
            // 
            labelIssueDate.AutoSize = true;
            labelIssueDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelIssueDate.Location = new Point(16, 12);
            labelIssueDate.Name = "labelIssueDate";
            labelIssueDate.Size = new Size(123, 21);
            labelIssueDate.TabIndex = 0;
            labelIssueDate.Text = "Fecha Emisión:";
            // 
            // textBoxIssueDate
            // 
            textBoxIssueDate.BorderStyle = BorderStyle.FixedSingle;
            textBoxIssueDate.Font = new Font("Segoe UI", 10F);
            textBoxIssueDate.Location = new Point(16, 34);
            textBoxIssueDate.Name = "textBoxIssueDate";
            textBoxIssueDate.ReadOnly = true;
            textBoxIssueDate.Size = new Size(140, 30);
            textBoxIssueDate.TabIndex = 1;
            // 
            // labelDocumentType
            // 
            labelDocumentType.AutoSize = true;
            labelDocumentType.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelDocumentType.Location = new Point(170, 12);
            labelDocumentType.Name = "labelDocumentType";
            labelDocumentType.Size = new Size(157, 21);
            labelDocumentType.TabIndex = 2;
            labelDocumentType.Text = "Tipo Comprobante:";
            // 
            // textBoxDocumentType
            // 
            textBoxDocumentType.BorderStyle = BorderStyle.FixedSingle;
            textBoxDocumentType.Font = new Font("Segoe UI", 10F);
            textBoxDocumentType.Location = new Point(170, 34);
            textBoxDocumentType.Name = "textBoxDocumentType";
            textBoxDocumentType.ReadOnly = true;
            textBoxDocumentType.Size = new Size(160, 30);
            textBoxDocumentType.TabIndex = 3;
            // 
            // labelCashierName
            // 
            labelCashierName.AutoSize = true;
            labelCashierName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelCashierName.Location = new Point(345, 12);
            labelCashierName.Name = "labelCashierName";
            labelCashierName.Size = new Size(151, 21);
            labelCashierName.TabIndex = 4;
            labelCashierName.Text = "Cajero / Operador:";
            // 
            // textBoxCashierName
            // 
            textBoxCashierName.BorderStyle = BorderStyle.FixedSingle;
            textBoxCashierName.Font = new Font("Segoe UI", 10F);
            textBoxCashierName.Location = new Point(345, 34);
            textBoxCashierName.Name = "textBoxCashierName";
            textBoxCashierName.ReadOnly = true;
            textBoxCashierName.Size = new Size(200, 30);
            textBoxCashierName.TabIndex = 5;
            // 
            // labelCustomerDoc
            // 
            labelCustomerDoc.AutoSize = true;
            labelCustomerDoc.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelCustomerDoc.Location = new Point(16, 68);
            labelCustomerDoc.Name = "labelCustomerDoc";
            labelCustomerDoc.Size = new Size(95, 21);
            labelCustomerDoc.TabIndex = 6;
            labelCustomerDoc.Text = "DNI / CUIT:";
            // 
            // textBoxCustomerDoc
            // 
            textBoxCustomerDoc.BorderStyle = BorderStyle.FixedSingle;
            textBoxCustomerDoc.Font = new Font("Segoe UI", 10F);
            textBoxCustomerDoc.Location = new Point(16, 90);
            textBoxCustomerDoc.Name = "textBoxCustomerDoc";
            textBoxCustomerDoc.ReadOnly = true;
            textBoxCustomerDoc.Size = new Size(140, 30);
            textBoxCustomerDoc.TabIndex = 7;
            // 
            // labelCustomerFirstName
            // 
            labelCustomerFirstName.AutoSize = true;
            labelCustomerFirstName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelCustomerFirstName.Location = new Point(170, 68);
            labelCustomerFirstName.Name = "labelCustomerFirstName";
            labelCustomerFirstName.Size = new Size(77, 21);
            labelCustomerFirstName.TabIndex = 8;
            labelCustomerFirstName.Text = "Nombre:";
            // 
            // textBoxCustomerFirstName
            // 
            textBoxCustomerFirstName.BorderStyle = BorderStyle.FixedSingle;
            textBoxCustomerFirstName.Font = new Font("Segoe UI", 10F);
            textBoxCustomerFirstName.Location = new Point(170, 90);
            textBoxCustomerFirstName.Name = "textBoxCustomerFirstName";
            textBoxCustomerFirstName.ReadOnly = true;
            textBoxCustomerFirstName.Size = new Size(160, 30);
            textBoxCustomerFirstName.TabIndex = 9;
            // 
            // labelCustomerLastName
            // 
            labelCustomerLastName.AutoSize = true;
            labelCustomerLastName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelCustomerLastName.Location = new Point(345, 68);
            labelCustomerLastName.Name = "labelCustomerLastName";
            labelCustomerLastName.Size = new Size(191, 21);
            labelCustomerLastName.TabIndex = 10;
            labelCustomerLastName.Text = "Apellido / Razón Social:";
            // 
            // textBoxCustomerLastName
            // 
            textBoxCustomerLastName.BorderStyle = BorderStyle.FixedSingle;
            textBoxCustomerLastName.Font = new Font("Segoe UI", 10F);
            textBoxCustomerLastName.Location = new Point(345, 90);
            textBoxCustomerLastName.Name = "textBoxCustomerLastName";
            textBoxCustomerLastName.ReadOnly = true;
            textBoxCustomerLastName.Size = new Size(200, 30);
            textBoxCustomerLastName.TabIndex = 11;
            // 
            // dataGridViewSaleItems
            // 
            dataGridViewSaleItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewSaleItems.BackgroundColor = Color.White;
            dataGridViewSaleItems.BorderStyle = BorderStyle.None;
            dataGridViewSaleItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSaleItems.Location = new Point(16, 329);
            dataGridViewSaleItems.Name = "dataGridViewSaleItems";
            dataGridViewSaleItems.RowHeadersWidth = 51;
            dataGridViewSaleItems.Size = new Size(1101, 299);
            dataGridViewSaleItems.TabIndex = 3;
            // 
            // panelTotalsCard
            // 
            panelTotalsCard.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelTotalsCard.BackColor = Color.White;
            panelTotalsCard.Controls.Add(labelTotalPrompt);
            panelTotalsCard.Controls.Add(textBoxTotalAmount);
            panelTotalsCard.Controls.Add(labelAmountPaidPrompt);
            panelTotalsCard.Controls.Add(textBoxAmountPaid);
            panelTotalsCard.Controls.Add(labelChangePrompt);
            panelTotalsCard.Controls.Add(textBoxChangeAmount);
            panelTotalsCard.Location = new Point(16, 638);
            panelTotalsCard.Name = "panelTotalsCard";
            panelTotalsCard.Size = new Size(1101, 60);
            panelTotalsCard.TabIndex = 4;
            // 
            // labelTotalPrompt
            // 
            labelTotalPrompt.AutoSize = true;
            labelTotalPrompt.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelTotalPrompt.Location = new Point(16, 18);
            labelTotalPrompt.Name = "labelTotalPrompt";
            labelTotalPrompt.Size = new Size(73, 25);
            labelTotalPrompt.TabIndex = 0;
            labelTotalPrompt.Text = "TOTAL:";
            // 
            // textBoxTotalAmount
            // 
            textBoxTotalAmount.BorderStyle = BorderStyle.FixedSingle;
            textBoxTotalAmount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            textBoxTotalAmount.ForeColor = Color.FromArgb(16, 185, 129);
            textBoxTotalAmount.Location = new Point(94, 16);
            textBoxTotalAmount.Name = "textBoxTotalAmount";
            textBoxTotalAmount.ReadOnly = true;
            textBoxTotalAmount.Size = new Size(180, 34);
            textBoxTotalAmount.TabIndex = 1;
            textBoxTotalAmount.Text = "$ 0,00";
            // 
            // labelAmountPaidPrompt
            // 
            labelAmountPaidPrompt.AutoSize = true;
            labelAmountPaidPrompt.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelAmountPaidPrompt.Location = new Point(285, 22);
            labelAmountPaidPrompt.Name = "labelAmountPaidPrompt";
            labelAmountPaidPrompt.Size = new Size(95, 21);
            labelAmountPaidPrompt.TabIndex = 2;
            labelAmountPaidPrompt.Text = "ABONADO:";
            // 
            // textBoxAmountPaid
            // 
            textBoxAmountPaid.BorderStyle = BorderStyle.FixedSingle;
            textBoxAmountPaid.Font = new Font("Segoe UI", 10F);
            textBoxAmountPaid.Location = new Point(386, 18);
            textBoxAmountPaid.Name = "textBoxAmountPaid";
            textBoxAmountPaid.ReadOnly = true;
            textBoxAmountPaid.Size = new Size(150, 30);
            textBoxAmountPaid.TabIndex = 3;
            textBoxAmountPaid.Text = "$ 0,00";
            // 
            // labelChangePrompt
            // 
            labelChangePrompt.AutoSize = true;
            labelChangePrompt.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelChangePrompt.Location = new Point(552, 24);
            labelChangePrompt.Name = "labelChangePrompt";
            labelChangePrompt.Size = new Size(73, 21);
            labelChangePrompt.TabIndex = 4;
            labelChangePrompt.Text = "VUELTO:";
            // 
            // textBoxChangeAmount
            // 
            textBoxChangeAmount.BorderStyle = BorderStyle.FixedSingle;
            textBoxChangeAmount.Font = new Font("Segoe UI", 10F);
            textBoxChangeAmount.Location = new Point(631, 20);
            textBoxChangeAmount.Name = "textBoxChangeAmount";
            textBoxChangeAmount.ReadOnly = true;
            textBoxChangeAmount.Size = new Size(150, 30);
            textBoxChangeAmount.TabIndex = 5;
            textBoxChangeAmount.Text = "$ 0,00";
            // 
            // FormSaleDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1137, 718);
            Controls.Add(panelTotalsCard);
            Controls.Add(dataGridViewSaleItems);
            Controls.Add(panelVoucherInfoCard);
            Controls.Add(panelSearchCard);
            Controls.Add(panelHeader);
            Name = "FormSaleDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detalle de Venta";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelSearchCard.ResumeLayout(false);
            panelSearchCard.PerformLayout();
            panelVoucherInfoCard.ResumeLayout(false);
            panelVoucherInfoCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSaleItems).EndInit();
            panelTotalsCard.ResumeLayout(false);
            panelTotalsCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonDownloadPdf;
        private System.Windows.Forms.Panel panelSearchCard;
        private System.Windows.Forms.Label labelDocumentNumberPrompt;
        private System.Windows.Forms.TextBox textBoxSearchDocumentNumber;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonClearSearch;
        private System.Windows.Forms.Panel panelVoucherInfoCard;
        private System.Windows.Forms.Label labelIssueDate;
        private System.Windows.Forms.TextBox textBoxIssueDate;
        private System.Windows.Forms.Label labelDocumentType;
        private System.Windows.Forms.TextBox textBoxDocumentType;
        private System.Windows.Forms.Label labelCashierName;
        private System.Windows.Forms.TextBox textBoxCashierName;
        private System.Windows.Forms.Label labelCustomerDoc;
        private System.Windows.Forms.TextBox textBoxCustomerDoc;
        private System.Windows.Forms.Label labelCustomerFirstName;
        private System.Windows.Forms.TextBox textBoxCustomerFirstName;
        private System.Windows.Forms.Label labelCustomerLastName;
        private System.Windows.Forms.TextBox textBoxCustomerLastName;
        private System.Windows.Forms.DataGridView dataGridViewSaleItems;
        private System.Windows.Forms.Panel panelTotalsCard;
        private System.Windows.Forms.Label labelTotalPrompt;
        private System.Windows.Forms.TextBox textBoxTotalAmount;
        private System.Windows.Forms.Label labelAmountPaidPrompt;
        private System.Windows.Forms.TextBox textBoxAmountPaid;
        private System.Windows.Forms.Label labelChangePrompt;
        private System.Windows.Forms.TextBox textBoxChangeAmount;
    }
}