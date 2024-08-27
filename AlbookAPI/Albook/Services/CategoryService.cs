using Albook.Models.Domain;
using Albook.Models.DTO;
using Albook.Repositories.Interfaces;

namespace Albook.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;


        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

        }
        public async Task<CategoryDto> AddCategoryAsync(CreateCategoryDto categoryDto)
        {
            // Manually map CategoryDto to Category
            var category = new Category
            {
                Name = categoryDto.Name

            }; // KQYR A MUNET MU KON PROBLEM NDRRIMI I PARAMETRIT PREJ CATEGORY N'CREATECATEGORY

            var newCategory = await _categoryRepository.AddCategoryAsync(category);

            // Manually map the new Category back to CategoryDto
            return new CategoryDto
            {
                CategoryId = newCategory.CategoryId,
                Name = newCategory.Name,

            };
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();

            // Manually map each Category to CategoryDto
            var categoryDtos = new List<CategoryDto>();
            foreach (var category in categories)
            {
                categoryDtos.Add(new CategoryDto
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,

                });
            }

            return categoryDtos;
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);

            if (category == null)
            {
                return null;
            }

            // Manually map Category to CategoryDto
            return new CategoryDto
            {
                CategoryId = category.CategoryId,
                Name = category.Name,

            };
        }

        public async Task<CategoryDto> UpdateCategoryAsync(int categoryId, UpdateCategoryDto updateCategoryDto)
        {
            var existingCategory = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            if (existingCategory == null) return null;


            existingCategory.Name = updateCategoryDto.Name;


            await _categoryRepository.UpdateCategoryAsync(existingCategory);


            var updatedCategoryDto = new CategoryDto
            {
                CategoryId = existingCategory.CategoryId,
                Name = existingCategory.Name

            };

            return updatedCategoryDto;
        }

        public async Task<CategoryDto> DeleteCategoryAsync(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            if (category == null) return null;

            await _categoryRepository.DeleteCategoryAsync(categoryId);
            var deletedCategoryDto = new CategoryDto
            { CategoryId = category.CategoryId };
            return deletedCategoryDto;
        }





    }



}
