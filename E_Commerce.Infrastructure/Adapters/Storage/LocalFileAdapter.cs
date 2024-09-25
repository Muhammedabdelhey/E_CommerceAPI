using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace E_Commerce.Infrastructure.Adapters.Storage
{
    public class LocalFileAdapter : IFileAdapter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly string serverPath;

        public LocalFileAdapter(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            serverPath = webHostEnvironment.WebRootPath;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> UploadFileAsync(string folderName, IFormFile file)
        {
            if (!Directory.Exists(serverPath))
            {
                Directory.CreateDirectory("wwwroot");
            }
            var filePath = Path.Combine(serverPath, folderName);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var fullPath = Path.Combine(filePath, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return fileName;
        }

        public async Task<bool> DeleteFileAsync(string folderName, string fileName)
        {
            var filePath = Path.Combine(folderName, fileName);
            var fullPath = Path.Combine(serverPath, filePath);
            if (!File.Exists(fullPath))
            {
                return false;
            }
            await Task.Run(() => File.Delete(fullPath));
            return true;
        }

        public string? GetFileUrl(string folderName, string fileName)
        {
            var request = _httpContextAccessor.HttpContext?.Request;
            var filePath = Path.Combine(folderName, fileName);
            var fullPath = Path.Combine(serverPath, filePath);
            if (!File.Exists(fullPath))
            {
                return null;
            }
            return $"{request?.Scheme}://{request?.Host}/{folderName}/{fileName}";
        }
    }
}
