using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GAM.Domain.Entities
{
    /// <summary>
    /// 部门实体
    /// </summary>
    public class Department
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [Required][MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 部门编号
        /// </summary>
        [Required][MaxLength(50)]
        public string Code { get; set; }

        /// <summary>
        /// 部门负责人
        /// </summary>
        [Required][MaxLength(20)]
        public string Manager { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [Required][MaxLength(11)]
        public string ContactNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(100)]
        public string Remarks { get; set; }

        /// <summary>
        /// 父级部门ID
        /// </summary>
        [DefaultValue(0)]
        public int ParentId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 是否已删除
        /// </summary>
        [DefaultValue(false)]
        public int IsDeleted { get; set; }

        /// <summary>
        /// 包含用户
        /// </summary>
        public virtual IQueryable<User> Users { get; set; }

        /// <summary>
        /// 创建人信息
        /// </summary>
        public virtual User CreateUser { get; set; } = new User();
    }
}
