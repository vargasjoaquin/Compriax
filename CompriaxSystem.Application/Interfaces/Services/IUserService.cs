using CompriaxSystem.Application.Common;
using CompriaxSystem.Application.DTOs;
using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Obtiene la lista de usuarios.
        /// </summary>
        /// <returns>Colección de usuarios.</returns>
        Task<IEnumerable<UserDto>> GetUserListAsync();

        /// <summary>
        /// Obtiene los roles de usuario disponibles.
        /// </summary>
        /// <returns>Colección de roles.</returns>
        Task<IEnumerable<Role>> GetRolesAsync();

        /// <summary>
        /// Crea o actualiza un usuario.
        /// </summary>
        /// <param name="dto">Datos del usuario.</param>
        /// <returns>Resultado de la operación.</returns>
        Task<OperationResult> UpsertUserAsync(UserCreateDto dto);

        /// <summary>
        /// Permite a un usuario actualizar sus propios datos de perfil.
        /// </summary>
        /// <param name="dto">Datos actualizados del perfil.</param>
        /// <returns>Resultado de la actualización.</returns>
        Task<OperationResult> UpdateProfileAsync(UserProfileUpdateDto dto);

        /// <summary>
        /// Elimina un usuario.
        /// </summary>
        /// <param name="id">ID del usuario.</param>
        /// <returns>Resultado de la eliminación.</returns>
        Task<OperationResult> DeleteUserAsync(int id);

        /// <summary>
        /// Cambia el estado de bloqueo o activación de un usuario.
        /// </summary>
        /// <param name="id">ID del usuario.</param>
        /// <returns>Resultado del cambio de estado.</returns>
        Task<OperationResult> ToggleUserStatusAsync(int id);
    }
}
