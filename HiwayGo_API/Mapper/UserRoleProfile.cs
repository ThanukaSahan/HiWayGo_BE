using AutoMapper;
using HiwayGo_API.Entity;

namespace HiwayGo_API.Mapper
{
    public class UserRoleProfile : Profile
    {
        public UserRoleProfile()
        {
            // Map only Id and RoleName
            CreateMap<UserRole, UserRoleDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.RoleName));

            // Reverse mapping in case you want to map back from DTO to entity
            CreateMap<UserRoleDto, UserRole>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.RoleName));
        }
    }
}