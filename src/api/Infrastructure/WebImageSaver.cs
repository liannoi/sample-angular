using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SampleAngular.WebAPI.Infrastructure
{
    public class WebImageSaver : IWebImageSaver
    {
        public async Task SaveAsync(string filePath, IFormFile image)
        {
            await using var stream = new FileStream(filePath, FileMode.Create);
            await image.CopyToAsync(stream);
        }

        public string Unique(IFormFile file)
        {
            return $"{Guid.NewGuid()}{System.IO.Path.GetExtension(System.IO.Path.GetFileName(file.FileName))}";
        }

        public string Path(string filePath, string uniqueFileName)
        {
            return System.IO.Path.Combine(filePath, uniqueFileName);
        }
    }
}