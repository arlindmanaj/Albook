using Albook.Models.DTO;

namespace Albook.Repositories.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IFormFile file);
    }
}
