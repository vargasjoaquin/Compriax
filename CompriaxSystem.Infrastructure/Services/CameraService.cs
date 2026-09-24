using CompriaxSystem.Application.Interfaces.Services;
using DirectShowLib;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing;
using System.Timers;

namespace CompriaxSystem.Infrastructure.Services
{
    public class CameraService : ICameraService, IDisposable
    {
        private VideoCapture? _videoCapture;
        private Action<Bitmap>? _onFrameReceived;
        private System.Timers.Timer? _frameTimer;
        private VideoCapture? _videoSource;
        private Bitmap? _lastFrame;
        private readonly object _syncLock = new();

        /// <summary>
        /// Obtiene los nombres descriptivos de todos los dispositivos de entrada de video de cámaras disponibles en el sistema.
        /// </summary>
        /// <returns>Una colección de nombres de cámaras detectadas.</returns>
        public IEnumerable<string> GetAvailableCameras()
        {
            var cameraDeviceNames = new List<string>();

            try
            {
                DsDevice[] videoDevices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
                
                foreach (var videoDevice in videoDevices)
                {
                    cameraDeviceNames.Add(videoDevice.Name);
                }
            }
            catch
            {
            }

            if (cameraDeviceNames.Count == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    using var temporaryVideoCapture = new VideoCapture(i);
                    
                    if (temporaryVideoCapture.IsOpened())
                        cameraDeviceNames.Add($"Camera Device {i}");
                }
            }
            return cameraDeviceNames;
        }

        /// <summary>
        /// Inicia la captura y transmisión de cuadros de video desde una cámara específica.
        /// </summary>
        /// <param name="cameraIndex">Índice del dispositivo de cámara a utilizar.</param>
        /// <param name="onFrameReceived">Acción que se ejecutará cada vez que se reciba un nuevo cuadro (Bitmap).</param>
        public void StartStreaming(int cameraIndex, Action<Bitmap> onFrameReceived)
        {
            _onFrameReceived = onFrameReceived;
            _videoCapture = new VideoCapture(cameraIndex);
            _videoCapture.Open(cameraIndex);

            if (!_videoCapture.IsOpened())
                return;

            _frameTimer = new System.Timers.Timer(33);
            _frameTimer.Elapsed += CaptureFrame;
            _frameTimer.Start();
        }

        /// <summary>
        /// Método interno encargado de capturar el cuadro actual del dispositivo de video y enviarlo al suscriptor.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Argumentos del temporizador.</param>
        private void CaptureFrame(object? sender, ElapsedEventArgs e)
        {
            if (_videoCapture == null || !_videoCapture.IsOpened())
                return;

            using Mat videoFrame = new Mat();
            _videoCapture.Read(videoFrame);

            if (videoFrame.Empty())
                return;

            var capturedBitmap = BitmapConverter.ToBitmap(videoFrame);

            lock (_syncLock)
            {
                _lastFrame?.Dispose();
                _lastFrame = capturedBitmap;
            }

            _onFrameReceived?.Invoke((Bitmap)capturedBitmap.Clone());
        }

        /// <summary>
        /// Detiene la captura de video y libera los recursos del dispositivo de captura.
        /// </summary>
        public void StopStreaming()
        {
            _frameTimer?.Stop();
            _videoSource?.Release();
            _videoCapture?.Release();
            _videoCapture?.Dispose();
            _videoCapture = null;
        }

        /// <summary>
        /// Obtiene una captura instantánea (foto) del último cuadro procesado por la cámara.
        /// </summary>
        /// <returns>Un Bitmap con la imagen capturada o null si no hay transmisión.</returns>
        public Bitmap? TakeSnapshot()
        {
            lock (_syncLock)
            {
                return _lastFrame != null ? (Bitmap)_lastFrame.Clone() : null;
            }
        }

        /// <summary>
        /// Libera los recursos de captura y limpia los objetos en memoria.
        /// </summary>
        public void Dispose()
        {
            StopStreaming();
            _lastFrame?.Dispose();
        }
    }
}
