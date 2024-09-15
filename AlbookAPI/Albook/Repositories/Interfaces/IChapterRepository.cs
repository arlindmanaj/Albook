using Albook.Models.Domain;

namespace Albook.Repositories.Interfaces
{
    public interface IChapterRepository
    {
        Task<List<Chapter>> GetChaptersByBookIdAsync(string bookId);
        Task<Chapter> GetChapterByIdAsync(int chapterId);
        Task AddChapterAsync(Chapter chapter);
        Task UpdateChapterAsync(Chapter chapter);
        Task DeleteChapterAsync(int chapterId);
    }
}
