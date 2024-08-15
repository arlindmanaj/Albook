using Albook.Data;
using Albook.Models.Domain;
using Albook.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Albook.Repositories.Implementation
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(string bookId)
        {
            return await _context.Books.FindAsync(bookId);
        }

        public async Task AddBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateBookAsync(string bookId, Book book)
        {
            var existingBook = await _context.Books.FindAsync(bookId);
            if (existingBook == null)
            {
                return false;
            }

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Description = book.Description;
            existingBook.Language = book.Language;
            existingBook.CoverUrl = book.CoverUrl;
            existingBook.ContentUrl = book.ContentUrl;
            existingBook.Price = book.Price;
            existingBook.PublishedAt = book.PublishedAt;

            _context.Books.Update(existingBook);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBookAsync(string bookId)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book == null)
            {
                return false;
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
