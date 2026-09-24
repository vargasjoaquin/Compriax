using AutoMapper;
using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;

namespace CompriaxSystem.Application.Services
{
    public class AuthService(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, ICurrentUserService currentUserService, IEmailService emailService, IMapper mapper) : IAuthService
    {
        /// <summary>
        /// Autentica a un usuario en el sistema verificando sus credenciales y estado de cuenta.
        /// </summary>
        /// <param name="username">Nombre de usuario ingresado.</param>
        /// <param name="password">Contraseña en texto plano.</param>
        /// <returns>Un objeto OperationResult con los datos de la sesión o el mensaje de error.</returns>
        public async Task<OperationResult> LoginAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return OperationResult.Failure("Debe ingresar su nombre de usuario y contraseña.");

            string normalizedUsername = username.Trim();
            string inputPassword = password;

            var allUsers = await unitOfWork.Users.GetAllAsync();
            var user = allUsers.FirstOrDefault(u => u.Username.Equals(normalizedUsername, StringComparison.OrdinalIgnoreCase) && !u.IsDeleted);

            if (user == null)
                return OperationResult.Failure($"El usuario '{normalizedUsername}' no existe en el sistema.");

            if (!user.IsActive)
                return OperationResult.Failure($"La cuenta del usuario '{user.Username}' se encuentra desactivada. Contacte a soporte.");

            string storedPassword = user.Password.Trim();
            bool isPasswordValid = false;

            bool isBcryptPassword = storedPassword.StartsWith("$2");

            if (isBcryptPassword)
            {
                try
                {
                    isPasswordValid = passwordHasher.Verify(inputPassword, storedPassword);
                }
                catch
                {
                    isPasswordValid = false;
                }
            }
            else
            {
                isPasswordValid = string.Equals(inputPassword, storedPassword, StringComparison.Ordinal);

                if (isPasswordValid)
                {
                    user.Password = passwordHasher.Hash(inputPassword);
                    unitOfWork.Users.Update(user);
                    await unitOfWork.CompleteAsync();
                }
            }

            if (!isPasswordValid)
            {
                return OperationResult.Failure("Contraseña incorrecta. Verifique sus credenciales.");
            }

            currentUserService.CurrentUser = mapper.Map<UserSessionDto>(user);
            currentUserService.CurrentUser.UserId = user.Id;
            currentUserService.CurrentUser.LoginTime = DateTime.Now;

            return OperationResult.Ok($"¡Bienvenido/a, {user.FirstName}!");
        }

