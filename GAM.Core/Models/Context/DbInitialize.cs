using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using GAM.Core.Models.DepartRoot;
using GAM.Core.Models.RoleRoot;
using GAM.Core.Models.MenuRoot;
using GAM.Core.Models.UserRoot;
using GAM.Core.IApi;

namespace GAM.Core.Models.Context
{
    public class DbInitialize
    {
        public static void Seed(ISqlLocalContext icxt)
        {
            if (icxt.Set<Depart>().Any())
                return;
            var depart = DepartFactory.CreateInstance("总部", "管理员");
            icxt.Set<Depart>().Add(depart);

            if (icxt.Set<Role>().Any())
                return;
            var role = RoleFactory.ClassInstance("管理员", "admin", "系统管理员");
            icxt.Set<Role>().Add(role);

            if (icxt.Set<Menu>().Any())
                return;
            var menu = MenuFactory.ClassInstance(MenuType.menu, "首页", "Home", "HomeController");
            icxt.Set<Menu>().Add(menu);

            if (icxt.Set<User>().Any())
                return;
            var user = UserFactory.ClassInstance("admin", "password", "wujia", "3887626@qq.com", "16673956869", DateTime.Now, true);
            icxt.Set<User>().Add(user);

            icxt.SaveChanges();
        }

        public static void Run(IServiceProvider iService)
        {
            using (var sc = iService.GetService<ISqlLocalContext>())
            {
                if (sc.Set<Depart>().Any())
                    return;
                var depart = DepartFactory.CreateInstance("总部", "管理员");
                sc.Set<Depart>().Add(depart);

                if (sc.Set<Role>().Any())
                    return;
                var role = RoleFactory.ClassInstance("管理员", "admin", "系统管理员");
                sc.Set<Role>().Add(role);

                if (sc.Set<Menu>().Any())
                    return;
                var menu = MenuFactory.ClassInstance(MenuType.menu, "首页", "Home", "HomeController");
                sc.Set<Menu>().Add(menu);

                if (sc.Set<User>().Any())
                    return;
                var user = UserFactory.ClassInstance("admin", "password", "wujia", "3887626@qq.com", "16673956869", DateTime.Now, true);
                sc.Set<User>().Add(user);

                sc.SaveChanges();
            }
        }
    }
}
