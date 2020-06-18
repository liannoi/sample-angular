using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SampleAngular.WebAPI.Infrastructure
{
    public interface IWebImageSaver
    {
        string Unique(IFormFile file);
        Task SaveAsync(string fileName, IFormFile image);
        string Path(string filePath, string uniqueFileName);
    }
}