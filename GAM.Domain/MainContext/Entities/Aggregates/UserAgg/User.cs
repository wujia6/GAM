using System;
using System.Linq;
using GAM.Domain.MainContext.Entities.Aggregates.DepartmentAgg;

namespace GAM.Domain.MainContext.Entities.Aggregates.UserAgg
{
    public class User : BaseEntity, IAggregateRoot
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string MobileNumber { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime LastLoginTime { get; set; }
        public bool IsDeleted { get; set; }
        //导航属性
        public virtual Department Department { get; set; } = DepartmentFactory.Instance.Create();
        public virtual IQueryable<UserRole> Roles { get; set; }
    }
}
