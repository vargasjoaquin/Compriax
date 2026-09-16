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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.labelCameraDevicePrompt = new System.Windows.Forms.Label();
            this.comboBoxCameraDevices = new System.Windows.Forms.ComboBox();
            this.buttonToggleLiveView = new System.Windows.Forms.Button();
            this.buttonCaptureSnapshot = new System.Windows.Forms.Button();
            this.labelRecordingStatus = new System.Windows.Forms.Label();
            this.buttonToggleAutoRecording = new System.Windows.Forms.Button();
            this.tableLayoutPanelFeeds = new System.Windows.Forms.TableLayoutPanel();
            this.panelLiveContainer = new System.Windows.Forms.Panel();
            this.labelLiveTitle = new System.Windows.Forms.Label();
            this.pictureBoxLiveFeed = new System.Windows.Forms.PictureBox();
            this.panelCaptureContainer = new System.Windows.Forms.Panel();
            this.labelCaptureTitle = new System.Windows.Forms.Label();
            this.pictureBoxLastCapture = new System.Windows.Forms.PictureBox();

            this.panelHeader.SuspendLayout();
            this.panelToolbar.SuspendLayout();
            this.tableLayoutPanelFeeds.SuspendLayout();
            this.panelLiveContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLiveFeed)).BeginInit();
            this.panelCaptureContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLastCapture)).BeginInit();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1080, 56);
            this.panelHeader.TabIndex = 0;

            // labelTitle
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(16, 16);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(445, 25);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "MONITOREO Y CÁMARAS DE SEGURIDAD (CCTV)";

            // panelToolbar
            this.panelToolbar.BackColor = System.Drawing.Color.White;
            this.panelToolbar.Controls.Add(this.labelCameraDevicePrompt);
            this.panelToolbar.Controls.Add(this.comboBoxCameraDevices);
            this.panelToolbar.Controls.Add(this.buttonToggleLiveView);
            this.panelToolbar.Controls.Add(this.buttonCaptureSnapshot);
            this.panelToolbar.Controls.Add(this.labelRecordingStatus);
            this.panelToolbar.Controls.Add(this.buttonToggleAutoRecording);
            this.panelToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolbar.Location = new System.Drawing.Point(0, 56);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.panelToolbar.Size = new System.Drawing.Size(1080, 70);
            this.panelToolbar.TabIndex = 1;

            // labelCameraDevicePrompt
            this.labelCameraDevicePrompt.AutoSize = true;
            this.labelCameraDevicePrompt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelCameraDevicePrompt.Location = new System.Drawing.Point(16, 12);
            this.labelCameraDevicePrompt.Name = "labelCameraDevicePrompt";
            this.labelCameraDevicePrompt.Size = new System.Drawing.Size(74, 15);
            this.labelCameraDevicePrompt.TabIndex = 0;
            this.labelCameraDevicePrompt.Text = "Dispositivo:";

            // comboBoxCameraDevices
            this.comboBoxCameraDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCameraDevices.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxCameraDevices.Location = new System.Drawing.Point(16, 32);
            this.comboBoxCameraDevices.Name = "comboBoxCameraDevices";
            this.comboBoxCameraDevices.Size = new System.Drawing.Size(200, 25);
            this.comboBoxCameraDevices.TabIndex = 1;

            // buttonToggleLiveView
            this.buttonToggleLiveView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(132)))), ((int)(((byte)(199)))));
            this.buttonToggleLiveView.FlatAppearance.BorderSize = 0;
            this.buttonToggleLiveView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToggleLiveView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonToggleLiveView.ForeColor = System.Drawing.Color.White;
            this.buttonToggleLiveView.Location = new System.Drawing.Point(230, 24);
            this.buttonToggleLiveView.Name = "buttonToggleLiveView";
            this.buttonToggleLiveView.Size = new System.Drawing.Size(180, 38);
            this.buttonToggleLiveView.TabIndex = 2;
            this.buttonToggleLiveView.Text = "ACTIVAR CÁMARA";
            this.buttonToggleLiveView.UseVisualStyleBackColor = false;

            // buttonCaptureSnapshot
            this.buttonCaptureSnapshot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCaptureSnapshot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonCaptureSnapshot.Location = new System.Drawing.Point(420, 24);
            this.buttonCaptureSnapshot.Name = "buttonCaptureSnapshot";
            this.buttonCaptureSnapshot.Size = new System.Drawing.Size(170, 38);
            this.buttonCaptureSnapshot.TabIndex = 3;
            this.buttonCaptureSnapshot.Text = "CAPTURAR FOTO";
            this.buttonCaptureSnapshot.UseVisualStyleBackColor = true;

            // labelRecordingStatus
            this.labelRecordingStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelRecordingStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.labelRecordingStatus.Location = new System.Drawing.Point(610, 32);
            this.labelRecordingStatus.Name = "labelRecordingStatus";
            this.labelRecordingStatus.Size = new System.Drawing.Size(280, 22);
            this.labelRecordingStatus.TabIndex = 4;
            this.labelRecordingStatus.Text = "ESTADO: AUTO-GRABACIÓN ACTIVA";

            // buttonToggleAutoRecording
            this.buttonToggleAutoRecording.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.buttonToggleAutoRecording.FlatAppearance.BorderSize = 0;
            this.buttonToggleAutoRecording.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToggleAutoRecording.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonToggleAutoRecording.ForeColor = System.Drawing.Color.White;
            this.buttonToggleAutoRecording.Location = new System.Drawing.Point(900, 24);
            this.buttonToggleAutoRecording.Name = "buttonToggleAutoRecording";
            this.buttonToggleAutoRecording.Size = new System.Drawing.Size(150, 38);
            this.buttonToggleAutoRecording.TabIndex = 5;
            this.buttonToggleAutoRecording.Text = "PAUSAR AUTO";
            this.buttonToggleAutoRecording.UseVisualStyleBackColor = false;

            // tableLayoutPanelFeeds
            this.tableLayoutPanelFeeds.ColumnCount = 2;
            this.tableLayoutPanelFeeds.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelFeeds.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelFeeds.Controls.Add(this.panelLiveContainer, 0, 0);
            this.tableLayoutPanelFeeds.Controls.Add(this.panelCaptureContainer, 1, 0);
            this.tableLayoutPanelFeeds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFeeds.Location = new System.Drawing.Point(0, 126);
            this.tableLayoutPanelFeeds.Name = "tableLayoutPanelFeeds";
            this.tableLayoutPanelFeeds.Padding = new System.Windows.Forms.Padding(16);
            this.tableLayoutPanelFeeds.RowCount = 1;
            this.tableLayoutPanelFeeds.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelFeeds.Size = new System.Drawing.Size(1080, 554);
            this.tableLayoutPanelFeeds.TabIndex = 2;

            // panelLiveContainer
            this.panelLiveContainer.Controls.Add(this.pictureBoxLiveFeed);
            this.panelLiveContainer.Controls.Add(this.labelLiveTitle);
            this.panelLiveContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLiveContainer.Location = new System.Drawing.Point(19, 19);
            this.panelLiveContainer.Name = "panelLiveContainer";
            this.panelLiveContainer.Size = new System.Drawing.Size(518, 516);
            this.panelLiveContainer.TabIndex = 0;

            // labelLiveTitle
            this.labelLiveTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelLiveTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.labelLiveTitle.Location = new System.Drawing.Point(0, 0);
            this.labelLiveTitle.Name = "labelLiveTitle";
            this.labelLiveTitle.Size = new System.Drawing.Size(518, 28);
            this.labelLiveTitle.TabIndex = 0;
            this.labelLiveTitle.Text = "Transmisión en Vivo";

            // pictureBoxLiveFeed
            this.pictureBoxLiveFeed.BackColor = System.Drawing.Color.Black;
            this.pictureBoxLiveFeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLiveFeed.Location = new System.Drawing.Point(0, 28);
            this.pictureBoxLiveFeed.Name = "pictureBoxLiveFeed";
            this.pictureBoxLiveFeed.Size = new System.Drawing.Size(518, 488);
            this.pictureBoxLiveFeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLiveFeed.TabIndex = 1;
            this.pictureBoxLiveFeed.TabStop = false;

            // panelCaptureContainer
            this.panelCaptureContainer.Controls.Add(this.pictureBoxLastCapture);
            this.panelCaptureContainer.Controls.Add(this.labelCaptureTitle);
            this.panelCaptureContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCaptureContainer.Location = new System.Drawing.Point(543, 19);
            this.panelCaptureContainer.Name = "panelCaptureContainer";
            this.panelCaptureContainer.Size = new System.Drawing.Size(518, 516);
            this.panelCaptureContainer.TabIndex = 1;

            // labelCaptureTitle
            this.labelCaptureTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCaptureTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.labelCaptureTitle.Location = new System.Drawing.Point(0, 0);
            this.labelCaptureTitle.Name = "labelCaptureTitle";
            this.labelCaptureTitle.Size = new System.Drawing.Size(518, 28);
            this.labelCaptureTitle.TabIndex = 0;
            this.labelCaptureTitle.Text = "Última Instantánea de Seguridad";

            // pictureBoxLastCapture
            this.pictureBoxLastCapture.BackColor = System.Drawing.Color.White;
            this.pictureBoxLastCapture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxLastCapture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLastCapture.Location = new System.Drawing.Point(0, 28);
            this.pictureBoxLastCapture.Name = "pictureBoxLastCapture";
            this.pictureBoxLastCapture.Size = new System.Drawing.Size(518, 488);
            this.pictureBoxLastCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLastCapture.TabIndex = 1;
            this.pictureBoxLastCapture.TabStop = false;

            // Form Properties
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1080, 680);
            this.Controls.Add(this.tableLayoutPanelFeeds);
            this.Controls.Add(this.panelToolbar);
            this.Controls.Add(this.panelHeader);
            this.Name = "FormSecurityCameras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cámaras CCTV";

            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelToolbar.ResumeLayout(false);
            this.panelToolbar.PerformLayout();
            this.tableLayoutPanelFeeds.ResumeLayout(false);
            this.panelLiveContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLiveFeed)).EndInit();
            this.panelCaptureContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLastCapture)).EndInit();
            this.ResumeLayout(false);
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
    }
}