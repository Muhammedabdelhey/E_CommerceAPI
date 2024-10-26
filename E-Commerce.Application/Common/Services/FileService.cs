using E_Commerce.Application.Interfaces;

namespace E_Commerce.Application.Common.Services
{
    public class FileService : IFileService
    {
        private readonly IFileAdapter _fileAdapter;

        public FileService(IFileAdapter fileAdapter)
        {
            _fileAdapter = fileAdapter;
        }

        public async Task<string?> UploadFileAsync(IFormFile file, CancellationToken cancellationToken = default)
        {
            try
            {
                if (file is null) return null;
                return await _fileAdapter.UploadFileAsync(file, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while trying to upload the file.", ex);
            }
        }

        public async Task<bool> DeleteFileAsync(string fileName, CancellationToken cancellationToken = default)
        {
            try
            {
                var deleted = await _fileAdapter.DeleteFileAsync(fileName, cancellationToken);
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

        public string? GetFileUrl(string fileName)
        {
            return _fileAdapter.GetFileUrl(fileName);
        }
    }
}
