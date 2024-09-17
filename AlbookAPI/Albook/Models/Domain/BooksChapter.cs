namespace Albook.Models.Domain
{
    public class BooksChapter
    {
        public int BooksChapterId { get; set; }
        public string BookId { get; set; }
        public Book Book { get; set; }

        public int ChapterId { get; set; }
        public Chapter Chapter { get; set; }
    }
}
