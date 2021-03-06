using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SampleAngular.Application.Common.Interfaces;

namespace SampleAngular.Infrastructure.Common
{
    public class ApiImageSaver : IApiImageSaver
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