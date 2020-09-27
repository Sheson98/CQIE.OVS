using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.RIS.Domain
{
    /// <summary>
    /// 评价计划表
    /// </summary>
    [ActiveRecord]
    public class Apprisal_Plan:BaseEntity<Apprisal_Plan>
    {
        /// <summary>
        /// 评价结果集合
        /// </summary>
        [HasMany(Table ="Apprisal_Result",ColumnKey = "App_Plan")]
        public IList<Apprisal_Result> App_ResultList { get; set; }

        /// <summary>
        /// 计划人集合
        /// </summary>
        [HasMany(Table ="SysRole",ColumnKey ="App_Plan")]
        public IList<SysRole> SysRole { get; set; }

        /// <summary>
        /// 评价开启时间
        /// </summary>
        [Property]
        public string StartTime { get; set; }

        /// <summary>
        /// 评价关闭时间
        /// </summary>
        [Property]
        public string Endtime { get; set; }

        /// <summary>
        /// 是否开启当前评价
        /// 1:开启 ， 2:关闭
        /// </summary>
        [Property]
        public int IsActive { get; set; }
    }
}
