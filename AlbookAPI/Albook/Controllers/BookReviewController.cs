using Albook.Models.DTO;
using Albook.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Albook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookReviewsController : ControllerBase
    {
        private readonly IBookReviewService _bookReviewService;

        public BookReviewsController(IBookReviewService bookReviewService)
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
        public async Task<ActionResult<BookReviewDTO>> GetBookReview(string id)
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
        public async Task<ActionResult> UpdateBookReview(string id, [FromBody] BookReviewDTO reviewDTO)
        {
            var result = await _bookReviewService.UpdateBookReviewAsync(id, reviewDTO);
            if (!result) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBookReview(string id)
        {
            var result = await _bookReviewService.DeleteBookReviewAsync(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}
