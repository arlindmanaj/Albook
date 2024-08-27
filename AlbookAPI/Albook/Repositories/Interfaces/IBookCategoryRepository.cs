using Albook.Models.Domain;

namespace Albook.Repositories.Interfaces
{
    public interface IBookCategoryRepository
    {
        Task<IEnumerable<BooksCategories>> GetCategoriesByBookIdAsync(string bookId);
        Task AddBookCategoryAsync(BooksCategories bookCategory);
        Task RemoveCategoriesByBookIdAsync(string bookId);
    }

}
