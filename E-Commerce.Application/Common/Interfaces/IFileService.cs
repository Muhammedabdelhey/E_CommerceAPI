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
        /// <param name="folderName">The desired path for the uploaded file (excluding the file name).</param>
        /// <param name="file">The file to be uploaded.</param>
        /// <returns> File name or null if no file passed.</returns>
        Task<string?> UploadFileAsync(string folderName, IFormFile file);

        /// <summary>
        /// Asynchronously Delete a file also this will use IFileAdapter for deleteing process itself.
        /// </summary>
        /// <param name="folderName">The desired path for the file (excluding the file name).</param>
        /// <param name="fileName"> file name you wanna deleted</param>
        /// <returns>true if file deleted</returns>
        Task<bool> DeleteFileAsync(string folderName, string fileName);
        /// <summary>
        /// Return file url based on IFileAdapter for get process itself.
        /// </summary>
        /// <param name="folderName">The desired path for the file (excluding the file name).</param>
        /// <param name="fileName"> file name you wanna get</param>
        /// <returns></returns>
        string? GetFileUrl(string folderName,string fileName); 
    }
}
