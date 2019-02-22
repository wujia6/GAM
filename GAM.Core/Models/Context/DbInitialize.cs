using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GAM.Core.Models.DepartRoot;
using GAM.Core.Models.RoleRoot;
using GAM.Core.Models.MenuRoot;
using GAM.Core.Models.UserRoot;

namespace GAM.Core.Models.Context
{
    public static class DbInitialize
    {
        public static void Initialize(IServiceProvider iServicePro)
        {
            using (var cxt = new SqlLocalContext(iServicePro.GetRequiredService<DbContextOptions<SqlLocalContext>>()))
            {
                //判断初始化，已初始化则返回
                //部门
                if (cxt.Departs.Any())
                    return;
                var depart = DepartFactory.CreateInstance("总部", "管理员");
                cxt.Departs.Add(depart);
                //角色
                if (cxt.Roles.Any())
                    return;
                var role = RoleFactory.ClassInstance("管理员","admin","系统管理员");
                cxt.Roles.Add(role);
                //菜单
                if (cxt.Menus.Any())
                    return;
                var menu = MenuFactory.ClassInstance(MenuType.menu, "首页", "Home", "HomeController");
                cxt.Menus.Add(menu);
                //用户
                if (cxt.Users.Any())
                    return;
                var user = UserFactory.ClassInstance("admin", "password", "wujia", "3887626@qq.com", "16673956869", DateTime.Now, true);
                cxt.Users.Add(user);

                cxt.SaveChanges();
            }
        }
    }
}
