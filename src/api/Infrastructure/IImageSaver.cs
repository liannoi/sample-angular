using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SampleAngular.WebAPI.Infrastructure
{
    public interface IImageSaver
    {
        string GenerateUniqueFileName(IFormFile file);
        Task SaveImageAsync(string fileName, IFormFile image);
        string GenerateDatabasePath(string filePath, string uniqueFileName);
    }
}