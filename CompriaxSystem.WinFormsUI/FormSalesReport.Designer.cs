namespace CompriaxSystem.WinFormsUI
{
    partial class FormSalesReport
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
            btnSearchDates = new Button();
            lblSearch = new Label();
            cboSearchBy = new ComboBox();
            txtSearchValue = new TextBox();
            btnExportExcel = new Button();
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
            pnlHeader.Size = new Size(1130, 56);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(16, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(508, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📊 HISTORIAL GENERAL Y REPORTE DE VENTAS";
            // 
            // pnlFilters
            // 
            pnlFilters.BackColor = Color.White;
            pnlFilters.Controls.Add(lblStart);
            pnlFilters.Controls.Add(dtpStart);
            pnlFilters.Controls.Add(lblEnd);
            pnlFilters.Controls.Add(dtpEnd);
            pnlFilters.Controls.Add(btnSearchDates);
            pnlFilters.Controls.Add(lblSearch);
            pnlFilters.Controls.Add(cboSearchBy);
            pnlFilters.Controls.Add(txtSearchValue);
            pnlFilters.Controls.Add(btnExportExcel);
            pnlFilters.Location = new Point(16, 72);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(1100, 100);
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
            dtpStart.Size = new Size(120, 30);
            dtpStart.TabIndex = 1;
            // 
            // lblEnd
            // 
            lblEnd.AutoSize = true;
            lblEnd.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEnd.Location = new Point(145, 12);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new Size(57, 21);
            lblEnd.TabIndex = 2;
            lblEnd.Text = "Hasta:";
            // 
            // dtpEnd
            // 
            dtpEnd.Font = new Font("Segoe UI", 10F);
            dtpEnd.Format = DateTimePickerFormat.Short;
            dtpEnd.Location = new Point(145, 36);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(120, 30);
            dtpEnd.TabIndex = 3;
            // 
            // btnSearchDates
            // 
            btnSearchDates.BackColor = Color.FromArgb(2, 132, 199);
            btnSearchDates.FlatAppearance.BorderSize = 0;
            btnSearchDates.FlatStyle = FlatStyle.Flat;
            btnSearchDates.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearchDates.ForeColor = Color.White;
            btnSearchDates.Location = new Point(275, 32);
            btnSearchDates.Name = "btnSearchDates";
            btnSearchDates.Size = new Size(105, 34);
            btnSearchDates.TabIndex = 4;
            btnSearchDates.Text = "🔍 FILTRAR";
            btnSearchDates.UseVisualStyleBackColor = false;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSearch.Location = new Point(400, 12);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(95, 21);
            lblSearch.TabIndex = 5;
            lblSearch.Text = "Buscar por:";
            // 
            // cboSearchBy
            // 
            cboSearchBy.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSearchBy.Font = new Font("Segoe UI", 10F);
            cboSearchBy.Location = new Point(400, 36);
            cboSearchBy.Name = "cboSearchBy";
            cboSearchBy.Size = new Size(140, 31);
            cboSearchBy.TabIndex = 6;
            // 
            // txtSearchValue
            // 
            txtSearchValue.BorderStyle = BorderStyle.FixedSingle;
            txtSearchValue.Font = new Font("Segoe UI", 10F);
            txtSearchValue.Location = new Point(548, 36);
            txtSearchValue.Name = "txtSearchValue";
            txtSearchValue.Size = new Size(230, 30);
            txtSearchValue.TabIndex = 7;
            // 
            // btnExportExcel
            // 
            btnExportExcel.BackColor = Color.FromArgb(16, 185, 129);
            btnExportExcel.FlatAppearance.BorderSize = 0;
            btnExportExcel.FlatStyle = FlatStyle.Flat;
            btnExportExcel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExportExcel.ForeColor = Color.White;
            btnExportExcel.Location = new Point(807, 12);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(280, 78);
            btnExportExcel.TabIndex = 8;
            btnExportExcel.Text = "📗 EXPORTAR EXCEL";
            btnExportExcel.UseVisualStyleBackColor = false;
            // 
            // dgvData
            // 
            dgvData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvData.BackgroundColor = Color.White;
            dgvData.BorderStyle = BorderStyle.None;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Location = new Point(16, 194);
            dgvData.Name = "dgvData";
            dgvData.RowHeadersWidth = 51;
            dgvData.Size = new Size(1100, 468);
            dgvData.TabIndex = 2;
            // 
            // FormSalesReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1130, 677);
            Controls.Add(dgvData);
            Controls.Add(pnlFilters);
            Controls.Add(pnlHeader);
            Name = "FormSalesReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reporte de Ventas";
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
        private System.Windows.Forms.Button btnSearchDates;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ComboBox cboSearchBy;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.DataGridView dgvData;
    }
}