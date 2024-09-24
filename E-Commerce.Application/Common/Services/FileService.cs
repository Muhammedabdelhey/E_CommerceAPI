using E_Commerce.Application.Interfaces;
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

        public async Task<string?> UploadFileAsync(string folderName, IFormFile file)
        {
            try
            {
                if (file is null) return null;
                return await _fileAdapter.UploadFileAsync(folderName, file); ;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while trying to upload the file.", ex);
            }
        }

        public async Task<bool> DeleteFileAsync(string folderName, string fileName)
        {
            try
            {
                var deleted = await _fileAdapter.DeleteFileAsync(folderName, fileName);
                if (!deleted)
                {
                    throw new NotFoundException("the file you want delete not found.");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while trying to delete the file.", ex);
            }
        }

        public string? GetFileUrl(string folderName, string fileName)
        {
            return _fileAdapter.GetFileUrl(folderName, fileName);
        }
    }
}
