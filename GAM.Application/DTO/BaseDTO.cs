using System.Runtime.Serialization;

namespace GAM.Application.DTO
{
    public abstract class BaseDTO
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Remarks { get; set; }
    }
}
