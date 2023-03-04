using ApplicationDomian.Models;
using ApplicationServices.DTOs.Models;
using ApplicationServices.DTOs.ViewModels;
using ApplicationServices.Helpers;
using AutoMapper;

namespace ApplicationServices.Automapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile() 
        {
            CreateMap<User, UserViewModel>()
                .ForMember(c => c.Position,opt => opt.MapFrom(src => src.IdPositionNavigation.Name))
                .ForMember(c => c.TypeContact, opt => opt.MapFrom(src => src.IdTypeContactNavigation.Type));

            CreateMap<UserModel, User>()
                .ForMember(c => c.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(c => c.CreationDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(c => c.Status, opt => opt.MapFrom(src => true))
                .ForMember(c => c.Gmail, opt => opt.MapFrom(src => src.Gmail))
                .ForMember(c => c.UserName, opt => opt.MapFrom(src => src.UserName.Trim().ToCamelCase()))
                .ForMember(c => c.User1, opt => opt.MapFrom(src => src.User.Trim().ToCamelCase()));
        } 
    }
}
