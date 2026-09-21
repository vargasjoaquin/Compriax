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
            this.picIconSendRecovery = new System.Windows.Forms.PictureBox();
            this.picIconCancel = new System.Windows.Forms.PictureBox();
            panelCard = new Panel();
            labelHeaderIcon = new Label();
            labelMainTitle = new Label();
            labelInstructions = new Label();
            textBoxIdentity = new TextBox();
            // 
            // picIconSendRecovery
            // 
            this.picIconSendRecovery.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconSendRecovery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSendRecovery.Image = global::CompriaxSystem.WinFormsUI.Resources._083_enviar_mensaje;
            this.picIconSendRecovery.Location = new System.Drawing.Point(36, 202);
            this.picIconSendRecovery.Name = "picIconSendRecovery";
            this.picIconSendRecovery.Size = new System.Drawing.Size(20, 20);
            this.picIconSendRecovery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSendRecovery.TabIndex = 99;
            this.picIconSendRecovery.TabStop = false;

            // 
            // picIconCancel
            // 
            this.picIconCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCancel.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCancel.Location = new System.Drawing.Point(36, 250);
            this.picIconCancel.Name = "picIconCancel";
            this.picIconCancel.Size = new System.Drawing.Size(18, 18);
            this.picIconCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCancel.TabIndex = 99;
            this.picIconCancel.TabStop = false;
            buttonSendRecovery = new Button();
            buttonCancel = new Button();
            labelResultStatus = new Label();
            buttonCloseDialog = new Button();
            panelCard.SuspendLayout();
            SuspendLayout();

            // panelCard
            panelCard.BackColor = Color.White;
            panelCard.Controls.Add(labelHeaderIcon);
            panelCard.Controls.Add(labelMainTitle);
            panelCard.Controls.Add(labelInstructions);
            panelCard.Controls.Add(textBoxIdentity);
panelCard.Controls.Add(this.picIconSendRecovery);
            panelCard.Controls.Add(buttonSendRecovery);
