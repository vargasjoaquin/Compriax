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
            panelHeader = new Panel();
            labelTitle = new Label();
            panelCard = new Panel();
            labelCategoryName = new Label();
            textBoxCategoryName = new TextBox();
            labelDescription = new Label();
            textBoxDescription = new TextBox();
            buttonSave = new Button();
            buttonDelete = new Button();
            buttonCancel = new Button();
            dataGridViewCategories = new DataGridView();
            panelHeader.SuspendLayout();
            panelCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCategories).BeginInit();
            SuspendLayout();

            // panelHeader
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1167, 56);
            panelHeader.TabIndex = 0;

            // labelTitle
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 16);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(478, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "CATEGORÍAS Y FAMILIAS DE PRODUCTOS";

            // panelCard
            panelCard.BackColor = Color.White;
            panelCard.Controls.Add(labelCategoryName);
            panelCard.Controls.Add(textBoxCategoryName);
            panelCard.Controls.Add(labelDescription);
            panelCard.Controls.Add(textBoxDescription);
            panelCard.Controls.Add(buttonSave);
            panelCard.Controls.Add(buttonDelete);
            panelCard.Controls.Add(buttonCancel);
            panelCard.Location = new Point(16, 72);
            panelCard.Name = "panelCard";
            panelCard.Padding = new Padding(16);
            panelCard.Size = new Size(340, 562);
            panelCard.TabIndex = 1;

            // labelCategoryName
            labelCategoryName.AutoSize = true;
            labelCategoryName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelCategoryName.Location = new Point(16, 20);
            labelCategoryName.Name = "labelCategoryName";
            labelCategoryName.Size = new Size(196, 21);
            labelCategoryName.TabIndex = 0;
            labelCategoryName.Text = "Nombre de la Categoría:";

            // textBoxCategoryName
            textBoxCategoryName.BorderStyle = BorderStyle.FixedSingle;
            textBoxCategoryName.Font = new Font("Segoe UI", 10F);
            textBoxCategoryName.Location = new Point(16, 45);
            textBoxCategoryName.Name = "textBoxCategoryName";
            textBoxCategoryName.Size = new Size(306, 30);
            textBoxCategoryName.TabIndex = 1;

            // labelDescription
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelDescription.Location = new Point(16, 90);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(104, 21);
            labelDescription.TabIndex = 2;
            labelDescription.Text = "Descripción:";

            // textBoxDescription
            textBoxDescription.BorderStyle = BorderStyle.FixedSingle;
            textBoxDescription.Font = new Font("Segoe UI", 10F);
            textBoxDescription.Location = new Point(16, 115);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(306, 120);
            textBoxDescription.TabIndex = 3;

            // buttonSave
            buttonSave.BackColor = Color.FromArgb(16, 185, 129);
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonSave.ForeColor = Color.White;
            buttonSave.Location = new Point(16, 260);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(306, 92);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "GUARDAR";
            buttonSave.UseVisualStyleBackColor = false;

            // buttonDelete
            buttonDelete.BackColor = Color.FromArgb(239, 68, 68);
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(16, 358);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(306, 85);
            buttonDelete.TabIndex = 5;
            buttonDelete.Text = "ELIMINAR";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Visible = false;

            // buttonCancel
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonCancel.Location = new Point(15, 449);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(306, 94);
            buttonCancel.TabIndex = 6;
            buttonCancel.Text = "CANCELAR";
            buttonCancel.UseVisualStyleBackColor = true;

            // dataGridViewCategories
            dataGridViewCategories.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCategories.BackgroundColor = Color.White;
            dataGridViewCategories.BorderStyle = BorderStyle.None;
            dataGridViewCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCategories.Location = new Point(375, 72);
            dataGridViewCategories.Name = "dataGridViewCategories";
            dataGridViewCategories.RowHeadersWidth = 51;
            dataGridViewCategories.Size = new Size(767, 562);
            dataGridViewCategories.TabIndex = 2;

            // FormCategories
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1167, 662);
            Controls.Add(dataGridViewCategories);
            Controls.Add(panelCard);
            Controls.Add(panelHeader);
            Name = "FormCategories";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administración de Categorías";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCategories).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Label labelCategoryName;
        private System.Windows.Forms.TextBox textBoxCategoryName;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DataGridView dataGridViewCategories;
    }
}