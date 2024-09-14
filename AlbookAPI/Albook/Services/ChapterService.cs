using Albook.Models.Domain;
using Albook.Models.DTO;
using Albook.Repositories.Implementation;
using Albook.Repositories.Interfaces;

namespace Albook.Services
{
    public class ChapterService : IChapterService
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly IFileService _fileService;
        private readonly IBookRepository _bookRepository;

        public ChapterService(IChapterRepository chapterRepository, IFileService fileService, IBookRepository bookRepository)
        {
            _chapterRepository = chapterRepository;
            _fileService = fileService;
            _bookRepository = bookRepository;
        }
        public async Task<BookDto> AddBookWithPdfAsync(CreateBookRequestDto createBookDto, IFormFile pdfFile)
        {
            // Save the PDF file and get its relative path
            var contentUrl = await _fileService.SaveFileAsync(pdfFile);

            var book = new Book
            {
                BookId = Guid.NewGuid().ToString(),
                Title = createBookDto.Title,
                Author = createBookDto.Author,
                Description = createBookDto.Description,
                Language = createBookDto.Language,
                CoverUrl = createBookDto.CoverUrl,
                ContentUrl = contentUrl,  // Save the PDF's path to the book
                Price = createBookDto.Price,
                PublishedAt = DateTime.Now
            };

            var addedBook = await _bookRepository.AddBookAsync(book);

            return new BookDto
            {
                BookId = addedBook.BookId,
                Title = addedBook.Title,
                Author = addedBook.Author,
                ContentUrl = addedBook.ContentUrl // Return the ContentUrl
                                                  // Include other properties as needed
            };
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
