using AutoMapper;
using GAM.Core.Models;
using GAM.Core.Models.DepartRoot;
using GAM.Core.Models.MenuRoot;
using GAM.Core.Models.RoleRoot;
using GAM.Core.Models.UserRoot;

namespace GAM.Application.DTO.AutoMapping
{
    /// <summary>
    /// AutoMapper映射配置
    /// </summary>
    public class SourceProfile: Profile
    {
        public SourceProfile()
        {
            CreateMap<BaseDTO, BaseEntity>();

            CreateMap<DepartDTO, Depart>()
                .ForMember(dest => dest.Users, opts => opts.MapFrom(src => src.UserDtos));

            CreateMap<RoleDTO, Role>()
                .ForMember(dest => dest.RoleMenus, opts => opts.MapFrom(src => src.RoleMenuDtos))
                .ForMember(dest => dest.Users, opts => opts.MapFrom(src => src.UserDtos));

            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.Depart, opts => opts.MapFrom(src => src.DepartDto))
                .ForMember(dest => dest.Roles, opts => opts.MapFrom(src => src.UserRoleDtos));

            CreateMap<MenuDTO, Menu>()
                .ForMember(dest => dest.RoleMenus, opts => opts.MapFrom(src => src.RoleMenus));

            CreateMap<RoleMenuDTO, RoleMenu>()
                .ForMember(dest => dest.Role, opts => opts.MapFrom(src => src.RoleDto))
                .ForMember(dest => dest.Menu, opts => opts.MapFrom(src => src.MenuDto));

            CreateMap<UserRoleDTO, UserRole>()
                .ForMember(dest => dest.User, opts => opts.MapFrom(src => src.UserDto))
                .ForMember(dest => dest.Role, opts => opts.MapFrom(src => src.RoleDto));
        }
    }
}
