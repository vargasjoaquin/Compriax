using AutoMapper;
using FluentValidation;
using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Common;
using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Services
{
    public class UserService(
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher,
        IMapper mapper,
        IValidator<UserCreateDto> userValidator,
        IValidator<UserProfileUpdateDto> profileValidator) : IUserService
    {
        public async Task<IEnumerable<UserDto>> GetUserListAsync()
        {
            var users = await unitOfWork.Users.GetAllAsync();
            return mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            return await unitOfWork.Roles.GetAllAsync();
        }

        public async Task<OperationResult> UpsertUserAsync(UserCreateDto dto)
        {
            var validation = await userValidator.ValidateAsync(dto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            var roles = await unitOfWork.Roles.GetAllAsync();
            var adminRole = roles.FirstOrDefault(r => r.Name.Equals("Administrador", StringComparison.OrdinalIgnoreCase));
            int adminRoleId = adminRole!.Id;

            if (dto.Id == 0)
            {
                if (dto.RoleId == adminRoleId)
                {
                    var allUsers = await unitOfWork.Users.GetAllAsync();
                    bool adminExists = allUsers.Any(u => u.RoleId == adminRoleId && !u.IsDeleted);

                    if (adminExists)
                        return OperationResult.Failure("Ya existe un usuario con el rol de Administrador. El sistema solo permite un único Administrador.");
                }

                var existing = await unitOfWork.Users.GetByUsernameAsync(dto.Username.Trim());
                
                if (existing != null)
                    return OperationResult.Failure("El nombre de usuario ya está en uso.");

                var newUser = mapper.Map<User>(dto);
                newUser.Password = passwordHasher.Hash(dto.Password);
                newUser.IsActive = true;

                await unitOfWork.Users.AddAsync(newUser);
            }
            else
            {
                var user = await unitOfWork.Users.GetByIdAsync(dto.Id);
                
                if (user == null)
                    return OperationResult.Failure("Usuario no encontrado.");

                bool isMasterAdmin = user.Username.Equals("admin", StringComparison.OrdinalIgnoreCase) || user.RoleId == adminRoleId;

                if (isMasterAdmin && dto.RoleId != adminRoleId)
                    return OperationResult.Failure("El usuario Administrador principal no puede cambiar su rol a otro nivel de acceso.");

                if (!isMasterAdmin && dto.RoleId == adminRoleId)
                {
                    var allUsers = await unitOfWork.Users.GetAllAsync();
                    bool adminExists = allUsers.Any(u => u.RoleId == adminRoleId && u.Id != dto.Id && !u.IsDeleted);
                    
                    if (adminExists)
                        return OperationResult.Failure("Ya existe un Administrador en el sistema. No se permite crear administradores adicionales.");
                }

                mapper.Map(dto, user);

                if (user.Username.Equals("admin", StringComparison.OrdinalIgnoreCase))
                {
                    user.RoleId = adminRoleId;
                    user.IsActive = true;
                }

                if (!string.IsNullOrWhiteSpace(dto.Password))
                {
                    user.Password = passwordHasher.Hash(dto.Password);
                }

                unitOfWork.Users.Update(user);
            }

            return await unitOfWork.CompleteAsync()
                ? OperationResult.Ok("Usuario procesado correctamente.")
                : OperationResult.Failure("No se detectaron cambios para guardar.");
        }

        public async Task<OperationResult> DeleteUserAsync(int id)
        {
            var user = await unitOfWork.Users.GetByIdAsync(id);
            
            if (user == null)
                return OperationResult.Failure("Usuario no encontrado.");

            if (user.Username.Equals("admin", StringComparison.OrdinalIgnoreCase) ||
                user.Role?.Name.Equals("Administrador", StringComparison.OrdinalIgnoreCase) == true)
            {
                return OperationResult.Failure("El usuario Administrador está protegido por el sistema y no puede ser eliminado.");
            }

            user.IsActive = false;
            user.IsDeleted = true;

            unitOfWork.Users.Update(user);
            return await unitOfWork.CompleteAsync()
                ? OperationResult.Ok("Usuario eliminado.")
                : OperationResult.Failure("Error en el proceso de eliminación.");
        }

        public async Task<OperationResult> UpdateProfileAsync(UserProfileUpdateDto dto)
        {
            var validation = await profileValidator.ValidateAsync(dto);
            
            if (!validation.IsValid)
                return validation.ToResult();

            var user = await unitOfWork.Users.GetByIdAsync(dto.UserId);
            
            if (user == null)
                return OperationResult.Failure("Acceso denegado: registro de usuario no encontrado.");

            if (!string.IsNullOrWhiteSpace(dto.NewPassword))
            {
                if (string.IsNullOrWhiteSpace(dto.CurrentPassword))
                    return OperationResult.Failure("Se requiere la contraseña actual para cambiar a una nueva.");

                bool isVerified = passwordHasher.Verify(dto.CurrentPassword, user.Password);
             
                if (!isVerified)
                    return OperationResult.Failure("Error de verificación: La contraseña actual es incorrecta.");

                user.Password = passwordHasher.Hash(dto.NewPassword);
            }

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;

            if (dto.Photo != null)
                user.Photo = dto.Photo;

            unitOfWork.Users.Update(user);
            var success = await unitOfWork.CompleteAsync();

            return success
                ? OperationResult.Ok("¡Perfil actualizado con éxito!")
                : OperationResult.Failure("No se realizaron cambios.");
        }

        public async Task<OperationResult> ToggleUserStatusAsync(int id)
        {
            var user = await unitOfWork.Users.GetByIdAsync(id);
            
            if (user == null)
                return OperationResult.Failure("Usuario no encontrado.");

            if (user.Username.Equals("admin", StringComparison.OrdinalIgnoreCase) ||
                user.Role?.Name.Equals("Administrador", StringComparison.OrdinalIgnoreCase) == true)
            {
                return OperationResult.Failure("La cuenta del Administrador principal no puede ser desactivada.");
            }

            user.IsActive = !user.IsActive;
            unitOfWork.Users.Update(user);
            
            var result = await unitOfWork.CompleteAsync();

            string status = user.IsActive ? "activada" : "desactivada";

            return result
                ? OperationResult.Ok($"La cuenta de usuario ha sido {status} exitosamente.")
                : OperationResult.Failure("No se realizaron cambios en la base de datos.");
        }
    }
}