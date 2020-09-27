using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.RIS.Domain
{
    /// <summary>
    /// 评价结果明细表
    /// </summary>
    [ActiveRecord]
    public class Apprisal_Detail:BaseEntity<Apprisal_Detail>
    {
        /// <summary>
        /// 对应指标集合表
        /// </summary>
        [HasMany(Table ="Mark",ColumnKey = "App_DetailID")]
        public IList<Mark> MarkList { get; set; }

        /// <summary>
        /// 被评价人
        /// </summary>
        [BelongsTo("BeApprisalerId")]
        public SysUser BeApprisaler { get; set; }

        /// <summary>
        /// 评价选项
        /// </summary>
        [Property]
        public string Apprisal_Option { get; set; }
        
        /// <summary>
        /// 选项分数
        /// </summary>
        [Property]
        public float Apprisal_Score { get; set; }
    }
}
