using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SampleAngular.WebAPI.Infrastructure
{
    public class ImageSaver : IImageSaver
    {
        public async Task SaveImageAsync(string filePath, IFormFile image)
        {
            await using var stream = new FileStream(filePath, FileMode.Create);
            await image.CopyToAsync(stream);
        }

        public string GenerateUniqueFileName(IFormFile file)
        {
            return $"{Guid.NewGuid()}{Path.GetExtension(Path.GetFileName(file.FileName))}";
        }

        public string GenerateDatabasePath(string filePath, string uniqueFileName)
        {
            return Path.Combine(filePath, uniqueFileName);
        }
    }
}