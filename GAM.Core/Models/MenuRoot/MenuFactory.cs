using System;

namespace GAM.Core.Models.MenuRoot
{
    public class MenuFactory
    {
        public static Menu ClassInstance(Guid menuId, int pId, MenuType tp, string name, string code, string url, string remarks = null)
        {
            var menu = new Menu
            {
                ID = menuId,
                PID = pId,
                Type = tp,
                Name = name,
                Code = code,
                Url = url,
                Remarks = string.IsNullOrEmpty(remarks) ? "暂无" : remarks
            };
            return menu;
        }
    }
}
