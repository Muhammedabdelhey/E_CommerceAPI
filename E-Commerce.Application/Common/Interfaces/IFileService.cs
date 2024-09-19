using E_Commerce.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace E_Commerce.Domain.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// Asynchronously uploads a file to the specified path, validating it's content before storage,
        /// also this will use IFileAdapter for uploading process itself.
        /// </summary>
        /// <param name="filePath">The desired path for the uploaded file (excluding the file name).</param>
        /// <param name="file">The file to be uploaded.</param>
        /// <returns> File name.</returns>
        Task<string> UploadFileAsync(string filePath, IFormFile file);

        /// <summary>
        /// Asynchronously Delete a file also this will use IFileAdapter for deleteing process itself.
        /// </summary>
        /// <param name="filePath">The desired path for the file (excluding the file name).</param>
        /// <param name="fileName"> file name you wanna deleted</param>
        /// <returns>true if file deleted</returns>
        Task<bool> DeleteFileAsync(string filePath, string fileName);
        /// <summary>
        /// Return file url based on IFileAdapter for get process itself.
        /// </summary>
        /// <param name="filePath">The desired path for the file (excluding the file name).</param>
        /// <param name="fileName"> file name you wanna get</param>
        /// <returns></returns>
        string? GetFileUrl(string filePath,string fileName); 
    }
}
