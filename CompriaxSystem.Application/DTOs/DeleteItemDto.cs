namespace CompriaxSystem.Application.DTOs
{
    public class DeletedItemDto
    {
        public int Id { get; set; }
        public string EntityType { get; set; } = null!;
        public string Identifier { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? AdditionalInfo { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }
    }
}