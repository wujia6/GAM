using System;
using System.Linq;
using GAM.Domain.MainContext.Entities.Aggregates.UserAgg;

namespace GAM.Domain.MainContext.Entities.Aggregates.RoleAgg
{
    public class Role: BaseEntity, IAggregateRoot
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime? CreateTime { get; set; }
        //导航属性
        public virtual IQueryable<UserRole> Users { get; set; }
        public virtual IQueryable<RoleMenu> RoleMenus { get; set; }
    }
}
