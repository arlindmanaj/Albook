namespace Albook.Repositories.Interfaces
{
    public interface IFileHandlerService
    {
        Task<string> UploadFileAsync(IFormFile file, string userId);
        Task<Stream> DownloadFileAsync(string filePath);
    }
}
