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
            components = new System.ComponentModel.Container();
            picIconLogout = new PictureBox();
            panelTopNavigation = new Panel();
            flowLayoutPanelNavigationButtons = new FlowLayoutPanel();
            panelBrand = new Panel();
            pictureBoxLogo = new PictureBox();
            labelSystemName = new Label();
            panelStatusFooter = new Panel();
            panelStatusLeft = new Panel();
            pictureBoxUserIcon = new PictureBox();
            labelSessionUser = new Label();
            pictureBoxRoleIcon = new PictureBox();
            labelRoleName = new Label();
            labelShiftStatus = new Label();
            labelClockTime = new Label();
            buttonLogout = new Button();
            panelMainContainer = new Panel();
            timerSystemClock = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)picIconLogout).BeginInit();
            panelTopNavigation.SuspendLayout();
            panelBrand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            panelStatusFooter.SuspendLayout();
            panelStatusLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUserIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRoleIcon).BeginInit();
            SuspendLayout();
            // 
            // picIconLogout
            // 
            picIconLogout.BackColor = Color.FromArgb(192, 0, 0);
            picIconLogout.Cursor = Cursors.Hand;
            picIconLogout.Image = Resources._066_cerrar_sesion;
            picIconLogout.Location = new Point(1105, 0);
            picIconLogout.Name = "picIconLogout";
            picIconLogout.Size = new Size(31, 48);
            picIconLogout.SizeMode = PictureBoxSizeMode.Zoom;
            picIconLogout.TabIndex = 99;
            picIconLogout.TabStop = false;
            // 
            // panelTopNavigation
            // 
            panelTopNavigation.BackColor = Color.FromArgb(235, 235, 235);
            panelTopNavigation.Controls.Add(flowLayoutPanelNavigationButtons);
            panelTopNavigation.Controls.Add(panelBrand);
            panelTopNavigation.Dock = DockStyle.Top;
            panelTopNavigation.Location = new Point(0, 0);
            panelTopNavigation.Name = "panelTopNavigation";
            panelTopNavigation.Size = new Size(1280, 110);
            panelTopNavigation.TabIndex = 0;
            // 
            // flowLayoutPanelNavigationButtons
            // 
            flowLayoutPanelNavigationButtons.AutoScroll = true;
            flowLayoutPanelNavigationButtons.Dock = DockStyle.Fill;
            flowLayoutPanelNavigationButtons.Location = new Point(160, 0);
            flowLayoutPanelNavigationButtons.Name = "flowLayoutPanelNavigationButtons";
            flowLayoutPanelNavigationButtons.Padding = new Padding(10, 8, 10, 0);
            flowLayoutPanelNavigationButtons.Size = new Size(1120, 110);
            flowLayoutPanelNavigationButtons.TabIndex = 1;
            flowLayoutPanelNavigationButtons.WrapContents = false;
            // 
            // panelBrand
            // 
            panelBrand.Controls.Add(pictureBoxLogo);
            panelBrand.Controls.Add(labelSystemName);
            panelBrand.Dock = DockStyle.Left;
            panelBrand.Location = new Point(0, 0);
            panelBrand.Name = "panelBrand";
            panelBrand.Size = new Size(160, 110);
            panelBrand.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = Color.Transparent;
            pictureBoxLogo.Location = new Point(35, 12);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(90, 75);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // labelSystemName
            // 
            labelSystemName.Location = new Point(0, 0);
            labelSystemName.Name = "labelSystemName";
            labelSystemName.Size = new Size(100, 23);
            labelSystemName.TabIndex = 0;
            // 
            // panelStatusFooter
            // 
            panelStatusFooter.BackColor = Color.FromArgb(0, 80, 180);
            panelStatusFooter.Controls.Add(panelStatusLeft);
            panelStatusFooter.Controls.Add(labelClockTime);
            panelStatusFooter.Controls.Add(picIconLogout);
            panelStatusFooter.Controls.Add(buttonLogout);
            panelStatusFooter.Dock = DockStyle.Bottom;
            panelStatusFooter.Location = new Point(0, 752);
            panelStatusFooter.Name = "panelStatusFooter";
            panelStatusFooter.Size = new Size(1280, 48);
            panelStatusFooter.TabIndex = 1;
            // 
            // panelStatusLeft
            // 
            panelStatusLeft.Controls.Add(pictureBoxUserIcon);
            panelStatusLeft.Controls.Add(labelSessionUser);
            panelStatusLeft.Controls.Add(pictureBoxRoleIcon);
            panelStatusLeft.Controls.Add(labelRoleName);
            panelStatusLeft.Controls.Add(labelShiftStatus);
            panelStatusLeft.Dock = DockStyle.Left;
            panelStatusLeft.Location = new Point(0, 0);
            panelStatusLeft.Name = "panelStatusLeft";
            panelStatusLeft.Size = new Size(900, 48);
            panelStatusLeft.TabIndex = 0;
            // 
            // pictureBoxUserIcon
            // 
            pictureBoxUserIcon.Image = Resources._067_rol_de_usuario;
            pictureBoxUserIcon.Location = new Point(25, 0);
            pictureBoxUserIcon.Name = "pictureBoxUserIcon";
            pictureBoxUserIcon.Size = new Size(31, 48);
            pictureBoxUserIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxUserIcon.TabIndex = 0;
            pictureBoxUserIcon.TabStop = false;
            // 
            // labelSessionUser
            // 
            labelSessionUser.AutoSize = true;
            labelSessionUser.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelSessionUser.ForeColor = Color.White;
            labelSessionUser.Location = new Point(62, 15);
            labelSessionUser.Name = "labelSessionUser";
            labelSessionUser.Size = new Size(81, 21);
            labelSessionUser.TabIndex = 1;
            labelSessionUser.Text = "USUARIO";
            // 
            // pictureBoxRoleIcon
            // 
            pictureBoxRoleIcon.Image = Resources._068_avatar_usuario;
            pictureBoxRoleIcon.Location = new Point(176, 0);
            pictureBoxRoleIcon.Name = "pictureBoxRoleIcon";
            pictureBoxRoleIcon.Size = new Size(35, 48);
            pictureBoxRoleIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxRoleIcon.TabIndex = 2;
            pictureBoxRoleIcon.TabStop = false;
            // 
            // labelRoleName
            // 
            labelRoleName.AutoSize = true;
            labelRoleName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelRoleName.ForeColor = Color.White;
            labelRoleName.Location = new Point(217, 15);
            labelRoleName.Name = "labelRoleName";
            labelRoleName.Size = new Size(156, 21);
            labelRoleName.TabIndex = 3;
            labelRoleName.Text = "[ADMINISTRADOR]";
            // 
            // labelShiftStatus
            // 
            labelShiftStatus.AutoSize = true;
            labelShiftStatus.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelShiftStatus.ForeColor = Color.FromArgb(16, 185, 129);
            labelShiftStatus.Location = new Point(438, 14);
            labelShiftStatus.Name = "labelShiftStatus";
            labelShiftStatus.Size = new Size(135, 21);
            labelShiftStatus.TabIndex = 4;
            labelShiftStatus.Text = "Caja 01 - Abierta";
            // 
            // labelClockTime
            // 
            labelClockTime.Dock = DockStyle.Right;
            labelClockTime.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelClockTime.ForeColor = Color.White;
            labelClockTime.Location = new Point(934, 0);
            labelClockTime.Name = "labelClockTime";
            labelClockTime.Size = new Size(171, 48);
            labelClockTime.TabIndex = 5;
            labelClockTime.Text = "00:00:00";
            labelClockTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonLogout
            // 
            buttonLogout.BackColor = Color.FromArgb(192, 0, 0);
            buttonLogout.Dock = DockStyle.Right;
            buttonLogout.FlatAppearance.BorderSize = 0;
            buttonLogout.FlatStyle = FlatStyle.Flat;
            buttonLogout.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonLogout.ForeColor = Color.White;
            buttonLogout.ImageAlign = ContentAlignment.MiddleLeft;
            buttonLogout.Location = new Point(1105, 0);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Padding = new Padding(12, 0, 0, 0);
            buttonLogout.Size = new Size(175, 48);
            buttonLogout.TabIndex = 6;
            buttonLogout.Text = "CERRAR SESION";
            buttonLogout.UseVisualStyleBackColor = false;
            // 
            // panelMainContainer
            // 
            panelMainContainer.BackColor = Color.White;
            panelMainContainer.Dock = DockStyle.Fill;
            panelMainContainer.Location = new Point(0, 110);
            panelMainContainer.Name = "panelMainContainer";
            panelMainContainer.Size = new Size(1280, 642);
            panelMainContainer.TabIndex = 2;
            // 
            // timerSystemClock
            // 
            timerSystemClock.Interval = 1000;
            // 
            // FormPanelControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 800);
            Controls.Add(panelMainContainer);
            Controls.Add(panelStatusFooter);
            Controls.Add(panelTopNavigation);
            Name = "FormPanelControl";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Panel de Control";
            ((System.ComponentModel.ISupportInitialize)picIconLogout).EndInit();
            panelTopNavigation.ResumeLayout(false);
            panelBrand.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            panelStatusFooter.ResumeLayout(false);
            panelStatusLeft.ResumeLayout(false);
            panelStatusLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUserIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRoleIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTopNavigation;
        private System.Windows.Forms.Panel panelBrand;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelSystemName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelNavigationButtons;
        private System.Windows.Forms.Panel panelStatusFooter;
        private System.Windows.Forms.Panel panelStatusLeft;
        private System.Windows.Forms.PictureBox pictureBoxUserIcon;
        private System.Windows.Forms.Label labelSessionUser;
        private System.Windows.Forms.PictureBox pictureBoxRoleIcon;
        private System.Windows.Forms.Label labelRoleName;
        private System.Windows.Forms.Label labelShiftStatus;
        private System.Windows.Forms.Label labelClockTime;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Panel panelMainContainer;
        private System.Windows.Forms.Timer timerSystemClock;
        private System.Windows.Forms.PictureBox picIconLogout;
    }
}
