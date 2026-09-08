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
            pnlCard = new Panel();
            lblBrand = new Label();
            lblSubTitle = new Label();
            lblUser = new Label();
            txtUsuario = new TextBox();
            lblPass = new Label();
            txtPass = new TextBox();
            btnLogin = new Button();
            linkPass = new LinkLabel();
            lblErrorMessage = new Label();
            btnClose = new Button();
            pnlCard.SuspendLayout();
            SuspendLayout();

            // pnlCard
            pnlCard.BackColor = Color.White;
            pnlCard.Controls.Add(lblBrand);
            pnlCard.Controls.Add(lblSubTitle);
            pnlCard.Controls.Add(lblUser);
            pnlCard.Controls.Add(txtUsuario);
            pnlCard.Controls.Add(lblPass);
            pnlCard.Controls.Add(txtPass);
            pnlCard.Controls.Add(btnLogin);
            pnlCard.Controls.Add(linkPass);
            pnlCard.Controls.Add(lblErrorMessage);
            pnlCard.Location = new Point(30, 40);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(400, 460);
            pnlCard.TabIndex = 0;

            // lblBrand
            lblBrand.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblBrand.ForeColor = Color.FromArgb(2, 132, 199);
            lblBrand.Location = new Point(20, 25);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(360, 35);
            lblBrand.TabIndex = 0;
            lblBrand.Text = "COMPRIAX SYSTEM";
            lblBrand.TextAlign = ContentAlignment.MiddleCenter;

            // lblSubTitle
            lblSubTitle.Font = new Font("Segoe UI", 8.5F);
            lblSubTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubTitle.Location = new Point(20, 60);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(360, 20);
            lblSubTitle.TabIndex = 1;
            lblSubTitle.Text = "Punto de Venta y Gestión de Supermercado";
            lblSubTitle.TextAlign = ContentAlignment.MiddleCenter;

            // lblUser
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUser.ForeColor = Color.FromArgb(15, 23, 42);
            lblUser.Location = new Point(30, 100);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(73, 21);
            lblUser.TabIndex = 2;
            lblUser.Text = "Usuario:";

            // txtUsuario
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Font = new Font("Segoe UI", 11F);
            txtUsuario.Location = new Point(30, 125);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(340, 32);
            txtUsuario.TabIndex = 3;

            // lblPass
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPass.ForeColor = Color.FromArgb(15, 23, 42);
            lblPass.Location = new Point(30, 175);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(100, 21);
            lblPass.TabIndex = 4;
            lblPass.Text = "Contraseña:";

            // txtPass
            txtPass.BorderStyle = BorderStyle.FixedSingle;
            txtPass.Font = new Font("Segoe UI", 11F);
            txtPass.Location = new Point(30, 200);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '●';
            txtPass.Size = new Size(340, 32);
            txtPass.TabIndex = 5;

            // btnLogin
            btnLogin.BackColor = Color.FromArgb(2, 132, 199);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(30, 285);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(340, 48);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "INGRESAR";
            btnLogin.UseVisualStyleBackColor = false;

            // linkPass
            linkPass.Font = new Font("Segoe UI", 8.5F);
            linkPass.LinkColor = Color.FromArgb(2, 132, 199);
            linkPass.Location = new Point(30, 350);
            linkPass.Name = "linkPass";
            linkPass.Size = new Size(340, 25);
            linkPass.TabIndex = 8;
            linkPass.TabStop = true;
            linkPass.Text = "¿Olvidó su contraseña?";
            linkPass.TextAlign = ContentAlignment.MiddleCenter;

            // lblErrorMessage
            lblErrorMessage.Font = new Font("Segoe UI", 8.5F);
            lblErrorMessage.ForeColor = Color.FromArgb(239, 68, 68);
            lblErrorMessage.Location = new Point(30, 240);
            lblErrorMessage.Name = "lblErrorMessage";
            lblErrorMessage.Size = new Size(340, 35);
            lblErrorMessage.TabIndex = 6;
            lblErrorMessage.Visible = false;

            // btnClose
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(420, 8);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(32, 28);
            btnClose.TabIndex = 1;
            btnClose.Text = "✕";
            btnClose.UseVisualStyleBackColor = true;

            // FormLogin
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            ClientSize = new Size(460, 540);
            Controls.Add(btnClose);
            Controls.Add(pnlCard);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Iniciar Sesión";
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel linkPass;
        private System.Windows.Forms.Label lblErrorMessage;
    }
}