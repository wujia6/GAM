using System.Runtime.Serialization;

namespace GAM.Infrastructure.Dtos
{
    public class RoleMenuDTO
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Remarks { get; set; }

        [DataMember]
        public RoleDTO RoleDto { get; set; }

        [DataMember]
        public MenuDTO MenuDto { get; set; }
    }
}
