using Albook.Models.Domain;
using Albook.Models.DTO;
using Albook.Repositories.Interfaces;

namespace Albook.Services
{
    public class BookService : IBookService
    {
        private readonly ICategoryRepository _categoryRepository;

        private readonly IBookRepository _bookRepository;
        private readonly IBookCategoryRepository _bookCategoryRepository;
        public BookService(ICategoryRepository categoryRepository, IBookRepository bookRepository, IBookCategoryRepository bookCategoryRepository)
        {
            _categoryRepository = categoryRepository;
            _bookRepository = bookRepository;
            _bookCategoryRepository = bookCategoryRepository;
        }

        //FIX
        public async Task<IEnumerable<BookDto>> GetBooksAsync()
        {
            var books = await _bookRepository.GetBooksAsync();
            var response = new List<BookDto>();

            foreach (var book in books)
            {
                var bookCategories = await _bookCategoryRepository.GetCategoriesByBookIdAsync(book.BookId);

                response.Add(new BookDto
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
                    Categories = bookCategories.Select(bc => new CategoryDto
                    {
                        CategoryId = bc.CategoryId,
                        Name = bc.Category.Name
                    }).ToList()
                });
            }

            return response;
        }

        //FIX
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

        //FIX
        public async Task<BookDto> AddBookAsync(BookDto bookDto)
        {
            var book = new Book
            {
                BookId = Guid.NewGuid().ToString(), // Assuming BookId is a GUID or similar unique identifier
                Title = bookDto.Title,
                Author = bookDto.Author,
                Description = bookDto.Description,
                Language = bookDto.Language,
                CoverUrl = bookDto.CoverUrl,
                ContentUrl = bookDto.ContentUrl,
                Price = bookDto.Price,
                PublishedAt = DateTime.Now // Assuming new books have a current timestamp
            };

            Book addedBook = await _bookRepository.AddBookAsync(book);

            // Create BookCategories entries
            foreach (var categoryDto in bookDto.Categories)
            {
                var bookCategory = new BooksCategories
                {
                    BookId = addedBook.BookId,
                    CategoryId = categoryDto.CategoryId
                };
                await _bookCategoryRepository.AddBookCategoryAsync(bookCategory);
            }

            // Re-fetch the book to include the related categories
            return await GetBookByIdAsync(addedBook.BookId);
        }

        //FIX
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

            // Remove existing category associations -> LIND, ose i len qysh i pat e ja shton t rejat, ose mas miri i fshin krejt
            //Pse i fshin krejt? se ne UI i ki aty diku me check items kategoriat, kshtu qe ja fshin e ja rishkrun nuk i hupin
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