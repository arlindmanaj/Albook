using System.Threading.Tasks;
namespace Albook.Services.Interfaces
{
    public interface IFileHandlerService
    {

        Task<string> UploadFileAsync(IFormFile file);
        Task<byte[]> DownloadFileAsync(string fileName);
        Task<bool> DeleteFileAsync(string fileName);
        bool CheckFileExists(string fileName);
        List<string> ListUploadedFiles();
    }
}
