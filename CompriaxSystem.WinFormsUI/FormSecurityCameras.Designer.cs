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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblCamSelect = new System.Windows.Forms.Label();
            this.cboCameraDevices = new System.Windows.Forms.ComboBox();
            this.btnActivate = new System.Windows.Forms.Button();
            this.btnCapture = new System.Windows.Forms.Button();
            this.lblRecordingStatus = new System.Windows.Forms.Label();
            this.btnToggleAutoRecording = new System.Windows.Forms.Button();
            this.pnlFeeds = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLiveContainer = new System.Windows.Forms.Panel();
            this.lblLiveTitle = new System.Windows.Forms.Label();
            this.picLiveFeed = new System.Windows.Forms.PictureBox();
            this.pnlCaptureContainer = new System.Windows.Forms.Panel();
            this.lblCaptureTitle = new System.Windows.Forms.Label();
            this.picLastCapture = new System.Windows.Forms.PictureBox();

            this.pnlHeader.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlFeeds.SuspendLayout();
            this.pnlLiveContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLiveFeed)).BeginInit();
            this.pnlCaptureContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLastCapture)).BeginInit();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1080, 56);
            this.pnlHeader.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(16, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(445, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "MONITOREO Y CÁMARAS DE SEGURIDAD (CCTV)";

            // pnlToolbar
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Controls.Add(this.lblCamSelect);
            this.pnlToolbar.Controls.Add(this.cboCameraDevices);
            this.pnlToolbar.Controls.Add(this.btnActivate);
            this.pnlToolbar.Controls.Add(this.btnCapture);
            this.pnlToolbar.Controls.Add(this.lblRecordingStatus);
            this.pnlToolbar.Controls.Add(this.btnToggleAutoRecording);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 56);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlToolbar.Size = new System.Drawing.Size(1080, 70);
            this.pnlToolbar.TabIndex = 1;

            // lblCamSelect
            this.lblCamSelect.AutoSize = true;
            this.lblCamSelect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCamSelect.Location = new System.Drawing.Point(16, 12);
            this.lblCamSelect.Name = "lblCamSelect";
            this.lblCamSelect.Size = new System.Drawing.Size(74, 15);
            this.lblCamSelect.TabIndex = 0;
            this.lblCamSelect.Text = "Dispositivo:";

            // cboCameraDevices
            this.cboCameraDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCameraDevices.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCameraDevices.Location = new System.Drawing.Point(16, 32);
            this.cboCameraDevices.Name = "cboCameraDevices";
            this.cboCameraDevices.Size = new System.Drawing.Size(200, 25);
            this.cboCameraDevices.TabIndex = 1;

            // btnActivate
            this.btnActivate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(132)))), ((int)(((byte)(199)))));
            this.btnActivate.FlatAppearance.BorderSize = 0;
            this.btnActivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnActivate.ForeColor = System.Drawing.Color.White;
            this.btnActivate.Location = new System.Drawing.Point(230, 24);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(180, 38);
            this.btnActivate.TabIndex = 2;
            this.btnActivate.Text = "ACTIVAR CÁMARA";
            this.btnActivate.UseVisualStyleBackColor = false;

            // btnCapture
            this.btnCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapture.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCapture.Location = new System.Drawing.Point(420, 24);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(170, 38);
            this.btnCapture.TabIndex = 3;
            this.btnCapture.Text = "CAPTURAR FOTO";
            this.btnCapture.UseVisualStyleBackColor = true;

            // lblRecordingStatus
            this.lblRecordingStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRecordingStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblRecordingStatus.Location = new System.Drawing.Point(610, 32);
            this.lblRecordingStatus.Name = "lblRecordingStatus";
            this.lblRecordingStatus.Size = new System.Drawing.Size(280, 22);
            this.lblRecordingStatus.TabIndex = 4;
            this.lblRecordingStatus.Text = "ESTADO: AUTO-GRABACIÓN ACTIVA";

            // btnToggleAutoRecording
            this.btnToggleAutoRecording.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnToggleAutoRecording.FlatAppearance.BorderSize = 0;
            this.btnToggleAutoRecording.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleAutoRecording.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnToggleAutoRecording.ForeColor = System.Drawing.Color.White;
            this.btnToggleAutoRecording.Location = new System.Drawing.Point(900, 24);
            this.btnToggleAutoRecording.Name = "btnToggleAutoRecording";
            this.btnToggleAutoRecording.Size = new System.Drawing.Size(150, 38);
            this.btnToggleAutoRecording.TabIndex = 5;
            this.btnToggleAutoRecording.Text = "PAUSAR AUTO";
            this.btnToggleAutoRecording.UseVisualStyleBackColor = false;

            // pnlFeeds
            this.pnlFeeds.ColumnCount = 2;
            this.pnlFeeds.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlFeeds.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlFeeds.Controls.Add(this.pnlLiveContainer, 0, 0);
            this.pnlFeeds.Controls.Add(this.pnlCaptureContainer, 1, 0);
            this.pnlFeeds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFeeds.Location = new System.Drawing.Point(0, 126);
            this.pnlFeeds.Name = "pnlFeeds";
            this.pnlFeeds.Padding = new System.Windows.Forms.Padding(16);
            this.pnlFeeds.RowCount = 1;
            this.pnlFeeds.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlFeeds.Size = new System.Drawing.Size(1080, 554);
            this.pnlFeeds.TabIndex = 2;

            // pnlLiveContainer
            this.pnlLiveContainer.Controls.Add(this.picLiveFeed);
            this.pnlLiveContainer.Controls.Add(this.lblLiveTitle);
            this.pnlLiveContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLiveContainer.Location = new System.Drawing.Point(19, 19);
            this.pnlLiveContainer.Name = "pnlLiveContainer";
            this.pnlLiveContainer.Size = new System.Drawing.Size(518, 516);
            this.pnlLiveContainer.TabIndex = 0;

            // lblLiveTitle
            this.lblLiveTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLiveTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblLiveTitle.Location = new System.Drawing.Point(0, 0);
            this.lblLiveTitle.Name = "lblLiveTitle";
            this.lblLiveTitle.Size = new System.Drawing.Size(518, 28);
            this.lblLiveTitle.TabIndex = 0;
            this.lblLiveTitle.Text = "Transmisión en Vivo";

            // picLiveFeed
            this.picLiveFeed.BackColor = System.Drawing.Color.Black;
            this.picLiveFeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLiveFeed.Location = new System.Drawing.Point(0, 28);
            this.picLiveFeed.Name = "picLiveFeed";
            this.picLiveFeed.Size = new System.Drawing.Size(518, 488);
            this.picLiveFeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLiveFeed.TabIndex = 1;
            this.picLiveFeed.TabStop = false;

            // pnlCaptureContainer
            this.pnlCaptureContainer.Controls.Add(this.picLastCapture);
            this.pnlCaptureContainer.Controls.Add(this.lblCaptureTitle);
            this.pnlCaptureContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCaptureContainer.Location = new System.Drawing.Point(543, 19);
            this.pnlCaptureContainer.Name = "pnlCaptureContainer";
            this.pnlCaptureContainer.Size = new System.Drawing.Size(518, 516);
            this.pnlCaptureContainer.TabIndex = 1;

            // lblCaptureTitle
            this.lblCaptureTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCaptureTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCaptureTitle.Location = new System.Drawing.Point(0, 0);
            this.lblCaptureTitle.Name = "lblCaptureTitle";
            this.lblCaptureTitle.Size = new System.Drawing.Size(518, 28);
            this.lblCaptureTitle.TabIndex = 0;
            this.lblCaptureTitle.Text = "Última Instantánea de Seguridad";

            // picLastCapture
            this.picLastCapture.BackColor = System.Drawing.Color.White;
            this.picLastCapture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLastCapture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLastCapture.Location = new System.Drawing.Point(0, 28);
            this.picLastCapture.Name = "picLastCapture";
            this.picLastCapture.Size = new System.Drawing.Size(518, 488);
            this.picLastCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLastCapture.TabIndex = 1;
            this.picLastCapture.TabStop = false;

            // Form Properties
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1080, 680);
            this.Controls.Add(this.pnlFeeds);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FormSecurityCameras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cámaras CCTV";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlFeeds.ResumeLayout(false);
            this.pnlLiveContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLiveFeed)).EndInit();
            this.pnlCaptureContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLastCapture)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Label lblCamSelect;
        private System.Windows.Forms.ComboBox cboCameraDevices;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Label lblRecordingStatus;
        private System.Windows.Forms.Button btnToggleAutoRecording;
        private System.Windows.Forms.TableLayoutPanel pnlFeeds;
        private System.Windows.Forms.Panel pnlLiveContainer;
        private System.Windows.Forms.Label lblLiveTitle;
        private System.Windows.Forms.PictureBox picLiveFeed;
        private System.Windows.Forms.Panel pnlCaptureContainer;
        private System.Windows.Forms.Label lblCaptureTitle;
        private System.Windows.Forms.PictureBox picLastCapture;
    }
}