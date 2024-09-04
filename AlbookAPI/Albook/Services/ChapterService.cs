using Albook.Models.Domain;
using Albook.Models.DTO;
using Albook.Repositories.Interfaces;

namespace Albook.Services
{
    public class ChapterService : IChapterService
    {
        private readonly IChapterRepository _chapterRepository;

        public ChapterService(IChapterRepository chapterRepository)
        {
            _chapterRepository = chapterRepository;
        }

        public async Task<IEnumerable<ChaptersDto>> GetChaptersByBookIdAsync(string bookId)
        {
            var chapters = await _chapterRepository.GetChaptersByBookIdAsync(bookId);
            return chapters.Select(ch => new ChaptersDto
            {
                ChapterId = ch.ChapterId,
                Title = ch.Title,
                Order = ch.Order
            }).ToList();
        }

        public async Task<ChaptersDto> GetChapterByIdAsync(int chapterId)
        {
            var chapter = await _chapterRepository.GetChapterByIdAsync(chapterId);
            if (chapter == null) throw new Exception("Chapter not found");

            return new ChaptersDto
            {
                ChapterId = chapter.ChapterId,
                Title = chapter.Title,
                Content = chapter.Content,
                Order = chapter.Order
            };
        }

        public async Task AddChapterAsync(CreateChapterDto createChapterDto)
        {
            var chapter = new Chapters
            {
                BookId = createChapterDto.BookId,
                Title = createChapterDto.Title,
                Content = createChapterDto.Content,
                Order = createChapterDto.Order
            };
            await _chapterRepository.AddChapterAsync(chapter);
        }

        public async Task UpdateChapterAsync(int chapterId, UpdateChapterDto updateChapterDto)
        {
            var chapter = await _chapterRepository.GetChapterByIdAsync(chapterId);
            if (chapter == null) throw new Exception("Chapter not found");

            chapter.Title = updateChapterDto.Title;
            chapter.Content = updateChapterDto.Content;
            chapter.Order = updateChapterDto.Order;

            await _chapterRepository.UpdateChapterAsync(chapter);
        }

        public async Task DeleteChapterAsync(int chapterId)
        {
            await _chapterRepository.DeleteChapterAsync(chapterId);
        }
    }
}
