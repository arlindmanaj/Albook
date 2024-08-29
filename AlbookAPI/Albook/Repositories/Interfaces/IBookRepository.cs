using Albook.Models.Domain;

namespace Albook.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookByIdAsync(string bookId);
        Task<Book> AddBookAsync(Book createBook);
        Task<bool> UpdateBookAsync(string bookId, Book book);
        Task<bool> DeleteBookAsync(string bookId);
    }
}
