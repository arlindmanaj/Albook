using Albook.Services.Interfaces;
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

        // Endpoint for file upload
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            var result = await _fileHandlerService.UploadFileAsync(file);

            if (result == "Invalid file." || result == "Invalid file format. Only PDF and DocX files are allowed.")
            {
                return BadRequest(result);
            }

            return Ok(new { FileName = result });
        }

        // Endpoint for file download
        [HttpGet("download/{fileName}")]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            try
            {
                var fileBytes = await _fileHandlerService.DownloadFileAsync(fileName);
                return File(fileBytes, "application/octet-stream", fileName);
            }
            catch (FileNotFoundException)
            {
                return NotFound("File not found.");
            }
        }
    }
}
