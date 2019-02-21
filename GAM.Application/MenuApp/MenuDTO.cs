using System.Runtime.Serialization;
using GAM.Application.RoleApp;

namespace GAM.Application.MenuApp
{
    public enum MenuTypeDTO
    {
        menu = 1,
        module = 2,
        action = 3,
    }

    public class MenuDTO
    {
        [DataMember]
        public int ID { get; set; }

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

        [DataMember]
        public string Remarks { get; set; }

        //导航属性
        [DataMember]
        public RoleMenuDTO RoleMenuDtos { get; set; }
    }
}
