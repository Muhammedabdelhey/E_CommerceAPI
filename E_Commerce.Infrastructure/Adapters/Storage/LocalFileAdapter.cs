﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace E_Commerce.Infrastructure.Adapters.Storage
{
    public class LocalFileAdapter : IFileAdapter
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly string serverPath;

        public LocalFileAdapter(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
            serverPath = webHostEnvironment.WebRootPath;
        }

        public async Task<string> UploadFileAsync(string path, IFormFile file)
        {
            if (!Directory.Exists(serverPath))
            {
                Directory.CreateDirectory("wwwroot");
            }
            var filePath = Path.Combine(serverPath, path);
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

        public async Task<bool> DeleteFileAsync(string path, string fileName)
        {
            var filePath = Path.Combine(path, fileName);
            var fullPath = Path.Combine(serverPath, filePath);
            if (!File.Exists(fullPath))
            {
                return false;
            }
            await Task.Run(() => File.Delete(fullPath));
            return true;
        }
    }
}
