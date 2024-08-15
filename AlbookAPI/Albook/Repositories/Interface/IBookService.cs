using Albook.Models.Domain;

namespace Albook.Repositories.Interface
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookByIdAsync(string id);
        Task AddBookAsync(Book book);
        Task<bool> DeleteBookAsync(string id);
        Task<bool> UpdateBookAsync(string id, Book book);

    }
}
