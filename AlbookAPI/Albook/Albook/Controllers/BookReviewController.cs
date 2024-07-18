using Albook.Models.DTO;
using Albook.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Albook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookReviewsController : ControllerBase
    {
        private readonly BookReviewService _bookReviewService;

        public BookReviewsController(BookReviewService bookReviewService)
        {
            _bookReviewService = bookReviewService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookReviewDTO>>> GetBookReviews()
        {
            var reviews = await _bookReviewService.GetBookReviewsAsync();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookReviewDTO>> GetBookReview(int id)
        {
            var review = await _bookReviewService.GetBookReviewByIdAsync(id);
            if (review == null) return NotFound();

            return Ok(review);
        }

        [HttpPost]
        public async Task<ActionResult> AddBookReview([FromBody] BookReviewDTO reviewDTO)
        {
            await _bookReviewService.AddBookReviewAsync(reviewDTO);
            return CreatedAtAction(nameof(GetBookReview), new { id = reviewDTO.ReviewId }, reviewDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBookReview(int id, [FromBody] BookReviewDTO reviewDTO)
        {
            var result = await _bookReviewService.UpdateBookReviewAsync(id, reviewDTO);
            if (!result) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBookReview(int id)
        {
            var result = await _bookReviewService.DeleteBookReviewAsync(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}
