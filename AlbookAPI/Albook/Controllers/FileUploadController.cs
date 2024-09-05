using Albook.Repositories.Interfaces;
using Albook.Uploads;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Albook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileUploadController : ControllerBase
    {
      
        public FileUploadController()
        {
        }

        [HttpPost("upload-pdf")]
        public async Task<IActionResult> UploadPdf( IFormFile file)
        {
          

            return Ok(new UploadHandler().Upload(file));

        }
    }
}
