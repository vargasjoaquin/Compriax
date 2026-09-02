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

            this.Load += (s, e) => InitializeForm();
            this.btnActivate.Click += (s, e) => ExecuteToggleLiveViewAction();
            this.btnCapture.Click += (s, e) => ExecuteCaptureSnapshotAction();
            this.btnToggleAutoRecording.Click += (s, e) => ExecuteToggleRecordingAction();
        }

        private void InitializeForm()
        {
            using (new WaitCursorHelper(this))
            {
                cboCameraDevices.DataSource = _cameraService.GetAvailableCameras().ToList();
                cboCameraDevices.Enabled = false;
                UpdateRecordingStatusUI();
            }
        }

        private void ExecuteToggleLiveViewAction()
        {
            if (!_isViewingLive)
            {
                _recordingService.Start();
                _recordingService.FrameCaptured += OnFrameCaptured;
                _isViewingLive = true;
                btnActivate.Text = "DESACTIVAR";
                btnActivate.BackColor = Color.Firebrick;
            }
            else
            {
                _recordingService.FrameCaptured -= OnFrameCaptured;
                _isViewingLive = false;
                btnActivate.Text = "ACTVAR";
                btnActivate.BackColor = Color.FromArgb(80, 80, 80);
            }
        }

        private void ExecuteCaptureSnapshotAction()
        {
            if (picLiveFeed.Image == null)
            {
                UIHelper.WarnMessage(this, "No hay una transmisión de cámara activa en este momento para tomar una fotografía.", "Cámara Inactiva");
                return;
            }

            picLastCapture.Image?.Dispose();
            picLastCapture.Image = (Bitmap)picLiveFeed.Image.Clone();

            UIHelper.InfoMessage(this, "Instantánea capturada exitosamente.", "Captura de Seguridad");
        }

        private void ExecuteToggleRecordingAction()
        {
            _recordingService.SetAutoRecordingEnabled(!_recordingService.IsAutoRecordingEnabled);
            UpdateRecordingStatusUI();
        }

        private void OnFrameCaptured(Bitmap frame)
        {
            if (!this.IsDisposed)
            {
                this.BeginInvoke(new Action(() =>
                {
                    picLiveFeed.Image?.Dispose();
                    picLiveFeed.Image = frame;
                }));
            }
            else
                frame.Dispose();
        }

        private void UpdateRecordingStatusUI()
        {
            lblRecordingStatus.Text = _recordingService.IsAutoRecordingEnabled ? "GRABACIÓN AUTOMÁTICA ACTIVA" : "MODO MANUAL";
            btnToggleAutoRecording.Text = _recordingService.IsAutoRecordingEnabled ? "DESACTIVAR AUTO" : "ACTIVAR AUTO";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_isViewingLive)
                _recordingService.FrameCaptured -= OnFrameCaptured;

            base.OnFormClosing(e);
        }
    }
}
