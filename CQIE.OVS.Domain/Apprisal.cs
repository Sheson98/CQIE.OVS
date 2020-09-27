using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.RIS.Domain
{
    /// <summary>
    /// 评价表(日志记录)
    /// </summary>
    [ActiveRecord]
    public class Apprisal:BaseEntity<Apprisal>
    {      
        /// <summary>
        /// 标题
        /// </summary>
        [Property]
        public string Title { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        [Property]
        public string CreateTime { get; set; }
    }
}
