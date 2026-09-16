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
            this.panelTopNavigation = new System.Windows.Forms.Panel();
            this.flowLayoutPanelNavigationButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.panelBrand = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.labelSystemName = new System.Windows.Forms.Label();
            this.panelStatusFooter = new System.Windows.Forms.Panel();
            this.flowLayoutPanelStatusLeft = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxUserIcon = new System.Windows.Forms.PictureBox();
            this.labelSessionUser = new System.Windows.Forms.Label();
            this.pictureBoxRoleIcon = new System.Windows.Forms.PictureBox();
            this.labelRoleName = new System.Windows.Forms.Label();
            this.labelShiftStatus = new System.Windows.Forms.Label();
            this.labelClockTime = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.panelMainContainer = new System.Windows.Forms.Panel();
            this.timerSystemClock = new System.Windows.Forms.Timer(this.components);

            this.panelTopNavigation.SuspendLayout();
            this.panelBrand.SuspendLayout();
            this.panelStatusFooter.SuspendLayout();
            this.flowLayoutPanelStatusLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRoleIcon)).BeginInit();
            this.SuspendLayout();

            // ==================== panelTopNavigation ====================
            this.panelTopNavigation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panelTopNavigation.Controls.Add(this.flowLayoutPanelNavigationButtons);
            this.panelTopNavigation.Controls.Add(this.panelBrand);
            this.panelTopNavigation.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopNavigation.Location = new System.Drawing.Point(0, 0);
            this.panelTopNavigation.Name = "panelTopNavigation";
            this.panelTopNavigation.Size = new System.Drawing.Size(1280, 110);
            this.panelTopNavigation.TabIndex = 0;

            // panelBrand
            this.panelBrand.Controls.Add(this.pictureBoxLogo);
            this.panelBrand.Controls.Add(this.labelSystemName);
            this.panelBrand.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBrand.Location = new System.Drawing.Point(0, 0);
            this.panelBrand.Name = "panelBrand";
            this.panelBrand.Size = new System.Drawing.Size(160, 110);
            this.panelBrand.TabIndex = 0;

            // pictureBoxLogo
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.Location = new System.Drawing.Point(35, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(90, 75);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;

            // flowLayoutPanelNavigationButtons
            this.flowLayoutPanelNavigationButtons.AutoScroll = true;
            this.flowLayoutPanelNavigationButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelNavigationButtons.Location = new System.Drawing.Point(160, 0);
            this.flowLayoutPanelNavigationButtons.Name = "flowLayoutPanelNavigationButtons";
            this.flowLayoutPanelNavigationButtons.Padding = new System.Windows.Forms.Padding(10, 8, 10, 0);
            this.flowLayoutPanelNavigationButtons.Size = new System.Drawing.Size(1120, 110);
            this.flowLayoutPanelNavigationButtons.TabIndex = 1;
            this.flowLayoutPanelNavigationButtons.WrapContents = false;

            // ==================== panelStatusFooter ====================
            this.panelStatusFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(180)))));
            this.panelStatusFooter.Controls.Add(this.flowLayoutPanelStatusLeft);
            this.panelStatusFooter.Controls.Add(this.labelClockTime);
            this.panelStatusFooter.Controls.Add(this.buttonLogout);
            this.panelStatusFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatusFooter.Location = new System.Drawing.Point(0, 752);
            this.panelStatusFooter.Name = "panelStatusFooter";
            this.panelStatusFooter.Size = new System.Drawing.Size(1280, 48);
            this.panelStatusFooter.TabIndex = 1;

            // flowLayoutPanelStatusLeft 
            this.flowLayoutPanelStatusLeft.AutoSize = true;
            this.flowLayoutPanelStatusLeft.Controls.Add(this.pictureBoxUserIcon);
            this.flowLayoutPanelStatusLeft.Controls.Add(this.labelSessionUser);
            this.flowLayoutPanelStatusLeft.Controls.Add(this.pictureBoxRoleIcon);
            this.flowLayoutPanelStatusLeft.Controls.Add(this.labelRoleName);
            this.flowLayoutPanelStatusLeft.Controls.Add(this.labelShiftStatus);
            this.flowLayoutPanelStatusLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanelStatusLeft.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelStatusLeft.Name = "flowLayoutPanelStatusLeft";
            this.flowLayoutPanelStatusLeft.Padding = new System.Windows.Forms.Padding(12, 10, 10, 0);
            this.flowLayoutPanelStatusLeft.Size = new System.Drawing.Size(900, 48);
            this.flowLayoutPanelStatusLeft.TabIndex = 0;
            this.flowLayoutPanelStatusLeft.WrapContents = false;

            // pictureBoxUserIcon
            this.pictureBoxUserIcon.Margin = new System.Windows.Forms.Padding(0, 2, 4, 0);
            this.pictureBoxUserIcon.Name = "pictureBoxUserIcon";
            this.pictureBoxUserIcon.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxUserIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxUserIcon.TabIndex = 0;
            this.pictureBoxUserIcon.TabStop = false;

            // labelSessionUser
            this.labelSessionUser.AutoSize = true;
            this.labelSessionUser.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.labelSessionUser.ForeColor = System.Drawing.Color.White;
            this.labelSessionUser.Margin = new System.Windows.Forms.Padding(0, 2, 20, 0);
            this.labelSessionUser.Name = "labelSessionUser";
            this.labelSessionUser.Size = new System.Drawing.Size(77, 17);
            this.labelSessionUser.TabIndex = 1;
            this.labelSessionUser.Text = "USUARIO";

            // pictureBoxRoleIcon
            this.pictureBoxRoleIcon.Margin = new System.Windows.Forms.Padding(0, 2, 4, 0);
            this.pictureBoxRoleIcon.Name = "pictureBoxRoleIcon";
            this.pictureBoxRoleIcon.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxRoleIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRoleIcon.TabIndex = 2;
            this.pictureBoxRoleIcon.TabStop = false;

            // labelRoleName
            this.labelRoleName.AutoSize = true;
            this.labelRoleName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.labelRoleName.ForeColor = System.Drawing.Color.White;
            this.labelRoleName.Margin = new System.Windows.Forms.Padding(0, 2, 25, 0);
            this.labelRoleName.Name = "labelRoleName";
            this.labelRoleName.Size = new System.Drawing.Size(130, 17);
            this.labelRoleName.TabIndex = 3;
            this.labelRoleName.Text = "[ADMINISTRADOR]";

            // labelShiftStatus
            this.labelShiftStatus.AutoSize = true;
            this.labelShiftStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.labelShiftStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.labelShiftStatus.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.labelShiftStatus.Name = "labelShiftStatus";
            this.labelShiftStatus.Size = new System.Drawing.Size(135, 17);
            this.labelShiftStatus.TabIndex = 4;
            this.labelShiftStatus.Text = "Caja 01 - Abierta";

            // labelClockTime
            this.labelClockTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelClockTime.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelClockTime.ForeColor = System.Drawing.Color.White;
            this.labelClockTime.Location = new System.Drawing.Point(980, 0);
            this.labelClockTime.Name = "labelClockTime";
            this.labelClockTime.Size = new System.Drawing.Size(150, 48);
            this.labelClockTime.TabIndex = 5;
            this.labelClockTime.Text = "00:00:00";
            this.labelClockTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // buttonLogout
            this.buttonLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonLogout.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonLogout.FlatAppearance.BorderSize = 0;
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.buttonLogout.ForeColor = System.Drawing.Color.White;
            this.buttonLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLogout.Location = new System.Drawing.Point(1130, 0);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.buttonLogout.Size = new System.Drawing.Size(150, 48);
            this.buttonLogout.TabIndex = 6;
            this.buttonLogout.Text = "CERRAR";
            this.buttonLogout.UseVisualStyleBackColor = false;

            // ==================== panelMainContainer ====================
            this.panelMainContainer.BackColor = System.Drawing.Color.White;
            this.panelMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainContainer.Location = new System.Drawing.Point(0, 110);
            this.panelMainContainer.Name = "panelMainContainer";
            this.panelMainContainer.Size = new System.Drawing.Size(1280, 642);
            this.panelMainContainer.TabIndex = 2;

            // timerSystemClock
            this.timerSystemClock.Interval = 1000;

            // FormPanelControl
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.panelMainContainer);
            this.Controls.Add(this.panelStatusFooter);
            this.Controls.Add(this.panelTopNavigation);
            this.Name = "FormPanelControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CompriaxSystem - Panel de Control";

            this.panelTopNavigation.ResumeLayout(false);
            this.panelBrand.ResumeLayout(false);
            this.panelBrand.PerformLayout();
            this.panelStatusFooter.ResumeLayout(false);
            this.panelStatusFooter.PerformLayout();
            this.flowLayoutPanelStatusLeft.ResumeLayout(false);
            this.flowLayoutPanelStatusLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRoleIcon)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTopNavigation;
        private System.Windows.Forms.Panel panelBrand;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelSystemName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelNavigationButtons;
        private System.Windows.Forms.Panel panelStatusFooter;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelStatusLeft;
        private System.Windows.Forms.PictureBox pictureBoxUserIcon;
        private System.Windows.Forms.Label labelSessionUser;
        private System.Windows.Forms.PictureBox pictureBoxRoleIcon;
        private System.Windows.Forms.Label labelRoleName;
        private System.Windows.Forms.Label labelShiftStatus;
        private System.Windows.Forms.Label labelClockTime;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Panel panelMainContainer;
        private System.Windows.Forms.Timer timerSystemClock;
    }
}