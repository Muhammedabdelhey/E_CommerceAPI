using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.IO;
using System.Reflection.Metadata;

namespace E_Commerce.Infrastructure.Adapters.Storage
{
    public class LocalFileAdapter : IFileAdapter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string serverPath;
        private bool disposed = false;

        public LocalFileAdapter(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            serverPath = Path.Combine(webHostEnvironment.WebRootPath, "Images");
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> UploadFileAsync(IFormFile file, CancellationToken cancellationToken = default)
        {
            if (!Directory.Exists(serverPath))
            {
                Directory.CreateDirectory("wwwroot");
            }
            if (!Directory.Exists(serverPath))
            {
                Directory.CreateDirectory(serverPath);
            }
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var fullPath = Path.Combine(serverPath, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream, cancellationToken);
            }
            return fileName;
        }

        public async Task<bool> DeleteFileAsync(string fileName, CancellationToken cancellationToken = default)
        {
            var fullPath = Path.Combine(serverPath, fileName);
            if (!File.Exists(fullPath))
            {
                return false;
            }
            await Task.Run(() => File.Delete(fullPath), cancellationToken);
            return true;
        }

        public string? GetFileUrl(string fileName)
        {
            var request = _httpContextAccessor.HttpContext?.Request;
            var fullPath = Path.Combine(serverPath, fileName);
            if (!File.Exists(fullPath))
            {
                return null;
            }
            return $"{request?.Scheme}://{request?.Host}/Images/{fileName}";
        }
    }
}
