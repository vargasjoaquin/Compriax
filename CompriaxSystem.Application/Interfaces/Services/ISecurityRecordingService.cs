using System.Drawing;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ISecurityRecordingService
    {
        /// <summary>
        /// Indica si la grabación automática está habilitada.
        /// </summary>
        bool IsAutoRecordingEnabled { get; }

        /// <summary>
        /// Indica si se está realizando una grabación en este momento.
        /// </summary>
        bool IsCurrentlyRecording { get; }

        /// <summary>
        /// Evento que se dispara cada vez que se captura un cuadro del video de seguridad.
        /// </summary>
        event Action<Bitmap>? FrameCaptured;

        /// <summary>
        /// Inicia el proceso de grabación de seguridad.
        /// </summary>
        void Start();

        /// <summary>
        /// Detiene el proceso de grabación actual.
        /// </summary>
        void Stop();

        /// <summary>
        /// Habilita o deshabilita la función de grabación automática.
        /// </summary>
        /// <param name="enabled">Estado a definir.</param>
        void SetAutoRecordingEnabled(bool enabled);
    }
}
