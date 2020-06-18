using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SampleAngular.Application.Common.Interfaces
{
    public interface IApiImageSaver
    {
        string Unique(IFormFile file);
        Task SaveAsync(string fileName, IFormFile image);
        string Path(string filePath, string uniqueFileName);
    }
}