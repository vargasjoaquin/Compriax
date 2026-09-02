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
        private readonly SecurityRecordingSettings _settings;
        private readonly string _recordingsRootPath;

        private readonly object _syncLock = new();
        private System.Timers.Timer? _captureTimer;
        private VideoCapture? _videoCapture;
        private VideoWriter? _videoWriter;
        private DateTime? _currentSegmentStart;
        private bool _autoRecordingEnabled = true;

        public bool IsAutoRecordingEnabled => _autoRecordingEnabled;
        public bool IsCurrentlyRecording => _videoWriter != null;

        public event Action<Bitmap>? FrameCaptured;

        public SecurityRecordingService(IOptions<SecurityRecordingSettings> options)
        {
            _settings = options.Value;
            _recordingsRootPath = Path.IsPathRooted(_settings.RecordingsRootPath)
                ? _settings.RecordingsRootPath
                : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _settings.RecordingsRootPath);
        }

        public void Start()
        {
            if (_captureTimer != null) return;

            _videoCapture = new VideoCapture(_settings.CameraIndex);
            if (!_videoCapture.IsOpened())
                return;

            _captureTimer = new System.Timers.Timer(1000.0 / _settings.RecordingFps);
            _captureTimer.Elapsed += OnTimerElapsed;
            _captureTimer.Start();
        }

        public void Stop()
        {
            _captureTimer?.Stop();
            _captureTimer?.Dispose();
            _captureTimer = null;

            lock (_syncLock)
            {
                CloseWriter();
                _videoCapture?.Release();
                _videoCapture?.Dispose();
                _videoCapture = null;
            }
        }

        public void SetAutoRecordingEnabled(bool enabled) => _autoRecordingEnabled = enabled;

        private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
        {
            lock (_syncLock)
            {
                if (_videoCapture == null || !_videoCapture.IsOpened())
                    return;

                using var frame = new Mat();
                _videoCapture.Read(frame);
                if (frame.Empty())
                    return;

                EvaluateRecordingSchedule(frame);

                var bmp = BitmapConverter.ToBitmap(frame);
                FrameCaptured?.Invoke(bmp); // copia independiente para quien esté escuchando
            }
        }

        private void EvaluateRecordingSchedule(Mat frame)
        {
            var now = DateTime.Now;
            var (isStoreOpen, segmentStart, segmentEnd) = GetCurrentSegment(now);
            bool shouldRecord = _autoRecordingEnabled && isStoreOpen;

            if (!shouldRecord)
            {
                CloseWriter();
                return;
            }

            if (_videoWriter == null || _currentSegmentStart != segmentStart)
            {
                CloseWriter();
                OpenWriter(frame, now, segmentStart, segmentEnd);
            }

            _videoWriter?.Write(frame);
        }

        private (bool isOpen, DateTime segmentStart, DateTime segmentEnd) GetCurrentSegment(DateTime now)
        {
            int openH = _settings.StoreOpenHour;
            int closeH = _settings.StoreCloseHour;

            bool crossMidnight = closeH < openH;
            bool isActive;
            DateTime logicalOpen;

            if (!crossMidnight)
            {
                logicalOpen = now.Date.AddHours(openH);
                var logicalClose = now.Date.AddHours(closeH);
                isActive = now >= logicalOpen && now < logicalClose;
            }
            else
            {
                if (now.Hour >= openH)
                {
                    isActive = true;
                    logicalOpen = now.Date.AddHours(openH);
                }
                else if (now.Hour < closeH)
                {
                    isActive = true;
                    logicalOpen = now.Date.AddDays(-1).AddHours(openH);
                }
                else
                {
                    isActive = false;
                    logicalOpen = now.Date.AddHours(openH);
                }
            }

            if (!isActive)
                return (false, default, default);

            var timeSinceOpen = now - logicalOpen;
            double hoursSinceOpen = timeSinceOpen.TotalHours;

            int segmentIndex = (int)(hoursSinceOpen / _settings.SegmentHours);
            var segStart = logicalOpen.AddHours(segmentIndex * _settings.SegmentHours);
            var segEnd = segStart.AddHours(_settings.SegmentHours);

            DateTime actualClose = !crossMidnight
                ? now.Date.AddHours(closeH)
                : logicalOpen.AddDays(1).Date.AddHours(closeH);

            if (segEnd > actualClose)
                segEnd = actualClose;

            return (true, segStart, segEnd);
        }

        private void OpenWriter(Mat frame, DateTime now, DateTime segStart, DateTime segEnd)
        {
            var folder = Path.Combine(_recordingsRootPath, now.ToString("dd-MM-yyyy"));
            Directory.CreateDirectory(folder);

            var fileName = $"backup_{segStart:HH}-{segEnd:HH}.mp4";
            var fullPath = Path.Combine(folder, fileName);

            var fourcc = VideoWriter.FourCC('m', 'p', '4', 'v');
            _videoWriter = new VideoWriter(fullPath, fourcc, _settings.RecordingFps, new OpenCvSharp.Size(frame.Width, frame.Height));
            _currentSegmentStart = segStart;
        }

        private void CloseWriter()
        {
            if (_videoWriter != null)
            {
                _videoWriter.Release();
                _videoWriter.Dispose();
                _videoWriter = null;
                _currentSegmentStart = null;
            }
        }

        public void Dispose() => Stop();
    }
}
