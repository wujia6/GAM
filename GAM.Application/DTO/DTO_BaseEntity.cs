using System.Runtime.Serialization;

namespace GAM.Application.DTO
{
    public abstract class DTO_BaseEntity
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Remarks { get; set; }
    }
}
