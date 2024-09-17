using Albook.Models.Domain;
using Albook.Models.DTO;
using Albook.Repositories.Interfaces;
using Albook.Services.Interfaces;

namespace Albook.Services.Implementation
{
    public class BookService : IBookService
    {
        private readonly ICategoryRepository _categoryRepository;

        private readonly IBookRepository _bookRepository;
        private readonly IBookCategoryRepository _bookCategoryRepository;
        private readonly IBooksChapterRepository _booksChapterRepository;

        public BookService(ICategoryRepository categoryRepository, 
            IBookRepository bookRepository, 
            IBookCategoryRepository bookCategoryRepository,
            IBooksChapterRepository bookChapterRepository)
        {
            _categoryRepository = categoryRepository;
            _bookRepository = bookRepository;
            _bookCategoryRepository = bookCategoryRepository;
            _booksChapterRepository = bookChapterRepository;
        }


        public async Task<IEnumerable<BookDto>> GetBooksAsync()
        {
            var books = await _bookRepository.GetBooksAsync();
            var response = new List<BookDto>();

            foreach (var book in books)
            {
                // Retrieve the categories associated with the book
                var bookCategories = await _bookCategoryRepository.GetCategoriesByBookIdAsync(book.BookId);
                var booksChapters = await _booksChapterRepository.GetChaptersByBookIdAsync(book.BookId);

                // Map the book and its categories to a BookDto
                var bookDto = new BookDto
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description,
                    Language = book.Language,
                    CoverUrl = book.CoverUrl,
                    ContentUrl = book.ContentUrl,
                    Price = book.Price,
                    PublishedAt = book.PublishedAt,
                    Categories = bookCategories.Select(c => new CategoryDto
                    {
                        CategoryId = c.CategoryId,
                        Name = c.Category.Name
                    }).ToList(),
                    Chapters = booksChapters.Select(bc => new ChapterDto
                    {
                        ChapterId = bc.Chapter.ChapterId,
                        Title = bc.Chapter.Title,
                        Content = bc.Chapter.Content
                    }).ToList()
                };

                response.Add(bookDto);
            }

            return response;
        }

        public async Task<BookDto> GetBookByIdAsync(string id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id); // Fetch from the database
            if (book == null) return null;

            var bookCategories = await _bookCategoryRepository.GetCategoriesByBookIdAsync(book.BookId);

            return new BookDto
            {
                BookId = book.BookId,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Language = book.Language,
                CoverUrl = book.CoverUrl,
                ContentUrl = book.ContentUrl,
                Price = book.Price,
                Categories = bookCategories.Select(bc => new CategoryDto
                {
                    CategoryId = bc.CategoryId,
                    Name = bc.Category.Name
                }).ToList()
            };
        }

        public async Task<BookDto> AddBookAsync(CreateBookRequestDto createBookDto)
        {
            var book = new Book
            {
                BookId = Guid.NewGuid().ToString(), // Assuming BookId is a GUID or similar unique identifier
                Title = createBookDto.Title,
                Author = createBookDto.Author,
                Description = createBookDto.Description,
                Language = createBookDto.Language,
                CoverUrl = createBookDto.CoverUrl,
                ContentUrl = createBookDto.ContentUrl,
                Price = createBookDto.Price,
                PublishedAt = DateTime.Now, // Assuming new books have a current timestamp
                Translations = createBookDto.Translations

            };

            foreach (var item in book.Translations)
            {
                item.BookId = book.BookId;
            }

            var addedBook = await _bookRepository.AddBookAsync(book);

            // Create BookCategories entries
            foreach (var categoryId in createBookDto.CategoryIds)
            {
                var bookCategory = new BooksCategories
                {
                    BookId = book.BookId,
                    CategoryId = categoryId
                };
                await _bookCategoryRepository.AddBookCategoryAsync(bookCategory);
            }

            // Re-fetch the book to include the related categories
            return await GetBookByIdAsync(addedBook.BookId);
        }


        public async Task<bool> UpdateBookAsync(string id, BookDto bookDto)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null)
            {
                return false;
            }

            // Update book properties
            book.Title = bookDto.Title;
            book.Author = bookDto.Author;
            book.Description = bookDto.Description;
            book.Language = bookDto.Language;
            book.CoverUrl = bookDto.CoverUrl;
            book.ContentUrl = bookDto.ContentUrl;
            book.Price = bookDto.Price;



            await _bookCategoryRepository.RemoveCategoriesByBookIdAsync(book.BookId);

            // Add new category associations
            foreach (var categoryDto in bookDto.Categories)
            {
                var bookCategory = new BooksCategories
                {
                    BookId = book.BookId,
                    CategoryId = categoryDto.CategoryId
                };
                await _bookCategoryRepository.AddBookCategoryAsync(bookCategory);
            }

            // Save the updated book
            return await _bookRepository.UpdateBookAsync(id, book);
        }

        public async Task<bool> DeleteBookAsync(string id)
        {
            return await _bookRepository.DeleteBookAsync(id);
        }
    }
}