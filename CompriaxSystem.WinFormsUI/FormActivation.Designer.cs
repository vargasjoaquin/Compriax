namespace CompriaxSystem.WinFormsUI
{
    partial class FormActivation
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
            picHeaderIcon = new PictureBox();
            lblTitle = new Label();
            pnlCard = new Panel();
            lblInstruct = new Label();
            lblCuit = new Label();
            txtCuit = new TextBox();
            lblKey = new Label();
            txtKey1 = new TextBox();
            lblSep1 = new Label();
            txtKey2 = new TextBox();
            lblSep2 = new Label();
            txtKey3 = new TextBox();
            lblSep3 = new Label();
            txtKey4 = new TextBox();
            lblStatusMessage = new Label();
            btnActivate = new Button();
            btnExit = new Button();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHeaderIcon).BeginInit();
            pnlCard.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(15, 23, 42);
            pnlHeader.Controls.Add(picHeaderIcon);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(520, 56);
            pnlHeader.TabIndex = 0;
            // 
            // picHeaderIcon
            // 
            picHeaderIcon.BackColor = Color.Transparent;
            picHeaderIcon.Image = Resources._097_activacion_supervisor;
            picHeaderIcon.Location = new Point(16, 14);
            picHeaderIcon.Name = "picHeaderIcon";
            picHeaderIcon.Size = new Size(28, 28);
            picHeaderIcon.SizeMode = PictureBoxSizeMode.Zoom;
            picHeaderIcon.TabIndex = 1;
            picHeaderIcon.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(50, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(289, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ACTIVACIÓN DEL SISTEMA";
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.Controls.Add(lblInstruct);
            pnlCard.Controls.Add(lblCuit);
            pnlCard.Controls.Add(txtCuit);
            pnlCard.Controls.Add(lblKey);
            pnlCard.Controls.Add(txtKey1);
            pnlCard.Controls.Add(lblSep1);
            pnlCard.Controls.Add(txtKey2);
            pnlCard.Controls.Add(lblSep2);
            pnlCard.Controls.Add(txtKey3);
            pnlCard.Controls.Add(lblSep3);
            pnlCard.Controls.Add(txtKey4);
            pnlCard.Controls.Add(lblStatusMessage);
            pnlCard.Controls.Add(btnActivate);
            pnlCard.Controls.Add(btnExit);
            pnlCard.Location = new Point(24, 76);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(472, 330);
            pnlCard.TabIndex = 1;
            // 
            // lblInstruct
            // 
            lblInstruct.Font = new Font("Segoe UI", 9F);
            lblInstruct.ForeColor = Color.FromArgb(100, 116, 139);
            lblInstruct.Location = new Point(24, 16);
            lblInstruct.Name = "lblInstruct";
            lblInstruct.Size = new Size(424, 34);
            lblInstruct.TabIndex = 0;
            lblInstruct.Text = "Ingrese los datos de su comercio para autorizar la instalación en este equipo:";
            // 
            // lblCuit
            // 
            lblCuit.AutoSize = true;
            lblCuit.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCuit.Location = new Point(24, 56);
            lblCuit.Name = "lblCuit";
            lblCuit.Size = new Size(155, 21);
            lblCuit.TabIndex = 1;
            lblCuit.Text = "CUIT del Comercio:";
            // 
            // txtCuit
            // 
            txtCuit.BorderStyle = BorderStyle.FixedSingle;
            txtCuit.Font = new Font("Consolas", 11F);
            txtCuit.Location = new Point(24, 78);
            txtCuit.MaxLength = 13;
            txtCuit.Name = "txtCuit";
            txtCuit.PlaceholderText = "30-XXXXXXXX-X";
            txtCuit.Size = new Size(424, 29);
            txtCuit.TabIndex = 2;
            // 
            // lblKey
            // 
            lblKey.AutoSize = true;
            lblKey.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblKey.Location = new Point(24, 118);
            lblKey.Name = "lblKey";
            lblKey.Size = new Size(245, 21);
            lblKey.TabIndex = 3;
            lblKey.Text = "License Key / Número de Serie:";
            // 
            // txtKey1
            // 
            txtKey1.BorderStyle = BorderStyle.FixedSingle;
            txtKey1.Font = new Font("Consolas", 12F, FontStyle.Bold);
            txtKey1.Location = new Point(24, 147);
            txtKey1.MaxLength = 4;
            txtKey1.Name = "txtKey1";
            txtKey1.Size = new Size(88, 31);
            txtKey1.TabIndex = 4;
            txtKey1.TextAlign = HorizontalAlignment.Center;
            // 
            // lblSep1
            // 
            lblSep1.AutoSize = true;
            lblSep1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSep1.ForeColor = Color.FromArgb(100, 116, 139);
            lblSep1.Location = new Point(119, 144);
            lblSep1.Name = "lblSep1";
            lblSep1.Size = new Size(20, 28);
            lblSep1.TabIndex = 5;
            lblSep1.Text = "-";
            // 
            // txtKey2
            // 
            txtKey2.BorderStyle = BorderStyle.FixedSingle;
            txtKey2.Font = new Font("Consolas", 12F, FontStyle.Bold);
            txtKey2.Location = new Point(142, 147);
            txtKey2.MaxLength = 4;
            txtKey2.Name = "txtKey2";
            txtKey2.Size = new Size(88, 31);
            txtKey2.TabIndex = 6;
            txtKey2.TextAlign = HorizontalAlignment.Center;
            // 
            // lblSep2
            // 
            lblSep2.AutoSize = true;
            lblSep2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSep2.ForeColor = Color.FromArgb(100, 116, 139);
            lblSep2.Location = new Point(236, 144);
            lblSep2.Name = "lblSep2";
            lblSep2.Size = new Size(20, 28);
            lblSep2.TabIndex = 7;
            lblSep2.Text = "-";
            // 
            // txtKey3
            // 
            txtKey3.BorderStyle = BorderStyle.FixedSingle;
            txtKey3.Font = new Font("Consolas", 12F, FontStyle.Bold);
            txtKey3.Location = new Point(259, 147);
            txtKey3.MaxLength = 4;
            txtKey3.Name = "txtKey3";
            txtKey3.Size = new Size(88, 31);
            txtKey3.TabIndex = 8;
            txtKey3.TextAlign = HorizontalAlignment.Center;
            // 
            // lblSep3
            // 
            lblSep3.AutoSize = true;
            lblSep3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSep3.ForeColor = Color.FromArgb(100, 116, 139);
            lblSep3.Location = new Point(353, 144);
            lblSep3.Name = "lblSep3";
            lblSep3.Size = new Size(20, 28);
            lblSep3.TabIndex = 9;
            lblSep3.Text = "-";
            // 
            // txtKey4
            // 
            txtKey4.BorderStyle = BorderStyle.FixedSingle;
            txtKey4.Font = new Font("Consolas", 12F, FontStyle.Bold);
            txtKey4.Location = new Point(375, 147);
            txtKey4.MaxLength = 4;
            txtKey4.Name = "txtKey4";
            txtKey4.Size = new Size(82, 31);
            txtKey4.TabIndex = 10;
            txtKey4.TextAlign = HorizontalAlignment.Center;
            // 
            // lblStatusMessage
            // 
            lblStatusMessage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatusMessage.ForeColor = Color.FromArgb(239, 68, 68);
            lblStatusMessage.Location = new Point(24, 182);
            lblStatusMessage.Name = "lblStatusMessage";
            lblStatusMessage.Size = new Size(424, 38);
            lblStatusMessage.TabIndex = 11;
            lblStatusMessage.Visible = false;
            // 
            // btnActivate
            // 
            btnActivate.BackColor = Color.FromArgb(16, 185, 129);
            btnActivate.FlatAppearance.BorderSize = 0;
            btnActivate.FlatStyle = FlatStyle.Flat;
            btnActivate.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnActivate.ForeColor = Color.White;
            btnActivate.Location = new Point(24, 230);
            btnActivate.Name = "btnActivate";
            btnActivate.Padding = new Padding(25, 0, 0, 0);
            btnActivate.Size = new Size(424, 44);
            btnActivate.TabIndex = 6;
            btnActivate.Text = "ACTIVAR SISTEMA";
            btnActivate.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnActivate.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExit.Location = new Point(24, 282);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(424, 32);
            btnExit.TabIndex = 13;
            btnExit.Text = "SALIR";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // FormActivation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(520, 430);
            Controls.Add(pnlCard);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormActivation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Activación de Licencia";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHeaderIcon).EndInit();
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox picHeaderIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblInstruct;
        private System.Windows.Forms.Label lblCuit;
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.TextBox txtKey1;
        private System.Windows.Forms.Label lblSep1;
        private System.Windows.Forms.TextBox txtKey2;
        private System.Windows.Forms.Label lblSep2;
        private System.Windows.Forms.TextBox txtKey3;
        private System.Windows.Forms.Label lblSep3;
        private System.Windows.Forms.TextBox txtKey4;
        private System.Windows.Forms.Label lblStatusMessage;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.Button btnExit;
    }
}