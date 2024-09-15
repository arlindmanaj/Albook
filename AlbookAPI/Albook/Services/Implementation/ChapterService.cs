using Albook.Models.Domain;
using Albook.Repositories.Interfaces;
using Albook.Services.Interfaces;
using System.Text.RegularExpressions;

namespace Albook.Services.Implementation
{
    public class ChapterService : IChapterService
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly IFileHandlerService _fileHandlerService; // For file handling
        private readonly ILogger<ChapterService> _logger;

        public ChapterService(IChapterRepository chapterRepository, IFileHandlerService fileHandlerService, ILogger<ChapterService> logger)
        {
            _chapterRepository = chapterRepository;
            _fileHandlerService = fileHandlerService;
            _logger = logger;
        }

      
        public async Task<List<Chapter>> GetChaptersByBookIdAsync(string bookId)
        {
            return await _chapterRepository.GetChaptersByBookIdAsync(bookId);
        }

       
        public async Task<Chapter> GetChapterByIdAsync(int chapterId)
        {
            return await _chapterRepository.GetChapterByIdAsync(chapterId);
        }

      
        public async Task AddChaptersFromFileAsync(string bookId, IFormFile file)
        {
           
            var extractedText = _fileHandlerService.ExtractTextFromFile(file); // You'll need your existing file extraction logic here

        
            var chaptersContent = SplitTextIntoChapters(extractedText);

           
            int chapterNumber = 1;
            foreach (var content in chaptersContent)
            {
                var chapter = new Chapter
                {
                    BookId = bookId,
                    Title = $"Chapter {chapterNumber}",
                    Content = content,
                    ChapterNumber = chapterNumber
                };

                await _chapterRepository.AddChapterAsync(chapter);
                chapterNumber++;
            }
        }

       
        public async Task UpdateChapterAsync(int chapterId, Chapter updatedChapter)
        {
            var existingChapter = await _chapterRepository.GetChapterByIdAsync(chapterId);
            if (existingChapter == null)
            {
                _logger.LogWarning($"Chapter with ID {chapterId} not found.");
                return;
            }

            existingChapter.Title = updatedChapter.Title;
            existingChapter.Content = updatedChapter.Content;
            existingChapter.ChapterNumber = updatedChapter.ChapterNumber;

            await _chapterRepository.UpdateChapterAsync(existingChapter);
        }

       
        public async Task DeleteChapterAsync(int chapterId)
        {
            await _chapterRepository.DeleteChapterAsync(chapterId);
        }

       
        private List<string> SplitTextIntoChapters(string text)
        {
           
            return Regex.Split(text, @"Chapter \d+").Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        }
    }

}
