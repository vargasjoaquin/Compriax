namespace CompriaxSystem.WinFormsUI
{
    partial class FormLogin
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
            picIconLogin = new PictureBox();
            panelLoginCard = new Panel();
            pictureBoxLogo = new PictureBox();
            labelUsername = new Label();
            textBoxUsername = new TextBox();
            labelPassword = new Label();
            textBoxPassword = new TextBox();
            buttonLogin = new Button();
            linkLabelForgotPassword = new LinkLabel();
            labelErrorMessage = new Label();
            buttonCloseApplication = new Button();
            ((System.ComponentModel.ISupportInitialize)picIconLogin).BeginInit();
            panelLoginCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // picIconLogin
            // 
            picIconLogin.BackColor = Color.FromArgb(2, 132, 199);
            picIconLogin.Cursor = Cursors.Hand;
            picIconLogin.Image = Resources._096_bloqueo_cierre;
            picIconLogin.Location = new Point(116, 332);
            picIconLogin.Name = "picIconLogin";
            picIconLogin.Size = new Size(42, 48);
            picIconLogin.SizeMode = PictureBoxSizeMode.Zoom;
            picIconLogin.TabIndex = 99;
            picIconLogin.TabStop = false;
            // 
            // panelLoginCard
            // 
            panelLoginCard.BackColor = Color.White;
            panelLoginCard.Controls.Add(pictureBoxLogo);
            panelLoginCard.Controls.Add(labelUsername);
            panelLoginCard.Controls.Add(textBoxUsername);
            panelLoginCard.Controls.Add(labelPassword);
            panelLoginCard.Controls.Add(textBoxPassword);
            panelLoginCard.Controls.Add(picIconLogin);
            panelLoginCard.Controls.Add(buttonLogin);
            panelLoginCard.Controls.Add(linkLabelForgotPassword);
            panelLoginCard.Controls.Add(labelErrorMessage);
            panelLoginCard.Location = new Point(30, 40);
            panelLoginCard.Name = "panelLoginCard";
            panelLoginCard.Size = new Size(400, 460);
            panelLoginCard.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = Color.Transparent;
            pictureBoxLogo.Image = Resources.logo_compriax;
            pictureBoxLogo.Location = new Point(30, 15);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(340, 123);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelUsername.ForeColor = Color.FromArgb(15, 23, 42);
            labelUsername.Location = new Point(30, 152);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(73, 21);
            labelUsername.TabIndex = 1;
            labelUsername.Text = "Usuario:";
            // 
            // textBoxUsername
            // 
            textBoxUsername.BorderStyle = BorderStyle.FixedSingle;
            textBoxUsername.Font = new Font("Segoe UI", 11F);
            textBoxUsername.Location = new Point(30, 177);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(340, 32);
            textBoxUsername.TabIndex = 2;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelPassword.ForeColor = Color.FromArgb(15, 23, 42);
            labelPassword.Location = new Point(30, 222);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(100, 21);
            labelPassword.TabIndex = 3;
            labelPassword.Text = "Contraseña:";
            // 
            // textBoxPassword
            // 
            textBoxPassword.BorderStyle = BorderStyle.FixedSingle;
            textBoxPassword.Font = new Font("Segoe UI", 11F);
            textBoxPassword.Location = new Point(30, 247);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '●';
            textBoxPassword.Size = new Size(340, 32);
            textBoxPassword.TabIndex = 4;
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = Color.FromArgb(2, 132, 199);
            buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonLogin.ForeColor = Color.White;
            buttonLogin.Location = new Point(30, 332);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(340, 48);
            buttonLogin.TabIndex = 6;
            buttonLogin.Text = "INGRESAR";
            buttonLogin.UseVisualStyleBackColor = false;
            // 
            // linkLabelForgotPassword
            // 
            linkLabelForgotPassword.Font = new Font("Segoe UI", 8.5F);
            linkLabelForgotPassword.LinkColor = Color.FromArgb(2, 132, 199);
            linkLabelForgotPassword.Location = new Point(30, 397);
            linkLabelForgotPassword.Name = "linkLabelForgotPassword";
            linkLabelForgotPassword.Size = new Size(340, 25);
            linkLabelForgotPassword.TabIndex = 7;
            linkLabelForgotPassword.TabStop = true;
            linkLabelForgotPassword.Text = "¿Olvidó su contraseña?";
            linkLabelForgotPassword.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelErrorMessage
            // 
            labelErrorMessage.Font = new Font("Segoe UI", 8.5F);
            labelErrorMessage.ForeColor = Color.FromArgb(239, 68, 68);
            labelErrorMessage.Location = new Point(30, 287);
            labelErrorMessage.Name = "labelErrorMessage";
            labelErrorMessage.Size = new Size(340, 35);
            labelErrorMessage.TabIndex = 5;
            labelErrorMessage.Visible = false;
            // 
            // buttonCloseApplication
            // 
            buttonCloseApplication.Cursor = Cursors.Hand;
            buttonCloseApplication.FlatAppearance.BorderSize = 0;
            buttonCloseApplication.FlatStyle = FlatStyle.Flat;
            buttonCloseApplication.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonCloseApplication.ForeColor = Color.White;
            buttonCloseApplication.Location = new Point(420, 8);
            buttonCloseApplication.Name = "buttonCloseApplication";
            buttonCloseApplication.Size = new Size(32, 28);
            buttonCloseApplication.TabIndex = 1;
            buttonCloseApplication.Text = "✕";
            buttonCloseApplication.UseVisualStyleBackColor = true;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            ClientSize = new Size(460, 540);
            Controls.Add(buttonCloseApplication);
            Controls.Add(panelLoginCard);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Iniciar Sesión";
            ((System.ComponentModel.ISupportInitialize)picIconLogin).EndInit();
            panelLoginCard.ResumeLayout(false);
            panelLoginCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelLoginCard;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonCloseApplication;
        private System.Windows.Forms.LinkLabel linkLabelForgotPassword;
        private System.Windows.Forms.Label labelErrorMessage;
        private System.Windows.Forms.PictureBox picIconLogin;
    }
}
