namespace CompriaxSystem.WinFormsUI
{
    partial class FormPanelControl
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
            this.components = new System.ComponentModel.Container();
            this.pnlTopNav = new System.Windows.Forms.Panel();
            this.flowLayoutButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBrand = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblSystemName = new System.Windows.Forms.Label();
            this.pnlStatusFooter = new System.Windows.Forms.Panel();
            this.pbUserIcon = new System.Windows.Forms.PictureBox();
            this.lblSessionUser = new System.Windows.Forms.Label();
            this.pbRoleIcon = new System.Windows.Forms.PictureBox();
            this.lblRoleName = new System.Windows.Forms.Label();
            this.lblShiftStatus = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.HoraFecha = new System.Windows.Forms.Timer(this.components);

            this.pnlTopNav.SuspendLayout();
            this.pnlBrand.SuspendLayout();
            this.pnlStatusFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRoleIcon)).BeginInit();
            this.SuspendLayout();

            // ==================== pnlTopNav ====================
            this.pnlTopNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlTopNav.Controls.Add(this.flowLayoutButtons);
            this.pnlTopNav.Controls.Add(this.pnlBrand);
            this.pnlTopNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopNav.Location = new System.Drawing.Point(0, 0);
            this.pnlTopNav.Name = "pnlTopNav";
            this.pnlTopNav.Size = new System.Drawing.Size(1280, 110);
            this.pnlTopNav.TabIndex = 0;

            // pnlBrand
            this.pnlBrand.Controls.Add(this.picLogo);
            this.pnlBrand.Controls.Add(this.lblSystemName);
            this.pnlBrand.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBrand.Location = new System.Drawing.Point(0, 0);
            this.pnlBrand.Name = "pnlBrand";
            this.pnlBrand.Size = new System.Drawing.Size(160, 110);
            this.pnlBrand.TabIndex = 0;

            // picLogo
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Location = new System.Drawing.Point(35, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(90, 75);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;

            // lblSystemName
            this.lblSystemName.AutoSize = true;
            this.lblSystemName.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSystemName.Location = new System.Drawing.Point(10, 90);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(130, 15);
            this.lblSystemName.TabIndex = 1;
            this.lblSystemName.Text = "SUPERMARKET POS";

            // flowLayoutButtons
            this.flowLayoutButtons.AutoScroll = true;
            this.flowLayoutButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutButtons.Location = new System.Drawing.Point(160, 0);
            this.flowLayoutButtons.Name = "flowLayoutButtons";
            this.flowLayoutButtons.Padding = new System.Windows.Forms.Padding(10, 8, 10, 0);
            this.flowLayoutButtons.Size = new System.Drawing.Size(1120, 110);
            this.flowLayoutButtons.TabIndex = 1;
            this.flowLayoutButtons.WrapContents = false;

            // ==================== pnlStatusFooter ====================
            this.pnlStatusFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(180)))));
            this.pnlStatusFooter.Controls.Add(this.pbUserIcon);
            this.pnlStatusFooter.Controls.Add(this.lblSessionUser);
            this.pnlStatusFooter.Controls.Add(this.pbRoleIcon);
            this.pnlStatusFooter.Controls.Add(this.lblRoleName);
            this.pnlStatusFooter.Controls.Add(this.lblShiftStatus);
            this.pnlStatusFooter.Controls.Add(this.lblHora);
            this.pnlStatusFooter.Controls.Add(this.btnLogout);
            this.pnlStatusFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatusFooter.Location = new System.Drawing.Point(0, 752);
            this.pnlStatusFooter.Name = "pnlStatusFooter";
            this.pnlStatusFooter.Size = new System.Drawing.Size(1280, 48);
            this.pnlStatusFooter.TabIndex = 1;

            // pbUserIcon
            this.pbUserIcon.Location = new System.Drawing.Point(15, 12);
            this.pbUserIcon.Name = "pbUserIcon";
            this.pbUserIcon.Size = new System.Drawing.Size(24, 24);
            this.pbUserIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbUserIcon.TabIndex = 0;
            this.pbUserIcon.TabStop = false;

            // lblSessionUser
            this.lblSessionUser.AutoSize = true;
            this.lblSessionUser.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSessionUser.ForeColor = System.Drawing.Color.White;
            this.lblSessionUser.Location = new System.Drawing.Point(45, 14);
            this.lblSessionUser.Name = "lblSessionUser";
            this.lblSessionUser.Size = new System.Drawing.Size(77, 17);
            this.lblSessionUser.TabIndex = 1;
            this.lblSessionUser.Text = "USUARIO";

            // pbRoleIcon
            this.pbRoleIcon.Location = new System.Drawing.Point(280, 12);
            this.pbRoleIcon.Name = "pbRoleIcon";
            this.pbRoleIcon.Size = new System.Drawing.Size(24, 24);
            this.pbRoleIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRoleIcon.TabIndex = 2;
            this.pbRoleIcon.TabStop = false;

            // lblRoleName
            this.lblRoleName.AutoSize = true;
            this.lblRoleName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRoleName.ForeColor = System.Drawing.Color.White;
            this.lblRoleName.Location = new System.Drawing.Point(310, 14);
            this.lblRoleName.Name = "lblRoleName";
            this.lblRoleName.Size = new System.Drawing.Size(130, 17);
            this.lblRoleName.TabIndex = 3;
            this.lblRoleName.Text = "[ADMINISTRADOR]";

            // lblShiftStatus
            this.lblShiftStatus.AutoSize = true;
            this.lblShiftStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblShiftStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblShiftStatus.Location = new System.Drawing.Point(480, 14);
            this.lblShiftStatus.Name = "lblShiftStatus";
            this.lblShiftStatus.Size = new System.Drawing.Size(135, 17);
            this.lblShiftStatus.TabIndex = 4;
            this.lblShiftStatus.Text = "🟢 Caja 01 - Abierta";

            // lblHora
            this.lblHora.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblHora.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblHora.ForeColor = System.Drawing.Color.White;
            this.lblHora.Location = new System.Drawing.Point(980, 0);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(150, 48);
            this.lblHora.TabIndex = 5;
            this.lblHora.Text = "00:00:00";
            this.lblHora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnLogout
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(1130, 0);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(150, 48);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "  CERRAR";
            this.btnLogout.UseVisualStyleBackColor = false;

            // ==================== panelContenedor ====================
            this.panelContenedor.BackColor = System.Drawing.Color.White;
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 110);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1280, 642);
            this.panelContenedor.TabIndex = 2;

            // HoraFecha
            this.HoraFecha.Interval = 1000;

            // ==================== Form Properties ====================
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.pnlStatusFooter);
            this.Controls.Add(this.pnlTopNav);
            this.Name = "FormPanelControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supermarket System - Panel de Control";

            this.pnlTopNav.ResumeLayout(false);
            this.pnlBrand.ResumeLayout(false);
            this.pnlBrand.PerformLayout();
            this.pnlStatusFooter.ResumeLayout(false);
            this.pnlStatusFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRoleIcon)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTopNav;
        private System.Windows.Forms.Panel pnlBrand;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblSystemName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutButtons;
        private System.Windows.Forms.Panel pnlStatusFooter;
        private System.Windows.Forms.PictureBox pbUserIcon;
        private System.Windows.Forms.Label lblSessionUser;
        private System.Windows.Forms.PictureBox pbRoleIcon;
        private System.Windows.Forms.Label lblRoleName;
        private System.Windows.Forms.Label lblShiftStatus;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Timer HoraFecha;
    }
}