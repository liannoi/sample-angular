using AutoMapper;
using SampleAngular.Application.Common.Mappings;
using SampleAngular.Domain.Entities;

namespace SampleAngular.Application.Storage.Products
{
    public class ProductLookupDto : IMapFrom<Product>
    {
        public int ProductId { get; set; }
        public int ManufacturerId { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductLookupDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(s => s.ProductId))
                .ForMember(dest => dest.ManufacturerId, opt => opt.MapFrom(s => s.ManufacturerId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(dest => dest.ProductNumber, opt => opt.MapFrom(s => s.ProductNumber));
        }
    }
}