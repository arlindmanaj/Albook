namespace Albook.Models.DTO
{
    public class TranslationDto
    {
        public int TranslationId { get; set; }
        public int BookId { get; set; }
        public string? Language { get; set; }
        public string? ContentUrl { get; set; }
    }
}
