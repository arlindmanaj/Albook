namespace Albook.Models.Domain
{
    public class BooksCategories
    {
        public int BookCategoryId { get; set; } // Primary Key

        public string BookId { get; set; }      // Foreign Key to Book
        public Book Book { get; set; }          // Navigation property

        public int CategoryId { get; set; }     // Foreign Key to Category
        public Category Category { get; set; }  // Navigation property
    }
}