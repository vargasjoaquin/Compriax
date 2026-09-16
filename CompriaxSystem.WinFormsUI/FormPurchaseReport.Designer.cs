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
            panelHeader = new Panel();
            labelTitle = new Label();
            panelFiltersCard = new Panel();
            labelStartDate = new Label();
            dateTimePickerStartDate = new DateTimePicker();
            labelEndDate = new Label();
            dateTimePickerEndDate = new DateTimePicker();
            labelSupplierFilter = new Label();
            comboBoxSupplierFilter = new ComboBox();
            buttonSearch = new Button();
            labelSearchCriteriaPrompt = new Label();
            comboBoxSearchCriteria = new ComboBox();
            textBoxSearchValue = new TextBox();
            buttonExportExcel = new Button();
            dataGridViewPurchaseData = new DataGridView();
            panelHeader.SuspendLayout();
            panelFiltersCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPurchaseData).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1275, 56);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 16);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(612, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "HISTORIAL Y REPORTE DE COMPRAS A PROVEEDORES";
            // 
            // panelFiltersCard
            // 
            panelFiltersCard.BackColor = Color.White;
            panelFiltersCard.Controls.Add(labelStartDate);
            panelFiltersCard.Controls.Add(dateTimePickerStartDate);
            panelFiltersCard.Controls.Add(labelEndDate);
            panelFiltersCard.Controls.Add(dateTimePickerEndDate);
            panelFiltersCard.Controls.Add(labelSupplierFilter);
            panelFiltersCard.Controls.Add(comboBoxSupplierFilter);
            panelFiltersCard.Controls.Add(buttonSearch);
            panelFiltersCard.Controls.Add(labelSearchCriteriaPrompt);
            panelFiltersCard.Controls.Add(comboBoxSearchCriteria);
            panelFiltersCard.Controls.Add(textBoxSearchValue);
            panelFiltersCard.Controls.Add(buttonExportExcel);
            panelFiltersCard.Location = new Point(16, 72);
            panelFiltersCard.Name = "panelFiltersCard";
            panelFiltersCard.Size = new Size(1233, 90);
            panelFiltersCard.TabIndex = 1;
            // 
            // labelStartDate
            // 
            labelStartDate.AutoSize = true;
            labelStartDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelStartDate.Location = new Point(16, 12);
            labelStartDate.Name = "labelStartDate";
            labelStartDate.Size = new Size(61, 21);
            labelStartDate.TabIndex = 0;
            labelStartDate.Text = "Desde:";
            // 
            // dateTimePickerStartDate
            // 
            dateTimePickerStartDate.Font = new Font("Segoe UI", 10F);
            dateTimePickerStartDate.Format = DateTimePickerFormat.Short;
            dateTimePickerStartDate.Location = new Point(16, 36);
            dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            dateTimePickerStartDate.Size = new Size(115, 30);
            dateTimePickerStartDate.TabIndex = 1;
            // 
            // labelEndDate
            // 
            labelEndDate.AutoSize = true;
            labelEndDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelEndDate.Location = new Point(140, 12);
            labelEndDate.Name = "labelEndDate";
            labelEndDate.Size = new Size(57, 21);
            labelEndDate.TabIndex = 2;
            labelEndDate.Text = "Hasta:";
            // 
            // dateTimePickerEndDate
            // 
            dateTimePickerEndDate.Font = new Font("Segoe UI", 10F);
            dateTimePickerEndDate.Format = DateTimePickerFormat.Short;
            dateTimePickerEndDate.Location = new Point(140, 36);
            dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            dateTimePickerEndDate.Size = new Size(115, 30);
            dateTimePickerEndDate.TabIndex = 3;
            // 
            // labelSupplierFilter
            // 
            labelSupplierFilter.AutoSize = true;
            labelSupplierFilter.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelSupplierFilter.Location = new Point(265, 12);
            labelSupplierFilter.Name = "labelSupplierFilter";
            labelSupplierFilter.Size = new Size(94, 21);
            labelSupplierFilter.TabIndex = 4;
            labelSupplierFilter.Text = "Proveedor:";
            // 
            // comboBoxSupplierFilter
            // 
            comboBoxSupplierFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSupplierFilter.Font = new Font("Segoe UI", 10F);
            comboBoxSupplierFilter.Location = new Point(265, 36);
            comboBoxSupplierFilter.Name = "comboBoxSupplierFilter";
            comboBoxSupplierFilter.Size = new Size(180, 31);
            comboBoxSupplierFilter.TabIndex = 5;
            // 
            // buttonSearch
            // 
            buttonSearch.BackColor = Color.FromArgb(2, 132, 199);
            buttonSearch.FlatAppearance.BorderSize = 0;
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonSearch.ForeColor = Color.White;
            buttonSearch.Location = new Point(460, 14);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(132, 54);
            buttonSearch.TabIndex = 6;
            buttonSearch.Text = "🔍 FILTRAR";
            buttonSearch.UseVisualStyleBackColor = false;
            // 
            // labelSearchCriteriaPrompt
            // 
            labelSearchCriteriaPrompt.AutoSize = true;
            labelSearchCriteriaPrompt.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelSearchCriteriaPrompt.Location = new Point(628, 12);
            labelSearchCriteriaPrompt.Name = "labelSearchCriteriaPrompt";
            labelSearchCriteriaPrompt.Size = new Size(95, 21);
            labelSearchCriteriaPrompt.TabIndex = 7;
            labelSearchCriteriaPrompt.Text = "Buscar por:";
            // 
            // comboBoxSearchCriteria
            // 
            comboBoxSearchCriteria.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSearchCriteria.Font = new Font("Segoe UI", 10F);
            comboBoxSearchCriteria.Location = new Point(628, 34);
            comboBoxSearchCriteria.Name = "comboBoxSearchCriteria";
            comboBoxSearchCriteria.Size = new Size(130, 31);
            comboBoxSearchCriteria.TabIndex = 8;
            // 
            // textBoxSearchValue
            // 
            textBoxSearchValue.BorderStyle = BorderStyle.FixedSingle;
            textBoxSearchValue.Font = new Font("Segoe UI", 10F);
            textBoxSearchValue.Location = new Point(793, 35);
            textBoxSearchValue.Name = "textBoxSearchValue";
            textBoxSearchValue.Size = new Size(210, 30);
            textBoxSearchValue.TabIndex = 9;
            // 
            // buttonExportExcel
            // 
            buttonExportExcel.BackColor = Color.FromArgb(16, 185, 129);
            buttonExportExcel.FlatAppearance.BorderSize = 0;
            buttonExportExcel.FlatStyle = FlatStyle.Flat;
            buttonExportExcel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonExportExcel.ForeColor = Color.White;
            buttonExportExcel.Location = new Point(1020, 12);
            buttonExportExcel.Name = "buttonExportExcel";
            buttonExportExcel.Size = new Size(201, 65);
            buttonExportExcel.TabIndex = 10;
            buttonExportExcel.Text = "EXPORTAR EXCEL";
            buttonExportExcel.UseVisualStyleBackColor = false;
            // 
            // dataGridViewPurchaseData
            // 
            dataGridViewPurchaseData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewPurchaseData.BackgroundColor = Color.White;
            dataGridViewPurchaseData.BorderStyle = BorderStyle.None;
            dataGridViewPurchaseData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPurchaseData.Location = new Point(16, 188);
            dataGridViewPurchaseData.Name = "dataGridViewPurchaseData";
            dataGridViewPurchaseData.RowHeadersWidth = 51;
            dataGridViewPurchaseData.Size = new Size(1242, 467);
            dataGridViewPurchaseData.TabIndex = 2;
            // 
            // FormPurchaseReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1275, 675);
            Controls.Add(dataGridViewPurchaseData);
            Controls.Add(panelFiltersCard);
            Controls.Add(panelHeader);
            Name = "FormPurchaseReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reporte de Compras";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFiltersCard.ResumeLayout(false);
            panelFiltersCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPurchaseData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelFiltersCard;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Label labelSupplierFilter;
        private System.Windows.Forms.ComboBox comboBoxSupplierFilter;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label labelSearchCriteriaPrompt;
        private System.Windows.Forms.ComboBox comboBoxSearchCriteria;
        private System.Windows.Forms.TextBox textBoxSearchValue;
        private System.Windows.Forms.Button buttonExportExcel;
        private System.Windows.Forms.DataGridView dataGridViewPurchaseData;
    }
}