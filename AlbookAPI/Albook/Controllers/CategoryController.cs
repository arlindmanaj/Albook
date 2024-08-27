using Albook.Models.DTO;
using Albook.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Albook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CreateCategoryDto categoryDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdCategory = await _categoryService.AddCategoryAsync(categoryDto);
            return CreatedAtAction(nameof(GetCategoryById), new { id = createdCategory.CategoryId }, createdCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryDto updateCategoryDto)
        {
            var updatedCategory = await _categoryService.UpdateCategoryAsync(id, updateCategoryDto);
            if (updatedCategory == null)
            {
                return NotFound(); // Category not found
            }

            return Ok(updatedCategory); // Return the updated category
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var deletedCategory = await _categoryService.DeleteCategoryAsync(id);
            if (deletedCategory == null)
            {
                return NotFound(); // Category not found
            }

            return Ok(deletedCategory); // Return the deleted category
        }
    }
}
