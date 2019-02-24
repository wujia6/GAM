using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GAM.Infrastructure.Dtos
{
    public class DepartDTO
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Manager { get; set; }

        [DataMember]
        public string Remarks { get; set; }

        [DataMember]
        public ICollection<UserDTO> UserDtos { get; set; }
    }
}
