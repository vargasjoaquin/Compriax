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
            labelBrandTitle = new Label();
            labelSubtitle = new Label();
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
            SuspendLayout();
            // 
            // picIconLogin
            // 
            picIconLogin.BackColor = Color.FromArgb(2, 132, 199);
            picIconLogin.Cursor = Cursors.Hand;
            picIconLogin.Image = Resources._096_bloqueo_cierre;
            picIconLogin.Location = new Point(120, 285);
            picIconLogin.Name = "picIconLogin";
            picIconLogin.Size = new Size(39, 48);
            picIconLogin.SizeMode = PictureBoxSizeMode.Zoom;
            picIconLogin.TabIndex = 99;
            picIconLogin.TabStop = false;
            // 
            // panelLoginCard
            // 
            panelLoginCard.BackColor = Color.White;
            panelLoginCard.Controls.Add(labelBrandTitle);
            panelLoginCard.Controls.Add(labelSubtitle);
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
            // labelBrandTitle
            // 
            labelBrandTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelBrandTitle.ForeColor = Color.FromArgb(2, 132, 199);
            labelBrandTitle.Location = new Point(20, 25);
            labelBrandTitle.Name = "labelBrandTitle";
            labelBrandTitle.Size = new Size(360, 35);
            labelBrandTitle.TabIndex = 0;
            labelBrandTitle.Text = "COMPRIAX SYSTEM";
            labelBrandTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelSubtitle
            // 
            labelSubtitle.Font = new Font("Segoe UI", 8.5F);
            labelSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            labelSubtitle.Location = new Point(20, 60);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new Size(360, 20);
            labelSubtitle.TabIndex = 1;
            labelSubtitle.Text = "Punto de Venta y Gestión de Supermercado";
            labelSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelUsername.ForeColor = Color.FromArgb(15, 23, 42);
            labelUsername.Location = new Point(30, 100);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(73, 21);
            labelUsername.TabIndex = 2;
            labelUsername.Text = "Usuario:";
            // 
            // textBoxUsername
            // 
            textBoxUsername.BorderStyle = BorderStyle.FixedSingle;
            textBoxUsername.Font = new Font("Segoe UI", 11F);
            textBoxUsername.Location = new Point(30, 125);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(340, 32);
            textBoxUsername.TabIndex = 3;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelPassword.ForeColor = Color.FromArgb(15, 23, 42);
            labelPassword.Location = new Point(30, 175);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(100, 21);
            labelPassword.TabIndex = 4;
            labelPassword.Text = "Contraseña:";
            // 
            // textBoxPassword
            // 
            textBoxPassword.BorderStyle = BorderStyle.FixedSingle;
            textBoxPassword.Font = new Font("Segoe UI", 11F);
            textBoxPassword.Location = new Point(30, 200);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '●';
            textBoxPassword.Size = new Size(340, 32);
            textBoxPassword.TabIndex = 5;
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = Color.FromArgb(2, 132, 199);
            buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonLogin.ForeColor = Color.White;
            buttonLogin.Location = new Point(30, 285);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(340, 48);
            buttonLogin.TabIndex = 7;
            buttonLogin.Text = "INGRESAR";
            buttonLogin.UseVisualStyleBackColor = false;
            // 
            // linkLabelForgotPassword
            // 
            linkLabelForgotPassword.Font = new Font("Segoe UI", 8.5F);
            linkLabelForgotPassword.LinkColor = Color.FromArgb(2, 132, 199);
            linkLabelForgotPassword.Location = new Point(30, 350);
            linkLabelForgotPassword.Name = "linkLabelForgotPassword";
            linkLabelForgotPassword.Size = new Size(340, 25);
            linkLabelForgotPassword.TabIndex = 8;
            linkLabelForgotPassword.TabStop = true;
            linkLabelForgotPassword.Text = "¿Olvidó su contraseña?";
            linkLabelForgotPassword.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelErrorMessage
            // 
            labelErrorMessage.Font = new Font("Segoe UI", 8.5F);
            labelErrorMessage.ForeColor = Color.FromArgb(239, 68, 68);
            labelErrorMessage.Location = new Point(30, 240);
            labelErrorMessage.Name = "labelErrorMessage";
            labelErrorMessage.Size = new Size(340, 35);
            labelErrorMessage.TabIndex = 6;
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
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelLoginCard;
        private System.Windows.Forms.Label labelBrandTitle;
        private System.Windows.Forms.Label labelSubtitle;
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
