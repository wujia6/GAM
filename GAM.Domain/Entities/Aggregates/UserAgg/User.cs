using System;
using System.Linq;
using GAM.Domain.Entities.Aggregates.DepartAgg;

namespace GAM.Domain.Entities.Aggregates.UserAgg
{
    public class User : IAggregateRoot
    {
        public int ID { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string MobileNumber { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime LastLoginTime { get; set; }
        public bool IsDeleted { get; set; }
        public string Remarks { get; set; }
        //导航属性
        public virtual Depart Department { get; set; } = DepartFactory.Instance.Create();
        public virtual IQueryable<UserRole> Roles { get; set; }
    }
}
