using Albook.Models.Domain;

namespace Albook.Repositories.Interface
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task AddBookAsync(Book book);
        Task<bool> DeleteBookAsync(int id);
        Task<bool> UpdateBookAsync(int id, Book book);

    }
}
