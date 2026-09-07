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
            pnlHeader = new Panel();
            lblTitle = new Label();
            btnDownloadPdf = new Button();
            pnlSearch = new Panel();
            lblNumDoc = new Label();
            txtSearchNumber = new TextBox();
            btnSearch = new Button();
            btnClear = new Button();
            pnlInfo = new Panel();
            lblFecha = new Label();
            txtDate = new TextBox();
            lblDocType = new Label();
            txtDocType = new TextBox();
            lblUser = new Label();
            txtUser = new TextBox();
            lblDniCli = new Label();
            txtClientDoc = new TextBox();
            lblNomCli = new Label();
            txtClientName = new TextBox();
            lblApeCli = new Label();
            txtClientLastName = new TextBox();
            dgvItems = new DataGridView();
            pnlTotals = new Panel();
            lblTotal = new Label();
            txtTotal = new TextBox();
            lblPago = new Label();
            txtPaid = new TextBox();
            lblCambio = new Label();
            txtChange = new TextBox();
            pnlHeader.SuspendLayout();
            pnlSearch.SuspendLayout();
            pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            pnlTotals.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(15, 23, 42);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnDownloadPdf);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1137, 87);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(16, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(514, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "AUDITORÍA Y CONSULTA DE COMPROBANTE";
            // 
            // btnDownloadPdf
            // 
            btnDownloadPdf.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDownloadPdf.BackColor = Color.FromArgb(2, 132, 199);
            btnDownloadPdf.FlatAppearance.BorderSize = 0;
            btnDownloadPdf.FlatStyle = FlatStyle.Flat;
            btnDownloadPdf.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDownloadPdf.ForeColor = Color.White;
            btnDownloadPdf.Location = new Point(911, 12);
            btnDownloadPdf.Name = "btnDownloadPdf";
            btnDownloadPdf.Size = new Size(184, 60);
            btnDownloadPdf.TabIndex = 1;
            btnDownloadPdf.Text = "REIMPRIMIR PDF";
            btnDownloadPdf.UseVisualStyleBackColor = false;
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = Color.White;
            pnlSearch.Controls.Add(lblNumDoc);
            pnlSearch.Controls.Add(txtSearchNumber);
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(btnClear);
            pnlSearch.Location = new Point(16, 93);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(1068, 51);
            pnlSearch.TabIndex = 1;
            // 
            // lblNumDoc
            // 
            lblNumDoc.AutoSize = true;
            lblNumDoc.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNumDoc.Location = new Point(16, 15);
            lblNumDoc.Name = "lblNumDoc";
            lblNumDoc.Size = new Size(209, 21);
            lblNumDoc.TabIndex = 0;
            lblNumDoc.Text = "Número de Comprobante:";
            // 
            // txtSearchNumber
            // 
            txtSearchNumber.BorderStyle = BorderStyle.FixedSingle;
            txtSearchNumber.Font = new Font("Segoe UI", 10F);
            txtSearchNumber.Location = new Point(231, 12);
            txtSearchNumber.Name = "txtSearchNumber";
            txtSearchNumber.Size = new Size(280, 30);
            txtSearchNumber.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(2, 132, 199);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(534, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(130, 41);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "BUSCAR";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClear.Location = new Point(670, 3);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(111, 41);
            btnClear.TabIndex = 3;
            btnClear.Text = "LIMPIAR";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // pnlInfo
            // 
            pnlInfo.BackColor = Color.White;
            pnlInfo.Controls.Add(lblFecha);
            pnlInfo.Controls.Add(txtDate);
            pnlInfo.Controls.Add(lblDocType);
            pnlInfo.Controls.Add(txtDocType);
            pnlInfo.Controls.Add(lblUser);
            pnlInfo.Controls.Add(txtUser);
            pnlInfo.Controls.Add(lblDniCli);
            pnlInfo.Controls.Add(txtClientDoc);
            pnlInfo.Controls.Add(lblNomCli);
            pnlInfo.Controls.Add(txtClientName);
            pnlInfo.Controls.Add(lblApeCli);
            pnlInfo.Controls.Add(txtClientLastName);
            pnlInfo.Location = new Point(16, 150);
            pnlInfo.Name = "pnlInfo";
            pnlInfo.Size = new Size(1068, 173);
            pnlInfo.TabIndex = 2;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblFecha.Location = new Point(16, 12);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(123, 21);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "Fecha Emisión:";
            // 
            // txtDate
            // 
            txtDate.BorderStyle = BorderStyle.FixedSingle;
            txtDate.Font = new Font("Segoe UI", 10F);
            txtDate.Location = new Point(16, 34);
            txtDate.Name = "txtDate";
            txtDate.ReadOnly = true;
            txtDate.Size = new Size(140, 30);
            txtDate.TabIndex = 1;
            // 
            // lblDocType
            // 
            lblDocType.AutoSize = true;
            lblDocType.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDocType.Location = new Point(170, 12);
            lblDocType.Name = "lblDocType";
            lblDocType.Size = new Size(157, 21);
            lblDocType.TabIndex = 2;
            lblDocType.Text = "Tipo Comprobante:";
            // 
            // txtDocType
            // 
            txtDocType.BorderStyle = BorderStyle.FixedSingle;
            txtDocType.Font = new Font("Segoe UI", 10F);
            txtDocType.Location = new Point(170, 34);
            txtDocType.Name = "txtDocType";
            txtDocType.ReadOnly = true;
            txtDocType.Size = new Size(160, 30);
            txtDocType.TabIndex = 3;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUser.Location = new Point(345, 12);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(151, 21);
            lblUser.TabIndex = 4;
            lblUser.Text = "Cajero / Operador:";
            // 
            // txtUser
            // 
            txtUser.BorderStyle = BorderStyle.FixedSingle;
            txtUser.Font = new Font("Segoe UI", 10F);
            txtUser.Location = new Point(345, 34);
            txtUser.Name = "txtUser";
            txtUser.ReadOnly = true;
            txtUser.Size = new Size(200, 30);
            txtUser.TabIndex = 5;
            // 
            // lblDniCli
            // 
            lblDniCli.AutoSize = true;
            lblDniCli.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDniCli.Location = new Point(16, 68);
            lblDniCli.Name = "lblDniCli";
            lblDniCli.Size = new Size(95, 21);
            lblDniCli.TabIndex = 6;
            lblDniCli.Text = "DNI / CUIT:";
            // 
            // txtClientDoc
            // 
            txtClientDoc.BorderStyle = BorderStyle.FixedSingle;
            txtClientDoc.Font = new Font("Segoe UI", 10F);
            txtClientDoc.Location = new Point(16, 90);
            txtClientDoc.Name = "txtClientDoc";
            txtClientDoc.ReadOnly = true;
            txtClientDoc.Size = new Size(140, 30);
            txtClientDoc.TabIndex = 7;
            // 
            // lblNomCli
            // 
            lblNomCli.AutoSize = true;
            lblNomCli.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNomCli.Location = new Point(170, 68);
            lblNomCli.Name = "lblNomCli";
            lblNomCli.Size = new Size(77, 21);
            lblNomCli.TabIndex = 8;
            lblNomCli.Text = "Nombre:";
            // 
            // txtClientName
            // 
            txtClientName.BorderStyle = BorderStyle.FixedSingle;
            txtClientName.Font = new Font("Segoe UI", 10F);
            txtClientName.Location = new Point(170, 90);
            txtClientName.Name = "txtClientName";
            txtClientName.ReadOnly = true;
            txtClientName.Size = new Size(160, 30);
            txtClientName.TabIndex = 9;
            // 
            // lblApeCli
            // 
            lblApeCli.AutoSize = true;
            lblApeCli.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblApeCli.Location = new Point(345, 68);
            lblApeCli.Name = "lblApeCli";
            lblApeCli.Size = new Size(191, 21);
            lblApeCli.TabIndex = 10;
            lblApeCli.Text = "Apellido / Razón Social:";
            // 
            // txtClientLastName
            // 
            txtClientLastName.BorderStyle = BorderStyle.FixedSingle;
            txtClientLastName.Font = new Font("Segoe UI", 10F);
            txtClientLastName.Location = new Point(345, 90);
            txtClientLastName.Name = "txtClientLastName";
            txtClientLastName.ReadOnly = true;
            txtClientLastName.Size = new Size(200, 30);
            txtClientLastName.TabIndex = 11;
            // 
            // dgvItems
            // 
            dgvItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvItems.BackgroundColor = Color.White;
            dgvItems.BorderStyle = BorderStyle.None;
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Location = new Point(16, 329);
            dgvItems.Name = "dgvItems";
            dgvItems.RowHeadersWidth = 51;
            dgvItems.Size = new Size(1101, 299);
            dgvItems.TabIndex = 3;
            // 
            // pnlTotals
            // 
            pnlTotals.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlTotals.BackColor = Color.White;
            pnlTotals.Controls.Add(lblTotal);
            pnlTotals.Controls.Add(txtTotal);
            pnlTotals.Controls.Add(lblPago);
            pnlTotals.Controls.Add(txtPaid);
            pnlTotals.Controls.Add(lblCambio);
            pnlTotals.Controls.Add(txtChange);
            pnlTotals.Location = new Point(16, 638);
            pnlTotals.Name = "pnlTotals";
            pnlTotals.Size = new Size(1101, 60);
            pnlTotals.TabIndex = 4;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotal.Location = new Point(16, 18);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(73, 25);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "TOTAL:";
            // 
            // txtTotal
            // 
            txtTotal.BorderStyle = BorderStyle.FixedSingle;
            txtTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtTotal.ForeColor = Color.FromArgb(16, 185, 129);
            txtTotal.Location = new Point(94, 16);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(180, 34);
            txtTotal.TabIndex = 1;
            txtTotal.Text = "$ 0,00";
            // 
            // lblPago
            // 
            lblPago.AutoSize = true;
            lblPago.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPago.Location = new Point(285, 22);
            lblPago.Name = "lblPago";
            lblPago.Size = new Size(95, 21);
            lblPago.TabIndex = 2;
            lblPago.Text = "ABONADO:";
            // 
            // txtPaid
            // 
            txtPaid.BorderStyle = BorderStyle.FixedSingle;
            txtPaid.Font = new Font("Segoe UI", 10F);
            txtPaid.Location = new Point(386, 18);
            txtPaid.Name = "txtPaid";
            txtPaid.ReadOnly = true;
            txtPaid.Size = new Size(150, 30);
            txtPaid.TabIndex = 3;
            txtPaid.Text = "$ 0,00";
            // 
            // lblCambio
            // 
            lblCambio.AutoSize = true;
            lblCambio.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCambio.Location = new Point(552, 24);
            lblCambio.Name = "lblCambio";
            lblCambio.Size = new Size(73, 21);
            lblCambio.TabIndex = 4;
            lblCambio.Text = "VUELTO:";
            // 
            // txtChange
            // 
            txtChange.BorderStyle = BorderStyle.FixedSingle;
            txtChange.Font = new Font("Segoe UI", 10F);
            txtChange.Location = new Point(631, 20);
            txtChange.Name = "txtChange";
            txtChange.ReadOnly = true;
            txtChange.Size = new Size(150, 30);
            txtChange.TabIndex = 5;
            txtChange.Text = "$ 0,00";
            // 
            // FormSaleDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1137, 718);
            Controls.Add(pnlTotals);
            Controls.Add(dgvItems);
            Controls.Add(pnlInfo);
            Controls.Add(pnlSearch);
            Controls.Add(pnlHeader);
            Name = "FormSaleDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detalle de Venta";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlInfo.ResumeLayout(false);
            pnlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            pnlTotals.ResumeLayout(false);
            pnlTotals.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnDownloadPdf;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblNumDoc;
        private System.Windows.Forms.TextBox txtSearchNumber;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label lblDocType;
        private System.Windows.Forms.TextBox txtDocType;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblDniCli;
        private System.Windows.Forms.TextBox txtClientDoc;
        private System.Windows.Forms.Label lblNomCli;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label lblApeCli;
        private System.Windows.Forms.TextBox txtClientLastName;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Panel pnlTotals;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblPago;
        private System.Windows.Forms.TextBox txtPaid;
        private System.Windows.Forms.Label lblCambio;
        private System.Windows.Forms.TextBox txtChange;
    }
}