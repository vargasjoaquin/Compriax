using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.WinFormsUI.Helpers;

namespace CompriaxSystem.WinFormsUI
{
    public partial class FormSecurityCameras : Form
    {
        private readonly ICameraService _cameraService;
        private readonly ISecurityRecordingService _recordingService;
        private bool _isViewingLive = false;

        public FormSecurityCameras(ICameraService cameraService, ISecurityRecordingService recordingService)
        {
            _cameraService = cameraService;
            _recordingService = recordingService;
            InitializeComponent();
            
            ButtonIconOverlayHelper.BindEvents(this.buttonToggleLiveView, this.picIconToggleLiveView);
            ButtonIconOverlayHelper.BindEvents(this.buttonCaptureSnapshot, this.picIconCaptureSnapshot);
            ButtonIconOverlayHelper.BindEvents(this.buttonToggleAutoRecording, this.picIconToggleAutoRecording);
            

            this.Load += (s, e) => InitializeSecurityCamerasForm();
            this.buttonToggleLiveView.Click += (s, e) => ExecuteToggleCameraLiveStreaming();
            this.buttonCaptureSnapshot.Click += (s, e) => ExecuteCaptureSecuritySnapshot();
            this.buttonToggleAutoRecording.Click += (s, e) => ExecuteToggleAutoRecordingMode();
        }

        private void InitializeSecurityCamerasForm()
        {
            using (new WaitCursorHelper(this))
            {
                comboBoxCameraDevices.DataSource = _cameraService.GetAvailableCameras().ToList();
                comboBoxCameraDevices.Enabled = false;
                UpdateRecordingStatusIndicators();
            }
        }

        private void ExecuteToggleCameraLiveStreaming()
        {
            if (!_isViewingLive)
            {
                _recordingService.Start();
                _recordingService.FrameCaptured += HandleCameraFrameCaptured;
                _isViewingLive = true;
                buttonToggleLiveView.Text = "DESACTIVAR CÁMARA";
                buttonToggleLiveView.BackColor = Color.Firebrick;
            }
            else
            {
                _recordingService.FrameCaptured -= HandleCameraFrameCaptured;
                _isViewingLive = false;
                buttonToggleLiveView.Text = "ACTIVAR CÁMARA";
                buttonToggleLiveView.BackColor = Color.FromArgb(2, 132, 199);
            }
        }

        private void ExecuteCaptureSecuritySnapshot()
        {
            if (pictureBoxLiveFeed.Image == null)
            {
                UIHelper.WarnMessage(this, "No hay una transmisión de cámara activa en este momento para tomar una fotografía.", "Cámara Inactiva");
                return;
            }

            pictureBoxLastCapture.Image?.Dispose();
            pictureBoxLastCapture.Image = (Bitmap)pictureBoxLiveFeed.Image.Clone();

            UIHelper.InfoMessage(this, "Instantánea capturada exitosamente.", "Captura de Seguridad");
        }

        private void ExecuteToggleAutoRecordingMode()
        {
            _recordingService.SetAutoRecordingEnabled(!_recordingService.IsAutoRecordingEnabled);
            UpdateRecordingStatusIndicators();
        }

        private void HandleCameraFrameCaptured(Bitmap capturedVideoFrame)
        {
            if (!this.IsDisposed)
            {
                this.BeginInvoke(new Action(() =>
                {
                    pictureBoxLiveFeed.Image?.Dispose();
                    pictureBoxLiveFeed.Image = capturedVideoFrame;
                }));
            }
            else
                capturedVideoFrame.Dispose();
        }

        private void UpdateRecordingStatusIndicators()
        {
            bool isAutoRecordingEnabled = _recordingService.IsAutoRecordingEnabled;
            labelRecordingStatus.Text = isAutoRecordingEnabled ? "GRABACIÓN AUTOMÁTICA ACTIVA" : "MODO MANUAL";
            labelRecordingStatus.ImageAlign = ContentAlignment.MiddleLeft;

            buttonToggleAutoRecording.Text = isAutoRecordingEnabled ? "PAUSAR AUTO" : "ACTIVAR AUTO";
            buttonToggleAutoRecording.ImageAlign = ContentAlignment.MiddleLeft;
            buttonToggleAutoRecording.TextImageRelation = TextImageRelation.ImageBeforeText;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_isViewingLive)
                _recordingService.FrameCaptured -= HandleCameraFrameCaptured;

            base.OnFormClosing(e);
        }
    }
}










