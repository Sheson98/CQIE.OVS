using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.RIS.Domain
{
    /// <summary>
    /// 指标类
    /// </summary>
    [ActiveRecord]
    public class Mark:BaseEntity<Mark>
    {
        /// <summary>
        /// 对应到结果的指标
        /// </summary>
        [BelongsTo("App_DetailID")]
        public Apprisal_Detail MarkID { get; set; }
        /// <summary>
        /// 指标选项集合
        /// </summary>
        
        [HasMany(Table ="Options",ColumnKey = "MarkId")]
        public IList<Options> OptionList { get; set; }

        /// <summary>
        /// 对应角色
        /// </summary>
        [HasAndBelongsToMany(Table = "SysRole_Mark", ColumnKey = "MarkId", ColumnRef = "SysRoleId")]
        public IList<SysRole> SysRoleList { get; set; }

        /// <summary>
        /// 父级指标
        /// </summary>
        [BelongsTo("ParentId")]
        public Mark ParentMark { get; set; }

        /// <summary>
        /// 指标内容
        /// </summary>
        [Property]
        public string MarkContent { get; set; }

        /// <summary>
        /// 指标权重
        /// </summary>
        [Property]
        public float MarkWeight { get; set; }

        /// <summary>
        /// 指标等级
        /// </summary>
        /// 1 表示一级指标，依次往下推
        [Property]
        public int MarkGrade { get; set; }


    }
}
