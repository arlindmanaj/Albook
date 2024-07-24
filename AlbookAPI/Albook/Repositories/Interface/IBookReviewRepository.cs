using Albook.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Albook.Repositories.Interfaces
{
    public interface IBookReviewRepository
    {
        Task<IEnumerable<BookReview>> GetBookReviewsAsync();
        Task<BookReview> GetBookReviewByIdAsync(int id);
        Task AddBookReviewAsync(BookReview review);
        Task UpdateBookReviewAsync(BookReview review);
        Task DeleteBookReviewAsync(BookReview review);
    }
}
