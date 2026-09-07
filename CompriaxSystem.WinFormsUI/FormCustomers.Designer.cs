namespace CompriaxSystem.WinFormsUI
{
    partial class FormCustomers
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            btnExportPdf = new Button();
            pnlMain = new Panel();
            dgvCustomers = new DataGridView();
            groupBox1 = new Panel();
            lblDni = new Label();
            txtDni = new TextBox();
            lblCuil = new Label();
            txtCuil = new TextBox();
            lblNombre = new Label();
            txtName = new TextBox();
            lblApellido = new Label();
            txtLastName = new TextBox();
            lblFiscal = new Label();
            cboTaxCondition = new ComboBox();
            lblTel = new Label();
            txtPhone = new TextBox();
            lblDir = new Label();
            txtAddress = new TextBox();
            lblCiu = new Label();
            txtCity = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            btnSave = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            pnlHeader.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            groupBox1.SuspendLayout();
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
            pnlHeader.Size = new Size(1163, 79);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(16, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(282, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "GESTIÓN DE CLIENTES";
            // 
            // btnExportPdf
            // 
            btnExportPdf.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportPdf.BackColor = Color.FromArgb(2, 132, 199);
            btnExportPdf.FlatAppearance.BorderSize = 0;
            btnExportPdf.FlatStyle = FlatStyle.Flat;
            btnExportPdf.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnExportPdf.ForeColor = Color.White;
            btnExportPdf.Location = new Point(936, 12);
            btnExportPdf.Name = "btnExportPdf";
            btnExportPdf.Size = new Size(211, 55);
            btnExportPdf.TabIndex = 1;
            btnExportPdf.Text = "EXPORTAR PDF";
            btnExportPdf.UseVisualStyleBackColor = false;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(248, 250, 252);
            pnlMain.Controls.Add(dgvCustomers);
            pnlMain.Controls.Add(groupBox1);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 79);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(16, 12, 16, 16);
            pnlMain.Size = new Size(1163, 624);
            pnlMain.TabIndex = 1;
            // 
            // dgvCustomers
            // 
            dgvCustomers.BackgroundColor = Color.White;
            dgvCustomers.BorderStyle = BorderStyle.None;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Dock = DockStyle.Fill;
            dgvCustomers.Location = new Point(16, 239);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.Size = new Size(1131, 369);
            dgvCustomers.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(lblDni);
            groupBox1.Controls.Add(txtDni);
            groupBox1.Controls.Add(lblCuil);
            groupBox1.Controls.Add(txtCuil);
            groupBox1.Controls.Add(lblNombre);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(lblApellido);
            groupBox1.Controls.Add(txtLastName);
            groupBox1.Controls.Add(lblFiscal);
            groupBox1.Controls.Add(cboTaxCondition);
            groupBox1.Controls.Add(lblTel);
            groupBox1.Controls.Add(txtPhone);
            groupBox1.Controls.Add(lblDir);
            groupBox1.Controls.Add(txtAddress);
            groupBox1.Controls.Add(lblCiu);
            groupBox1.Controls.Add(txtCity);
            groupBox1.Controls.Add(lblEmail);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(btnEdit);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(16, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1131, 227);
            groupBox1.TabIndex = 0;
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDni.Location = new Point(20, 16);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(149, 21);
            lblDni.TabIndex = 0;
            lblDni.Text = "DNI / Documento:";
            // 
            // txtDni
            // 
            txtDni.BorderStyle = BorderStyle.FixedSingle;
            txtDni.Font = new Font("Segoe UI", 10F);
            txtDni.Location = new Point(20, 42);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(160, 30);
            txtDni.TabIndex = 1;
            // 
            // lblCuil
            // 
            lblCuil.AutoSize = true;
            lblCuil.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCuil.Location = new Point(195, 16);
            lblCuil.Name = "lblCuil";
            lblCuil.Size = new Size(100, 21);
            lblCuil.TabIndex = 2;
            lblCuil.Text = "CUIL / CUIT:";
            // 
            // txtCuil
            // 
            txtCuil.BorderStyle = BorderStyle.FixedSingle;
            txtCuil.Font = new Font("Segoe UI", 10F);
            txtCuil.Location = new Point(195, 42);
            txtCuil.Name = "txtCuil";
            txtCuil.Size = new Size(160, 30);
            txtCuil.TabIndex = 3;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNombre.Location = new Point(370, 16);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(77, 21);
            lblNombre.TabIndex = 4;
            lblNombre.Text = "Nombre:";
            // 
            // txtName
            // 
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(370, 42);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 30);
            txtName.TabIndex = 5;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblApellido.Location = new Point(585, 16);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(79, 21);
            lblApellido.TabIndex = 6;
            lblApellido.Text = "Apellido:";
            // 
            // txtLastName
            // 
            txtLastName.BorderStyle = BorderStyle.FixedSingle;
            txtLastName.Font = new Font("Segoe UI", 10F);
            txtLastName.Location = new Point(585, 42);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(200, 30);
            txtLastName.TabIndex = 7;
            // 
            // lblFiscal
            // 
            lblFiscal.AutoSize = true;
            lblFiscal.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblFiscal.Location = new Point(20, 88);
            lblFiscal.Name = "lblFiscal";
            lblFiscal.Size = new Size(138, 21);
            lblFiscal.TabIndex = 8;
            lblFiscal.Text = "Condición Fiscal:";
            // 
            // cboTaxCondition
            // 
            cboTaxCondition.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTaxCondition.Font = new Font("Segoe UI", 10F);
            cboTaxCondition.Location = new Point(20, 113);
            cboTaxCondition.Name = "cboTaxCondition";
            cboTaxCondition.Size = new Size(160, 31);
            cboTaxCondition.TabIndex = 9;
            // 
            // lblTel
            // 
            lblTel.AutoSize = true;
            lblTel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTel.Location = new Point(195, 88);
            lblTel.Name = "lblTel";
            lblTel.Size = new Size(81, 21);
            lblTel.TabIndex = 10;
            lblTel.Text = "Teléfono:";
            // 
            // txtPhone
            // 
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(195, 113);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(160, 30);
            txtPhone.TabIndex = 11;
            // 
            // lblDir
            // 
            lblDir.AutoSize = true;
            lblDir.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDir.Location = new Point(370, 88);
            lblDir.Name = "lblDir";
            lblDir.Size = new Size(87, 21);
            lblDir.TabIndex = 12;
            lblDir.Text = "Dirección:";
            // 
            // txtAddress
            // 
            txtAddress.BorderStyle = BorderStyle.FixedSingle;
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.Location = new Point(370, 113);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(200, 30);
            txtAddress.TabIndex = 13;
            // 
            // lblCiu
            // 
            lblCiu.AutoSize = true;
            lblCiu.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCiu.Location = new Point(585, 88);
            lblCiu.Name = "lblCiu";
            lblCiu.Size = new Size(68, 21);
            lblCiu.TabIndex = 14;
            lblCiu.Text = "Ciudad:";
            // 
            // txtCity
            // 
            txtCity.BorderStyle = BorderStyle.FixedSingle;
            txtCity.Font = new Font("Segoe UI", 10F);
            txtCity.Location = new Point(585, 113);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(200, 30);
            txtCity.TabIndex = 15;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEmail.Location = new Point(20, 158);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(155, 21);
            lblEmail.TabIndex = 16;
            lblEmail.Text = "Correo electronico:";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(20, 182);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(335, 30);
            txtEmail.TabIndex = 17;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(16, 185, 129);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(830, 16);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(286, 66);
            btnSave.TabIndex = 18;
            btnSave.Text = "GUARDAR CLIENTE";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEdit.Location = new Point(830, 88);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(286, 56);
            btnEdit.TabIndex = 19;
            btnEdit.Text = "EDITAR CLIENTE";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(239, 68, 68);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(830, 150);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(286, 62);
            btnDelete.TabIndex = 20;
            btnDelete.Text = "ELIMINAR CLIENTE";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // FormCustomers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1163, 703);
            Controls.Add(pnlMain);
            Controls.Add(pnlHeader);
            Name = "FormCustomers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de Clientes";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnExportPdf;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel groupBox1;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblCuil;
        private System.Windows.Forms.TextBox txtCuil;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblFiscal;
        private System.Windows.Forms.ComboBox cboTaxCondition;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblDir;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblCiu;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvCustomers;
    }
}