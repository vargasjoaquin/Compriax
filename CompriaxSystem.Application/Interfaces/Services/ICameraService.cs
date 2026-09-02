using System.Drawing;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ICameraService
    {
        IEnumerable<string> GetAvailableCameras();
        void StartStreaming(int cameraIndex, Action<Bitmap> onFrameReceived);
        void StopStreaming();
        Bitmap? TakeSnapshot();
    }
}
