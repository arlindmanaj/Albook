using Albook.Models.Domain;
using Albook.Models.DTO;

namespace Albook.Services.Interfaces
{
    public interface IChapterService
    {
        Task<List<Chapter>> GetChaptersByBookIdAsync(string bookId);
        Task<Chapter> GetChapterByIdAsync(int chapterId);
        Task AddChaptersFromFileAsync(string bookId, IFormFile file);
        Task UpdateChapterAsync(int chapterId, UpdateChapterDto updatedChapterDto);
        Task DeleteChapterAsync(int chapterId);
    }
}
