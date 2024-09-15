using Albook.Models.DTO;

namespace Albook.Services.Interfaces
{
    public interface IBookReviewService
    {
        Task<IEnumerable<BookReviewDTO>> GetBookReviewsAsync();
        Task<BookReviewDTO> GetBookReviewByIdAsync(string id);
        Task AddBookReviewAsync(BookReviewDTO reviewDTO);
        Task<bool> UpdateBookReviewAsync(string id, BookReviewDTO reviewDTO);
        Task<bool> DeleteBookReviewAsync(string id);
    }
}
