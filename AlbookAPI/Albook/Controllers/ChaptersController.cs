using Albook.Models.DTO;
using Albook.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Albook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChapterController : ControllerBase
    {
        private readonly IChapterService _chapterService;

        public ChapterController(IChapterService chapterService)
        {
            _chapterService = chapterService;
        }

        [HttpGet("book/{bookId}")]
        public async Task<IActionResult> GetChaptersByBookId(string bookId)
        {
            var chapters = await _chapterService.GetChaptersByBookIdAsync(bookId);
            return Ok(chapters);
        }

        [HttpGet("{chapterId}")]
        public async Task<IActionResult> GetChapterById(int chapterId)
        {
            var chapter = await _chapterService.GetChapterByIdAsync(chapterId);
            return Ok(chapter);
        }

        [HttpPost]
        public async Task<IActionResult> AddChapter([FromBody] CreateChapterDto createChapterDto)
        {
            await _chapterService.AddChapterAsync(createChapterDto);
            return Ok();
        }

        [HttpPut("{chapterId}")]
        public async Task<IActionResult> UpdateChapter(int chapterId, [FromBody] UpdateChapterDto updateChapterDto)
        {
            await _chapterService.UpdateChapterAsync(chapterId, updateChapterDto);
            return Ok();
        }

        [HttpDelete("{chapterId}")]
        public async Task<IActionResult> DeleteChapter(int chapterId)
        {
            await _chapterService.DeleteChapterAsync(chapterId);
            return Ok();
        }
    }

}
