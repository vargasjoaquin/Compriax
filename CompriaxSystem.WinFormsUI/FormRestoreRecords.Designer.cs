namespace CompriaxSystem.WinFormsUI
{
    partial class FormRestoreRecords
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
            panelControlsCard = new Panel();
            labelEntityTypePrompt = new Label();
            comboBoxEntityType = new ComboBox();
            labelSearchPrompt = new Label();
            textBoxSearch = new TextBox();
            labelSelectedItemInfo = new Label();
            buttonRestoreRecord = new Button();
            labelRecordCount = new Label();
            dataGridViewDeletedRecords = new DataGridView();
            panelHeader.SuspendLayout();
            panelControlsCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDeletedRecords).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1135, 56);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 16);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(504, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "PAPELERA Y RECUPERACIÓN DE REGISTROS";
            // 
            // panelControlsCard
            // 
            panelControlsCard.BackColor = Color.White;
            panelControlsCard.Controls.Add(labelEntityTypePrompt);
            panelControlsCard.Controls.Add(comboBoxEntityType);
            panelControlsCard.Controls.Add(labelSearchPrompt);
            panelControlsCard.Controls.Add(textBoxSearch);
            panelControlsCard.Controls.Add(labelSelectedItemInfo);
            panelControlsCard.Controls.Add(buttonRestoreRecord);
            panelControlsCard.Location = new Point(16, 72);
            panelControlsCard.Name = "panelControlsCard";
            panelControlsCard.Size = new Size(1100, 110);
            panelControlsCard.TabIndex = 1;
            // 
            // labelEntityTypePrompt
            // 
            labelEntityTypePrompt.AutoSize = true;
            labelEntityTypePrompt.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelEntityTypePrompt.Location = new Point(16, 14);
            labelEntityTypePrompt.Name = "labelEntityTypePrompt";
            labelEntityTypePrompt.Size = new Size(148, 21);
            labelEntityTypePrompt.TabIndex = 0;
            labelEntityTypePrompt.Text = "Módulo / Entidad:";
            // 
            // comboBoxEntityType
            // 
            comboBoxEntityType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEntityType.Font = new Font("Segoe UI", 10F);
            comboBoxEntityType.Location = new Point(16, 36);
            comboBoxEntityType.Name = "comboBoxEntityType";
            comboBoxEntityType.Size = new Size(220, 31);
            comboBoxEntityType.TabIndex = 1;
            // 
            // labelSearchPrompt
            // 
            labelSearchPrompt.AutoSize = true;
            labelSearchPrompt.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelSearchPrompt.Location = new Point(260, 14);
            labelSearchPrompt.Name = "labelSearchPrompt";
            labelSearchPrompt.Size = new Size(209, 21);
            labelSearchPrompt.TabIndex = 2;
            labelSearchPrompt.Text = "Buscar registro eliminado:";
            // 
            // textBoxSearch
            // 
            textBoxSearch.BorderStyle = BorderStyle.FixedSingle;
            textBoxSearch.Font = new Font("Segoe UI", 10F);
            textBoxSearch.Location = new Point(260, 36);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(420, 30);
            textBoxSearch.TabIndex = 3;
            // 
            // labelSelectedItemInfo
            // 
            labelSelectedItemInfo.AutoSize = true;
            labelSelectedItemInfo.Font = new Font("Segoe UI", 9.5F);
            labelSelectedItemInfo.ForeColor = Color.FromArgb(2, 132, 199);
            labelSelectedItemInfo.Location = new Point(16, 78);
            labelSelectedItemInfo.Name = "labelSelectedItemInfo";
            labelSelectedItemInfo.Size = new Size(213, 21);
            labelSelectedItemInfo.TabIndex = 4;
            labelSelectedItemInfo.Text = "Ningún registro seleccionado";
            // 
            // buttonRestoreRecord
            // 
            buttonRestoreRecord.BackColor = Color.FromArgb(16, 185, 129);
            buttonRestoreRecord.Enabled = false;
            buttonRestoreRecord.FlatAppearance.BorderSize = 0;
            buttonRestoreRecord.FlatStyle = FlatStyle.Flat;
            buttonRestoreRecord.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            buttonRestoreRecord.ForeColor = Color.White;
            buttonRestoreRecord.Location = new Point(732, 14);
            buttonRestoreRecord.Name = "buttonRestoreRecord";
            buttonRestoreRecord.Size = new Size(348, 85);
            buttonRestoreRecord.TabIndex = 5;
            buttonRestoreRecord.Text = "RESTAURAR SELECCIÓN";
            buttonRestoreRecord.UseVisualStyleBackColor = false;
            // 
            // labelRecordCount
            // 
            labelRecordCount.AutoSize = true;
            labelRecordCount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelRecordCount.ForeColor = Color.FromArgb(100, 116, 139);
            labelRecordCount.Location = new Point(16, 192);
            labelRecordCount.Name = "labelRecordCount";
            labelRecordCount.Size = new Size(186, 21);
            labelRecordCount.TabIndex = 2;
            labelRecordCount.Text = "Registros eliminados: 0";
            // 
            // dataGridViewDeletedRecords
            // 
            dataGridViewDeletedRecords.BackgroundColor = Color.White;
            dataGridViewDeletedRecords.BorderStyle = BorderStyle.None;
            dataGridViewDeletedRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDeletedRecords.Location = new Point(16, 218);
            dataGridViewDeletedRecords.Name = "dataGridViewDeletedRecords";
            dataGridViewDeletedRecords.RowHeadersWidth = 51;
            dataGridViewDeletedRecords.Size = new Size(1100, 440);
            dataGridViewDeletedRecords.TabIndex = 3;
            // 
            // FormRestoreRecords
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1135, 680);
            Controls.Add(dataGridViewDeletedRecords);
            Controls.Add(labelRecordCount);
            Controls.Add(panelControlsCard);
            Controls.Add(panelHeader);
            Name = "FormRestoreRecords";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Papelera y Restauración";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelControlsCard.ResumeLayout(false);
            panelControlsCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDeletedRecords).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelControlsCard;
        private System.Windows.Forms.Label labelEntityTypePrompt;
        private System.Windows.Forms.ComboBox comboBoxEntityType;
        private System.Windows.Forms.Label labelSearchPrompt;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label labelSelectedItemInfo;
        private System.Windows.Forms.Button buttonRestoreRecord;
        private System.Windows.Forms.Label labelRecordCount;
        private System.Windows.Forms.DataGridView dataGridViewDeletedRecords;
    }
}