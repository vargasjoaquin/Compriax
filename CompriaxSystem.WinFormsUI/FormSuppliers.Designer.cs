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
            pnlHeader = new Panel();
            lblTitle = new Label();
            btnExportPdf = new Button();
            groupBoxData = new Panel();
            lblTaxId = new Label();
            txtTaxId = new TextBox();
            lblCompanyName = new Label();
            txtCompanyName = new TextBox();
            lblContact = new Label();
            txtContact = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            btnSave = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            dgvSuppliers = new DataGridView();
            pnlHeader.SuspendLayout();
            groupBoxData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(15, 23, 42);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnExportPdf);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1125, 69);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(16, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(339, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🚚 GESTIÓN DE PROVEEDORES";
            // 
            // btnExportPdf
            // 
            btnExportPdf.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportPdf.BackColor = Color.FromArgb(2, 132, 199);
            btnExportPdf.FlatAppearance.BorderSize = 0;
            btnExportPdf.FlatStyle = FlatStyle.Flat;
            btnExportPdf.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnExportPdf.ForeColor = Color.White;
            btnExportPdf.Location = new Point(892, 8);
            btnExportPdf.Name = "btnExportPdf";
            btnExportPdf.Size = new Size(182, 51);
            btnExportPdf.TabIndex = 1;
            btnExportPdf.Text = "📄 EXPORTAR PDF";
            btnExportPdf.UseVisualStyleBackColor = false;
            // 
            // groupBoxData
            // 
            groupBoxData.BackColor = Color.White;
            groupBoxData.Controls.Add(lblTaxId);
            groupBoxData.Controls.Add(txtTaxId);
            groupBoxData.Controls.Add(lblCompanyName);
            groupBoxData.Controls.Add(txtCompanyName);
            groupBoxData.Controls.Add(lblContact);
            groupBoxData.Controls.Add(txtContact);
            groupBoxData.Controls.Add(lblEmail);
            groupBoxData.Controls.Add(txtEmail);
            groupBoxData.Controls.Add(lblPhone);
            groupBoxData.Controls.Add(txtPhone);
            groupBoxData.Controls.Add(lblAddress);
            groupBoxData.Controls.Add(txtAddress);
            groupBoxData.Controls.Add(btnSave);
            groupBoxData.Controls.Add(btnEdit);
            groupBoxData.Controls.Add(btnDelete);
            groupBoxData.Location = new Point(16, 86);
            groupBoxData.Name = "groupBoxData";
            groupBoxData.Size = new Size(1090, 210);
            groupBoxData.TabIndex = 1;
            // 
            // lblTaxId
            // 
            lblTaxId.AutoSize = true;
            lblTaxId.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTaxId.Location = new Point(20, 16);
            lblTaxId.Name = "lblTaxId";
            lblTaxId.Size = new Size(155, 21);
            lblTaxId.TabIndex = 0;
            lblTaxId.Text = "CUIT / Documento:";
            // 
            // txtTaxId
            // 
            txtTaxId.BorderStyle = BorderStyle.FixedSingle;
            txtTaxId.Font = new Font("Segoe UI", 10F);
            txtTaxId.Location = new Point(20, 38);
            txtTaxId.Name = "txtTaxId";
            txtTaxId.Size = new Size(220, 30);
            txtTaxId.TabIndex = 1;
            // 
            // lblCompanyName
            // 
            lblCompanyName.AutoSize = true;
            lblCompanyName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCompanyName.Location = new Point(260, 16);
            lblCompanyName.Name = "lblCompanyName";
            lblCompanyName.Size = new Size(191, 21);
            lblCompanyName.TabIndex = 2;
            lblCompanyName.Text = "Razón Social / Empresa:";
            // 
            // txtCompanyName
            // 
            txtCompanyName.BorderStyle = BorderStyle.FixedSingle;
            txtCompanyName.Font = new Font("Segoe UI", 10F);
            txtCompanyName.Location = new Point(260, 38);
            txtCompanyName.Name = "txtCompanyName";
            txtCompanyName.Size = new Size(250, 30);
            txtCompanyName.TabIndex = 3;
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblContact.Location = new Point(530, 16);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(164, 21);
            lblContact.TabIndex = 4;
            lblContact.Text = "Contacto Comercial:";
            // 
            // txtContact
            // 
            txtContact.BorderStyle = BorderStyle.FixedSingle;
            txtContact.Font = new Font("Segoe UI", 10F);
            txtContact.Location = new Point(530, 38);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(240, 30);
            txtContact.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEmail.Location = new Point(20, 105);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(155, 21);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Correo Electrónico:";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(20, 127);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(220, 30);
            txtEmail.TabIndex = 7;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPhone.Location = new Point(260, 105);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(81, 21);
            lblPhone.TabIndex = 8;
            lblPhone.Text = "Teléfono:";
            // 
            // txtPhone
            // 
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(260, 127);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(250, 30);
            txtPhone.TabIndex = 9;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAddress.Location = new Point(530, 105);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(168, 21);
            lblAddress.TabIndex = 10;
            lblAddress.Text = "Dirección Comercial:";
            // 
            // txtAddress
            // 
            txtAddress.BorderStyle = BorderStyle.FixedSingle;
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.Location = new Point(530, 127);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(240, 30);
            txtAddress.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(16, 185, 129);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(800, 16);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(284, 54);
            btnSave.TabIndex = 12;
            btnSave.Text = "💾 GUARDAR PROVEEDOR";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEdit.Location = new Point(800, 76);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(284, 55);
            btnEdit.TabIndex = 13;
            btnEdit.Text = "EDITAR PROVEEDOR";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(239, 68, 68);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(800, 137);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(284, 55);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "ELIMINAR PROVEEDOR";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // dgvSuppliers
            // 
            dgvSuppliers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSuppliers.BackgroundColor = Color.White;
            dgvSuppliers.BorderStyle = BorderStyle.None;
            dgvSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSuppliers.Location = new Point(16, 302);
            dgvSuppliers.Name = "dgvSuppliers";
            dgvSuppliers.RowHeadersWidth = 51;
            dgvSuppliers.Size = new Size(1090, 376);
            dgvSuppliers.TabIndex = 2;
            // 
            // FormSuppliers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1125, 698);
            Controls.Add(dgvSuppliers);
            Controls.Add(groupBoxData);
            Controls.Add(pnlHeader);
            Name = "FormSuppliers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Proveedores";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            groupBoxData.ResumeLayout(false);
            groupBoxData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnExportPdf;
        private System.Windows.Forms.Panel groupBoxData;
        private System.Windows.Forms.Label lblTaxId;
        private System.Windows.Forms.TextBox txtTaxId;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvSuppliers;
    }
}