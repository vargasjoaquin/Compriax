namespace CompriaxSystem.Application.DTOs
{
    public class UserCreateDto : UserDto
    {
        public string Password { get; set; } = null!;
    }
}