using CompriaxSystem.Application.Common;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IAuthService
    {
        /// <summary>
        /// Realiza el proceso de autenticación de un usuario.
        /// </summary>
        /// <param name="username">Nombre de usuario.</param>
        /// <param name="password">Contraseña en texto plano.</param>
        /// <returns>Resultado de la operación con los datos de la sesión o error.</returns>
        Task<OperationResult> LoginAsync(string username, string password);

        /// <summary>
        /// Finaliza la sesión del usuario actual y limpia las credenciales.
        /// </summary>
        void Logout();

        /// <summary>
        /// Inicia el proceso de recuperación de contraseña enviando un correo al usuario.
        /// </summary>
        /// <param name="identity">Nombre de usuario o correo electrónico.</param>
        /// <returns>Resultado del envío de la solicitud de restablecimiento.</returns>
        Task<OperationResult> SendPasswordResetAsync(string identity);
    }
}
