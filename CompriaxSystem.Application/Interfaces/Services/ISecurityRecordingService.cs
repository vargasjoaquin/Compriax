using System.Drawing;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ISecurityRecordingService
    {
        bool IsAutoRecordingEnabled { get; }
        bool IsCurrentlyRecording { get; }

        event Action<Bitmap>? FrameCaptured;

        void Start();
        void Stop();
        void SetAutoRecordingEnabled(bool enabled);
    }
}
