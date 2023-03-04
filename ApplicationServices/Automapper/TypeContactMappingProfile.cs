using ApplicationDomian.Models;
using ApplicationServices.Helpers;
using AutoMapper;

namespace ApplicationServices.Automapper
{
    public class TypeContactMappingProfile :Profile
    {
        public TypeContactMappingProfile()
        {
            CreateMap<string, Position>()
                .ForMember(c => c.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(c => c.CreateDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(c => c.Status, opt => opt.MapFrom(src => true))
                .ForMember(c => c.Name, opt => opt.MapFrom(src => src.Trim().ToCamelCase()));

        }
    }
}
