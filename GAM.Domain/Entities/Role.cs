using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using GAM.Infrastructure.IComm;

namespace GAM.Domain.Entities
{
    /// <summary>
    /// 角色领域模型
    /// </summary>
    public partial class Role: IAggregareRoot
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// 角色代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 包含用户
        /// </summary>
        public virtual IQueryable<UserRole> UserRoles { get; set; }

        /// <summary>
        /// 包含菜单项
        /// </summary>
        public virtual IQueryable<RoleMenu> RoleMenus { get; set; }
    }
}
