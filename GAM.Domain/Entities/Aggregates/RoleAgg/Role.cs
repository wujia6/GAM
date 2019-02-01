using System;
using System.Linq;
using GAM.Domain.Entities.Aggregates.UserAgg;

namespace GAM.Domain.Entities.Aggregates.RoleAgg
{
    public class Role: IAggregateRoot
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime? CreateTime { get; set; }
        public string Remarks { get; set; }
        //导航属性
        public virtual IQueryable<UserRole> Users { get; set; }
        public virtual IQueryable<RoleMenu> Menus { get; set; }
    }
}
