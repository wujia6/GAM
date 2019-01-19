using System.ComponentModel.DataAnnotations;

namespace GAM.Domain.Entities
{
    public class RoleMenu
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// 角色对象
        /// </summary>
        public virtual Role Role { get; set; } = new Role();

        /// <summary>
        /// 菜单对象
        /// </summary>
        public virtual Menu Menu { get; set; } = new Menu();
    }
}
