using System.Runtime.Serialization;

namespace GAM.Infrastructure.Dtos
{
    public class UserRoleDTO
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Remarks { get; set; }

        [DataMember]
        public UserDTO UserDto { get; set; }

        [DataMember]
        public RoleDTO RoleDto { get; set; }
    }
}
