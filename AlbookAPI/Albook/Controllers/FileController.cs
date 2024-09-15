using Albook.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Albook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileHandlerService _fileHandlerService;

        public FileController(IFileHandlerService fileHandlerService)
        {
            _fileHandlerService = fileHandlerService;
        }

        [HttpPost("upload/{userId}")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file, string userId)
        {
            try
            {
                var filePath = await _fileHandlerService.UploadFileAsync(file, userId);
                return Ok(new { FilePath = filePath });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("download")]
        public async Task<IActionResult> DownloadFile([FromQuery] string filePath)
        {
            try
            {
                var fileStream = await _fileHandlerService.DownloadFileAsync(filePath);
                return File(fileStream, "application/pdf", Path.GetFileName(filePath));
            }
            catch (FileNotFoundException)
            {
                return NotFound("File not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
