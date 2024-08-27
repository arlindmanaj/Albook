using Albook.Models.Domain;

namespace Albook.Repositories.Interfaces
{
    public interface ITranslationService
    {
        Task<IEnumerable<Translation>> GetTranslationsAsync();
        Task<Translation> GetTranslationByIdAsync(int id);
        Task AddTranslationAsync(Translation translation);

        Task<bool> UpdateTranslationAsync(int id, Translation translation);
        Task<bool> DeleteTranslationAsync(int id);
    }
}
