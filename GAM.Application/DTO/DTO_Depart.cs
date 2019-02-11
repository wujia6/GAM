using System.Runtime.Serialization;

namespace GAM.Application.DTO
{
    public class DTO_Depart: DTO_BaseEntity
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Manager { get; set; }
    }
}
