using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.RIS.Domain
{
    /// <summary>
    /// 学院部门表
    /// </summary>
    [ActiveRecord]
    public class Dept:BaseEntity<Dept>
    {
        /// <summary>
        /// 部门拥有的老师
        /// </summary>
        [HasAndBelongsToMany(Table = "Teacher_Dept", ColumnKey = "DeptId", ColumnRef = "TeacherId")]

        public IList<SysUser> TeacherList { get; set; } 

        /// <summary>
        /// 部门所属学院
        /// </summary>
        [BelongsTo("Collect_DeptId")]
        public College College { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [Property]
        public string DeptName { get; set; }
    }
}
