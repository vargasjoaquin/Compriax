namespace CompriaxSystem.WinFormsUI
{
    partial class FormUserProfile
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

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblHeaderTitle = new Label();
            pnlLeftCard = new Panel();
            picAvatar = new PictureBox();
            lblNameVal = new Label();
            lblRoleVal = new Label();
            lblUserVal = new Label();
            lblEmailVal = new Label();
            pnlRightCard = new Panel();
            lblEditTitle = new Label();
            lblFirstName = new Label();
            txtEditFirstName = new TextBox();
            lblLastName = new Label();
            txtEditLastName = new TextBox();
            lblEmail = new Label();
            txtEditEmail = new TextBox();
            lblCurrentPass = new Label();
            txtEditCurrentPass = new TextBox();
            lblNewPass = new Label();
            txtEditPassword = new TextBox();
            lblConfirmPass = new Label();
            txtEditConfirmPass = new TextBox();
            btnSave = new Button();
            pnlHeader.SuspendLayout();
            pnlLeftCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            pnlRightCard.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(15, 23, 42);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(950, 56);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(20, 16);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(290, 30);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "👤 MI PERFIL DE USUARIO";
            // 
            // pnlLeftCard
            // 
            pnlLeftCard.BackColor = Color.White;
            pnlLeftCard.Controls.Add(picAvatar);
            pnlLeftCard.Controls.Add(lblNameVal);
            pnlLeftCard.Controls.Add(lblRoleVal);
            pnlLeftCard.Controls.Add(lblUserVal);
            pnlLeftCard.Controls.Add(lblEmailVal);
            pnlLeftCard.Location = new Point(24, 76);
            pnlLeftCard.Name = "pnlLeftCard";
            pnlLeftCard.Size = new Size(320, 480);
            pnlLeftCard.TabIndex = 1;
            // 
            // picAvatar
            // 
            picAvatar.BackColor = Color.FromArgb(248, 250, 252);
            picAvatar.BorderStyle = BorderStyle.FixedSingle;
            picAvatar.Location = new Point(60, 24);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(200, 200);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;
            // 
            // lblNameVal
            // 
            lblNameVal.AutoEllipsis = true;
            lblNameVal.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblNameVal.Location = new Point(10, 245);
            lblNameVal.Name = "lblNameVal";
            lblNameVal.Size = new Size(300, 56);
            lblNameVal.TabIndex = 1;
            lblNameVal.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblRoleVal
            // 
            lblRoleVal.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblRoleVal.ForeColor = Color.FromArgb(2, 132, 199);
            lblRoleVal.Location = new Point(10, 270);
            lblRoleVal.Name = "lblRoleVal";
            lblRoleVal.Size = new Size(300, 22);
            lblRoleVal.TabIndex = 2;
            lblRoleVal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUserVal
            // 
            lblUserVal.Font = new Font("Segoe UI", 8.5F);
            lblUserVal.ForeColor = Color.FromArgb(100, 116, 139);
            lblUserVal.Location = new Point(10, 310);
            lblUserVal.Name = "lblUserVal";
            lblUserVal.Size = new Size(300, 20);
            lblUserVal.TabIndex = 3;
            lblUserVal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEmailVal
            // 
            lblEmailVal.Font = new Font("Segoe UI", 8.5F);
            lblEmailVal.ForeColor = Color.FromArgb(100, 116, 139);
            lblEmailVal.Location = new Point(10, 335);
            lblEmailVal.Name = "lblEmailVal";
            lblEmailVal.Size = new Size(300, 20);
            lblEmailVal.TabIndex = 4;
            lblEmailVal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRightCard
            // 
            pnlRightCard.BackColor = Color.White;
            pnlRightCard.Controls.Add(lblEditTitle);
            pnlRightCard.Controls.Add(lblFirstName);
            pnlRightCard.Controls.Add(txtEditFirstName);
            pnlRightCard.Controls.Add(lblLastName);
            pnlRightCard.Controls.Add(txtEditLastName);
            pnlRightCard.Controls.Add(lblEmail);
            pnlRightCard.Controls.Add(txtEditEmail);
            pnlRightCard.Controls.Add(lblCurrentPass);
            pnlRightCard.Controls.Add(txtEditCurrentPass);
            pnlRightCard.Controls.Add(lblNewPass);
            pnlRightCard.Controls.Add(txtEditPassword);
            pnlRightCard.Controls.Add(lblConfirmPass);
            pnlRightCard.Controls.Add(txtEditConfirmPass);
            pnlRightCard.Controls.Add(btnSave);
            pnlRightCard.Location = new Point(364, 76);
            pnlRightCard.Name = "pnlRightCard";
            pnlRightCard.Size = new Size(560, 480);
            pnlRightCard.TabIndex = 2;
            // 
            // lblEditTitle
            // 
            lblEditTitle.AutoSize = true;
            lblEditTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblEditTitle.Location = new Point(24, 20);
            lblEditTitle.Name = "lblEditTitle";
            lblEditTitle.Size = new Size(347, 30);
            lblEditTitle.TabIndex = 0;
            lblEditTitle.Text = "Editar Información y Contraseña";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblFirstName.Location = new Point(24, 60);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(77, 21);
            lblFirstName.TabIndex = 1;
            lblFirstName.Text = "Nombre:";
            // 
            // txtEditFirstName
            // 
            txtEditFirstName.BorderStyle = BorderStyle.FixedSingle;
            txtEditFirstName.Font = new Font("Segoe UI", 10.5F);
            txtEditFirstName.Location = new Point(24, 82);
            txtEditFirstName.Name = "txtEditFirstName";
            txtEditFirstName.Size = new Size(240, 31);
            txtEditFirstName.TabIndex = 2;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblLastName.Location = new Point(290, 60);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(79, 21);
            lblLastName.TabIndex = 3;
            lblLastName.Text = "Apellido:";
            // 
            // txtEditLastName
            // 
            txtEditLastName.BorderStyle = BorderStyle.FixedSingle;
            txtEditLastName.Font = new Font("Segoe UI", 10.5F);
            txtEditLastName.Location = new Point(290, 82);
            txtEditLastName.Name = "txtEditLastName";
            txtEditLastName.Size = new Size(240, 31);
            txtEditLastName.TabIndex = 4;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEmail.Location = new Point(24, 130);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(155, 21);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Correo Electrónico:";
            // 
            // txtEditEmail
            // 
            txtEditEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEditEmail.Font = new Font("Segoe UI", 10.5F);
            txtEditEmail.Location = new Point(24, 152);
            txtEditEmail.Name = "txtEditEmail";
            txtEditEmail.Size = new Size(506, 31);
            txtEditEmail.TabIndex = 6;
            // 
            // lblCurrentPass
            // 
            lblCurrentPass.AutoSize = true;
            lblCurrentPass.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCurrentPass.Location = new Point(24, 200);
            lblCurrentPass.Name = "lblCurrentPass";
            lblCurrentPass.Size = new Size(391, 21);
            lblCurrentPass.TabIndex = 7;
            lblCurrentPass.Text = "Contraseña Actual (requerida para cambiar clave):";
            // 
            // txtEditCurrentPass
            // 
            txtEditCurrentPass.BorderStyle = BorderStyle.FixedSingle;
            txtEditCurrentPass.Font = new Font("Segoe UI", 10.5F);
            txtEditCurrentPass.Location = new Point(24, 222);
            txtEditCurrentPass.Name = "txtEditCurrentPass";
            txtEditCurrentPass.PasswordChar = '●';
            txtEditCurrentPass.Size = new Size(506, 31);
            txtEditCurrentPass.TabIndex = 8;
            // 
            // lblNewPass
            // 
            lblNewPass.AutoSize = true;
            lblNewPass.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNewPass.Location = new Point(24, 270);
            lblNewPass.Name = "lblNewPass";
            lblNewPass.Size = new Size(154, 21);
            lblNewPass.TabIndex = 9;
            lblNewPass.Text = "Nueva Contraseña:";
            // 
            // txtEditPassword
            // 
            txtEditPassword.BorderStyle = BorderStyle.FixedSingle;
            txtEditPassword.Font = new Font("Segoe UI", 10.5F);
            txtEditPassword.Location = new Point(24, 292);
            txtEditPassword.Name = "txtEditPassword";
            txtEditPassword.PasswordChar = '●';
            txtEditPassword.Size = new Size(240, 31);
            txtEditPassword.TabIndex = 10;
            // 
            // lblConfirmPass
            // 
            lblConfirmPass.AutoSize = true;
            lblConfirmPass.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblConfirmPass.Location = new Point(290, 270);
            lblConfirmPass.Name = "lblConfirmPass";
            lblConfirmPass.Size = new Size(235, 21);
            lblConfirmPass.TabIndex = 11;
            lblConfirmPass.Text = "Confirmar Nueva Contraseña:";
            // 
            // txtEditConfirmPass
            // 
            txtEditConfirmPass.BorderStyle = BorderStyle.FixedSingle;
            txtEditConfirmPass.Font = new Font("Segoe UI", 10.5F);
            txtEditConfirmPass.Location = new Point(290, 292);
            txtEditConfirmPass.Name = "txtEditConfirmPass";
            txtEditConfirmPass.PasswordChar = '●';
            txtEditConfirmPass.Size = new Size(240, 31);
            txtEditConfirmPass.TabIndex = 12;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(2, 132, 199);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(24, 400);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(506, 48);
            btnSave.TabIndex = 13;
            btnSave.Text = "💾 GUARDAR CAMBIOS";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // FormUserProfile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(950, 580);
            Controls.Add(pnlRightCard);
            Controls.Add(pnlLeftCard);
            Controls.Add(pnlHeader);
            Name = "FormUserProfile";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mi Perfil";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlLeftCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            pnlRightCard.ResumeLayout(false);
            pnlRightCard.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader, pnlLeftCard, pnlRightCard;
        private System.Windows.Forms.Label lblHeaderTitle, lblNameVal, lblRoleVal, lblUserVal, lblEmailVal, lblEditTitle;
        private System.Windows.Forms.Label lblFirstName, lblLastName, lblEmail, lblCurrentPass, lblNewPass, lblConfirmPass;
        private System.Windows.Forms.TextBox txtEditFirstName, txtEditLastName, txtEditEmail, txtEditPassword, txtEditConfirmPass, txtEditCurrentPass;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Button btnSave;
    }
}