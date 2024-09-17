namespace Albook.Models.Domain
{
    public class Chapter
    {
        public int ChapterId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ChapterNumber { get; set; }

        // Relationships
        public string BookId { get; set; }
        public Book Book { get; set; }
        public ICollection<BooksChapter> BooksChapter { get; set; } = new List<BooksChapter>();
    }
}
