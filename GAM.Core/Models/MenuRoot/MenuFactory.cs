using System;

namespace GAM.Core.Models.MenuRoot
{
    /// <summary>
    /// 聚合根工厂类，创建此聚合内所有对象
    /// </summary>
    public static class MenuFactory
    {
        public static Menu GetInstance
        {
            get { return new Menu(); }
        }

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
