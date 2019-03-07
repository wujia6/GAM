namespace GAM.Core.Models.MenuRoot
{
    public class MenuFactory
    {
        public static Menu ClassInstance(MenuType tp, string name, string code, string url, string remarks = null)
        {
            var menu = new Menu
            {
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
