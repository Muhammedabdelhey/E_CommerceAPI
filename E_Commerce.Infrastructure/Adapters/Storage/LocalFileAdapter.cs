using E_Commerce.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace E_Commerce.Infrastructure.Adapters.Storage
{
    public class LocalFileAdapter : IFileAdapter
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public LocalFileAdapter(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        public async Task<string> UploadFileAsync(string path, IFormFile file)
        {
            var serverPath = webHostEnvironment.WebRootPath;
            if (!Directory.Exists(serverPath))
            {
                Directory.CreateDirectory("wwwroot");
            }
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(serverPath, path);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            var fullPath = Path.Combine(filePath, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return fileName;
        }
    }
}
