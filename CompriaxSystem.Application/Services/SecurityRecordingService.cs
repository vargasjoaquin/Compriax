using Microsoft.Extensions.Options;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using CompriaxSystem.Application.Configuration;
using CompriaxSystem.Application.Interfaces.Services;
using System.Drawing;
using System.Timers;

namespace CompriaxSystem.Application.Services
{
    public class SecurityRecordingService : ISecurityRecordingService, IDisposable
    {
        private readonly SecurityRecordingSettings _recordingSettings;
        private readonly string _recordingsRootPath;

        private readonly object _synchronizationLock = new();
        private System.Timers.Timer? _captureTimer;
        private VideoCapture? _videoCapture;
        private VideoWriter? _videoWriter;
        private DateTime? _currentSegmentStartTime;
        private bool _isAutoRecordingEnabled = true;

        public bool IsAutoRecordingEnabled => _isAutoRecordingEnabled;
        public bool IsCurrentlyRecording => _videoWriter != null;
        public event Action<Bitmap>? FrameCaptured;

        public SecurityRecordingService(IOptions<SecurityRecordingSettings> options)
        {
            _recordingSettings = options.Value;

            _recordingsRootPath = Path.IsPathRooted(_recordingSettings.RecordingsRootPath)
                    ? _recordingSettings.RecordingsRootPath : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _recordingSettings.RecordingsRootPath);
        }

        /// <summary>
        /// Inicia la captura de video desde la cámara configurada.
        /// </summary>
        public void Start()
        {
            if (_captureTimer != null)
                return;

            _videoCapture = new VideoCapture(_recordingSettings.CameraIndex);

            if (!_videoCapture.IsOpened())
                return;

            _captureTimer = new System.Timers.Timer(1000.0 / _recordingSettings.RecordingFps);

            _captureTimer.Elapsed += OnTimerElapsed;
            _captureTimer.Start();
        }

        /// <summary>
        /// Detiene la captura de video y libera los recursos asociados.
        /// </summary>
        public void Stop()
        {
            _captureTimer?.Stop();
            _captureTimer?.Dispose();
            _captureTimer = null;

            lock (_synchronizationLock)
            {
                CloseWriter();

                _videoCapture?.Release();
                _videoCapture?.Dispose();
                _videoCapture = null;
            }
        }

        /// <summary>
        /// Habilita o deshabilita la grabación automática.
        /// </summary>
        /// <param name="isEnabled">
        /// Indica si la grabación automática debe permanecer habilitada.
        /// </param>
        public void SetAutoRecordingEnabled(bool isEnabled)
        {
            _isAutoRecordingEnabled = isEnabled;
        }

        /// <summary>
        /// Procesa cada intervalo del temporizador y captura un nuevo cuadro de video.
        /// </summary>
        /// <param name="sender">Objeto que originó el evento.</param>
        /// <param name="e">Información asociada al evento del temporizador.</param>
        private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
        {
            lock (_synchronizationLock)
            {
                if (_videoCapture == null || !_videoCapture.IsOpened())
                {
                    return;
                }

                using var videoFrame = new Mat();

                _videoCapture.Read(videoFrame);

                if (videoFrame.Empty())
                    return;

                EvaluateRecordingSchedule(videoFrame);

                var bitmapFrame = BitmapConverter.ToBitmap(videoFrame);

                FrameCaptured?.Invoke(bitmapFrame);
            }
        }

        /// <summary>
        /// Evalúa el horario de grabación y determina si el cuadro actual
        /// debe almacenarse en el segmento correspondiente.
        /// </summary>
        /// <param name="videoFrame">Cuadro de video que se está procesando.</param>
        private void EvaluateRecordingSchedule(Mat videoFrame)
        {
            var currentDateTime = DateTime.Now;

            var (isStoreOpen, segmentStartTime, segmentEndTime) = GetCurrentSegment(currentDateTime);

            bool shouldRecordAutomatically = _isAutoRecordingEnabled && isStoreOpen;

            if (!shouldRecordAutomatically)
            {
                CloseWriter();
                return;
            }

            if (_videoWriter == null || _currentSegmentStartTime != segmentStartTime)
            {
                CloseWriter();
                OpenWriter(videoFrame, currentDateTime, segmentStartTime, segmentEndTime);
            }

            _videoWriter?.Write(videoFrame);
        }

