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

            ApplyIcons();

            this.Load += (s, e) => InitializeForm();
            this.btnActivate.Click += (s, e) => ExecuteToggleLiveViewAction();
            this.btnCapture.Click += (s, e) => ExecuteCaptureSnapshotAction();
            this.btnToggleAutoRecording.Click += (s, e) => ExecuteToggleRecordingAction();
        }

        private void ApplyIcons()
        {
            btnActivate.Image = UIIconHelper.CamaraEncender;
            btnActivate.ImageAlign = ContentAlignment.MiddleLeft;
            btnActivate.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnCapture.Image = UIIconHelper.CapturarFoto;
            btnCapture.ImageAlign = ContentAlignment.MiddleLeft;
            btnCapture.TextImageRelation = TextImageRelation.ImageBeforeText;
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
                btnActivate.Text = "DESACTIVAR CÁMARA";
                btnActivate.Image = UIIconHelper.CamaraEncender;
                btnActivate.BackColor = Color.Firebrick;
            }
            else
            {
                _recordingService.FrameCaptured -= OnFrameCaptured;
                _isViewingLive = false;
                btnActivate.Text = "ACTIVAR CÁMARA";
                btnActivate.Image = UIIconHelper.CamaraEncender;
                btnActivate.BackColor = Color.FromArgb(2, 132, 199);
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
            bool isAuto = _recordingService.IsAutoRecordingEnabled;
            lblRecordingStatus.Text = isAuto ? "GRABACIÓN AUTOMÁTICA ACTIVA" : "MODO MANUAL";
            lblRecordingStatus.Image = isAuto ? UIIconHelper.EstadoActivo : UIIconHelper.EstadoInactivo;
            lblRecordingStatus.ImageAlign = ContentAlignment.MiddleLeft;

            btnToggleAutoRecording.Text = isAuto ? "PAUSAR AUTO" : "ACTIVAR AUTO";
            btnToggleAutoRecording.Image = isAuto ? UIIconHelper.BloqueoOperativo : UIIconHelper.Exito;
            btnToggleAutoRecording.ImageAlign = ContentAlignment.MiddleLeft;
            btnToggleAutoRecording.TextImageRelation = TextImageRelation.ImageBeforeText;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_isViewingLive)
                _recordingService.FrameCaptured -= OnFrameCaptured;

            base.OnFormClosing(e);
        }
    }
}