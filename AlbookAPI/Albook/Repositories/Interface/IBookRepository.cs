using Albook.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Albook.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookByIdAsync(string bookId);
        Task AddBookAsync(Book book);
        Task<bool> UpdateBookAsync(string bookId, Book book);
        Task<bool> DeleteBookAsync(string bookId);
    }
}
