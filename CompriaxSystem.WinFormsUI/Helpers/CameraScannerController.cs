using CompriaxSystem.Application.Interfaces.Services;

namespace CompriaxSystem.WinFormsUI.Helpers
{
    public class CameraScannerController : IDisposable
    {
        private readonly ICameraService _cameraService;
        private readonly IBarcodeService _barcodeService;
        private readonly PictureBox _previewPictureBox;
        private readonly Button _toggleButton;
        private readonly Action<string> _onBarcodeScanned;

        private bool _isActive = false;
        private string _lastScannedCode = string.Empty;
        private DateTime _lastScanTime = DateTime.MinValue;
        private readonly TimeSpan _scanCooldown = TimeSpan.FromSeconds(2.5);

        public bool IsActive => _isActive;

        public CameraScannerController(ICameraService cameraService, IBarcodeService barcodeService, PictureBox previewPictureBox, Button toggleButton, Action<string> onBarcodeScanned)
        {
            _cameraService = cameraService;
            _barcodeService = barcodeService;
            _previewPictureBox = previewPictureBox;
            _toggleButton = toggleButton;
            _onBarcodeScanned = onBarcodeScanned;

            UpdateToggleButtonAppearance();
        }

        public void Toggle()
        {
            if (!_isActive)
                Start();
            else
                Stop();
        }

        public void Start(int cameraIndex = 0)
        {
            if (_isActive)
                return;

            try
            {
                _cameraService.StartStreaming(cameraIndex, OnFrameCaptured);
                _isActive = true;
                UpdateToggleButtonAppearance();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo inicializar la cámara seleccionada:\n{ex.Message}", "Error de Dispositivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Stop()
        {
            if (!_isActive)
                return;

            _cameraService.StopStreaming();
            _isActive = false;

            if (_previewPictureBox.Image != null)
            {
                _previewPictureBox.Image.Dispose();
                _previewPictureBox.Image = null;
            }

            UpdateToggleButtonAppearance();
        }

        private void OnFrameCaptured(Bitmap frame)
        {
            if (_previewPictureBox.IsDisposed)
            {
                frame.Dispose();
                return;
            }

            if (_previewPictureBox.InvokeRequired)
            {
                _previewPictureBox.BeginInvoke(new Action(() =>
                {
                    if (!_previewPictureBox.IsDisposed)
                    {
                        _previewPictureBox.Image?.Dispose();
                        _previewPictureBox.Image = (Bitmap)frame.Clone();
                    }
                }));
            }

            string? decodedBarcode = _barcodeService.DecodeBarcode(frame);

            if (!string.IsNullOrWhiteSpace(decodedBarcode))
            {
                bool isSameCode = decodedBarcode.Equals(_lastScannedCode, StringComparison.OrdinalIgnoreCase);
                bool isInCooldown = (DateTime.Now - _lastScanTime) < _scanCooldown;

                if (!isSameCode || !isInCooldown)
                {
                    _lastScannedCode = decodedBarcode;
                    _lastScanTime = DateTime.Now;

                    if (!_previewPictureBox.IsDisposed && _previewPictureBox.InvokeRequired)
                    {
                        _previewPictureBox.BeginInvoke(new Action(() =>
                        {
                            _onBarcodeScanned(decodedBarcode);
                        }));
                    }
                }
            }

            frame.Dispose();
        }

        private void UpdateToggleButtonAppearance()
        {
            if (_isActive)
            {
                _toggleButton.Text = "APAGAR ESCÁNER";
                _toggleButton.BackColor = UIThemeHelper.Danger;
                _toggleButton.ForeColor = Color.White;
            }
            else
            {
                _toggleButton.Text = "CÁMARA ESCÁNER";
                _toggleButton.BackColor = UIThemeHelper.Surface;
                _toggleButton.ForeColor = UIThemeHelper.TextMain;
            }
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
