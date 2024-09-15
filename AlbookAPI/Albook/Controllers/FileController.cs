using Albook.Services.Implementation;
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


        [HttpDelete("{fileName}")]
        public IActionResult DeleteFile(string fileName)
        {
            var deletedFile = _fileHandlerService.DeleteFile(fileName);

            if (!deletedFile)
            {
                return NotFound(); // File not found or couldn't be deleted
            }

            return Ok(new { message = "File deleted successfully" }); // Return the deleted category
        }

        [HttpGet("exists/{fileName}")]
        public IActionResult CheckFileExists(string fileName)
        {
            var fileExists = _fileHandlerService.CheckFileExists(fileName);

            if (!fileExists)
            {
                return NotFound(new { message = $"File '{fileName}' not found." });
            }

            return Ok(new { message = $"File '{fileName}' exists." });
        }


        [HttpGet("list")]
        public IActionResult ListUploadedFiles()
        {
            var files = _fileHandlerService.ListUploadedFiles();

            if (files == null || files.Count == 0)
            {
                return NotFound(new { message = "No files found." });
            }

            return Ok(files);
        }
    }
}
