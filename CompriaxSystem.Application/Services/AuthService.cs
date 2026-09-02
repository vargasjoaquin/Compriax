using AutoMapper;
using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Common;

namespace CompriaxSystem.Application.Services
{
    public class AuthService(
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher,
        ICurrentUserService currentUserService,
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

            var allUsers = await unitOfWork.Users.GetAllAsync();
            
            var user = allUsers.FirstOrDefault(u =>
                (u.Username.Equals(identity.Trim(), StringComparison.OrdinalIgnoreCase) ||
                 (u.Email != null && u.Email.Equals(identity.Trim(), StringComparison.OrdinalIgnoreCase))) && !u.IsDeleted);

            if (user == null)
                return OperationResult.Failure($"No se encontró ninguna cuenta activa vinculada a '{identity.Trim()}'.");

            return OperationResult.Ok($"Cuenta verificada para '{user.FirstName} {user.LastName}'. Contacte al Administrador principal para el restablecimiento de su credencial.");
        }

        public void Logout()
        {
            currentUserService.CurrentUser = null;
            currentUserService.OperationalContext = null;
        }
    }
}