using Albook.Data;
using Albook.Models.Domain;
using Albook.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Albook.Repositories.Implementation
{
    public class BookReviewRepository : IBookReviewRepository
    {
        private readonly ApplicationDbContext _context;

        public BookReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookReview>> GetBookReviewsAsync()
        {
            return await _context.BookReviews.ToListAsync();
        }

        public async Task<BookReview> GetBookReviewByIdAsync(int id)
        {
            return await _context.BookReviews.FindAsync(id);
        }

        public async Task AddBookReviewAsync(BookReview review)
        {
            await _context.BookReviews.AddAsync(review);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookReviewAsync(BookReview review)
        {
            _context.BookReviews.Update(review);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookReviewAsync(BookReview review)
        {
            _context.BookReviews.Remove(review);
            await _context.SaveChangesAsync();
        }
    }
}
