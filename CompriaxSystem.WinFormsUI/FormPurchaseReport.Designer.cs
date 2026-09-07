namespace CompriaxSystem.WinFormsUI
{
    partial class FormPurchaseReport
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
            pnlFilters = new Panel();
            lblStart = new Label();
            dtpStart = new DateTimePicker();
            lblEnd = new Label();
            dtpEnd = new DateTimePicker();
            lblSupplier = new Label();
            cboSupplierFilter = new ComboBox();
            btnSearch = new Button();
            lblSearch = new Label();
            cboSearchBy = new ComboBox();
            txtSearchText = new TextBox();
            btnExport = new Button();
            dgvData = new DataGridView();
            pnlHeader.SuspendLayout();
            pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(15, 23, 42);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1275, 56);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(16, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(612, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "HISTORIAL Y REPORTE DE COMPRAS A PROVEEDORES";
            // 
            // pnlFilters
            // 
            pnlFilters.BackColor = Color.White;
            pnlFilters.Controls.Add(lblStart);
            pnlFilters.Controls.Add(dtpStart);
            pnlFilters.Controls.Add(lblEnd);
            pnlFilters.Controls.Add(dtpEnd);
            pnlFilters.Controls.Add(lblSupplier);
            pnlFilters.Controls.Add(cboSupplierFilter);
            pnlFilters.Controls.Add(btnSearch);
            pnlFilters.Controls.Add(lblSearch);
            pnlFilters.Controls.Add(cboSearchBy);
            pnlFilters.Controls.Add(txtSearchText);
            pnlFilters.Controls.Add(btnExport);
            pnlFilters.Location = new Point(16, 72);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(1233, 90);
            pnlFilters.TabIndex = 1;
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblStart.Location = new Point(16, 12);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(61, 21);
            lblStart.TabIndex = 0;
            lblStart.Text = "Desde:";
            // 
            // dtpStart
            // 
            dtpStart.Font = new Font("Segoe UI", 10F);
            dtpStart.Format = DateTimePickerFormat.Short;
            dtpStart.Location = new Point(16, 36);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(115, 30);
            dtpStart.TabIndex = 1;
            // 
            // lblEnd
            // 
            lblEnd.AutoSize = true;
            lblEnd.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEnd.Location = new Point(140, 12);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new Size(57, 21);
            lblEnd.TabIndex = 2;
            lblEnd.Text = "Hasta:";
            // 
            // dtpEnd
            // 
            dtpEnd.Font = new Font("Segoe UI", 10F);
            dtpEnd.Format = DateTimePickerFormat.Short;
            dtpEnd.Location = new Point(140, 36);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(115, 30);
            dtpEnd.TabIndex = 3;
            // 
            // lblSupplier
            // 
            lblSupplier.AutoSize = true;
            lblSupplier.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSupplier.Location = new Point(265, 12);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(94, 21);
            lblSupplier.TabIndex = 4;
            lblSupplier.Text = "Proveedor:";
            // 
            // cboSupplierFilter
            // 
            cboSupplierFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSupplierFilter.Font = new Font("Segoe UI", 10F);
            cboSupplierFilter.Location = new Point(265, 36);
            cboSupplierFilter.Name = "cboSupplierFilter";
            cboSupplierFilter.Size = new Size(180, 31);
            cboSupplierFilter.TabIndex = 5;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(2, 132, 199);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(460, 14);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(132, 54);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "🔍 FILTRAR";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSearch.Location = new Point(628, 12);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(95, 21);
            lblSearch.TabIndex = 7;
            lblSearch.Text = "Buscar por:";
            // 
            // cboSearchBy
            // 
            cboSearchBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSearchBy.Font = new Font("Segoe UI", 10F);
            cboSearchBy.Location = new Point(628, 34);
            cboSearchBy.Name = "cboSearchBy";
            cboSearchBy.Size = new Size(130, 31);
            cboSearchBy.TabIndex = 8;
            // 
            // txtSearchText
            // 
            txtSearchText.BorderStyle = BorderStyle.FixedSingle;
            txtSearchText.Font = new Font("Segoe UI", 10F);
            txtSearchText.Location = new Point(793, 35);
            txtSearchText.Name = "txtSearchText";
            txtSearchText.Size = new Size(210, 30);
            txtSearchText.TabIndex = 9;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(16, 185, 129);
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(1020, 12);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(201, 65);
            btnExport.TabIndex = 10;
            btnExport.Text = "EXPORTAR EXCEL";
            btnExport.UseVisualStyleBackColor = false;
            // 
            // dgvData
            // 
            dgvData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvData.BackgroundColor = Color.White;
            dgvData.BorderStyle = BorderStyle.None;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Location = new Point(16, 188);
            dgvData.Name = "dgvData";
            dgvData.RowHeadersWidth = 51;
            dgvData.Size = new Size(1242, 467);
            dgvData.TabIndex = 2;
            // 
            // FormPurchaseReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1275, 675);
            Controls.Add(dgvData);
            Controls.Add(pnlFilters);
            Controls.Add(pnlHeader);
            Name = "FormPurchaseReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reporte de Compras";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.ComboBox cboSupplierFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ComboBox cboSearchBy;
        private System.Windows.Forms.TextBox txtSearchText;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dgvData;
    }
}