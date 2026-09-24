namespace CompriaxSystem.WinFormsUI
{
    partial class FormSuppliers
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
            picIconExportPdf = new PictureBox();
            picIconSave = new PictureBox();
            picIconEdit = new PictureBox();
            picIconDelete = new PictureBox();
            panelHeader = new Panel();
            labelTitle = new Label();
            buttonExportPdf = new Button();
            panelSupplierForm = new Panel();
            labelTaxId = new Label();
            textBoxTaxId = new TextBox();
            labelCompanyName = new Label();
            textBoxCompanyName = new TextBox();
            labelContactName = new Label();
            textBoxContactName = new TextBox();
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            labelPhone = new Label();
            textBoxPhone = new TextBox();
            labelAddress = new Label();
            textBoxAddress = new TextBox();
            buttonSave = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            dataGridViewSuppliers = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)picIconExportPdf).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconSave).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconEdit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconDelete).BeginInit();
            panelHeader.SuspendLayout();
            panelSupplierForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSuppliers).BeginInit();
            SuspendLayout();
            // 
            // picIconExportPdf
            // 
            picIconExportPdf.BackColor = Color.FromArgb(2, 132, 199);
            picIconExportPdf.Cursor = Cursors.Hand;
            picIconExportPdf.Image = Resources._085_exportar_pdf;
            picIconExportPdf.Location = new Point(892, 8);
            picIconExportPdf.Name = "picIconExportPdf";
            picIconExportPdf.Size = new Size(42, 51);
            picIconExportPdf.SizeMode = PictureBoxSizeMode.Zoom;
            picIconExportPdf.TabIndex = 99;
            picIconExportPdf.TabStop = false;
            // 
            // picIconSave
            // 
            picIconSave.BackColor = Color.FromArgb(16, 185, 129);
            picIconSave.Cursor = Cursors.Hand;
            picIconSave.Image = Resources._077_guardar;
            picIconSave.Location = new Point(852, 20);
            picIconSave.Name = "picIconSave";
            picIconSave.Size = new Size(44, 48);
            picIconSave.SizeMode = PictureBoxSizeMode.Zoom;
            picIconSave.TabIndex = 99;
            picIconSave.TabStop = false;
            // 
            // picIconEdit
            // 
            picIconEdit.BackColor = Color.FromArgb(255, 255, 255);
            picIconEdit.Cursor = Cursors.Hand;
            picIconEdit.Image = Resources._078_editar;
            picIconEdit.Location = new Point(876, 76);
            picIconEdit.Name = "picIconEdit";
            picIconEdit.Size = new Size(40, 55);
            picIconEdit.SizeMode = PictureBoxSizeMode.Zoom;
            picIconEdit.TabIndex = 99;
            picIconEdit.TabStop = false;
            // 
            // picIconDelete
            // 
            picIconDelete.BackColor = Color.FromArgb(239, 68, 68);
            picIconDelete.Cursor = Cursors.Hand;
            picIconDelete.Image = Resources._079_eliminar;
            picIconDelete.Location = new Point(863, 137);
            picIconDelete.Name = "picIconDelete";
            picIconDelete.Size = new Size(42, 55);
            picIconDelete.SizeMode = PictureBoxSizeMode.Zoom;
            picIconDelete.TabIndex = 99;
            picIconDelete.TabStop = false;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Controls.Add(picIconExportPdf);
            panelHeader.Controls.Add(buttonExportPdf);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1125, 69);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 16);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(302, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "GESTIÓN DE PROVEEDORES";
            labelTitle.Click += labelTitle_Click;
            // 
            // buttonExportPdf
            // 
            buttonExportPdf.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonExportPdf.BackColor = Color.FromArgb(2, 132, 199);
            buttonExportPdf.FlatAppearance.BorderSize = 0;
            buttonExportPdf.FlatStyle = FlatStyle.Flat;
            buttonExportPdf.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonExportPdf.ForeColor = Color.White;
            buttonExportPdf.Location = new Point(892, 8);
            buttonExportPdf.Name = "buttonExportPdf";
            buttonExportPdf.Size = new Size(208, 51);
            buttonExportPdf.TabIndex = 1;
            buttonExportPdf.Text = "EXPORTAR PDF";
            buttonExportPdf.UseVisualStyleBackColor = false;
            // 
            // panelSupplierForm
            // 
            panelSupplierForm.BackColor = Color.White;
            panelSupplierForm.Controls.Add(labelTaxId);
            panelSupplierForm.Controls.Add(textBoxTaxId);
            panelSupplierForm.Controls.Add(labelCompanyName);
            panelSupplierForm.Controls.Add(textBoxCompanyName);
            panelSupplierForm.Controls.Add(labelContactName);
            panelSupplierForm.Controls.Add(textBoxContactName);
            panelSupplierForm.Controls.Add(labelEmail);
            panelSupplierForm.Controls.Add(textBoxEmail);
            panelSupplierForm.Controls.Add(labelPhone);
            panelSupplierForm.Controls.Add(textBoxPhone);
            panelSupplierForm.Controls.Add(labelAddress);
            panelSupplierForm.Controls.Add(textBoxAddress);
            panelSupplierForm.Controls.Add(picIconSave);
            panelSupplierForm.Controls.Add(buttonSave);
            panelSupplierForm.Controls.Add(picIconEdit);
            panelSupplierForm.Controls.Add(buttonEdit);
            panelSupplierForm.Controls.Add(picIconDelete);
            panelSupplierForm.Controls.Add(buttonDelete);
            panelSupplierForm.Location = new Point(16, 86);
            panelSupplierForm.Name = "panelSupplierForm";
            panelSupplierForm.Size = new Size(1090, 210);
            panelSupplierForm.TabIndex = 1;
            // 
            // labelTaxId
            // 
            labelTaxId.AutoSize = true;
            labelTaxId.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelTaxId.Location = new Point(20, 16);
            labelTaxId.Name = "labelTaxId";
            labelTaxId.Size = new Size(155, 21);
            labelTaxId.TabIndex = 0;
            labelTaxId.Text = "CUIT / Documento:";
            // 
            // textBoxTaxId
            // 
            textBoxTaxId.BorderStyle = BorderStyle.FixedSingle;
            textBoxTaxId.Font = new Font("Segoe UI", 10F);
            textBoxTaxId.Location = new Point(20, 38);
            textBoxTaxId.Name = "textBoxTaxId";
            textBoxTaxId.Size = new Size(220, 30);
            textBoxTaxId.TabIndex = 1;
            // 
            // labelCompanyName
            // 
            labelCompanyName.AutoSize = true;
            labelCompanyName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelCompanyName.Location = new Point(260, 16);
            labelCompanyName.Name = "labelCompanyName";
            labelCompanyName.Size = new Size(79, 21);
            labelCompanyName.TabIndex = 2;
            labelCompanyName.Text = "Empresa:";
            // 
            // textBoxCompanyName
            // 
            textBoxCompanyName.BorderStyle = BorderStyle.FixedSingle;
            textBoxCompanyName.Font = new Font("Segoe UI", 10F);
            textBoxCompanyName.Location = new Point(260, 38);
            textBoxCompanyName.Name = "textBoxCompanyName";
            textBoxCompanyName.Size = new Size(250, 30);
            textBoxCompanyName.TabIndex = 3;
            // 
            // labelContactName
            // 
            labelContactName.AutoSize = true;
            labelContactName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelContactName.Location = new Point(530, 16);
            labelContactName.Name = "labelContactName";
            labelContactName.Size = new Size(164, 21);
            labelContactName.TabIndex = 4;
            labelContactName.Text = "Contacto Comercial:";
            // 
            // textBoxContactName
            // 
            textBoxContactName.BorderStyle = BorderStyle.FixedSingle;
            textBoxContactName.Font = new Font("Segoe UI", 10F);
            textBoxContactName.Location = new Point(530, 38);
            textBoxContactName.Name = "textBoxContactName";
            textBoxContactName.Size = new Size(240, 30);
            textBoxContactName.TabIndex = 5;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelEmail.Location = new Point(20, 105);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(155, 21);
            labelEmail.TabIndex = 6;
            labelEmail.Text = "Correo Electrónico:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxEmail.Font = new Font("Segoe UI", 10F);
            textBoxEmail.Location = new Point(20, 127);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(220, 30);
            textBoxEmail.TabIndex = 7;
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelPhone.Location = new Point(260, 105);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(81, 21);
            labelPhone.TabIndex = 8;
            labelPhone.Text = "Teléfono:";
            // 
            // textBoxPhone
            // 
            textBoxPhone.BorderStyle = BorderStyle.FixedSingle;
            textBoxPhone.Font = new Font("Segoe UI", 10F);
            textBoxPhone.Location = new Point(260, 127);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(250, 30);
            textBoxPhone.TabIndex = 9;
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelAddress.Location = new Point(530, 105);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(168, 21);
            labelAddress.TabIndex = 10;
            labelAddress.Text = "Dirección Comercial:";
            // 
            // textBoxAddress
            // 
            textBoxAddress.BorderStyle = BorderStyle.FixedSingle;
            textBoxAddress.Font = new Font("Segoe UI", 10F);
            textBoxAddress.Location = new Point(530, 127);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(240, 30);
            textBoxAddress.TabIndex = 11;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.FromArgb(16, 185, 129);
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonSave.ForeColor = Color.White;
            buttonSave.Location = new Point(800, 16);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(284, 54);
            buttonSave.TabIndex = 12;
            buttonSave.Text = "GUARDAR";
            buttonSave.UseVisualStyleBackColor = false;
            // 
            // buttonEdit
            // 
            buttonEdit.FlatStyle = FlatStyle.Flat;
            buttonEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonEdit.Location = new Point(800, 76);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(284, 55);
            buttonEdit.TabIndex = 13;
            buttonEdit.Text = "EDITAR";
            buttonEdit.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.FromArgb(239, 68, 68);
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Location = new Point(800, 137);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(284, 55);
            buttonDelete.TabIndex = 14;
            buttonDelete.Text = "ELIMINAR";
            buttonDelete.UseVisualStyleBackColor = false;
            // 
            // dataGridViewSuppliers
            // 
            dataGridViewSuppliers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewSuppliers.BackgroundColor = Color.White;
            dataGridViewSuppliers.BorderStyle = BorderStyle.None;
            dataGridViewSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSuppliers.Location = new Point(16, 302);
            dataGridViewSuppliers.Name = "dataGridViewSuppliers";
            dataGridViewSuppliers.RowHeadersWidth = 51;
            dataGridViewSuppliers.Size = new Size(1090, 376);
            dataGridViewSuppliers.TabIndex = 2;
            // 
            // FormSuppliers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1125, 698);
            Controls.Add(dataGridViewSuppliers);
            Controls.Add(panelSupplierForm);
            Controls.Add(panelHeader);
            Name = "FormSuppliers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Proveedores";
            ((System.ComponentModel.ISupportInitialize)picIconExportPdf).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconSave).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconEdit).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconDelete).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelSupplierForm.ResumeLayout(false);
            panelSupplierForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSuppliers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonExportPdf;
        private System.Windows.Forms.Panel panelSupplierForm;
        private System.Windows.Forms.Label labelTaxId;
        private System.Windows.Forms.TextBox textBoxTaxId;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.TextBox textBoxCompanyName;
        private System.Windows.Forms.Label labelContactName;
        private System.Windows.Forms.TextBox textBoxContactName;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.DataGridView dataGridViewSuppliers;
        private System.Windows.Forms.PictureBox picIconExportPdf;
        private System.Windows.Forms.PictureBox picIconSave;
        private System.Windows.Forms.PictureBox picIconEdit;
        private System.Windows.Forms.PictureBox picIconDelete;
    }
}
