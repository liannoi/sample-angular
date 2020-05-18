using System.Collections.Generic;
using AutoMapper;
using SampleAngular.Application.Common.Mappings;
using SampleAngular.Application.Storage.Manufacturers;
using SampleAngular.Application.Storage.Products.Infrastructure.Photos;
using SampleAngular.Domain.Entities;

namespace SampleAngular.Application.Storage.Products
{
    public class ProductLookupDto : IMapFrom<Product>
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }

        public ManufacturerLookupDto Manufacturer { get; set; }
        public IEnumerable<ProductPhotoLookupDto> Photos { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductLookupDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(s => s.ProductId))
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(s => s.Manufacturer))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(dest => dest.ProductNumber, opt => opt.MapFrom(s => s.ProductNumber));
        }
    }
}