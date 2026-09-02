namespace CompriaxSystem.WinFormsUI
{
    partial class FormRecoverPassword
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
            pnlCard = new Panel();
            lblHeaderIcon = new Label();
            lblMainTitle = new Label();
            lblInstruct = new Label();
            txtIdentity = new TextBox();
            btnSend = new Button();
            btnCancel = new Button();
            lblResult = new Label();
            btnCloseX = new Button();
            pnlCard.SuspendLayout();
            SuspendLayout();

            // pnlCard
            pnlCard.BackColor = Color.White;
            pnlCard.Controls.Add(lblHeaderIcon);
            pnlCard.Controls.Add(lblMainTitle);
            pnlCard.Controls.Add(lblInstruct);
            pnlCard.Controls.Add(txtIdentity);
            pnlCard.Controls.Add(btnSend);
            pnlCard.Controls.Add(btnCancel);
            pnlCard.Controls.Add(lblResult);
            pnlCard.Location = new Point(24, 32);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(432, 360);
            pnlCard.TabIndex = 1;

            // lblHeaderIcon
            lblHeaderIcon.Font = new Font("Segoe UI", 24F);
            lblHeaderIcon.Location = new Point(20, 15);
            lblHeaderIcon.Name = "lblHeaderIcon";
            lblHeaderIcon.Size = new Size(392, 45);
            lblHeaderIcon.TabIndex = 0;
            lblHeaderIcon.Text = "🔐";
            lblHeaderIcon.TextAlign = ContentAlignment.MiddleCenter;

            // lblMainTitle
            lblMainTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblMainTitle.ForeColor = Color.FromArgb(2, 132, 199);
            lblMainTitle.Location = new Point(20, 65);
            lblMainTitle.Name = "lblMainTitle";
            lblMainTitle.Size = new Size(392, 25);
            lblMainTitle.TabIndex = 1;
            lblMainTitle.Text = "RECUPERAR CONTRASEÑA";
            lblMainTitle.TextAlign = ContentAlignment.MiddleCenter;

            // lblInstruct
            lblInstruct.Font = new Font("Segoe UI", 9.5F);
            lblInstruct.ForeColor = Color.FromArgb(100, 116, 139);
            lblInstruct.Location = new Point(24, 100);
            lblInstruct.Name = "lblInstruct";
            lblInstruct.Size = new Size(384, 38);
            lblInstruct.TabIndex = 2;
            lblInstruct.Text = "Ingrese su nombre de usuario o correo electrónico registrado:";

            // txtIdentity
            txtIdentity.Font = new Font("Segoe UI", 11F);
            txtIdentity.Location = new Point(24, 142);
            txtIdentity.Name = "txtIdentity";
            txtIdentity.PlaceholderText = "Usuario o email...";
            txtIdentity.Size = new Size(384, 32);
            txtIdentity.TabIndex = 3;

            // btnSend
            btnSend.BackColor = Color.FromArgb(2, 132, 199);
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(24, 190);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(384, 44);
            btnSend.TabIndex = 4;
            btnSend.Text = "ENVIAR";
            btnSend.UseVisualStyleBackColor = false;

            // btnCancel
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(24, 242);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(384, 36);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "VOLVER";

            // lblResult
            lblResult.Font = new Font("Segoe UI", 8.5F);
            lblResult.ForeColor = Color.FromArgb(16, 185, 129);
            lblResult.Location = new Point(24, 290);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(384, 55);
            lblResult.TabIndex = 6;
            lblResult.TextAlign = ContentAlignment.MiddleCenter;

            // btnCloseX
            btnCloseX.Cursor = Cursors.Hand;
            btnCloseX.FlatAppearance.BorderSize = 0;
            btnCloseX.FlatStyle = FlatStyle.Flat;
            btnCloseX.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCloseX.ForeColor = Color.White;
            btnCloseX.Location = new Point(440, 4);
            btnCloseX.Name = "btnCloseX";
            btnCloseX.Size = new Size(32, 28);
            btnCloseX.TabIndex = 0;
            btnCloseX.Text = "✕";

            // Form Properties
            BackColor = Color.FromArgb(15, 23, 42);
            ClientSize = new Size(480, 420);
            Controls.Add(btnCloseX);
            Controls.Add(pnlCard);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormRecoverPassword";
            StartPosition = FormStartPosition.CenterParent;
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblHeaderIcon, lblMainTitle, lblInstruct, lblResult;
        private System.Windows.Forms.TextBox txtIdentity;
        private System.Windows.Forms.Button btnSend, btnCancel, btnCloseX;
    }
}