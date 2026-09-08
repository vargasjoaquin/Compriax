using System.Drawing;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ICameraService
    {
        /// <summary>
        /// Lista los nombres de todas las cámaras conectadas y disponibles en el equipo.
        /// </summary>
        /// <returns>Colección de nombres de dispositivos de captura.</returns>
        IEnumerable<string> GetAvailableCameras();

        /// <summary>
        /// Inicia la transmisión de video de una cámara específica.
        /// </summary>
        /// <param name="cameraIndex">Índice del dispositivo de cámara.</param>
        /// <param name="onFrameReceived">Acción que se ejecuta cada vez que se recibe un nuevo cuadro.</param>
        void StartStreaming(int cameraIndex, Action<Bitmap> onFrameReceived);

        /// <summary>
        /// Detiene la transmisión de video actual.
        /// </summary>
        void StopStreaming();

        /// <summary>
        /// Captura un cuadro estático de la transmisión actual.
        /// </summary>
        /// <returns>Imagen capturada o null si no hay flujo activo.</returns>
        Bitmap? TakeSnapshot();
    }
}
