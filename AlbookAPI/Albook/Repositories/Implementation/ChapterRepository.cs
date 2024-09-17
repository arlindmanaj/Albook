using Albook.Data;
using Albook.Models.Domain;
using Albook.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Albook.Repositories.Implementation
{
    public class ChapterRepository : IChapterRepository
    {
        private readonly ApplicationDbContext _context;

        public ChapterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public async Task<List<Chapter>> GetChaptersByBookIdAsync(string bookId)
        {
            return await _context.BooksChapters
                .Where(c => c.BookId == bookId)
                .Select(bc => bc.Chapter)
                .ToListAsync();
        }

        
        public async Task<Chapter> GetChapterByIdAsync(int chapterId)
        {
            return await _context.Chapter.FindAsync(chapterId);
        }

        
        public async Task AddChapterAsync(Chapter chapter)
        {
            await _context.Chapter.AddAsync(chapter);
            await _context.SaveChangesAsync();
        }

    
        public async Task UpdateChapterAsync(Chapter chapter)
        {
            _context.Chapter.Update(chapter);
            await _context.SaveChangesAsync();
        }

      
        public async Task DeleteChapterAsync(int chapterId)
        {
            var chapter = await _context.Chapter.FindAsync(chapterId);
            if (chapter != null)
            {
                _context.Chapter.Remove(chapter);
                await _context.SaveChangesAsync();
            }
        }
    }

}
