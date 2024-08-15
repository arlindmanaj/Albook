namespace Albook.Models.DTO
{
    public class BookDto
    {
        public string BookId { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public string? Language { get; set; }
        public string? CoverUrl { get; set; }
        public string? ContentUrl { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishedAt { get; set; }
    }
}
