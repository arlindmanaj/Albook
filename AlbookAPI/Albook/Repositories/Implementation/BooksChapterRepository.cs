using Albook.Data;
using Albook.Models.Domain;
using Albook.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Albook.Repositories.Implementation
{
    public class BooksChapterRepository : IBooksChapterRepository
    {
        private readonly ApplicationDbContext _context;

        public BooksChapterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public BooksChapterRepository()
        {
        }

        public async Task<IEnumerable<BooksChapter>> GetChaptersByBookIdAsync(string bookId)
        {
            // Fetch BooksChapters and include related Chapter details in one query
            return await _context.BooksChapters
                .Include(bc => bc.Chapter)  // Eagerly load the related Chapter entity
                .Where(bc => bc.BookId == bookId)
                .ToListAsync();
        }

        // 2. Add a new entry to the BooksChapters junction table
        public async Task AddBooksChapterAsync(BooksChapter booksChapter)
        {
            await _context.BooksChapters.AddAsync(booksChapter);
        }

        // 3. Remove an entry from the BooksChapters junction table
        public async Task RemoveBooksChapterAsync(string bookId)
        {
            var chaptersToRemove = _context.BooksChapters.Where(bc => bc.BookId == bookId);
            _context.BooksChapters.RemoveRange(chaptersToRemove);
            await _context.SaveChangesAsync();
        }

        // 4. Save changes to the database
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
