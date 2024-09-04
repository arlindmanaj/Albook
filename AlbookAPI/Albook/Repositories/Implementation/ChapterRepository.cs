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

        public async Task<IEnumerable<Chapters>> GetChaptersByBookIdAsync(string bookId)
        {
            return await _context.Chapters
                .Where(c => c.BookId == bookId)
                .OrderBy(c => c.Order)  
                .ToListAsync();
        }

        public async Task<Chapters> GetChapterByIdAsync(int chapterId)
        {
            return await _context.Chapters.FindAsync(chapterId);
        }

        public async Task AddChapterAsync(Chapters chapter)
        {
            await _context.Chapters.AddAsync(chapter);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateChapterAsync(Chapters chapter)
        {
            _context.Chapters.Update(chapter);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteChapterAsync(int chapterId)
        {
            var chapter = await _context.Chapters.FindAsync(chapterId);
            if (chapter != null)
            {
                _context.Chapters.Remove(chapter);
                await _context.SaveChangesAsync();
            }
        }
    }
}

