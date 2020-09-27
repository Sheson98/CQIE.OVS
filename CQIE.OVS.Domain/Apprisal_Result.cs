using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.RIS.Domain
{
    /// <summary>
    /// 评价结果表
    /// </summary>
    [ActiveRecord]
    public class Apprisal_Result:BaseEntity<Apprisal_Result>
    {
        /// <summary>
        /// 评价计划(是否有效)
        /// </summary>
        [BelongsTo("App_Plan")]
        public Apprisal_Plan App_Plan { get; set; }
        /// <summary>
        /// 评价人
        /// </summary>
        [BelongsTo("ApprisalerId")]
        public SysUser Apprisaler { get; set; }

        /// <summary>
        /// 总评分
        /// </summary>
        [Property]
        public float TotalScore { get; set; }
    }
}
