namespace Albook.Models.Domain
{
    public class Category
    {
        public int CategoryId { get; set; }  // Primary Key
        public string Name { get; set; }     // Category Name

        public ICollection<BooksCategories> BooksCategories { get; set; } = new List<BooksCategories>();
    }
}
