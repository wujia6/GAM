using System;

namespace GAM.Domain.MainContext.Entities.Aggregates.DepartmentAgg
{
    public class Department : BaseEntity, IAggregateRoot
    {
        public int PID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Manager { get; set; }
        public string ContactNumber { get; set; }
        public DateTime? CreateTime { get; set; }
        public bool IsDeleted { get; set; }
        //导航属性
        //public virtual IQueryable<User> Users { get; set; }
    }
}