        /// <summary>
        /// Determina el segmento de grabación correspondiente al momento actual
        /// teniendo en cuenta los horarios de apertura y cierre del establecimiento.
        /// </summary>
        /// <param name="currentDateTime">Fecha y hora actual utilizada para evaluar el horario.</param>
        /// <returns>Indica si el establecimiento está abierto y proporciona el inicio y finalización del segmento de grabación.</returns>
        private (bool isOpen, DateTime segmentStartTime, DateTime segmentEndTime) GetCurrentSegment(DateTime currentDateTime)
        {
            int storeOpenHour = _recordingSettings.StoreOpenHour;
            int storeCloseHour = _recordingSettings.StoreCloseHour;

            bool crossesMidnight = storeCloseHour < storeOpenHour;

            bool isRecordingScheduleActive;
            DateTime logicalOpeningTime;

            if (!crossesMidnight)
            {
                logicalOpeningTime = currentDateTime.Date.AddHours(storeOpenHour);

                var logicalClosingTime = currentDateTime.Date.AddHours(storeCloseHour);

                isRecordingScheduleActive = currentDateTime >= logicalOpeningTime && currentDateTime < logicalClosingTime;
            }
            else
            {
                if (currentDateTime.Hour >= storeOpenHour)
                {
                    isRecordingScheduleActive = true;
                    logicalOpeningTime = currentDateTime.Date.AddHours(storeOpenHour);
                }
                else if (currentDateTime.Hour < storeCloseHour)
                {
                    isRecordingScheduleActive = true;
                    logicalOpeningTime = currentDateTime.Date.AddDays(-1).AddHours(storeOpenHour);
                }
                else
                {
                    isRecordingScheduleActive = false;
                    logicalOpeningTime = currentDateTime.Date.AddHours(storeOpenHour);
                }
            }

            if (!isRecordingScheduleActive)
                return (false, default, default);

            var elapsedTimeSinceOpening = currentDateTime - logicalOpeningTime;

            double elapsedHoursSinceOpening = elapsedTimeSinceOpening.TotalHours;

            int recordingSegmentIndex = (int)(elapsedHoursSinceOpening / _recordingSettings.SegmentHours);

            var segmentStartTime = logicalOpeningTime.AddHours(recordingSegmentIndex * _recordingSettings.SegmentHours);

            var segmentEndTime = segmentStartTime.AddHours(_recordingSettings.SegmentHours);

            DateTime actualClosingTime = !crossesMidnight ? currentDateTime.Date.AddHours(storeCloseHour) : logicalOpeningTime.AddDays(1).Date.AddHours(storeCloseHour);

            if (segmentEndTime > actualClosingTime)
                segmentEndTime = actualClosingTime;

            return (true,segmentStartTime, segmentEndTime);
        }

        /// <summary>
        /// Abre un nuevo archivo de video correspondiente al segmento de grabación actual.
        /// </summary>
        /// <param name="videoFrame">Cuadro de video utilizado para determinar la resolución de la grabación.</param>
        /// <param name="currentDateTime">Fecha y hora utilizada para generar la carpeta de almacenamiento.</param>
        /// <param name="segmentStartTime">Fecha y hora de inicio del segmento.</param>
        /// <param name="segmentEndTime">Fecha y hora de finalización del segmento.</param>
        private void OpenWriter(Mat videoFrame, DateTime currentDateTime, DateTime segmentStartTime,DateTime segmentEndTime)
        {
            var recordingFolderPath = Path.Combine(_recordingsRootPath, currentDateTime.ToString("dd-MM-yyyy"));

            Directory.CreateDirectory(recordingFolderPath);

            var recordingFileName = $"backup_{segmentStartTime:HH}-{segmentEndTime:HH}.mp4";

            var recordingFilePath = Path.Combine(recordingFolderPath, recordingFileName);

            var videoCodec = VideoWriter.FourCC('m', 'p', '4', 'v');

            _videoWriter = new VideoWriter(recordingFilePath, videoCodec, _recordingSettings.RecordingFps, new OpenCvSharp.Size(videoFrame.Width, videoFrame.Height));

            _currentSegmentStartTime = segmentStartTime;
        }

        /// <summary>
        /// Cierra la grabación de video actual y libera los recursos asociados.
        /// </summary>
        private void CloseWriter()
        {
            if (_videoWriter != null)
            {
                _videoWriter.Release();
                _videoWriter.Dispose();
                _videoWriter = null;
                _currentSegmentStartTime = null;
            }
        }

        /// <summary>
        /// Libera los recursos utilizados por el servicio de grabación.
        /// </summary>
        public void Dispose()
        {
            Stop();
        }
    }
}
