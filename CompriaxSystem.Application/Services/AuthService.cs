using AutoMapper;
using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;

namespace CompriaxSystem.Application.Services
{
    public class AuthService(
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher,
        ICurrentUserService currentUserService,
        IEmailService emailService,
        IMapper mapper) : IAuthService
    {
        public async Task<OperationResult> LoginAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return OperationResult.Failure("Debe ingresar su nombre de usuario y contraseña.");

            string cleanUsername = username.Trim();
            string inputPassword = password.Trim();

            var allUsers = await unitOfWork.Users.GetAllAsync();
            var user = allUsers.FirstOrDefault(u => u.Username.Equals(cleanUsername, StringComparison.OrdinalIgnoreCase) && !u.IsDeleted);

            if (user == null)
                return OperationResult.Failure($"El usuario '{cleanUsername}' no existe en el sistema.");

            if (!user.IsActive)
                return OperationResult.Failure($"La cuenta del usuario '{user.Username}' se encuentra desactivada. Contacte a soporte.");

            string storedPassword = user.Password.Trim();
            bool isValid = false;

            bool isBcryptHash = storedPassword.StartsWith("$2");

            if (isBcryptHash)
            {
                try
                {
                    isValid = passwordHasher.Verify(inputPassword, storedPassword);
                }
                catch
                {
                    isValid = false;
                }
            }
            else
            {
                isValid = string.Equals(inputPassword, storedPassword, StringComparison.Ordinal);

                if (isValid)
                {
                    user.Password = passwordHasher.Hash(inputPassword);
                    unitOfWork.Users.Update(user);
                    await unitOfWork.CompleteAsync();
                }
            }

            if (!isValid)
            {
                return OperationResult.Failure("Contraseña incorrecta. Verifique sus credenciales.");
            }

            currentUserService.CurrentUser = mapper.Map<UserSessionDto>(user);
            currentUserService.CurrentUser.UserId = user.Id;
            currentUserService.CurrentUser.LoginTime = DateTime.Now;

            return OperationResult.Ok($"¡Bienvenido/a, {user.FirstName}!");
        }

        public async Task<OperationResult> SendPasswordResetAsync(string identity)
        {
            if (string.IsNullOrWhiteSpace(identity))
                return OperationResult.Failure("Debe ingresar un nombre de usuario o correo electrónico.");

            string clientIdenity = identity.Trim();
            var allUsers = await unitOfWork.Users.GetAllAsync();
            
            var user = allUsers.FirstOrDefault(u =>
                (u.Username.Equals(clientIdenity, StringComparison.OrdinalIgnoreCase) ||
                 (u.Email != null && u.Email.Equals(clientIdenity, StringComparison.OrdinalIgnoreCase))) && !u.IsDeleted);

            if (user == null)
                return OperationResult.Failure($"No se encontró ninguna cuenta activa vinculada a '{clientIdenity}'.");

            if(string.IsNullOrWhiteSpace(user.Email))
                return OperationResult.Failure($"El usuario '{user.Username}' no posee un correo electrónico registrado en elsistema. Debe solicitar el blanqueo directamente al Administrador.");

            string temporaryPassword = GenerateTemporaryPassword();

            user.Password = passwordHasher.Hash(temporaryPassword);
            user.LastUpdatedAt = DateTime.UtcNow;
            user.LastUpdatedBy = "AutoRecovery";

            unitOfWork.Users.Update(user);
            bool updateToDatabase = await unitOfWork.CompleteAsync();

            if (!updateToDatabase)
                return OperationResult.Failure("No se pudo actualizar la credencial temporal en la base de datos.");

            string maskedEmail = MaskEmail(user.Email);
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
                await emailService.SendEmailAsync(user.Email, "Restablecimiento de Contraseña — Compriax POS", emailBody);
            }
            catch (Exception ex)
            {
                return OperationResult.Ok($"Se generó tu clave temporal: '{temporaryPassword}'. (Aviso: No se pudo enviar el correo SMTP: {ex.Message})");
            }

            return OperationResult.Ok($"¡Contraseña temporal generada con éxito! Se ha enviado a tu correo registrado: {maskedEmail}. Inicia sesión con la clave recibida y cámbiala desde 'Mi Perfil'.");
        }

        public void Logout()
        {
            currentUserService.CurrentUser = null;
            currentUserService.OperationalContext = null;
        }

        private static string GenerateTemporaryPassword()
        {
            const string upper = "ABCDEFGHJKLMNPQRSTUVWXYZ";
            const string numbers = "23456789";
            var random = new Random();

            var part1 = new string(Enumerable.Range(0, 4).Select(_ => upper[random.Next(upper.Length)]).ToArray());
            var part2 = new string(Enumerable.Range(0, 4).Select(_ => numbers[random.Next(numbers.Length)]).ToArray());

            return $"CPX#{part1}{part2}";
        }

        private static string MaskEmail(string email)
        {
            var parts = email.Split('@');
            
            if (parts.Length != 2) 
                return email;

            string name = parts[0];
            string domain = parts[1];

            string maskedName = name.Length <= 2 ? name + "***" : name.Substring(0, 2) + new string('*', name.Length - 2);
            return $"{maskedName}@{domain}";
        }
    }
}