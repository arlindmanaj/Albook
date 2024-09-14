using Albook.Models.DTO;

namespace Albook.Repositories.Interfaces
{
    public interface IChapterService
    {
        Task<IEnumerable<ChaptersDto>> GetChaptersByBookIdAsync(string bookId);
        Task<ChaptersDto> GetChapterByIdAsync(int chapterId);
        Task AddChapterAsync(CreateChapterDto createChapterDto);
        Task UpdateChapterAsync(int chapterId, UpdateChapterDto updateChapterDto);
        Task DeleteChapterAsync(int chapterId);
        Task<BookDto> AddBookWithPdfAsync(CreateBookRequestDto createBookRequestDto, IFormFile pdfFile);
    }

}
