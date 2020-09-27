using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.RIS.Domain
{
    /// <summary>
    /// 选项类
    /// </summary>
    [ActiveRecord]
    public class Options:BaseEntity<Options>
    {
        /// <summary>
        /// 选项所属指标
        /// </summary>
        [BelongsTo("MarkId")]
        public Mark Mark { get; set; }

        /// <summary>
        /// 选项内容
        /// </summary>
        [Property]
        public string OptionContent { get; set; }

        /// <summary>
        /// 选项权重
        /// </summary>
        [Property]
        public float OptionWeight { get; set; }
    }
}
