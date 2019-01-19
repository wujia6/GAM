using System.ComponentModel.DataAnnotations;

namespace GAM.Domain.Entities
{
    public class UserRole
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// 角色对象信息
        /// </summary>
        public virtual Role Role { get; set; } = new Role();

        /// <summary>
        /// 用户对象信息
        /// </summary>
        public virtual User User { get; set; } = new User();
    }
}
