namespace CompriaxSystem.WinFormsUI
{
    partial class FormUsers
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
            picPhoto = new PictureBox();
            btnBrowsePhoto = new Button();
            btnClearPhoto = new Button();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblRole = new Label();
            cboRole = new ComboBox();
            btnSave = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            dgvUsers = new DataGridView();
            pnlHeader.SuspendLayout();
            groupBoxData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPhoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();

            // pnlHeader
            pnlHeader.BackColor = Color.FromArgb(15, 23, 42);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnExportPdf);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1103, 76);
            pnlHeader.TabIndex = 0;

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(16, 21);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(534, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🔐 ADMINISTRACIÓN DE USUARIOS DEL SISTEMA";

            // btnExportPdf
            btnExportPdf.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportPdf.BackColor = Color.FromArgb(2, 132, 199);
            btnExportPdf.FlatAppearance.BorderSize = 0;
            btnExportPdf.FlatStyle = FlatStyle.Flat;
            btnExportPdf.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExportPdf.ForeColor = Color.White;
            btnExportPdf.Location = new Point(919, 12);
            btnExportPdf.Name = "btnExportPdf";
            btnExportPdf.Size = new Size(165, 54);
            btnExportPdf.TabIndex = 1;
            btnExportPdf.Text = "📄 EXPORTAR PDF";
            btnExportPdf.UseVisualStyleBackColor = false;

            // groupBoxData
            groupBoxData.BackColor = Color.White;
            groupBoxData.Controls.Add(picPhoto);
            groupBoxData.Controls.Add(btnBrowsePhoto);
            groupBoxData.Controls.Add(btnClearPhoto);
            groupBoxData.Controls.Add(lblUsername);
            groupBoxData.Controls.Add(txtUsername);
            groupBoxData.Controls.Add(lblFirstName);
            groupBoxData.Controls.Add(txtFirstName);
            groupBoxData.Controls.Add(lblLastName);
            groupBoxData.Controls.Add(txtLastName);
            groupBoxData.Controls.Add(lblEmail);
            groupBoxData.Controls.Add(txtEmail);
            groupBoxData.Controls.Add(lblPassword);
            groupBoxData.Controls.Add(txtPassword);
            groupBoxData.Controls.Add(lblRole);
            groupBoxData.Controls.Add(cboRole);
            groupBoxData.Controls.Add(btnSave);
            groupBoxData.Controls.Add(btnEdit);
            groupBoxData.Controls.Add(btnDelete);
            groupBoxData.Location = new Point(16, 82);
            groupBoxData.Name = "groupBoxData";
            groupBoxData.Size = new Size(1068, 261);
            groupBoxData.TabIndex = 1;

            // picPhoto
            picPhoto.BackColor = Color.FromArgb(248, 250, 252);
            picPhoto.BorderStyle = BorderStyle.FixedSingle;
            picPhoto.Location = new Point(16, 16);
            picPhoto.Name = "picPhoto";
            picPhoto.Size = new Size(162, 170);
            picPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            picPhoto.TabIndex = 0;
            picPhoto.TabStop = false;

            // btnBrowsePhoto
            btnBrowsePhoto.BackColor = Color.FromArgb(2, 132, 199);
            btnBrowsePhoto.FlatAppearance.BorderSize = 0;
            btnBrowsePhoto.FlatStyle = FlatStyle.Flat;
            btnBrowsePhoto.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnBrowsePhoto.ForeColor = Color.White;
            btnBrowsePhoto.Location = new Point(16, 192);
            btnBrowsePhoto.Name = "btnBrowsePhoto";
            btnBrowsePhoto.Size = new Size(96, 46);
            btnBrowsePhoto.TabIndex = 1;
            btnBrowsePhoto.Text = "FOTO";
            btnBrowsePhoto.UseVisualStyleBackColor = false;

            // btnClearPhoto
            btnClearPhoto.BackColor = Color.FromArgb(239, 68, 68);
            btnClearPhoto.FlatAppearance.BorderSize = 0;
            btnClearPhoto.FlatStyle = FlatStyle.Flat;
            btnClearPhoto.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnClearPhoto.ForeColor = Color.White;
            btnClearPhoto.Location = new Point(118, 192);
            btnClearPhoto.Name = "btnClearPhoto";
            btnClearPhoto.Size = new Size(60, 46);
            btnClearPhoto.TabIndex = 2;
            btnClearPhoto.Text = "✕";
            btnClearPhoto.UseVisualStyleBackColor = false;

            // lblUsername
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUsername.Location = new Point(209, 16);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(163, 21);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Nombre de Usuario:";

            // txtUsername
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(209, 40);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(227, 30);
            txtUsername.TabIndex = 4;

            // lblFirstName
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblFirstName.Location = new Point(209, 88);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(77, 21);
            lblFirstName.TabIndex = 5;
            lblFirstName.Text = "Nombre:";

            // txtFirstName
            txtFirstName.BorderStyle = BorderStyle.FixedSingle;
            txtFirstName.Font = new Font("Segoe UI", 10F);
            txtFirstName.Location = new Point(209, 111);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(227, 30);
            txtFirstName.TabIndex = 6;

            // lblLastName
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblLastName.Location = new Point(209, 165);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(79, 21);
            lblLastName.TabIndex = 7;
            lblLastName.Text = "Apellido:";

            // txtLastName
            txtLastName.BorderStyle = BorderStyle.FixedSingle;
            txtLastName.Font = new Font("Segoe UI", 10F);
            txtLastName.Location = new Point(209, 190);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(227, 30);
            txtLastName.TabIndex = 8;

            // lblEmail
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEmail.Location = new Point(501, 16);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(155, 21);
            lblEmail.TabIndex = 9;
            lblEmail.Text = "Correo Electrónico:";

            // txtEmail
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(501, 40);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(239, 30);
            txtEmail.TabIndex = 10;

            // lblPassword
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPassword.Location = new Point(501, 87);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(100, 21);
            lblPassword.TabIndex = 11;
            lblPassword.Text = "Contraseña:";

            // txtPassword
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(501, 111);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(239, 30);
            txtPassword.TabIndex = 12;

            // lblRole
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblRole.Location = new Point(501, 165);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(119, 21);
            lblRole.TabIndex = 13;
            lblRole.Text = "Rol de Acceso:";

            // cboRole
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.Font = new Font("Segoe UI", 10F);
            cboRole.Location = new Point(501, 190);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(239, 31);
            cboRole.TabIndex = 14;

            // btnSave
            btnSave.BackColor = Color.FromArgb(16, 185, 129);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(789, 8);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(251, 74);
            btnSave.TabIndex = 15;
            btnSave.Text = "💾 GUARDAR USUARIO";
            btnSave.UseVisualStyleBackColor = false;

            // btnEdit
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEdit.Location = new Point(789, 88);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(251, 81);
            btnEdit.TabIndex = 16;
            btnEdit.Text = "EDITAR USUARIO";
            btnEdit.UseVisualStyleBackColor = true;

            // btnDelete
            btnDelete.BackColor = Color.FromArgb(239, 68, 68);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(789, 177);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(251, 76);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "ACTIVAR / DESACTIVAR";
            btnDelete.UseVisualStyleBackColor = false;

            // dgvUsers
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(16, 349);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.Size = new Size(1068, 367);
            dgvUsers.TabIndex = 2;

            // FormUsers
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1103, 728);
            Controls.Add(dgvUsers);
            Controls.Add(groupBoxData);
            Controls.Add(pnlHeader);
            Name = "FormUsers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Usuarios del Sistema";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            groupBoxData.ResumeLayout(false);
            groupBoxData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPhoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnExportPdf;
        private System.Windows.Forms.Panel groupBoxData;
        private System.Windows.Forms.PictureBox picPhoto;
        private System.Windows.Forms.Button btnBrowsePhoto;
        private System.Windows.Forms.Button btnClearPhoto;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvUsers;
    }
}