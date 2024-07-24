using Albook.Models.Domain;

using Albook.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Albook.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookByIdAsync(int bookId);
        Task AddBookAsync(Book book);
        Task<bool> UpdateBookAsync(int bookId, Book book);
        Task<bool> DeleteBookAsync(int bookId);
    }
}
