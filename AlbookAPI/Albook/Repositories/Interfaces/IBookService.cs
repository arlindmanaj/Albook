using Albook.Models.Domain;
using Albook.Models.DTO;

namespace Albook.Repositories.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetBooksAsync();
        Task<BookDto> GetBookByIdAsync(string id);
        Task<BookDto> AddBookAsync(CreateBookRequestDto createBookDto);
        Task<bool> DeleteBookAsync(string id);
        Task<bool> UpdateBookAsync(string id, BookDto book);
    }
}
