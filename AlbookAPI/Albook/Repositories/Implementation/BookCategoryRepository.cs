using Albook.Data;
using Albook.Models.Domain;
using Albook.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Albook.Repositories.Implementation
{
    public class BookCategoryRepository : IBookCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public BookCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retrieve all categories associated with a given book ID
        public async Task<IEnumerable<BooksCategories>> GetCategoriesByBookIdAsync(string bookId)
        {
            return await _context.BooksCategories
                .Include(bc => bc.Category) // Include category details
                .Where(bc => bc.BookId == bookId)
                .ToListAsync();
        }

        // Add a new BooksCategories entry
        public async Task AddBookCategoryAsync(BooksCategories bookCategory)
        {
            await _context.BooksCategories.AddAsync(bookCategory);
            await _context.SaveChangesAsync();
        }

        // Remove all category associations for a given book ID
        public async Task RemoveCategoriesByBookIdAsync(string bookId)
        {
            var categoriesToRemove = _context.BooksCategories.Where(bc => bc.BookId == bookId);
            _context.BooksCategories.RemoveRange(categoriesToRemove);
            await _context.SaveChangesAsync();
        }
    }
}
