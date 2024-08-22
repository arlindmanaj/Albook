namespace Albook.Models.Domain
{
    public class Category
    {
        public int CategoryId { get; set; }  // Primary Key
        public string Name { get; set; }      // Category Name
        public ICollection<Book> Books { get; set; } // Navigation property
    }
}
