using AutoMapper;
using GAM.Infrastructure.Dtos;
using GAM.Core.Models.DepartRoot;
using GAM.Core.Models.MenuRoot;
using GAM.Core.Models.RoleRoot;
using GAM.Core.Models.UserRoot;

namespace GAM.Application.SourceMapper
{
    /// <summary>
    /// 映射规则配置
    /// </summary>
    public class Rules : Profile
    {
        public Rules()
        {
            CreateMap<DepartDTO, Depart>()
                .ForMember(dest => dest.ID, opts => opts.MapFrom(src => src.ID))
                .ForMember(dest => dest.Remarks, opts => opts.MapFrom(src => src.Remarks))
                .ForMember(dest => dest.Users, opts => opts.MapFrom(src => src.UserDtos));

            CreateMap<Depart, DepartDTO>();

            CreateMap<RoleDTO, Role>()
                .ForMember(dest => dest.ID, opts => opts.MapFrom(src => src.ID))
                .ForMember(dest => dest.Remarks, opts => opts.MapFrom(src => src.Remarks))
                .ForMember(dest => dest.RoleMenus, opts => opts.MapFrom(src => src.RoleMenuDtos))
                .ForMember(dest => dest.Users, opts => opts.MapFrom(src => src.UserDtos));

            CreateMap<Role, RoleDTO>();

            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.ID, opts => opts.MapFrom(src => src.ID))
                .ForMember(dest => dest.Remarks, opts => opts.MapFrom(src => src.Remarks))
                .ForMember(dest => dest.Depart, opts => opts.MapFrom(src => src.DepartDto))
                .ForMember(dest => dest.Roles, opts => opts.MapFrom(src => src.UserRoleDtos));

            CreateMap<User, UserDTO>();

            CreateMap<MenuDTO, Menu>()
                .ForMember(dest => dest.ID, opts => opts.MapFrom(src => src.ID))
                .ForMember(dest => dest.Remarks, opts => opts.MapFrom(src => src.Remarks))
                .ForMember(dest => dest.RoleMenus, opts => opts.MapFrom(src => src.RoleMenuDtos));

            CreateMap<Menu, MenuDTO>();

            CreateMap<RoleMenuDTO, RoleMenu>()
                .ForMember(dest => dest.ID, opts => opts.MapFrom(src => src.ID))
                .ForMember(dest => dest.Remarks, opts => opts.MapFrom(src => src.Remarks))
                .ForMember(dest => dest.Role, opts => opts.MapFrom(src => src.RoleDto))
                .ForMember(dest => dest.Menu, opts => opts.MapFrom(src => src.MenuDto));

            CreateMap<RoleMenu, RoleMenuDTO>();

            CreateMap<UserRoleDTO, UserRole>()
                .ForMember(dest => dest.ID, opts => opts.MapFrom(src => src.ID))
                .ForMember(dest => dest.Remarks, opts => opts.MapFrom(src => src.Remarks))
                .ForMember(dest => dest.User, opts => opts.MapFrom(src => src.UserDto))
                .ForMember(dest => dest.Role, opts => opts.MapFrom(src => src.RoleDto));

            CreateMap<UserRole, UserRoleDTO>();
        }
    }
}
