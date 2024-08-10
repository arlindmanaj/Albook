using Albook.Models.Domain;
using Albook.Models.DTO;
using Albook.Repositories.Interface;
using Albook.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albook.Services
{
    public class BookReviewService : IBookReviewService
    {
        private readonly IBookReviewRepository _bookReviewRepository;

        public BookReviewService(IBookReviewRepository bookReviewRepository)
        {
            _bookReviewRepository = bookReviewRepository;
        }

        public async Task<IEnumerable<BookReviewDTO>> GetBookReviewsAsync()
        {
            var reviews = await _bookReviewRepository.GetBookReviewsAsync();
            return reviews.Select(r => new BookReviewDTO
            {
                ReviewId = r.ReviewId,
                BookId = r.BookId,
                UserId = r.UserId,
                ReviewText = r.ReviewText,
                Rating = r.Rating,
                CreatedAt = r.CreatedAt
            }).ToList();
        }

        public async Task<BookReviewDTO> GetBookReviewByIdAsync(int id)
        {
            var review = await _bookReviewRepository.GetBookReviewByIdAsync(id);
            if (review == null) return null;

            return new BookReviewDTO
            {
                ReviewId = review.ReviewId,
                BookId = review.BookId,
                UserId = review.UserId,
                ReviewText = review.ReviewText,
                Rating = review.Rating,
                CreatedAt = review.CreatedAt
            };
        }

        public async Task AddBookReviewAsync(BookReviewDTO reviewDTO)
        {
            var review = new BookReview
            {
                BookId = reviewDTO.BookId,
                UserId = reviewDTO.UserId,
                ReviewText = reviewDTO.ReviewText,
                Rating = reviewDTO.Rating,
                CreatedAt = reviewDTO.CreatedAt
            };
            await _bookReviewRepository.AddBookReviewAsync(review);
        }

        public async Task<bool> UpdateBookReviewAsync(int id, BookReviewDTO reviewDTO)
        {
            var review = await _bookReviewRepository.GetBookReviewByIdAsync(id);
            if (review == null) return false;

            review.ReviewText = reviewDTO.ReviewText;
            review.Rating = reviewDTO.Rating;

            await _bookReviewRepository.UpdateBookReviewAsync(review);
            return true;
        }

        public async Task<bool> DeleteBookReviewAsync(int id)
        {
            var review = await _bookReviewRepository.GetBookReviewByIdAsync(id);
            if (review == null) return false;

            await _bookReviewRepository.DeleteBookReviewAsync(review);
            return true;
        }
    }
}
