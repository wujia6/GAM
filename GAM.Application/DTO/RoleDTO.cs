using System.Linq;
using System.Runtime.Serialization;

namespace GAM.Application.DTO
{
    public class RoleDTO: BaseDTO
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public IQueryable<UserRoleDTO> UserDtos { get; set; }

        [DataMember]
        public IQueryable<RoleMenuDTO> RoleMenuDtos { get; set; }
    }
}
