using E_Commerce.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace E_Commerce.Domain.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// Asynchronously uploads a file to the specified path, validating its content before storage,
        /// also this will use IFileAdapter for uploading process itself.
        /// </summary>
        /// <param name="filePath">The desired path for the uploaded file (excluding the file name).</param>
        /// <param name="file">The file to be uploaded.</param>
        /// <returns> File name.</returns>
        Task<string> UploadFileAsync(string filePath, IFormFile file);
    }
}
