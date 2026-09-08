using FluentValidation.Results;

namespace CompriaxSystem.Application.Common
{
    /// <summary>
    /// Provee métodos de extensión para facilitar la conversión entre resultados de validaciones 
    /// de FluentValidation y el modelo de respuesta del sistema.
    /// </summary>
    public static class ValidationExtensions
    {
        /// <summary>
        /// Convierte un objeto ValidationResult en un OperationResult.
        /// </summary>
        /// <param name="result">El resultado de validación generado por FluentValidation.</param>
        /// <returns>
        /// Un OperationResult exitoso si no hay errores; 
        /// de lo contrario, un resultado fallido con el primer mensaje de error encontrado.
        /// </returns>
        public static OperationResult ToResult(this ValidationResult result)
        {
            if (result.IsValid)
                return OperationResult.Ok();

            var errors = result.Errors.FirstOrDefault()?.ErrorMessage;
            return OperationResult.Failure(errors);
        }
    }
}
