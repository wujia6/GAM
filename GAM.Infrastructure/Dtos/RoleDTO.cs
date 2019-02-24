using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GAM.Infrastructure.Dtos
{
    public class RoleDTO
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Remarks { get; set; }

        [DataMember]
        public ICollection<UserRoleDTO> UserDtos { get; set; }

        [DataMember]
        public ICollection<RoleMenuDTO> RoleMenuDtos { get; set; }
    }
}
