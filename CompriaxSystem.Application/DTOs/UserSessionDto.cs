namespace CompriaxSystem.Application.DTOs
{
    public class UserSessionDto
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string RoleName { get; set; } = null!;
        public string? Email { get; set; }
        public DateTime LoginTime { get; set; } = DateTime.Now;
        public byte[]? Photo { get; set; }
    }
}