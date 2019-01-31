﻿using System.Linq;
using GAM.Domain.MainContext.Entities.Aggregates.RoleAgg;

namespace GAM.Domain.MainContext.Entities.Aggregates.MenuAgg
{
    public enum MenuType
    {
        menu = 1,
        module = 2,
        action = 3,
    }

    public class Menu: BaseEntity
    {
        public int PID { get; set; }
        public int SerialNo { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Url { get; set; }
        public MenuType Type { get; set; }
        public string Icon { get; set; }
        //导航属性
        public virtual IQueryable<RoleMenu> Roles { get; set; }
    }
}
