using AutoMapper;
using SampleAngular.Application.Common.Mappings;
using SampleAngular.Domain.Entities;

namespace SampleAngular.Application.Storage.Manufacturers.Models
{
    public class DetailViewModel : IMapFrom<Manufacturer>
    {
        public int ManufacturerId { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Manufacturer, DetailViewModel>()
                .ForMember(dest => dest.ManufacturerId, opt => opt.MapFrom(s => s.ManufacturerId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(s => s.Name));
        }
    }
}