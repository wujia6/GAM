using AutoMapper;
using GAM.Core.Models;
using GAM.Core.Models.DepartRoot;
using GAM.Core.Models.MenuRoot;
using GAM.Core.Models.RoleRoot;
using GAM.Core.Models.UserRoot;

namespace GAM.Application.DTO.AutoMapping
{
    public class SourceProfile: Profile
    {
        public SourceProfile()
        {
            CreateMap<BaseDTO, BaseEntity>();
            
            CreateMap<DepartDTO, Depart>();

            CreateMap<RoleDTO, Role>();

            CreateMap<UserDTO, User>();

            CreateMap<MenuDTO, Menu>();

            CreateMap<RoleMenuDTO, RoleMenu>();

            CreateMap<UserRoleDTO, UserRole>();
        }
    }
}
