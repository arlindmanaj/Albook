namespace Albook.Models.Domain
{
    public class Chapters
    {
        public int ChapterId { get; set; }  // Primary Key
        public string BookId { get; set; }  // Foreign Key to the Book entity
        public Book Book { get; set; }      // Navigation property

        public string Title { get; set; }   // Title of the Chapter (e.g., Chapter 1, Chapter 2)
        public int Order { get; set; }      // Order of the chapter in the book (for sorting)
        public string Content { get; set; } // The actual content of the chapter (markdown, HTML, or plain text)
    }

}
