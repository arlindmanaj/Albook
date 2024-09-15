using Albook.Models.Domain;
using Albook.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Albook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChapterController : ControllerBase
    {
       
            private readonly IChapterService _chapterService;

            public ChapterController(IChapterService chapterService)
            {
                _chapterService = chapterService;
            }

            // 1. Get all chapters for a specific book
            [HttpGet("book/{bookId}")]
            public async Task<IActionResult> GetChaptersByBookId(string bookId)
            {
                var chapters = await _chapterService.GetChaptersByBookIdAsync(bookId);
                if (chapters == null || !chapters.Any())
                {
                    return NotFound(new { message = "No chapters found for this book." });
                }
                return Ok(chapters);
            }

            // 2. Get a specific chapter by ID
            [HttpGet("{chapterId}")]
            public async Task<IActionResult> GetChapterById(int chapterId)
            {
                var chapter = await _chapterService.GetChapterByIdAsync(chapterId);
                if (chapter == null)
                {
                    return NotFound(new { message = "Chapter not found." });
                }
                return Ok(chapter);
            }

            // 3. Upload a file and add chapters by extracting text from the file
            [HttpPost("upload/{bookId}")]
            public async Task<IActionResult> UploadFileAndAddChapters(string bookId, IFormFile file)
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest(new { message = "Invalid file upload." });
                }

                try
                {
                    await _chapterService.AddChaptersFromFileAsync(bookId, file);
                    return Ok(new { message = "Chapters added successfully." });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { message = "An error occurred while processing the file.", error = ex.Message });
                }
            }

            // 4. Update a specific chapter
            [HttpPut("{chapterId}")]
            public async Task<IActionResult> UpdateChapter(int chapterId, [FromBody] Chapter updatedChapter)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingChapter = await _chapterService.GetChapterByIdAsync(chapterId);
                if (existingChapter == null)
                {
                    return NotFound(new { message = "Chapter not found." });
                }

                await _chapterService.UpdateChapterAsync(chapterId, updatedChapter);
                return NoContent(); // 204 No Content, indicating successful update with no body.
            }

            // 5. Delete a specific chapter
            [HttpDelete("{chapterId}")]
            public async Task<IActionResult> DeleteChapter(int chapterId)
            {
                var existingChapter = await _chapterService.GetChapterByIdAsync(chapterId);
                if (existingChapter == null)
                {
                    return NotFound(new { message = "Chapter not found." });
                }

                await _chapterService.DeleteChapterAsync(chapterId);
                return NoContent();
            }
        }

    }

