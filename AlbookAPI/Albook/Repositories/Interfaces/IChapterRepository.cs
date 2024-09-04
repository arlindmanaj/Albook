using Albook.Models.Domain;

namespace Albook.Repositories.Interfaces
{
    public interface IChapterRepository
    {
        Task<IEnumerable<Chapters>> GetChaptersByBookIdAsync(string bookId);
        Task<Chapters> GetChapterByIdAsync(int chapterId);
        Task AddChapterAsync(Chapters chapter);
        Task UpdateChapterAsync(Chapters chapter);
        Task DeleteChapterAsync(int chapterId);
    }
}
