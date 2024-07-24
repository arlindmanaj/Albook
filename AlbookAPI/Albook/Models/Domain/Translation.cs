namespace Albook.Models.Domain
{
    public class Translation
    {
        public int TranslationId { get; set; }
        public int BookId { get; set; }
        public string Language { get; set; }
        public string ContentUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Book Book { get; set; }
    }
}
