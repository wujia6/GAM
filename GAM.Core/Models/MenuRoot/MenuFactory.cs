namespace GAM.Core.Models.MenuRoot
{
    public class MenuFactory
    {
        public static Menu ClassInstance(MenuType? tp = null, string name = null, string code = null, string url = null, string remarks = null)
        {
            var menu = new Menu();
            if (tp != null)
                menu.Type = tp.Value;
            else if (name != null)
                menu.Name = name;
            else if (code != null)
                menu.Code = code;
            else if (url != null)
                menu.Url = url;
            else if (remarks != null)
                menu.Remarks = remarks;
            return menu;
        }
    }
}
