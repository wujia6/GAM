using System.Runtime.Serialization;

namespace GAM.Application.DTO
{
    public class RoleMenuDTO
    {
        [DataMember]
        public RoleDTO RoleDto { get; set; }

        [DataMember]
        public MenuDTO MenuDto { get; set; }
    }
}
