using Albook.Models.Domain;
using Albook.Repositories.Interface;
using Albook.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace Albook.Services
{
    public class TranslationService : ITranslationService
    {
        private readonly ITranslationRepository _translationRepository;

        public TranslationService(ITranslationRepository translationRepository)
        {
            _translationRepository = translationRepository;
        }

        public async Task<IEnumerable<Translation>> GetTranslationsAsync()
        {
            return await _translationRepository.GetTranslationsAsync();
        }

        public async Task<Translation> GetTranslationByIdAsync(int id)
        {
            return await _translationRepository.GetTranslationByIdAsync(id);
        }

        public async Task AddTranslationAsync(Translation translation)
        {
            await _translationRepository.AddTranslationAsync(translation);
        }

        public async Task<bool> UpdateTranslationAsync(int id, Translation translation)
        {
            return await _translationRepository.UpdateTranslationAsync(id, translation);
        }

        public async Task<bool> DeleteTranslationAsync(int id)
        {
            return await _translationRepository.DeleteTranslationAsync(id);
        }

       
    }
}
