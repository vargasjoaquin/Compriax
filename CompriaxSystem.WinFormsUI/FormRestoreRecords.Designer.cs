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
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlControls = new Panel();
            lblEntity = new Label();
            cboEntityType = new ComboBox();
            lblSearch = new Label();
            txtSearch = new TextBox();
            lblSelectedItem = new Label();
            btnRestore = new Button();
            lblCount = new Label();
            dgvDeletedRecords = new DataGridView();
            pnlHeader.SuspendLayout();
            pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDeletedRecords).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(15, 23, 42);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1135, 56);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(16, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(504, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "♻️ PAPELERA Y RECUPERACIÓN DE REGISTROS";
            // 
            // pnlControls
            // 
            pnlControls.BackColor = Color.White;
            pnlControls.Controls.Add(lblEntity);
            pnlControls.Controls.Add(cboEntityType);
            pnlControls.Controls.Add(lblSearch);
            pnlControls.Controls.Add(txtSearch);
            pnlControls.Controls.Add(lblSelectedItem);
            pnlControls.Controls.Add(btnRestore);
            pnlControls.Location = new Point(16, 72);
            pnlControls.Name = "pnlControls";
            pnlControls.Size = new Size(1100, 110);
            pnlControls.TabIndex = 1;
            // 
            // lblEntity
            // 
            lblEntity.AutoSize = true;
            lblEntity.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEntity.Location = new Point(16, 14);
            lblEntity.Name = "lblEntity";
            lblEntity.Size = new Size(148, 21);
            lblEntity.TabIndex = 0;
            lblEntity.Text = "Módulo / Entidad:";
            // 
            // cboEntityType
            // 
            cboEntityType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEntityType.Font = new Font("Segoe UI", 10F);
            cboEntityType.Location = new Point(16, 36);
            cboEntityType.Name = "cboEntityType";
            cboEntityType.Size = new Size(220, 31);
            cboEntityType.TabIndex = 1;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSearch.Location = new Point(260, 14);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(209, 21);
            lblSearch.TabIndex = 2;
            lblSearch.Text = "Buscar registro eliminado:";
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(260, 36);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(420, 30);
            txtSearch.TabIndex = 3;
            // 
            // lblSelectedItem
            // 
            lblSelectedItem.AutoSize = true;
            lblSelectedItem.Font = new Font("Segoe UI", 9.5F);
            lblSelectedItem.ForeColor = Color.FromArgb(2, 132, 199);
            lblSelectedItem.Location = new Point(16, 78);
            lblSelectedItem.Name = "lblSelectedItem";
            lblSelectedItem.Size = new Size(213, 21);
            lblSelectedItem.TabIndex = 4;
            lblSelectedItem.Text = "Ningún registro seleccionado";
            // 
            // btnRestore
            // 
            btnRestore.BackColor = Color.FromArgb(16, 185, 129);
            btnRestore.Enabled = false;
            btnRestore.FlatAppearance.BorderSize = 0;
            btnRestore.FlatStyle = FlatStyle.Flat;
            btnRestore.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnRestore.ForeColor = Color.White;
            btnRestore.Location = new Point(732, 14);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(348, 85);
            btnRestore.TabIndex = 5;
            btnRestore.Text = "♻️ RESTAURAR SELECCIÓN";
            btnRestore.UseVisualStyleBackColor = false;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCount.ForeColor = Color.FromArgb(100, 116, 139);
            lblCount.Location = new Point(16, 192);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(186, 21);
            lblCount.TabIndex = 2;
            lblCount.Text = "Registros eliminados: 0";
            // 
            // dgvDeletedRecords
            // 
            dgvDeletedRecords.BackgroundColor = Color.White;
            dgvDeletedRecords.BorderStyle = BorderStyle.None;
            dgvDeletedRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDeletedRecords.Location = new Point(16, 218);
            dgvDeletedRecords.Name = "dgvDeletedRecords";
            dgvDeletedRecords.RowHeadersWidth = 51;
            dgvDeletedRecords.Size = new Size(1100, 440);
            dgvDeletedRecords.TabIndex = 3;
            // 
            // FormRestoreRecords
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1135, 680);
            Controls.Add(dgvDeletedRecords);
            Controls.Add(lblCount);
            Controls.Add(pnlControls);
            Controls.Add(pnlHeader);
            Name = "FormRestoreRecords";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Papelera y Restauración";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlControls.ResumeLayout(false);
            pnlControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDeletedRecords).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Label lblEntity;
        private System.Windows.Forms.ComboBox cboEntityType;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSelectedItem;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DataGridView dgvDeletedRecords;
    }
}