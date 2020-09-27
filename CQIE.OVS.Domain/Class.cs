using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.RIS.Domain
{
    /// <summary>
    /// 班级表
    /// </summary>
    [ActiveRecord]

    public class Class:BaseEntity<Class>
    {
        /// <summary>
        /// 班级拥有学生集合
        /// </summary>
        [HasAndBelongsToMany(Table = "Student_Class", ColumnKey = "ClassId", ColumnRef = "StudentId")]
        public IList<SysUser> StudentList { get; set; }

        /// <summary>
        /// 班级拥有课程集合
        /// </summary>
        [HasAndBelongsToMany(Table ="Class_Lesson",ColumnKey ="ClassId",ColumnRef ="LessonId")]
        public IList<Lesson> LessonList { get; set; }

        /// <summary>
        /// 所属学院
        /// </summary>
        [BelongsTo("Collect_ClassId")]
        public College College { get; set; }

        /// <summary>
        /// 班级名
        /// </summary>
        [Property]
        public string CLassName { get; set; }
    }
}
