using System;
using System.Linq;
using GAM.Core.Models.DepartRoot;
using GAM.Core.Models.RoleRoot;
using GAM.Core.Models.MenuRoot;
using GAM.Core.Models.UserRoot;
using GAM.Core.IApi;

namespace GAM.Core.Models.Context
{
    public static class DbInitialize
    {
        public static void Seed(ISqlLocalContext icxt)
        {
            if (icxt.Departs.Any())
                return;
            var depart = DepartFactory.CreateInstance(new Guid(), "总部", "管理员");
            icxt.Departs.Add(depart);

            if (icxt.Roles.Any())
                return;
            var role = RoleFactory.ClassInstance(new Guid(), "管理员", "admin", "系统管理员");
            icxt.Roles.Add(role);

            if (icxt.Menus.Any())
                return;
            var menu = MenuFactory.ClassInstance(new Guid(), 0, MenuType.menu, "首页", "Home", "HomeController");
            icxt.Menus.Add(menu);

            if (icxt.Users.Any())
                return;
            var user = UserFactory.ClassInstance(new Guid(), "admin", "password", "wujia", "3887626@qq.com", "16673956869", DateTime.Now, true);
            icxt.Users.Add(user);

            icxt.SaveChanges();
        }
    }
}
