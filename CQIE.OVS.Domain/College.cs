using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.RIS.Domain
{
    /// <summary>
    /// 学院类
    /// </summary>
    [ActiveRecord]
    public class College:BaseEntity<College>
    {
        /// <summary>
        /// 学院拥有班级集合
        /// </summary>
        [HasMany(Table ="Class",ColumnKey = "Collect_ClassId")]
        public IList<Class> ClassList { get; set; }

        /// <summary>
        /// 学院拥有的部门集合
        /// </summary>
        [HasMany(Table ="Dept",ColumnKey = "Collect_DeptId")]
        public IList<Dept> DeptList { get; set; }

        /// <summary>
        /// 学院名称
        /// </summary>
        [Property]
        public string CollegeName { get; set; }
    }
}
