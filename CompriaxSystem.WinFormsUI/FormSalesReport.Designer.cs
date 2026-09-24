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
            picIconFilterDates = new PictureBox();
            picIconExportExcel = new PictureBox();
            panelHeader = new Panel();
            labelTitle = new Label();
            panelFiltersCard = new Panel();
            labelStartDate = new Label();
            dateTimePickerStartDate = new DateTimePicker();
            labelEndDate = new Label();
            dateTimePickerEndDate = new DateTimePicker();
            buttonFilterDates = new Button();
            labelSearchCriteriaPrompt = new Label();
            comboBoxSearchCriteria = new ComboBox();
            textBoxSearchValue = new TextBox();
            buttonExportExcel = new Button();
            dataGridViewSalesData = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)picIconFilterDates).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconExportExcel).BeginInit();
            panelHeader.SuspendLayout();
            panelFiltersCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSalesData).BeginInit();
            SuspendLayout();
            // 
            // picIconFilterDates
            // 
            picIconFilterDates.BackColor = Color.FromArgb(2, 132, 199);
            picIconFilterDates.Cursor = Cursors.Hand;
            picIconFilterDates.Image = Resources._080_buscar;
            picIconFilterDates.Location = new Point(275, 32);
            picIconFilterDates.Name = "picIconFilterDates";
            picIconFilterDates.Size = new Size(25, 34);
            picIconFilterDates.SizeMode = PictureBoxSizeMode.Zoom;
            picIconFilterDates.TabIndex = 99;
            picIconFilterDates.TabStop = false;
            // 
            // picIconExportExcel
            // 
            picIconExportExcel.BackColor = Color.FromArgb(16, 185, 129);
            picIconExportExcel.Cursor = Cursors.Hand;
            picIconExportExcel.Image = Resources._084_exportar_excel;
            picIconExportExcel.Location = new Point(831, 23);
            picIconExportExcel.Name = "picIconExportExcel";
            picIconExportExcel.Size = new Size(45, 59);
            picIconExportExcel.SizeMode = PictureBoxSizeMode.Zoom;
            picIconExportExcel.TabIndex = 99;
            picIconExportExcel.TabStop = false;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1130, 56);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 16);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(471, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "HISTORIAL GENERAL Y REPORTE DE VENTAS";
            // 
            // panelFiltersCard
            // 
            panelFiltersCard.BackColor = Color.White;
            panelFiltersCard.Controls.Add(labelStartDate);
            panelFiltersCard.Controls.Add(dateTimePickerStartDate);
            panelFiltersCard.Controls.Add(labelEndDate);
            panelFiltersCard.Controls.Add(dateTimePickerEndDate);
            panelFiltersCard.Controls.Add(picIconFilterDates);
            panelFiltersCard.Controls.Add(buttonFilterDates);
            panelFiltersCard.Controls.Add(labelSearchCriteriaPrompt);
            panelFiltersCard.Controls.Add(comboBoxSearchCriteria);
            panelFiltersCard.Controls.Add(textBoxSearchValue);
            panelFiltersCard.Controls.Add(picIconExportExcel);
            panelFiltersCard.Controls.Add(buttonExportExcel);
            panelFiltersCard.Location = new Point(16, 72);
            panelFiltersCard.Name = "panelFiltersCard";
            panelFiltersCard.Size = new Size(1100, 100);
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
            dateTimePickerStartDate.Size = new Size(120, 30);
            dateTimePickerStartDate.TabIndex = 1;
            // 
            // labelEndDate
            // 
            labelEndDate.AutoSize = true;
            labelEndDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelEndDate.Location = new Point(145, 12);
            labelEndDate.Name = "labelEndDate";
            labelEndDate.Size = new Size(57, 21);
            labelEndDate.TabIndex = 2;
            labelEndDate.Text = "Hasta:";
            // 
            // dateTimePickerEndDate
            // 
            dateTimePickerEndDate.Font = new Font("Segoe UI", 10F);
            dateTimePickerEndDate.Format = DateTimePickerFormat.Short;
            dateTimePickerEndDate.Location = new Point(145, 36);
            dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            dateTimePickerEndDate.Size = new Size(120, 30);
            dateTimePickerEndDate.TabIndex = 3;
            // 
            // buttonFilterDates
            // 
            buttonFilterDates.BackColor = Color.FromArgb(2, 132, 199);
            buttonFilterDates.FlatAppearance.BorderSize = 0;
            buttonFilterDates.FlatStyle = FlatStyle.Flat;
            buttonFilterDates.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonFilterDates.ForeColor = Color.White;
            buttonFilterDates.Location = new Point(275, 32);
            buttonFilterDates.Name = "buttonFilterDates";
            buttonFilterDates.Size = new Size(119, 34);
            buttonFilterDates.TabIndex = 4;
            buttonFilterDates.Text = "FILTRAR";
            buttonFilterDates.UseVisualStyleBackColor = false;
            // 
            // labelSearchCriteriaPrompt
            // 
            labelSearchCriteriaPrompt.AutoSize = true;
            labelSearchCriteriaPrompt.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelSearchCriteriaPrompt.Location = new Point(400, 12);
            labelSearchCriteriaPrompt.Name = "labelSearchCriteriaPrompt";
            labelSearchCriteriaPrompt.Size = new Size(95, 21);
            labelSearchCriteriaPrompt.TabIndex = 5;
            labelSearchCriteriaPrompt.Text = "Buscar por:";
            // 
            // comboBoxSearchCriteria
            // 
            comboBoxSearchCriteria.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSearchCriteria.Font = new Font("Segoe UI", 10F);
            comboBoxSearchCriteria.Location = new Point(400, 36);
            comboBoxSearchCriteria.Name = "comboBoxSearchCriteria";
            comboBoxSearchCriteria.Size = new Size(140, 31);
            comboBoxSearchCriteria.TabIndex = 6;
            // 
            // textBoxSearchValue
            // 
            textBoxSearchValue.BorderStyle = BorderStyle.FixedSingle;
            textBoxSearchValue.Font = new Font("Segoe UI", 10F);
            textBoxSearchValue.Location = new Point(548, 36);
            textBoxSearchValue.Name = "textBoxSearchValue";
            textBoxSearchValue.Size = new Size(230, 30);
            textBoxSearchValue.TabIndex = 7;
            // 
            // buttonExportExcel
            // 
            buttonExportExcel.BackColor = Color.FromArgb(16, 185, 129);
            buttonExportExcel.FlatAppearance.BorderSize = 0;
            buttonExportExcel.FlatStyle = FlatStyle.Flat;
            buttonExportExcel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonExportExcel.ForeColor = Color.White;
            buttonExportExcel.Location = new Point(807, 12);
            buttonExportExcel.Name = "buttonExportExcel";
            buttonExportExcel.Size = new Size(280, 78);
            buttonExportExcel.TabIndex = 8;
            buttonExportExcel.Text = "EXPORTAR EXCEL";
            buttonExportExcel.UseVisualStyleBackColor = false;
            // 
            // dataGridViewSalesData
            // 
            dataGridViewSalesData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewSalesData.BackgroundColor = Color.White;
            dataGridViewSalesData.BorderStyle = BorderStyle.None;
            dataGridViewSalesData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSalesData.Location = new Point(16, 194);
            dataGridViewSalesData.Name = "dataGridViewSalesData";
            dataGridViewSalesData.RowHeadersWidth = 51;
            dataGridViewSalesData.Size = new Size(1100, 468);
            dataGridViewSalesData.TabIndex = 2;
            // 
            // FormSalesReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1130, 677);
            Controls.Add(dataGridViewSalesData);
            Controls.Add(panelFiltersCard);
            Controls.Add(panelHeader);
            Name = "FormSalesReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reporte de Ventas";
            ((System.ComponentModel.ISupportInitialize)picIconFilterDates).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconExportExcel).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFiltersCard.ResumeLayout(false);
            panelFiltersCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSalesData).EndInit();
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
        private System.Windows.Forms.Button buttonFilterDates;
        private System.Windows.Forms.Label labelSearchCriteriaPrompt;
        private System.Windows.Forms.ComboBox comboBoxSearchCriteria;
        private System.Windows.Forms.TextBox textBoxSearchValue;
        private System.Windows.Forms.Button buttonExportExcel;
        private System.Windows.Forms.DataGridView dataGridViewSalesData;
        private System.Windows.Forms.PictureBox picIconFilterDates;
        private System.Windows.Forms.PictureBox picIconExportExcel;
    }
}
