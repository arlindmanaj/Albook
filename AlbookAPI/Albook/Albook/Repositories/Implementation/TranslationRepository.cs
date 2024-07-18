using Albook.Data;
using Albook.Models.Domain;
using Albook.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Albook.Repositories.Implementation
{
    public class TranslationRepository : ITranslationRepository
    {
        private readonly ApplicationDbContext _context;

        public TranslationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Translation>> GetTranslationsAsync()
        {
            return await _context.Translations.ToListAsync();
        }

        public async Task<Translation> GetTranslationByIdAsync(int translationId)
        {
            return await _context.Translations.FindAsync(translationId);
        }

        public async Task AddTranslationAsync(Translation translation)
        {
            await _context.Translations.AddAsync(translation);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateTranslationAsync(int translationId, Translation translation)
        {
            var existingTranslation = await _context.Translations.FindAsync(translationId);
            if (existingTranslation == null)
            {
                return false;
            }

            existingTranslation.Language = translation.Language;
            existingTranslation.ContentUrl = translation.ContentUrl;

            _context.Translations.Update(existingTranslation);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTranslationAsync(int translationId)
        {
            var translation = await _context.Translations.FindAsync(translationId);
            if (translation == null)
            {
                return false;
            }

            _context.Translations.Remove(translation);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
