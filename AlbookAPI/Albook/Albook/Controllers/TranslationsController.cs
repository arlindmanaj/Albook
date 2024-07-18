using Albook.Models.Domain;
using Albook.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Albook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslationsController : ControllerBase
    {
        private readonly TranslationService _translationService;

        public TranslationsController(TranslationService translationService)
        {
            _translationService = translationService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetTranslations()
        {
            var translations = await _translationService.GetTranslationsAsync();
            return Ok(translations);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetTranslation(int id)
        {
            var translation = await _translationService.GetTranslationByIdAsync(id);
            if (translation == null)
                return NotFound();

            return Ok(translation);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddTranslation([FromBody] Translation translation)
        {
            await _translationService.AddTranslationAsync(translation);
            return Ok(new { message = "Translation added successfully." });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateTranslation(int id, [FromBody] Translation translation)
        {
            var updated = await _translationService.UpdateTranslationAsync(id, translation);
            if (!updated)
                return NotFound();

            return Ok(new { message = "Translation updated successfully." });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTranslation(int id)
        {
            var deleted = await _translationService.DeleteTranslationAsync(id);
            if (!deleted)
                return NotFound();

            return Ok(new { message = "Translation deleted successfully." });
        }
    }
}
