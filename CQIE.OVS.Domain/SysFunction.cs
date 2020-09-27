using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.RIS.Domain
{
    /// <summary>
    /// 功能类
    /// </summary>
    [ActiveRecord]
    public class SysFunction:BaseEntity<SysFunction>
    {
        /// <summary>
        /// 父功能
        /// </summary>
        [BelongsTo("ParentId")]
        public SysFunction ParentFunc { get; set; }

        /// <summary>
        /// 用户集合
        /// </summary>
        [HasAndBelongsToMany(Table = "SysRole_SysFunction", ColumnKey = "SysFunId", ColumnRef = "SysRoleId")]
        public IList<SysRole> RoleList { get; set; }

        /// <summary>
        /// 功能名称
        /// </summary>
        [Property]
        [DisplayName("功能名称")]
        [Required(ErrorMessage = "请输入功能名称")]
        [StringLength(maximumLength: 30, ErrorMessage = "最大支持30个字符")]
        public string SysFunctionName { get; set; }

        /// <summary>
        /// 类别名称
        /// </summary>
        [Property]
        [DisplayName("类别名称")]
        public string ClassName { get; set; }

        /// <summary>
        /// 控制器名称
        /// </summary>
        [Property]
        [DisplayName("控制器名称")]
        public string ControllName { get; set; }

        /// <summary>
        /// 活动名称
        /// </summary>
        [Property]
        [DisplayName("活动名称")]
        public string ActionName { get; set; }

        /// <summary>
        /// 升序号
        /// </summary>
        [Property]
        [DisplayName("生序号")]
        public string SortCode { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        [Property]
        [DisplayName("是否显示")]
        public int IsActive { get; set; }
    }
}
