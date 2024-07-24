using Albook.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Albook.Repositories.Interfaces
{
    public interface ITranslationRepository
    {
        Task<IEnumerable<Translation>> GetTranslationsAsync();
        Task<Translation> GetTranslationByIdAsync(int translationId);
        Task AddTranslationAsync(Translation translation);
        Task<bool> UpdateTranslationAsync(int translationId, Translation translation);
        Task<bool> DeleteTranslationAsync(int translationId);
    }
}
