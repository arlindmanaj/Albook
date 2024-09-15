using Albook.Repositories.Interfaces;

namespace Albook.Services
{
    public class FileHandlerService : IFileHandlerService
    {
        private readonly string _baseFilePath;

        public FileHandlerService(IConfiguration configuration)
        {
            var relativePath = configuration["FileStorage:BasePath"];
            _baseFilePath = configuration["FileStorage:BasePath"];
        }

        public async Task<string> UploadFileAsync(IFormFile file, string userId)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File cannot be empty");

            // Create user-specific folder if it does not exist
            var userFolderPath = Path.Combine(_baseFilePath, userId);
            if (!Directory.Exists(userFolderPath))
                Directory.CreateDirectory(userFolderPath);

            // Save file to the folder
            var filePath = Path.Combine(userFolderPath, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;  // Return the full file path
        }

        public async Task<Stream> DownloadFileAsync(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found");

            var memoryStream = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memoryStream);
            }

            memoryStream.Position = 0;  // Reset stream position for reading
            return memoryStream;
        }
    }
}
