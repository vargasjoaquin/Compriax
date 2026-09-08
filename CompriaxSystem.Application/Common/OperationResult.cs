namespace CompriaxSystem.Application.Common
{
    /// <summary>
    /// Representa el resultado de una operación.
    /// Se utiliza para retornar el estado de éxito/fallo y mensajes informativos.
    /// </summary>
    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = null!;
        public int? EntityId { get; set; }

        /// <summary>
        /// Crea una respuesta de éxito.
        /// </summary>
        /// <param name="message">Mensaje de confirmación.</param>
        /// <returns>Una instancia de OperationResult indicando éxito.</returns>
        public static OperationResult Ok(string message = "Operación exitosa.")
            => new() { Success = true, Message = message };

        /// <summary>
        /// Crea una respuesta de fallo.
        /// </summary>
        /// <param name="message">Mensaje que describe el error ocurrido.</param>
        /// <returns>Una instancia de OperationResult indicando fallo.</returns>
        public static OperationResult Failure(string message)
            => new() { Success = false, Message = message };
    }
}
