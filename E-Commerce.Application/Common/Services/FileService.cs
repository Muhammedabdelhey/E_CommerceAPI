using E_Commerce.Application.Interfaces; // Fixed typo
using Microsoft.AspNetCore.Http;

namespace E_Commerce.Application.Common.Services
{
    public class FileService : IFileService
    {
        private readonly IFileAdapter _fileAdapter;

        public FileService(IFileAdapter fileAdapter)
        {
            _fileAdapter = fileAdapter;
        }

        public async Task<string> UploadFileAsync(string filePath, IFormFile file)
        {
            if (file == null)
            {
                throw new ValidationException("No file uploaded. Please upload a file.");
            }
            try
            {
                var fileName = await _fileAdapter.UploadFileAsync(filePath, file);
                return fileName;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while trying to upload the file.", ex);
            }
        }
    }
}
