using System.Collections.Generic;
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
        public ICollection<UserRoleDTO> UserDtos { get; set; }

        [DataMember]
        public ICollection<RoleMenuDTO> RoleMenuDtos { get; set; }
    }
}
