namespace Albook.Models.Domain
{
    public class Book
    {
        public string BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string CoverUrl { get; set; }
        public string ContentUrl { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;


        public ICollection<BookReview> BookReviews { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Translation> Translations { get; set; }

        public ICollection<BooksCategories> BooksCategories { get; set; }
        public ICollection<BooksChapter> BooksChapter { get; set; }
    }
}
