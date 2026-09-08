namespace CompriaxSystem.WinFormsUI
{
    partial class FormCategories
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
            pnlCard = new Panel();
            lblName = new Label();
            txtName = new TextBox();
            lblDesc = new Label();
            txtDescription = new TextBox();
            btnSave = new Button();
            btnDelete = new Button();
            btnCancel = new Button();
            dgvCategories = new DataGridView();
            pnlHeader.SuspendLayout();
            pnlCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).BeginInit();
            SuspendLayout();

            // pnlHeader
            pnlHeader.BackColor = Color.FromArgb(15, 23, 42);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1167, 56);
            pnlHeader.TabIndex = 0;

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(16, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(478, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "CATEGORÍAS Y FAMILIAS DE PRODUCTOS";

            // pnlCard
            pnlCard.BackColor = Color.White;
            pnlCard.Controls.Add(lblName);
            pnlCard.Controls.Add(txtName);
            pnlCard.Controls.Add(lblDesc);
            pnlCard.Controls.Add(txtDescription);
            pnlCard.Controls.Add(btnSave);
            pnlCard.Controls.Add(btnDelete);
            pnlCard.Controls.Add(btnCancel);
            pnlCard.Location = new Point(16, 72);
            pnlCard.Name = "pnlCard";
            pnlCard.Padding = new Padding(16);
            pnlCard.Size = new Size(340, 562);
            pnlCard.TabIndex = 1;

            // lblName
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblName.Location = new Point(16, 20);
            lblName.Name = "lblName";
            lblName.Size = new Size(196, 21);
            lblName.TabIndex = 0;
            lblName.Text = "Nombre de la Categoría:";

            // txtName
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(16, 45);
            txtName.Name = "txtName";
            txtName.Size = new Size(306, 30);
            txtName.TabIndex = 1;

            // lblDesc
            lblDesc.AutoSize = true;
            lblDesc.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDesc.Location = new Point(16, 90);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(104, 21);
            lblDesc.TabIndex = 2;
            lblDesc.Text = "Descripción:";

            // txtDescription
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(16, 115);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(306, 120);
            txtDescription.TabIndex = 3;

            // btnSave
            btnSave.BackColor = Color.FromArgb(16, 185, 129);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(16, 260);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(306, 92);
            btnSave.TabIndex = 4;
            btnSave.Text = "GUARDAR";
            btnSave.UseVisualStyleBackColor = false;

            // btnDelete
            btnDelete.BackColor = Color.FromArgb(239, 68, 68);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(16, 358);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(306, 85);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "ELIMINAR";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Visible = false;

            // btnCancel
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancel.Location = new Point(15, 449);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(306, 94);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "CANCELAR";
            btnCancel.UseVisualStyleBackColor = true;

            // dgvCategories
            dgvCategories.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCategories.BackgroundColor = Color.White;
            dgvCategories.BorderStyle = BorderStyle.None;
            dgvCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategories.Location = new Point(375, 72);
            dgvCategories.Name = "dgvCategories";
            dgvCategories.RowHeadersWidth = 51;
            dgvCategories.Size = new Size(767, 562);
            dgvCategories.TabIndex = 2;

            // FormCategories
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1167, 662);
            Controls.Add(dgvCategories);
            Controls.Add(pnlCard);
            Controls.Add(pnlHeader);
            Name = "FormCategories";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administración de Categorías";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvCategories;
    }
}