using System.Runtime.Serialization;

namespace GAM.Application.DTO
{
    public class UserRoleDTO
    {
        [DataMember]
        public UserDTO UserDto { get; set; }

        [DataMember]
        public RoleDTO RoleDto { get; set; }
    }
}