panelCard.Controls.Add(this.picIconCancel);
            panelCard.Controls.Add(buttonCancel);
            panelCard.Controls.Add(labelResultStatus);
            panelCard.Location = new Point(24, 32);
            panelCard.Name = "panelCard";
            panelCard.Size = new Size(432, 360);
            panelCard.TabIndex = 1;

            // labelHeaderIcon
            labelHeaderIcon.Font = new Font("Segoe UI", 24F);
            labelHeaderIcon.Location = new Point(20, 15);
            labelHeaderIcon.Name = "labelHeaderIcon";
            labelHeaderIcon.Size = new Size(392, 45);
            labelHeaderIcon.TabIndex = 0;
            labelHeaderIcon.Text = "";
            labelHeaderIcon.TextAlign = ContentAlignment.MiddleCenter;

            // labelMainTitle
            labelMainTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelMainTitle.ForeColor = Color.FromArgb(2, 132, 199);
            labelMainTitle.Location = new Point(20, 65);
            labelMainTitle.Name = "labelMainTitle";
            labelMainTitle.Size = new Size(392, 25);
            labelMainTitle.TabIndex = 1;
            labelMainTitle.Text = "RECUPERAR CONTRASEÑA";
            labelMainTitle.TextAlign = ContentAlignment.MiddleCenter;

            // labelInstructions
            labelInstructions.Font = new Font("Segoe UI", 9.5F);
            labelInstructions.ForeColor = Color.FromArgb(100, 116, 139);
            labelInstructions.Location = new Point(24, 100);
            labelInstructions.Name = "labelInstructions";
            labelInstructions.Size = new Size(384, 38);
            labelInstructions.TabIndex = 2;
            labelInstructions.Text = "Ingrese su nombre de usuario o correo electrónico registrado:";

            // textBoxIdentity
            textBoxIdentity.Font = new Font("Segoe UI", 11F);
            textBoxIdentity.Location = new Point(24, 142);
            textBoxIdentity.Name = "textBoxIdentity";
            textBoxIdentity.PlaceholderText = "Usuario o email...";
            textBoxIdentity.Size = new Size(384, 32);
            textBoxIdentity.TabIndex = 3;
            // 
            // picIconSendRecovery
            // 
            this.picIconSendRecovery.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconSendRecovery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSendRecovery.Image = global::CompriaxSystem.WinFormsUI.Resources._083_enviar_mensaje;
            this.picIconSendRecovery.Location = new System.Drawing.Point(36, 202);
            this.picIconSendRecovery.Name = "picIconSendRecovery";
            this.picIconSendRecovery.Size = new System.Drawing.Size(20, 20);
            this.picIconSendRecovery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSendRecovery.TabIndex = 99;
            this.picIconSendRecovery.TabStop = false;

            // 
            // picIconCancel
            // 
            this.picIconCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCancel.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCancel.Location = new System.Drawing.Point(36, 250);
            this.picIconCancel.Name = "picIconCancel";
            this.picIconCancel.Size = new System.Drawing.Size(18, 18);
            this.picIconCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCancel.TabIndex = 99;
            this.picIconCancel.TabStop = false;

            // buttonSendRecovery
            // 
            // picIconSendRecovery
            // 
            this.picIconSendRecovery.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconSendRecovery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSendRecovery.Image = global::CompriaxSystem.WinFormsUI.Resources._083_enviar_mensaje;
            this.picIconSendRecovery.Location = new System.Drawing.Point(36, 202);
            this.picIconSendRecovery.Name = "picIconSendRecovery";
            this.picIconSendRecovery.Size = new System.Drawing.Size(20, 20);
            this.picIconSendRecovery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSendRecovery.TabIndex = 99;
            this.picIconSendRecovery.TabStop = false;

            // 
            // picIconCancel
            // 
            this.picIconCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCancel.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCancel.Location = new System.Drawing.Point(36, 250);
            this.picIconCancel.Name = "picIconCancel";
            this.picIconCancel.Size = new System.Drawing.Size(18, 18);
            this.picIconCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCancel.TabIndex = 99;
            this.picIconCancel.TabStop = false;
            buttonSendRecovery.BackColor = Color.FromArgb(2, 132, 199);
            // 
            // picIconSendRecovery
            // 
            this.picIconSendRecovery.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconSendRecovery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSendRecovery.Image = global::CompriaxSystem.WinFormsUI.Resources._083_enviar_mensaje;
            this.picIconSendRecovery.Location = new System.Drawing.Point(36, 202);
            this.picIconSendRecovery.Name = "picIconSendRecovery";
            this.picIconSendRecovery.Size = new System.Drawing.Size(20, 20);
            this.picIconSendRecovery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSendRecovery.TabIndex = 99;
            this.picIconSendRecovery.TabStop = false;

            // 
            // picIconCancel
            // 
            this.picIconCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCancel.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCancel.Location = new System.Drawing.Point(36, 250);
            this.picIconCancel.Name = "picIconCancel";
            this.picIconCancel.Size = new System.Drawing.Size(18, 18);
            this.picIconCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCancel.TabIndex = 99;
            this.picIconCancel.TabStop = false;
            buttonSendRecovery.FlatAppearance.BorderSize = 0;
            // 
            // picIconSendRecovery
            // 
            this.picIconSendRecovery.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconSendRecovery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSendRecovery.Image = global::CompriaxSystem.WinFormsUI.Resources._083_enviar_mensaje;
            this.picIconSendRecovery.Location = new System.Drawing.Point(36, 202);
            this.picIconSendRecovery.Name = "picIconSendRecovery";
            this.picIconSendRecovery.Size = new System.Drawing.Size(20, 20);
            this.picIconSendRecovery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSendRecovery.TabIndex = 99;
            this.picIconSendRecovery.TabStop = false;

            // 
            // picIconCancel
            // 
            this.picIconCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCancel.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCancel.Location = new System.Drawing.Point(36, 250);
            this.picIconCancel.Name = "picIconCancel";
            this.picIconCancel.Size = new System.Drawing.Size(18, 18);
            this.picIconCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCancel.TabIndex = 99;
            this.picIconCancel.TabStop = false;
            buttonSendRecovery.FlatStyle = FlatStyle.Flat;
            // 
            // picIconSendRecovery
            // 
            this.picIconSendRecovery.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconSendRecovery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSendRecovery.Image = global::CompriaxSystem.WinFormsUI.Resources._083_enviar_mensaje;
            this.picIconSendRecovery.Location = new System.Drawing.Point(36, 202);
            this.picIconSendRecovery.Name = "picIconSendRecovery";
            this.picIconSendRecovery.Size = new System.Drawing.Size(20, 20);
            this.picIconSendRecovery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSendRecovery.TabIndex = 99;
            this.picIconSendRecovery.TabStop = false;

            // 
            // picIconCancel
            // 
            this.picIconCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCancel.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCancel.Location = new System.Drawing.Point(36, 250);
            this.picIconCancel.Name = "picIconCancel";
            this.picIconCancel.Size = new System.Drawing.Size(18, 18);
            this.picIconCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCancel.TabIndex = 99;
            this.picIconCancel.TabStop = false;
            buttonSendRecovery.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            // 
            // picIconSendRecovery
            // 
            this.picIconSendRecovery.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconSendRecovery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSendRecovery.Image = global::CompriaxSystem.WinFormsUI.Resources._083_enviar_mensaje;
            this.picIconSendRecovery.Location = new System.Drawing.Point(36, 202);
            this.picIconSendRecovery.Name = "picIconSendRecovery";
            this.picIconSendRecovery.Size = new System.Drawing.Size(20, 20);
            this.picIconSendRecovery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSendRecovery.TabIndex = 99;
            this.picIconSendRecovery.TabStop = false;

            // 
            // picIconCancel
            // 
            this.picIconCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCancel.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCancel.Location = new System.Drawing.Point(36, 250);
            this.picIconCancel.Name = "picIconCancel";
            this.picIconCancel.Size = new System.Drawing.Size(18, 18);
            this.picIconCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCancel.TabIndex = 99;
            this.picIconCancel.TabStop = false;
            buttonSendRecovery.ForeColor = Color.White;
            // 
            // picIconSendRecovery
            // 
            this.picIconSendRecovery.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconSendRecovery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSendRecovery.Image = global::CompriaxSystem.WinFormsUI.Resources._083_enviar_mensaje;
            this.picIconSendRecovery.Location = new System.Drawing.Point(36, 202);
            this.picIconSendRecovery.Name = "picIconSendRecovery";
            this.picIconSendRecovery.Size = new System.Drawing.Size(20, 20);
            this.picIconSendRecovery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSendRecovery.TabIndex = 99;
            this.picIconSendRecovery.TabStop = false;

            // 
            // picIconCancel
            // 
            this.picIconCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCancel.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCancel.Location = new System.Drawing.Point(36, 250);
            this.picIconCancel.Name = "picIconCancel";
            this.picIconCancel.Size = new System.Drawing.Size(18, 18);
            this.picIconCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCancel.TabIndex = 99;
            this.picIconCancel.TabStop = false;
            buttonSendRecovery.Location = new Point(24, 190);
            // 
            // picIconSendRecovery
            // 
            this.picIconSendRecovery.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconSendRecovery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSendRecovery.Image = global::CompriaxSystem.WinFormsUI.Resources._083_enviar_mensaje;
            this.picIconSendRecovery.Location = new System.Drawing.Point(36, 202);
            this.picIconSendRecovery.Name = "picIconSendRecovery";
            this.picIconSendRecovery.Size = new System.Drawing.Size(20, 20);
            this.picIconSendRecovery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSendRecovery.TabIndex = 99;
            this.picIconSendRecovery.TabStop = false;

            // 
            // picIconCancel
            // 
            this.picIconCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCancel.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCancel.Location = new System.Drawing.Point(36, 250);
            this.picIconCancel.Name = "picIconCancel";
            this.picIconCancel.Size = new System.Drawing.Size(18, 18);
            this.picIconCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCancel.TabIndex = 99;
            this.picIconCancel.TabStop = false;
            buttonSendRecovery.Name = "buttonSendRecovery";
            // 
            // picIconSendRecovery
            // 
            this.picIconSendRecovery.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconSendRecovery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSendRecovery.Image = global::CompriaxSystem.WinFormsUI.Resources._083_enviar_mensaje;
            this.picIconSendRecovery.Location = new System.Drawing.Point(36, 202);
            this.picIconSendRecovery.Name = "picIconSendRecovery";
            this.picIconSendRecovery.Size = new System.Drawing.Size(20, 20);
            this.picIconSendRecovery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSendRecovery.TabIndex = 99;
            this.picIconSendRecovery.TabStop = false;

            // 
            // picIconCancel
            // 
            this.picIconCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCancel.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCancel.Location = new System.Drawing.Point(36, 250);
            this.picIconCancel.Name = "picIconCancel";
            this.picIconCancel.Size = new System.Drawing.Size(18, 18);
            this.picIconCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCancel.TabIndex = 99;
            this.picIconCancel.TabStop = false;
            buttonSendRecovery.Size = new Size(384, 44);
            // 
            // picIconSendRecovery
            // 
            this.picIconSendRecovery.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconSendRecovery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSendRecovery.Image = global::CompriaxSystem.WinFormsUI.Resources._083_enviar_mensaje;
            this.picIconSendRecovery.Location = new System.Drawing.Point(36, 202);
            this.picIconSendRecovery.Name = "picIconSendRecovery";
            this.picIconSendRecovery.Size = new System.Drawing.Size(20, 20);
            this.picIconSendRecovery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSendRecovery.TabIndex = 99;
            this.picIconSendRecovery.TabStop = false;

            // 
            // picIconCancel
            // 
            this.picIconCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCancel.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCancel.Location = new System.Drawing.Point(36, 250);
            this.picIconCancel.Name = "picIconCancel";
            this.picIconCancel.Size = new System.Drawing.Size(18, 18);
            this.picIconCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCancel.TabIndex = 99;
            this.picIconCancel.TabStop = false;
            buttonSendRecovery.TabIndex = 4;
            // 
            // picIconSendRecovery
            // 
            this.picIconSendRecovery.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconSendRecovery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSendRecovery.Image = global::CompriaxSystem.WinFormsUI.Resources._083_enviar_mensaje;
            this.picIconSendRecovery.Location = new System.Drawing.Point(36, 202);
            this.picIconSendRecovery.Name = "picIconSendRecovery";
            this.picIconSendRecovery.Size = new System.Drawing.Size(20, 20);
            this.picIconSendRecovery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSendRecovery.TabIndex = 99;
            this.picIconSendRecovery.TabStop = false;

            // 
            // picIconCancel
            // 
            this.picIconCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCancel.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCancel.Location = new System.Drawing.Point(36, 250);
            this.picIconCancel.Name = "picIconCancel";
            this.picIconCancel.Size = new System.Drawing.Size(18, 18);
            this.picIconCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCancel.TabIndex = 99;
            this.picIconCancel.TabStop = false;
            buttonSendRecovery.Text = "ENVIAR";
            // 
            // picIconSendRecovery
            // 
            this.picIconSendRecovery.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            this.picIconSendRecovery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconSendRecovery.Image = global::CompriaxSystem.WinFormsUI.Resources._083_enviar_mensaje;
            this.picIconSendRecovery.Location = new System.Drawing.Point(36, 202);
            this.picIconSendRecovery.Name = "picIconSendRecovery";
            this.picIconSendRecovery.Size = new System.Drawing.Size(20, 20);
            this.picIconSendRecovery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconSendRecovery.TabIndex = 99;
            this.picIconSendRecovery.TabStop = false;

            // 
            // picIconCancel
            // 
            this.picIconCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.picIconCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIconCancel.Image = global::CompriaxSystem.WinFormsUI.Resources._093_error;
            this.picIconCancel.Location = new System.Drawing.Point(36, 250);
            this.picIconCancel.Name = "picIconCancel";
            this.picIconCancel.Size = new System.Drawing.Size(18, 18);
            this.picIconCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconCancel.TabIndex = 99;
            this.picIconCancel.TabStop = false;
            buttonSendRecovery.UseVisualStyleBackColor = false;

            // buttonCancel
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Location = new Point(24, 242);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(384, 36);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "VOLVER";

            // labelResultStatus
            labelResultStatus.Font = new Font("Segoe UI", 8.5F);
            labelResultStatus.ForeColor = Color.FromArgb(16, 185, 129);
            labelResultStatus.Location = new Point(24, 290);
            labelResultStatus.Name = "labelResultStatus";
            labelResultStatus.Size = new Size(384, 55);
            labelResultStatus.TabIndex = 6;
            labelResultStatus.TextAlign = ContentAlignment.MiddleCenter;

            // buttonCloseDialog
            buttonCloseDialog.Cursor = Cursors.Hand;
            buttonCloseDialog.FlatAppearance.BorderSize = 0;
            buttonCloseDialog.FlatStyle = FlatStyle.Flat;
            buttonCloseDialog.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonCloseDialog.ForeColor = Color.White;
            buttonCloseDialog.Location = new Point(440, 4);
            buttonCloseDialog.Name = "buttonCloseDialog";
            buttonCloseDialog.Size = new Size(32, 28);
            buttonCloseDialog.TabIndex = 0;
            buttonCloseDialog.Text = "✕";

            // Form Properties
            BackColor = Color.FromArgb(15, 23, 42);
            ClientSize = new Size(480, 420);
            Controls.Add(buttonCloseDialog);
            Controls.Add(panelCard);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormRecoverPassword";
            StartPosition = FormStartPosition.CenterParent;
ResumeLayout(false);
            panelCard.PerformLayout();

            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Label labelHeaderIcon, labelMainTitle, labelInstructions, labelResultStatus;
        private System.Windows.Forms.TextBox textBoxIdentity;
        private System.Windows.Forms.Button buttonSendRecovery, buttonCancel, buttonCloseDialog;
        private System.Windows.Forms.PictureBox picIconSendRecovery;
        private System.Windows.Forms.PictureBox picIconCancel;
    }
}
