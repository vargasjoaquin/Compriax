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

        public IEnumerable<string> GetAvailableCameras()
        {
            var deviceNames = new List<string>();

            try
            {
                DsDevice[] devices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
                
                foreach (var device in devices)
                {
                    deviceNames.Add(device.Name);
                }
            }
            catch
            {
            }

            if (deviceNames.Count == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    using var tempCap = new VideoCapture(i);
                    
                    if (tempCap.IsOpened())
                        deviceNames.Add($"Camera Device {i}");
                }
            }

            return deviceNames;
        }

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

        private void CaptureFrame(object? sender, ElapsedEventArgs e)
        {
            if (_videoCapture == null || !_videoCapture.IsOpened())
                return;

            using Mat frame = new Mat();
            _videoCapture.Read(frame);

            if (frame.Empty())
                return;

            var converted = BitmapConverter.ToBitmap(frame);

            lock (_syncLock)
            {
                _lastFrame?.Dispose();
                _lastFrame = converted;
            }

            _onFrameReceived?.Invoke((Bitmap)converted.Clone());
        }

        public void StopStreaming()
        {
            _frameTimer?.Stop();
            _videoSource?.Release();
            _videoCapture?.Release();
            _videoCapture?.Dispose();
            _videoCapture = null;
        }

        public Bitmap? TakeSnapshot()
        {
            lock (_syncLock)
            {
                return _lastFrame != null ? (Bitmap)_lastFrame.Clone() : null;
            }
        }

        public void Dispose()
        {
            StopStreaming();
            _lastFrame?.Dispose();
        }
    }
}
