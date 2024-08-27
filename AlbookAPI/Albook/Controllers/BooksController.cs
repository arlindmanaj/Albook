using Albook.Models.Domain;
using Albook.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Albook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookService.GetBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(string id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            //await _bookService.AddBookAsync(book);
            return Ok(new { message = "Book added successfully." });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateBook(string id, [FromBody] Book book)
        {
            //var updated = await _bookService.UpdateBookAsync(id, book);
            //if (!updated)
            //    return NotFound();

            return Ok(new { message = "Book updated successfully." });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteBook(string id)
        {
            var deleted = await _bookService.DeleteBookAsync(id);
            if (!deleted)
                return NotFound();

            return Ok(new { message = "Book deleted successfully." });
        }
    }
}
