using Albook.Models.Domain;
using Albook.Repositories.Interface;
using Albook.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Albook.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _bookRepository.GetBooksAsync();
        }

        public async Task<Book> GetBookByIdAsync(string id)
        {
            return await _bookRepository.GetBookByIdAsync(id);
        }

        public async Task AddBookAsync(Book book)
        {
            await _bookRepository.AddBookAsync(book);
        }

        public async Task<bool> UpdateBookAsync(string id, Book book)
        {
            return await _bookRepository.UpdateBookAsync(id, book);
        }

        public async Task<bool> DeleteBookAsync(string id)
        {
            return await _bookRepository.DeleteBookAsync(id);
        }

       
    }
}
