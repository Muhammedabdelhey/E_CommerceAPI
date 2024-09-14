using Microsoft.AspNetCore.Http;

namespace E_Commerce.Application.Interfaces
{
    public interface IFileAdapter
    {
        /// <summary>
        /// this upload files async based on your storge adapter implemented 
        /// </summary>
        /// <param name="path"> file path </param>
        /// <param name="file">file as IFromFile</param>
        /// <returns>string contains path of file(just name) </returns>
        Task<string> UploadFileAsync(string path,IFormFile file);
    }
}
