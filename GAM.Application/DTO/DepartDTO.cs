using System.Runtime.Serialization;

namespace GAM.Application.DTO
{
    public class DepartDTO: BaseDTO
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Manager { get; set; }
    }
}
