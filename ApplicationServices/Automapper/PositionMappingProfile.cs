using ApplicationDomian.Models;
using ApplicationServices.Helpers;
using AutoMapper;

namespace ApplicationServices.Automapper
{
    public class PositionMappingProfile : Profile
    {
        public PositionMappingProfile() 
        {
            CreateMap<string, TypeContact>()
                .ForMember(c => c.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(c => c.CreateDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(c => c.Status, opt => opt.MapFrom(src => true))
                .ForMember(c => c.Type, opt => opt.MapFrom(src => src.Trim().ToCamelCase()));
        }
    }
}
