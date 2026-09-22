namespace CompriaxSystem.WinFormsUI
{
    partial class FormSecurityCameras
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
            picIconToggleLiveView = new PictureBox();
            picIconCaptureSnapshot = new PictureBox();
            picIconToggleAutoRecording = new PictureBox();
            panelHeader = new Panel();
            labelTitle = new Label();
            panelToolbar = new Panel();
            labelCameraDevicePrompt = new Label();
            comboBoxCameraDevices = new ComboBox();
            buttonToggleLiveView = new Button();
            buttonCaptureSnapshot = new Button();
            labelRecordingStatus = new Label();
            buttonToggleAutoRecording = new Button();
            tableLayoutPanelFeeds = new TableLayoutPanel();
            panelLiveContainer = new Panel();
            pictureBoxLiveFeed = new PictureBox();
            labelLiveTitle = new Label();
            panelCaptureContainer = new Panel();
            pictureBoxLastCapture = new PictureBox();
            labelCaptureTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)picIconToggleLiveView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconCaptureSnapshot).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picIconToggleAutoRecording).BeginInit();
            panelHeader.SuspendLayout();
            panelToolbar.SuspendLayout();
            tableLayoutPanelFeeds.SuspendLayout();
            panelLiveContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLiveFeed).BeginInit();
            panelCaptureContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLastCapture).BeginInit();
            SuspendLayout();
            // 
            // picIconToggleLiveView
            // 
            picIconToggleLiveView.BackColor = Color.FromArgb(2, 132, 199);
            picIconToggleLiveView.Cursor = Cursors.Hand;
            picIconToggleLiveView.Image = Resources._087_camara_encender;
            picIconToggleLiveView.Location = new Point(230, 24);
            picIconToggleLiveView.Name = "picIconToggleLiveView";
            picIconToggleLiveView.Size = new Size(32, 38);
            picIconToggleLiveView.SizeMode = PictureBoxSizeMode.Zoom;
            picIconToggleLiveView.TabIndex = 99;
            picIconToggleLiveView.TabStop = false;
            // 
            // picIconCaptureSnapshot
            // 
            picIconCaptureSnapshot.BackColor = Color.FromArgb(255, 255, 255);
            picIconCaptureSnapshot.Cursor = Cursors.Hand;
            picIconCaptureSnapshot.Image = Resources._086_capturar_foto;
            picIconCaptureSnapshot.Location = new Point(435, 24);
            picIconCaptureSnapshot.Name = "picIconCaptureSnapshot";
            picIconCaptureSnapshot.Size = new Size(32, 38);
            picIconCaptureSnapshot.SizeMode = PictureBoxSizeMode.Zoom;
            picIconCaptureSnapshot.TabIndex = 99;
            picIconCaptureSnapshot.TabStop = false;
            // 
            // picIconToggleAutoRecording
            // 
            picIconToggleAutoRecording.BackColor = Color.FromArgb(239, 68, 68);
            picIconToggleAutoRecording.Cursor = Cursors.Hand;
            picIconToggleAutoRecording.Image = Resources._095_bloqueo_operativo;
            picIconToggleAutoRecording.Location = new Point(947, 25);
            picIconToggleAutoRecording.Name = "picIconToggleAutoRecording";
            picIconToggleAutoRecording.Size = new Size(30, 37);
            picIconToggleAutoRecording.SizeMode = PictureBoxSizeMode.Zoom;
            picIconToggleAutoRecording.TabIndex = 99;
            picIconToggleAutoRecording.TabStop = false;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1131, 56);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(16, 16);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(442, 30);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "MONITOREO Y CÁMARAS DE SEGURIDAD";
            // 
            // panelToolbar
            // 
            panelToolbar.BackColor = Color.White;
            panelToolbar.Controls.Add(labelCameraDevicePrompt);
            panelToolbar.Controls.Add(comboBoxCameraDevices);
            panelToolbar.Controls.Add(picIconToggleLiveView);
            panelToolbar.Controls.Add(buttonToggleLiveView);
            panelToolbar.Controls.Add(picIconCaptureSnapshot);
            panelToolbar.Controls.Add(buttonCaptureSnapshot);
            panelToolbar.Controls.Add(labelRecordingStatus);
            panelToolbar.Controls.Add(picIconToggleAutoRecording);
            panelToolbar.Controls.Add(buttonToggleAutoRecording);
            panelToolbar.Dock = DockStyle.Top;
            panelToolbar.Location = new Point(0, 56);
            panelToolbar.Name = "panelToolbar";
            panelToolbar.Padding = new Padding(16, 12, 16, 12);
            panelToolbar.Size = new Size(1131, 70);
            panelToolbar.TabIndex = 1;
            // 
            // labelCameraDevicePrompt
            // 
            labelCameraDevicePrompt.AutoSize = true;
            labelCameraDevicePrompt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelCameraDevicePrompt.Location = new Point(16, 12);
            labelCameraDevicePrompt.Name = "labelCameraDevicePrompt";
            labelCameraDevicePrompt.Size = new Size(91, 20);
            labelCameraDevicePrompt.TabIndex = 0;
            labelCameraDevicePrompt.Text = "Dispositivo:";
            // 
            // comboBoxCameraDevices
            // 
            comboBoxCameraDevices.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCameraDevices.Font = new Font("Segoe UI", 10F);
            comboBoxCameraDevices.Location = new Point(16, 32);
            comboBoxCameraDevices.Name = "comboBoxCameraDevices";
            comboBoxCameraDevices.Size = new Size(200, 31);
            comboBoxCameraDevices.TabIndex = 1;
            // 
            // buttonToggleLiveView
            // 
            buttonToggleLiveView.BackColor = Color.FromArgb(2, 132, 199);
            buttonToggleLiveView.FlatAppearance.BorderSize = 0;
            buttonToggleLiveView.FlatStyle = FlatStyle.Flat;
            buttonToggleLiveView.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonToggleLiveView.ForeColor = Color.White;
            buttonToggleLiveView.Location = new Point(230, 24);
            buttonToggleLiveView.Name = "buttonToggleLiveView";
            buttonToggleLiveView.Size = new Size(199, 38);
            buttonToggleLiveView.TabIndex = 2;
            buttonToggleLiveView.Text = "ACTIVAR CÁMARA";
            buttonToggleLiveView.UseVisualStyleBackColor = false;
            // 
            // buttonCaptureSnapshot
            // 
            buttonCaptureSnapshot.FlatStyle = FlatStyle.Flat;
            buttonCaptureSnapshot.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonCaptureSnapshot.Location = new Point(435, 24);
            buttonCaptureSnapshot.Name = "buttonCaptureSnapshot";
            buttonCaptureSnapshot.Size = new Size(187, 38);
            buttonCaptureSnapshot.TabIndex = 3;
            buttonCaptureSnapshot.Text = "CAPTURAR FOTO";
            buttonCaptureSnapshot.UseVisualStyleBackColor = true;
            // 
            // labelRecordingStatus
            // 
            labelRecordingStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelRecordingStatus.ForeColor = Color.FromArgb(16, 185, 129);
            labelRecordingStatus.Location = new Point(644, 32);
            labelRecordingStatus.Name = "labelRecordingStatus";
            labelRecordingStatus.Size = new Size(280, 22);
            labelRecordingStatus.TabIndex = 4;
            labelRecordingStatus.Text = "ESTADO: AUTO-GRABACIÓN ACTIVA";
            // 
            // buttonToggleAutoRecording
            // 
            buttonToggleAutoRecording.BackColor = Color.FromArgb(239, 68, 68);
            buttonToggleAutoRecording.FlatAppearance.BorderSize = 0;
            buttonToggleAutoRecording.FlatStyle = FlatStyle.Flat;
            buttonToggleAutoRecording.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonToggleAutoRecording.ForeColor = Color.White;
            buttonToggleAutoRecording.Location = new Point(947, 25);
            buttonToggleAutoRecording.Name = "buttonToggleAutoRecording";
            buttonToggleAutoRecording.Size = new Size(165, 38);
            buttonToggleAutoRecording.TabIndex = 5;
            buttonToggleAutoRecording.Text = "PAUSAR AUTO";
            buttonToggleAutoRecording.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanelFeeds
            // 
            tableLayoutPanelFeeds.ColumnCount = 2;
            tableLayoutPanelFeeds.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelFeeds.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelFeeds.Controls.Add(panelLiveContainer, 0, 0);
            tableLayoutPanelFeeds.Controls.Add(panelCaptureContainer, 1, 0);
            tableLayoutPanelFeeds.Dock = DockStyle.Fill;
            tableLayoutPanelFeeds.Location = new Point(0, 126);
            tableLayoutPanelFeeds.Name = "tableLayoutPanelFeeds";
            tableLayoutPanelFeeds.Padding = new Padding(16);
            tableLayoutPanelFeeds.RowCount = 1;
            tableLayoutPanelFeeds.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelFeeds.Size = new Size(1131, 554);
            tableLayoutPanelFeeds.TabIndex = 2;
            // 
            // panelLiveContainer
            // 
            panelLiveContainer.Controls.Add(pictureBoxLiveFeed);
            panelLiveContainer.Controls.Add(labelLiveTitle);
            panelLiveContainer.Dock = DockStyle.Fill;
            panelLiveContainer.Location = new Point(19, 19);
            panelLiveContainer.Name = "panelLiveContainer";
            panelLiveContainer.Size = new Size(518, 516);
            panelLiveContainer.TabIndex = 0;
            // 
            // pictureBoxLiveFeed
            // 
            pictureBoxLiveFeed.BackColor = Color.Black;
            pictureBoxLiveFeed.Dock = DockStyle.Fill;
            pictureBoxLiveFeed.Location = new Point(0, 28);
            pictureBoxLiveFeed.Name = "pictureBoxLiveFeed";
            pictureBoxLiveFeed.Size = new Size(518, 488);
            pictureBoxLiveFeed.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLiveFeed.TabIndex = 1;
            pictureBoxLiveFeed.TabStop = false;
            // 
            // labelLiveTitle
            // 
            labelLiveTitle.Dock = DockStyle.Top;
            labelLiveTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelLiveTitle.Location = new Point(0, 0);
            labelLiveTitle.Name = "labelLiveTitle";
            labelLiveTitle.Size = new Size(518, 28);
            labelLiveTitle.TabIndex = 0;
            labelLiveTitle.Text = "Transmisión en Vivo";
            // 
            // panelCaptureContainer
            // 
            panelCaptureContainer.Controls.Add(pictureBoxLastCapture);
            panelCaptureContainer.Controls.Add(labelCaptureTitle);
            panelCaptureContainer.Dock = DockStyle.Fill;
            panelCaptureContainer.Location = new Point(543, 19);
            panelCaptureContainer.Name = "panelCaptureContainer";
            panelCaptureContainer.Size = new Size(518, 516);
            panelCaptureContainer.TabIndex = 1;
            // 
            // pictureBoxLastCapture
            // 
            pictureBoxLastCapture.BackColor = Color.White;
            pictureBoxLastCapture.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxLastCapture.Dock = DockStyle.Fill;
            pictureBoxLastCapture.Location = new Point(0, 28);
            pictureBoxLastCapture.Name = "pictureBoxLastCapture";
            pictureBoxLastCapture.Size = new Size(518, 488);
            pictureBoxLastCapture.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLastCapture.TabIndex = 1;
            pictureBoxLastCapture.TabStop = false;
            // 
            // labelCaptureTitle
            // 
            labelCaptureTitle.Dock = DockStyle.Top;
            labelCaptureTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            labelCaptureTitle.Location = new Point(0, 0);
            labelCaptureTitle.Name = "labelCaptureTitle";
            labelCaptureTitle.Size = new Size(518, 28);
            labelCaptureTitle.TabIndex = 0;
            labelCaptureTitle.Text = "Última Instantánea de Seguridad";
            // 
            // FormSecurityCameras
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1131, 680);
            Controls.Add(tableLayoutPanelFeeds);
            Controls.Add(panelToolbar);
            Controls.Add(panelHeader);
            Name = "FormSecurityCameras";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cámaras de Seguridad";
            ((System.ComponentModel.ISupportInitialize)picIconToggleLiveView).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconCaptureSnapshot).EndInit();
            ((System.ComponentModel.ISupportInitialize)picIconToggleAutoRecording).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelToolbar.ResumeLayout(false);
            panelToolbar.PerformLayout();
            tableLayoutPanelFeeds.ResumeLayout(false);
            panelLiveContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLiveFeed).EndInit();
            panelCaptureContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLastCapture).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelToolbar;
        private System.Windows.Forms.Label labelCameraDevicePrompt;
        private System.Windows.Forms.ComboBox comboBoxCameraDevices;
        private System.Windows.Forms.Button buttonToggleLiveView;
        private System.Windows.Forms.Button buttonCaptureSnapshot;
        private System.Windows.Forms.Label labelRecordingStatus;
        private System.Windows.Forms.Button buttonToggleAutoRecording;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFeeds;
        private System.Windows.Forms.Panel panelLiveContainer;
        private System.Windows.Forms.Label labelLiveTitle;
        private System.Windows.Forms.PictureBox pictureBoxLiveFeed;
        private System.Windows.Forms.Panel panelCaptureContainer;
        private System.Windows.Forms.Label labelCaptureTitle;
        private System.Windows.Forms.PictureBox pictureBoxLastCapture;
        private System.Windows.Forms.PictureBox picIconToggleLiveView;
        private System.Windows.Forms.PictureBox picIconCaptureSnapshot;
        private System.Windows.Forms.PictureBox picIconToggleAutoRecording;
    }
}
