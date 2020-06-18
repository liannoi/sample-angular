using AutoMapper;
using SampleAngular.Application.Common.Mappings;
using SampleAngular.Application.Storage.Products.Core.Models;
using SampleAngular.Domain.Entities;

namespace SampleAngular.Application.Storage.Products.Photos.Models
{
    public class ProductPhotoDto : IMapFrom<ProductPhoto>
    {
        public int PhotoId { get; set; }
        public string Path { get; set; }

        public ProductDto Product { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductPhoto, ProductPhotoDto>()
                .ForMember(dest => dest.PhotoId, opt => opt.MapFrom(s => s.PhotoId))
                .ForMember(dest => dest.Path, opt => opt.MapFrom(s => s.Path))
                .ForMember(dest => dest.Product, opt => opt.MapFrom(s => s.Product));
        }
    }
}