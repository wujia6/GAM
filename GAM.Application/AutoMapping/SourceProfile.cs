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

            CreateMap<BaseEntity, BaseDTO>();

            CreateMap<DepartDTO, Depart>()
                .ForMember(dest => dest.Users, opts => opts.MapFrom(src => src.UserDtos));

            CreateMap<Depart, DepartDTO>()
                .ForMember(dest => dest.UserDtos, opts => opts.MapFrom(src => src.Users));

            CreateMap<RoleDTO, Role>()
                .ForMember(dest => dest.RoleMenus, opts => opts.MapFrom(src => src.RoleMenuDtos))
                .ForMember(dest => dest.Users, opts => opts.MapFrom(src => src.UserDtos));

            CreateMap<Role, RoleDTO>()
                .ForMember(dest => dest.RoleMenuDtos, opts => opts.MapFrom(src => src.RoleMenus))
                .ForMember(dest => dest.UserDtos, opts => opts.MapFrom(src => src.Users));

            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.Depart, opts => opts.MapFrom(src => src.DepartDto))
                .ForMember(dest => dest.Roles, opts => opts.MapFrom(src => src.UserRoleDtos));

            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.DepartDto, opts => opts.MapFrom(src => src.Depart))
                .ForMember(dest => dest.UserRoleDtos, opts => opts.MapFrom(src => src.Roles));

            CreateMap<MenuDTO, Menu>()
                .ForMember(dest => dest.RoleMenus, opts => opts.MapFrom(src => src.RoleMenuDtos));

            CreateMap<Menu, MenuDTO>()
                .ForMember(dest => dest.RoleMenuDtos, opts => opts.MapFrom(src => src.RoleMenus));

            CreateMap<RoleMenuDTO, RoleMenu>()
                .ForMember(dest => dest.Role, opts => opts.MapFrom(src => src.RoleDto))
                .ForMember(dest => dest.Menu, opts => opts.MapFrom(src => src.MenuDto));

            CreateMap<RoleMenu, RoleMenuDTO>()
                .ForMember(dest => dest.RoleDto, opts => opts.MapFrom(src => src.Role))
                .ForMember(dest => dest.MenuDto, opts => opts.MapFrom(src => src.Menu));

            CreateMap<UserRoleDTO, UserRole>()
                .ForMember(dest => dest.User, opts => opts.MapFrom(src => src.UserDto))
                .ForMember(dest => dest.Role, opts => opts.MapFrom(src => src.RoleDto));

            CreateMap<UserRole, UserRoleDTO>()
                .ForMember(dest => dest.UserDto, opts => opts.MapFrom(src => src.User))
                .ForMember(dest => dest.RoleDto, opts => opts.MapFrom(src => src.Role));
        }
    }
}