        /// <summary>
        /// Inicia el proceso de recuperación de cuenta, genera una clave temporal y la envía por correo.
        /// </summary>
        /// <param name="identity">Nombre de usuario o correo electrónico registrado.</param>
        /// <returns>Resultado de la operación indicando el éxito del envío o generación.</returns>
        public async Task<OperationResult> SendPasswordResetAsync(string identity)
        {
            if (string.IsNullOrWhiteSpace(identity))
                return OperationResult.Failure("Debe ingresar un nombre de usuario o correo electrónico.");

            string normalizedLoginIdentifier = identity.Trim();
            var allUsers = await unitOfWork.Users.GetAllAsync();
            
            var user = allUsers.FirstOrDefault(u =>
                (u.Username.Equals(normalizedLoginIdentifier, StringComparison.OrdinalIgnoreCase) ||
                 (u.Email != null && u.Email.Equals(normalizedLoginIdentifier, StringComparison.OrdinalIgnoreCase))) && !u.IsDeleted);

            if (user == null)
                return OperationResult.Failure($"No se encontró ninguna cuenta activa vinculada a '{normalizedLoginIdentifier}'.");

            if(string.IsNullOrWhiteSpace(user.Email))
                return OperationResult.Failure($"El usuario '{user.Username}' no posee un correo electrónico registrado en elsistema. Debe solicitar el blanqueo directamente al Administrador.");

            string temporaryPassword = GenerateTemporaryPassword();

            user.Password = passwordHasher.Hash(temporaryPassword);
            user.LastUpdatedAt = DateTime.UtcNow;
            user.LastUpdatedBy = "AutoRecovery";

            unitOfWork.Users.Update(user);
            bool databaseUpdateSucceeded = await unitOfWork.CompleteAsync();

            if (!databaseUpdateSucceeded)
                return OperationResult.Failure("No se pudo actualizar la credencial temporal en la base de datos.");

            string maskedEmailAddress = MaskEmail(user.Email);
            string emailBody = $@"
                <div style='font-family: Arial, sans-serif; max-width: 600px; margin: auto; padding: 20px; border: 1px solid #e2e8f0; border-radius: 8px;'>
                    <h2 style='color: #0284c7;'>Compriax POS — Restablecimiento de Credenciales</h2>
                    <p>Hola <strong>{user.FirstName} {user.LastName}</strong>,</p>
                    <p>Se ha solicitado el restablecimiento de tu contraseña para el usuario <strong>{user.Username}</strong>.</p>
                    <div style='background: #f8fafc; padding: 15px; border-left: 4px solid #10b981; margin: 20px 0;'>
                        <p style='margin: 0; font-size: 14px; color: #64748b;'>Tu nueva contraseña temporal es:</p>
                        <p style='margin: 5px 0 0 0; font-size: 22px; font-weight: bold; color: #0f172a;'>{temporaryPassword}</p>
                    </div>
                    <p style='color: #ef4444; font-size: 13px;'>⚠️ Por seguridad, una vez que inicies sesión ingresa a <strong>Mi Perfil</strong> y cámbiala por una contraseña personal.</p>
                    <hr style='border: none; border-top: 1px solid #cbd5e1; margin: 20px 0;' />
                    <p style='font-size: 12px; color: #94a3b8;'>CompriaxSystem — Sistema de Punto de Venta y Gestión Comercial.</p>
                </div>";

            try
            {
                await emailService.SendEmailAsync(user.Email, "Restablecimiento de Contraseña — Compriax", emailBody);
            }
            catch (Exception ex)
            {
                return OperationResult.Ok($"Se generó tu clave temporal: '{temporaryPassword}'. (Aviso: No se pudo enviar el correo SMTP: {ex.Message})");
            }

            return OperationResult.Ok($"¡Contraseña temporal generada con éxito! Se ha enviado a tu correo registrado: {maskedEmailAddress}. Inicia sesión con la clave recibida y cámbiala desde 'Mi Perfil'.");
        }

        /// <summary>
        /// Finaliza la sesión del usuario actual limpiando el contexto operativo.
        /// </summary>
        public void Logout()
        {
            currentUserService.CurrentUser = null;
            currentUserService.OperationalContext = null;
        }

        /// <summary>
        /// Genera una contraseña temporal aleatoria.
        /// </summary>
        /// <returns>Una contraseña temporal generada aleatoriamente.</returns>
        private static string GenerateTemporaryPassword()
        {
            const string uppercaseCharacters = "ABCDEFGHJKLMNPQRSTUVWXYZ";
            const string numericCharacters = "23456789";
            
            var randomGenerator = new Random();

            var randomLetters = new string(Enumerable.Range(0, 4).Select(_ => uppercaseCharacters[randomGenerator.Next(uppercaseCharacters.Length)]).ToArray()); 
            var randomNumbers = new string(Enumerable.Range(0, 4).Select(_ => numericCharacters[randomGenerator.Next(numericCharacters.Length)]).ToArray());

            return $"CPX#{randomLetters}{randomNumbers}";
        }

        /// <summary>
        /// Oculta parcialmente el nombre de usuario de una dirección de correo electrónico para proteger su privacidad.
        /// </summary>
        /// <param name="email">Correo electrónico que se desea enmascarar.</param>
        /// <returns>Correo electrónico con su nombre de usuario parcialmente oculto.</returns>
        private static string MaskEmail(string email)
        {
            var emailParts = email.Split('@');
            
            if (emailParts.Length != 2) 
                return email;

            string emailUsername = emailParts[0];
            string emailDomain = emailParts[1];

            string maskedEmailUsername = emailUsername.Length <= 2 ? emailUsername + "***" : emailUsername.Substring(0, 2) + new string('*', emailUsername.Length - 2);

            return $"{maskedEmailUsername}@{emailDomain}";
        }
    }
}