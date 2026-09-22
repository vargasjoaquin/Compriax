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
            picIconSaveChanges = new PictureBox();
            panelHeader = new Panel();
            labelHeaderTitle = new Label();
            panelProfileSummaryCard = new Panel();
            pictureBoxAvatar = new PictureBox();
            labelUserFullName = new Label();
            labelUserRole = new Label();
            labelUsername = new Label();
            labelUserEmail = new Label();
            panelEditProfileCard = new Panel();
            labelEditTitle = new Label();
            labelFirstName = new Label();
            textBoxFirstName = new TextBox();
            labelLastName = new Label();
            textBoxLastName = new TextBox();
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            labelCurrentPassword = new Label();
            textBoxCurrentPassword = new TextBox();
            labelNewPassword = new Label();
            textBoxNewPassword = new TextBox();
            labelConfirmPassword = new Label();
            textBoxConfirmPassword = new TextBox();
            buttonSaveChanges = new Button();
            ((System.ComponentModel.ISupportInitialize)picIconSaveChanges).BeginInit();
            panelHeader.SuspendLayout();
            panelProfileSummaryCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAvatar).BeginInit();
            panelEditProfileCard.SuspendLayout();
            SuspendLayout();
            // 
            // picIconSaveChanges
            // 
            picIconSaveChanges.BackColor = Color.FromArgb(2, 132, 199);
            picIconSaveChanges.Cursor = Cursors.Hand;
            picIconSaveChanges.Image = Resources._077_guardar;
            picIconSaveChanges.Location = new Point(153, 400);
            picIconSaveChanges.Name = "picIconSaveChanges";
            picIconSaveChanges.Size = new Size(47, 48);
            picIconSaveChanges.SizeMode = PictureBoxSizeMode.Zoom;
            picIconSaveChanges.TabIndex = 99;
            picIconSaveChanges.TabStop = false;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelHeaderTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(950, 56);
            panelHeader.TabIndex = 0;
            // 
            // labelHeaderTitle
            // 
            labelHeaderTitle.AutoSize = true;
            labelHeaderTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelHeaderTitle.ForeColor = Color.White;
            labelHeaderTitle.Location = new Point(20, 16);
            labelHeaderTitle.Name = "labelHeaderTitle";
            labelHeaderTitle.Size = new Size(253, 30);
            labelHeaderTitle.TabIndex = 0;
            labelHeaderTitle.Text = "MI PERFIL DE USUARIO";
            // 
            // panelProfileSummaryCard
            // 
            panelProfileSummaryCard.BackColor = Color.White;
            panelProfileSummaryCard.Controls.Add(pictureBoxAvatar);
            panelProfileSummaryCard.Controls.Add(labelUserFullName);
            panelProfileSummaryCard.Controls.Add(labelUserRole);
            panelProfileSummaryCard.Controls.Add(labelUsername);
            panelProfileSummaryCard.Controls.Add(labelUserEmail);
            panelProfileSummaryCard.Location = new Point(24, 76);
            panelProfileSummaryCard.Name = "panelProfileSummaryCard";
            panelProfileSummaryCard.Size = new Size(320, 480);
            panelProfileSummaryCard.TabIndex = 1;
            // 
            // pictureBoxAvatar
            // 
            pictureBoxAvatar.BackColor = Color.FromArgb(248, 250, 252);
            pictureBoxAvatar.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxAvatar.Location = new Point(60, 24);
            pictureBoxAvatar.Name = "pictureBoxAvatar";
            pictureBoxAvatar.Size = new Size(200, 200);
            pictureBoxAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxAvatar.TabIndex = 0;
            pictureBoxAvatar.TabStop = false;
            // 
            // labelUserFullName
            // 
            labelUserFullName.AutoEllipsis = true;
            labelUserFullName.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelUserFullName.Location = new Point(10, 245);
            labelUserFullName.Name = "labelUserFullName";
            labelUserFullName.Size = new Size(300, 56);
            labelUserFullName.TabIndex = 1;
            labelUserFullName.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelUserRole
            // 
            labelUserRole.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelUserRole.ForeColor = Color.FromArgb(2, 132, 199);
            labelUserRole.Location = new Point(10, 270);
            labelUserRole.Name = "labelUserRole";
            labelUserRole.Size = new Size(300, 22);
            labelUserRole.TabIndex = 2;
            labelUserRole.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelUsername
            // 
            labelUsername.Font = new Font("Segoe UI", 8.5F);
            labelUsername.ForeColor = Color.FromArgb(100, 116, 139);
            labelUsername.Location = new Point(10, 310);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(300, 20);
            labelUsername.TabIndex = 3;
            labelUsername.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelUserEmail
            // 
            labelUserEmail.Font = new Font("Segoe UI", 8.5F);
            labelUserEmail.ForeColor = Color.FromArgb(100, 116, 139);
            labelUserEmail.Location = new Point(10, 335);
            labelUserEmail.Name = "labelUserEmail";
            labelUserEmail.Size = new Size(300, 20);
            labelUserEmail.TabIndex = 4;
            labelUserEmail.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelEditProfileCard
            // 
            panelEditProfileCard.BackColor = Color.White;
            panelEditProfileCard.Controls.Add(labelEditTitle);
            panelEditProfileCard.Controls.Add(labelFirstName);
            panelEditProfileCard.Controls.Add(textBoxFirstName);
            panelEditProfileCard.Controls.Add(labelLastName);
            panelEditProfileCard.Controls.Add(textBoxLastName);
            panelEditProfileCard.Controls.Add(labelEmail);
            panelEditProfileCard.Controls.Add(textBoxEmail);
            panelEditProfileCard.Controls.Add(labelCurrentPassword);
            panelEditProfileCard.Controls.Add(textBoxCurrentPassword);
            panelEditProfileCard.Controls.Add(labelNewPassword);
            panelEditProfileCard.Controls.Add(textBoxNewPassword);
            panelEditProfileCard.Controls.Add(labelConfirmPassword);
            panelEditProfileCard.Controls.Add(textBoxConfirmPassword);
            panelEditProfileCard.Controls.Add(picIconSaveChanges);
            panelEditProfileCard.Controls.Add(buttonSaveChanges);
            panelEditProfileCard.Location = new Point(364, 76);
            panelEditProfileCard.Name = "panelEditProfileCard";
            panelEditProfileCard.Size = new Size(560, 480);
            panelEditProfileCard.TabIndex = 2;
            // 
            // labelEditTitle
            // 
            labelEditTitle.AutoSize = true;
            labelEditTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelEditTitle.Location = new Point(24, 20);
            labelEditTitle.Name = "labelEditTitle";
            labelEditTitle.Size = new Size(206, 30);
            labelEditTitle.TabIndex = 0;
            labelEditTitle.Text = "Editar Información";
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelFirstName.Location = new Point(24, 60);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(77, 21);
            labelFirstName.TabIndex = 1;
            labelFirstName.Text = "Nombre:";
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.BorderStyle = BorderStyle.FixedSingle;
            textBoxFirstName.Font = new Font("Segoe UI", 10.5F);
            textBoxFirstName.Location = new Point(24, 82);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(240, 31);
            textBoxFirstName.TabIndex = 2;
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelLastName.Location = new Point(290, 60);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(79, 21);
            labelLastName.TabIndex = 3;
            labelLastName.Text = "Apellido:";
            // 
            // textBoxLastName
            // 
            textBoxLastName.BorderStyle = BorderStyle.FixedSingle;
            textBoxLastName.Font = new Font("Segoe UI", 10.5F);
            textBoxLastName.Location = new Point(290, 82);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(240, 31);
            textBoxLastName.TabIndex = 4;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelEmail.Location = new Point(24, 130);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(155, 21);
            labelEmail.TabIndex = 5;
            labelEmail.Text = "Correo Electrónico:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxEmail.Font = new Font("Segoe UI", 10.5F);
            textBoxEmail.Location = new Point(24, 152);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(506, 31);
            textBoxEmail.TabIndex = 6;
            // 
            // labelCurrentPassword
            // 
            labelCurrentPassword.AutoSize = true;
            labelCurrentPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelCurrentPassword.Location = new Point(24, 200);
            labelCurrentPassword.Name = "labelCurrentPassword";
            labelCurrentPassword.Size = new Size(391, 21);
            labelCurrentPassword.TabIndex = 7;
            labelCurrentPassword.Text = "Contraseña Actual (requerida para cambiar clave):";
            // 
            // textBoxCurrentPassword
            // 
            textBoxCurrentPassword.BorderStyle = BorderStyle.FixedSingle;
            textBoxCurrentPassword.Font = new Font("Segoe UI", 10.5F);
            textBoxCurrentPassword.Location = new Point(24, 222);
            textBoxCurrentPassword.Name = "textBoxCurrentPassword";
            textBoxCurrentPassword.PasswordChar = '●';
            textBoxCurrentPassword.Size = new Size(506, 31);
            textBoxCurrentPassword.TabIndex = 8;
            // 
            // labelNewPassword
            // 
            labelNewPassword.AutoSize = true;
            labelNewPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelNewPassword.Location = new Point(24, 270);
            labelNewPassword.Name = "labelNewPassword";
            labelNewPassword.Size = new Size(154, 21);
            labelNewPassword.TabIndex = 9;
            labelNewPassword.Text = "Nueva Contraseña:";
            // 
            // textBoxNewPassword
            // 
            textBoxNewPassword.BorderStyle = BorderStyle.FixedSingle;
            textBoxNewPassword.Font = new Font("Segoe UI", 10.5F);
            textBoxNewPassword.Location = new Point(24, 292);
            textBoxNewPassword.Name = "textBoxNewPassword";
            textBoxNewPassword.PasswordChar = '●';
            textBoxNewPassword.Size = new Size(240, 31);
            textBoxNewPassword.TabIndex = 10;
            // 
            // labelConfirmPassword
            // 
            labelConfirmPassword.AutoSize = true;
            labelConfirmPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelConfirmPassword.Location = new Point(290, 270);
            labelConfirmPassword.Name = "labelConfirmPassword";
            labelConfirmPassword.Size = new Size(235, 21);
            labelConfirmPassword.TabIndex = 11;
            labelConfirmPassword.Text = "Confirmar Nueva Contraseña:";
            // 
            // textBoxConfirmPassword
            // 
            textBoxConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            textBoxConfirmPassword.Font = new Font("Segoe UI", 10.5F);
            textBoxConfirmPassword.Location = new Point(290, 292);
            textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            textBoxConfirmPassword.PasswordChar = '●';
            textBoxConfirmPassword.Size = new Size(240, 31);
            textBoxConfirmPassword.TabIndex = 12;
            // 
            // buttonSaveChanges
            // 
            buttonSaveChanges.BackColor = Color.FromArgb(2, 132, 199);
            buttonSaveChanges.FlatAppearance.BorderSize = 0;
            buttonSaveChanges.FlatStyle = FlatStyle.Flat;
            buttonSaveChanges.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonSaveChanges.ForeColor = Color.White;
            buttonSaveChanges.Location = new Point(24, 400);
            buttonSaveChanges.Name = "buttonSaveChanges";
            buttonSaveChanges.Size = new Size(506, 48);
            buttonSaveChanges.TabIndex = 13;
            buttonSaveChanges.Text = "GUARDAR CAMBIOS";
            buttonSaveChanges.UseVisualStyleBackColor = false;
            // 
            // FormUserProfile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(950, 580);
            Controls.Add(panelEditProfileCard);
            Controls.Add(panelProfileSummaryCard);
            Controls.Add(panelHeader);
            Name = "FormUserProfile";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mi Perfil";
            ((System.ComponentModel.ISupportInitialize)picIconSaveChanges).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelProfileSummaryCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxAvatar).EndInit();
            panelEditProfileCard.ResumeLayout(false);
            panelEditProfileCard.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelHeader, panelProfileSummaryCard, panelEditProfileCard;
        private System.Windows.Forms.Label labelHeaderTitle, labelUserFullName, labelUserRole, labelUsername, labelUserEmail, labelEditTitle;
        private System.Windows.Forms.Label labelFirstName, labelLastName, labelEmail, labelCurrentPassword, labelNewPassword, labelConfirmPassword;
        private System.Windows.Forms.TextBox textBoxFirstName, textBoxLastName, textBoxEmail, textBoxNewPassword, textBoxConfirmPassword, textBoxCurrentPassword;
        private System.Windows.Forms.PictureBox pictureBoxAvatar;
        private System.Windows.Forms.Button buttonSaveChanges;
        private System.Windows.Forms.PictureBox picIconSaveChanges;
    }
}
