using Albook.Services.Interfaces;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using UglyToad.PdfPig;

namespace Albook.Services.Implementation
{
    public class FileHandlerService : IFileHandlerService
    {
        private readonly string _uploadsFolderPath;

        public FileHandlerService()
        {
            // Set the uploads folder path relative to the application's root directory
            _uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

            // Ensure the Uploads directory exists
            if (!Directory.Exists(_uploadsFolderPath))
            {
                Directory.CreateDirectory(_uploadsFolderPath);
            }
        }
        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return "Invalid file.";
            }

            // Get file extension
            var fileExtension = Path.GetExtension(file.FileName).ToLower();
            if (fileExtension != ".pdf" && fileExtension != ".docx")
            {
                return "Invalid file format. Only PDF and DocX files are allowed.";
            }

            // Generate a unique file name to avoid overwriting
            var fileName = file.FileName;
            var filePath = Path.Combine(_uploadsFolderPath, fileName);
            int fileCount = 1;
            while (File.Exists(filePath))
            {
                fileName = $"{Path.GetFileNameWithoutExtension(file.FileName)}_{fileCount}{fileExtension}";
                filePath = Path.Combine(_uploadsFolderPath, fileName);
                fileCount++;
            }
            // Save the file to the specified path
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return fileName;  // Return the file name or path for further use
        }
        public Task<byte[]> DownloadFileAsync(string fileName)
        {
            var filePath = Path.Combine(_uploadsFolderPath, fileName);

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found.");
            }

            // Read the file as a byte array
            return File.ReadAllBytesAsync(filePath);
        }

        public bool DeleteFile(string fileName)
        {
            var filePath = Path.Combine(_uploadsFolderPath, fileName);

            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath); // Synchronous file delete
                    return true;
                }
                catch (Exception)
                {
                    // Handle/log the exception if necessary
                    return false;
                }
            }

            return false; // File does not exist


        }

        public bool CheckFileExists(string fileName)
        {
            var filePath = Path.Combine(_uploadsFolderPath, fileName);
            return File.Exists(filePath);
        }

        public List<string> ListUploadedFiles()
        {
            return Directory.GetFiles(_uploadsFolderPath)
                    .Select(file => Path.GetFileName(file))
                    .ToList();
        }

        public string ExtractTextFromFile(IFormFile file)
        {
            StringBuilder textBuilder = new StringBuilder();

            // Open the PDF using the stream from IFormFile
            using (var stream = file.OpenReadStream())
            using (UglyToad.PdfPig.PdfDocument pdf = UglyToad.PdfPig.PdfDocument.Open(stream))
            {
                // Loop through each page in the PDF
                foreach (var page in pdf.GetPages())
                {
                    // Extract text from the page
                    textBuilder.Append(page.Text);
                }
            }

            return textBuilder.ToString();
           
        }
        

       

    }
}
