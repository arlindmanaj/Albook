using Albook.Models.DTO;

namespace Albook.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int categoryId);
        Task<CategoryDto> AddCategoryAsync(CreateCategoryDto categoryDto);
        Task<CategoryDto> UpdateCategoryAsync(int categoryId, UpdateCategoryDto updateCategoryDto);
        Task<CategoryDto> DeleteCategoryAsync(int categoryId);
    }
}
