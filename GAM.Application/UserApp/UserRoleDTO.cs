using System.Runtime.Serialization;
using GAM.Application.RoleApp;

namespace GAM.Application.UserApp
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
