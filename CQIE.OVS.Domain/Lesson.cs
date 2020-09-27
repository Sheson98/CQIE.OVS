using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.RIS.Domain
{
    /// <summary>
    /// 课程表
    /// </summary>
    [ActiveRecord]
    public class Lesson:BaseEntity<Lesson>
    {
        /// <summary>
        /// 课程所属班级集合
        /// </summary>
        [HasAndBelongsToMany(Table ="Class_Lesson",ColumnKey ="LessonId",ColumnRef ="ClassId")]
        public IList<Class> ClassList { get; set; }

        /// <summary>
        /// 课程所属老师集合
        /// </summary>
        [HasAndBelongsToMany(Table ="Teacher_Lesson",ColumnKey ="LessonId",ColumnRef ="TeacherId")]
        public IList<SysUser> TeacherList { get; set; }

        /// <summary>
        /// 课程名称
        /// </summary>
        [Property]
        public string LessonName { get; set; }
    }
}
