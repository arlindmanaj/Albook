using Albook.Models.DTO;

namespace Albook.Repositories.Interface
{
    public interface IBookReviewService
    {
        Task<IEnumerable<BookReviewDTO>> GetBookReviewsAsync();
        Task<BookReviewDTO> GetBookReviewByIdAsync(int id);
        Task AddBookReviewAsync(BookReviewDTO reviewDTO);
        Task<bool> UpdateBookReviewAsync(int id, BookReviewDTO reviewDTO);
        Task<bool> DeleteBookReviewAsync(int id);
    }
}
