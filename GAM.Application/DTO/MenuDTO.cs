using System.Runtime.Serialization;

namespace GAM.Application.DTO
{
    public enum MenuTypeDTO
    {
        menu = 1,
        module = 2,
        action = 3,
    }

    public class MenuDTO: BaseDTO
    {
        [DataMember]
        public int PID { get; set; }

        [DataMember]
        public MenuTypeDTO Type { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Url { get; set; }

        //导航属性
        [DataMember]
        public RoleMenuDTO RoleMenu { get; set; }
    }
}
