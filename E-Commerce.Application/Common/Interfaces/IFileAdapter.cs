using Microsoft.AspNetCore.Http;

namespace E_Commerce.Application.Interfaces
{
    public interface IFileAdapter
    {
        /// <summary>
        /// this upload files async based on your storge adapter implemented 
        /// </summary>
        /// <param name="folderName"> file folderName </param>
        /// <param name="file">file as IFromFile</param>
        /// <returns>string contains path of file(just name) </returns>
        Task<string> UploadFileAsync(string folderName, IFormFile file);
        /// <summary>
        /// this delete files async based on your storge adapter implemented 
        /// </summary>
        /// <param name="folderName">The desired path for the file (excluding the file name).</param>
        /// <param name="fileName"> file name you wanna deleted</param>
        /// <returns>true if file deleted</returns>
        Task<bool> DeleteFileAsync(string folderName, string fileName);
        /// <summary>
        /// Return file url based on your storge adapter implemented.
        /// </summary>
        /// <param name="folderName">The desired path for the file (excluding the file name).</param>
        /// <param name="fileName"> file name you wanna get</param>
        /// <returns></returns>
        string? GetFileUrl(string folderName, string fileName);
    }
}

