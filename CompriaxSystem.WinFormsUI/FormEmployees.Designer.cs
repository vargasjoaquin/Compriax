namespace CompriaxSystem.WinFormsUI
{
    partial class FormEmployees
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
            gbData = new Panel();
            picPhoto = new PictureBox();
            btnBrowse = new Button();
            lblLegajo = new Label();
            txtCode = new TextBox();
            lblDni = new Label();
            txtDni = new TextBox();
            lblCuil = new Label();
            txtCuil = new TextBox();
            lblNombre = new Label();
            txtFirstName = new TextBox();
            lblApellido = new Label();
            txtLastName = new TextBox();
            lblCargo = new Label();
            cboPosition = new ComboBox();
            lblGenero = new Label();
            cboGender = new ComboBox();
            lblEstado = new Label();
            cboCivilStatus = new ComboBox();
            lblHijos = new Label();
            numChildren = new NumericUpDown();
            lblTel = new Label();
            txtPhone = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblDireccion = new Label();
            txtAddress = new TextBox();
            btnSave = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            dgvEmployees = new DataGridView();
            pnlHeader.SuspendLayout();
            gbData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPhoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numChildren).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
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
            pnlHeader.Size = new Size(1227, 91);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(16, 28);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(535, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "GESTIÓN DE PERSONAL Y EMPLEADOS (RRHH)";
            // 
            // btnExportPdf
            // 
            btnExportPdf.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportPdf.BackColor = Color.FromArgb(2, 132, 199);
            btnExportPdf.FlatAppearance.BorderSize = 0;
            btnExportPdf.FlatStyle = FlatStyle.Flat;
            btnExportPdf.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnExportPdf.ForeColor = Color.White;
            btnExportPdf.Location = new Point(995, 15);
            btnExportPdf.Name = "btnExportPdf";
            btnExportPdf.Size = new Size(196, 61);
            btnExportPdf.TabIndex = 1;
            btnExportPdf.Text = "EXPORTAR PDF";
            btnExportPdf.UseVisualStyleBackColor = false;
            // 
            // gbData
            // 
            gbData.BackColor = Color.White;
            gbData.Controls.Add(picPhoto);
            gbData.Controls.Add(btnBrowse);
            gbData.Controls.Add(lblLegajo);
            gbData.Controls.Add(txtCode);
            gbData.Controls.Add(lblDni);
            gbData.Controls.Add(txtDni);
            gbData.Controls.Add(lblCuil);
            gbData.Controls.Add(txtCuil);
            gbData.Controls.Add(lblNombre);
            gbData.Controls.Add(txtFirstName);
            gbData.Controls.Add(lblApellido);
            gbData.Controls.Add(txtLastName);
            gbData.Controls.Add(lblCargo);
            gbData.Controls.Add(cboPosition);
            gbData.Controls.Add(lblGenero);
            gbData.Controls.Add(cboGender);
            gbData.Controls.Add(lblEstado);
            gbData.Controls.Add(cboCivilStatus);
            gbData.Controls.Add(lblHijos);
            gbData.Controls.Add(numChildren);
            gbData.Controls.Add(lblTel);
            gbData.Controls.Add(txtPhone);
            gbData.Controls.Add(lblEmail);
            gbData.Controls.Add(txtEmail);
            gbData.Controls.Add(lblDireccion);
            gbData.Controls.Add(txtAddress);
            gbData.Controls.Add(btnSave);
            gbData.Controls.Add(btnEdit);
            gbData.Controls.Add(btnDelete);
            gbData.Location = new Point(16, 97);
            gbData.Name = "gbData";
            gbData.Size = new Size(1199, 267);
            gbData.TabIndex = 1;
            // 
            // picPhoto
            // 
            picPhoto.BackColor = Color.FromArgb(248, 250, 252);
            picPhoto.BorderStyle = BorderStyle.FixedSingle;
            picPhoto.Location = new Point(16, 16);
            picPhoto.Name = "picPhoto";
            picPhoto.Size = new Size(140, 150);
            picPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            picPhoto.TabIndex = 0;
            picPhoto.TabStop = false;
            // 
            // btnBrowse
            // 
            btnBrowse.BackColor = Color.FromArgb(2, 132, 199);
            btnBrowse.FlatAppearance.BorderSize = 0;
            btnBrowse.FlatStyle = FlatStyle.Flat;
            btnBrowse.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBrowse.ForeColor = Color.White;
            btnBrowse.Location = new Point(16, 183);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(140, 66);
            btnBrowse.TabIndex = 1;
            btnBrowse.Text = "FOTO";
            btnBrowse.UseVisualStyleBackColor = false;
            // 
            // lblLegajo
            // 
            lblLegajo.AutoSize = true;
            lblLegajo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblLegajo.Location = new Point(171, 29);
            lblLegajo.Name = "lblLegajo";
            lblLegajo.Size = new Size(65, 21);
            lblLegajo.TabIndex = 2;
            lblLegajo.Text = "Legajo:";
            // 
            // txtCode
            // 
            txtCode.BorderStyle = BorderStyle.FixedSingle;
            txtCode.Font = new Font("Segoe UI", 10F);
            txtCode.Location = new Point(171, 53);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(120, 30);
            txtCode.TabIndex = 3;
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDni.Location = new Point(311, 29);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(44, 21);
            lblDni.TabIndex = 4;
            lblDni.Text = "DNI:";
            // 
            // txtDni
            // 
            txtDni.BorderStyle = BorderStyle.FixedSingle;
            txtDni.Font = new Font("Segoe UI", 10F);
            txtDni.Location = new Point(311, 53);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(140, 30);
            txtDni.TabIndex = 5;
            // 
            // lblCuil
            // 
            lblCuil.AutoSize = true;
            lblCuil.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCuil.Location = new Point(475, 29);
            lblCuil.Name = "lblCuil";
            lblCuil.Size = new Size(49, 21);
            lblCuil.TabIndex = 6;
            lblCuil.Text = "CUIL:";
            // 
            // txtCuil
            // 
            txtCuil.BorderStyle = BorderStyle.FixedSingle;
            txtCuil.Font = new Font("Segoe UI", 10F);
            txtCuil.Location = new Point(475, 53);
            txtCuil.Name = "txtCuil";
            txtCuil.Size = new Size(140, 30);
            txtCuil.TabIndex = 7;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNombre.Location = new Point(638, 29);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(77, 21);
            lblNombre.TabIndex = 8;
            lblNombre.Text = "Nombre:";
            // 
            // txtFirstName
            // 
            txtFirstName.BorderStyle = BorderStyle.FixedSingle;
            txtFirstName.Font = new Font("Segoe UI", 10F);
            txtFirstName.Location = new Point(638, 53);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(168, 30);
            txtFirstName.TabIndex = 9;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblApellido.Location = new Point(820, 29);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(79, 21);
            lblApellido.TabIndex = 10;
            lblApellido.Text = "Apellido:";
            // 
            // txtLastName
            // 
            txtLastName.BorderStyle = BorderStyle.FixedSingle;
            txtLastName.Font = new Font("Segoe UI", 10F);
            txtLastName.Location = new Point(820, 53);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(165, 30);
            txtLastName.TabIndex = 11;
            // 
            // lblCargo
            // 
            lblCargo.AutoSize = true;
            lblCargo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCargo.Location = new Point(171, 90);
            lblCargo.Name = "lblCargo";
            lblCargo.Size = new Size(39, 21);
            lblCargo.TabIndex = 12;
            lblCargo.Text = "Rol:";
            // 
            // cboPosition
            // 
            cboPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPosition.Font = new Font("Segoe UI", 10F);
            cboPosition.Location = new Point(171, 114);
            cboPosition.Name = "cboPosition";
            cboPosition.Size = new Size(180, 31);
            cboPosition.TabIndex = 13;
            // 
            // lblGenero
            // 
            lblGenero.AutoSize = true;
            lblGenero.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblGenero.Location = new Point(372, 90);
            lblGenero.Name = "lblGenero";
            lblGenero.Size = new Size(69, 21);
            lblGenero.TabIndex = 14;
            lblGenero.Text = "Género:";
            // 
            // cboGender
            // 
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.Font = new Font("Segoe UI", 10F);
            cboGender.Location = new Point(372, 114);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(140, 31);
            cboGender.TabIndex = 15;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEstado.Location = new Point(540, 90);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(103, 21);
            lblEstado.TabIndex = 16;
            lblEstado.Text = "Estado Civil:";
            // 
            // cboCivilStatus
            // 
            cboCivilStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCivilStatus.Font = new Font("Segoe UI", 10F);
            cboCivilStatus.Location = new Point(540, 114);
            cboCivilStatus.Name = "cboCivilStatus";
            cboCivilStatus.Size = new Size(150, 31);
            cboCivilStatus.TabIndex = 17;
            // 
            // lblHijos
            // 
            lblHijos.AutoSize = true;
            lblHijos.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblHijos.Location = new Point(723, 91);
            lblHijos.Name = "lblHijos";
            lblHijos.Size = new Size(53, 21);
            lblHijos.TabIndex = 18;
            lblHijos.Text = "Hijos:";
            // 
            // numChildren
            // 
            numChildren.Font = new Font("Segoe UI", 10F);
            numChildren.Location = new Point(723, 115);
            numChildren.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numChildren.Name = "numChildren";
            numChildren.Size = new Size(70, 30);
            numChildren.TabIndex = 19;
            // 
            // lblTel
            // 
            lblTel.AutoSize = true;
            lblTel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTel.Location = new Point(820, 91);
            lblTel.Name = "lblTel";
            lblTel.Size = new Size(81, 21);
            lblTel.TabIndex = 20;
            lblTel.Text = "Teléfono:";
            // 
            // txtPhone
            // 
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(820, 114);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(165, 30);
            txtPhone.TabIndex = 21;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEmail.Location = new Point(171, 162);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(155, 21);
            lblEmail.TabIndex = 22;
            lblEmail.Text = "Correo Electrónico:";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(171, 186);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(270, 30);
            txtEmail.TabIndex = 23;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDireccion.Location = new Point(486, 162);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(165, 21);
            lblDireccion.TabIndex = 24;
            lblDireccion.Text = "Dirección Completa:";
            // 
            // txtAddress
            // 
            txtAddress.BorderStyle = BorderStyle.FixedSingle;
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.Location = new Point(486, 186);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(320, 30);
            txtAddress.TabIndex = 25;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(16, 185, 129);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(999, 16);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(193, 82);
            btnSave.TabIndex = 26;
            btnSave.Text = "GUARDAR";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEdit.Location = new Point(999, 104);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(193, 73);
            btnEdit.TabIndex = 27;
            btnEdit.Text = "EDITAR";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(239, 68, 68);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(999, 183);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(193, 77);
            btnDelete.TabIndex = 28;
            btnDelete.Text = "DESACTIVAR";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // dgvEmployees
            // 
            dgvEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEmployees.BackgroundColor = Color.White;
            dgvEmployees.BorderStyle = BorderStyle.None;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(16, 385);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.Size = new Size(1192, 328);
            dgvEmployees.TabIndex = 2;
            // 
            // FormEmployees
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1227, 733);
            Controls.Add(dgvEmployees);
            Controls.Add(gbData);
            Controls.Add(pnlHeader);
            Name = "FormEmployees";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nómina de Empleados";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            gbData.ResumeLayout(false);
            gbData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPhoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)numChildren).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnExportPdf;
        private System.Windows.Forms.Panel gbData;
        private System.Windows.Forms.PictureBox picPhoto;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblLegajo;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblCuil;
        private System.Windows.Forms.TextBox txtCuil;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.ComboBox cboPosition;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboCivilStatus;
        private System.Windows.Forms.Label lblHijos;
        private System.Windows.Forms.NumericUpDown numChildren;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvEmployees;
    }
}