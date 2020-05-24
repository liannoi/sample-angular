using System.IO;

namespace SampleAngular.WebAPI
{
    public static class ApiDefaults
    {
        public static string ProductPhotosPath => Path.Combine("res", "product-photos");
        public static string PhotosDirectoryRoot => Path.Combine(Directory.GetCurrentDirectory(), @"res");
        public static string PhotosDirectoryRootRequestPath => "/res";
    }
}