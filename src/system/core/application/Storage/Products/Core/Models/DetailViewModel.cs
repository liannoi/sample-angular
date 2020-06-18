using System.Collections.Generic;
using AutoMapper;
using SampleAngular.Application.Common.Mappings;
using SampleAngular.Domain.Entities;

namespace SampleAngular.Application.Storage.Products.Core.Models
{
    public class DetailViewModel : IMapFrom<Product>
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }

        public Manufacturers.Models.DetailViewModel Manufacturer { get; set; }

        public IEnumerable<Photos.Models.DetailViewModel> ProductPhotos { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, DetailViewModel>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(s => s.ProductId))
                .ForMember(dest => dest.Manufacturer, opt => opt.MapFrom(s => s.Manufacturer))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(dest => dest.ProductNumber, opt => opt.MapFrom(s => s.ProductNumber))
                .ForMember(dest => dest.ProductPhotos, opt => opt.MapFrom(s => s.ProductPhotos));
        }
    }
}