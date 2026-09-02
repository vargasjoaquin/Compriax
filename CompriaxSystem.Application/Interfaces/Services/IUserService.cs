using CompriaxSystem.Application.Common;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUserListAsync();
        Task<IEnumerable<Role>> GetRolesAsync();
        Task<OperationResult> UpsertUserAsync(UserCreateDto dto);
        Task<OperationResult> UpdateProfileAsync(UserProfileUpdateDto dto);
        Task<OperationResult> DeleteUserAsync(int id);
        Task<OperationResult> ToggleUserStatusAsync(int id);
    }
}
