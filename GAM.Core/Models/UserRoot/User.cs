using System;
using System.Linq;
using GAM.Core.Models.DepartRoot;

namespace GAM.Core.Models.UserRoot
{
    public class User: BaseEntity, IAggregateRoot
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string MobileNumber { get; set; }
        public DateTime LastLoginTime { get; set; }
        public bool IsDeleted { get; set; }

        public virtual IQueryable<UserRole> Roles { get; set; }
        public virtual Depart Depart { get; set; }
    }
}
