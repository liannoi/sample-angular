using AutoMapper;
using SampleAngular.Application.Common.Mappings;
using SampleAngular.Domain.Entities;

namespace SampleAngular.Application.Storage.ProductPhotos
{
    public class ProductPhotoLookupDto : IMapFrom<ProductPhoto>
    {
        public int PhotoId { get; set; }
        public int ProductId { get; set; }
        public string Path { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductPhoto, ProductPhotoLookupDto>()
                .ForMember(dest => dest.PhotoId, opt => opt.MapFrom(s => s.PhotoId))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(s => s.ProductId))
                .ForMember(dest => dest.Path, opt => opt.MapFrom(s => s.Path));
        }
    }
}