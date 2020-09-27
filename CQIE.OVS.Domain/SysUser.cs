using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.RIS.Domain
{
    /// <summary>
    /// 用户类
    /// </summary>
    [ActiveRecord]
    public class SysUser:BaseEntity<SysUser>
    {
        /// <summary>
        /// 评价表
        /// </summary>
        [HasMany(Table ="Apprisal_Result",ColumnKey ="ApprisalerId")]
        public IList<Apprisal_Result> ApprisalList { get; set; }

        /// <summary>
        /// 被评价表
        /// </summary>
        [HasMany(Table ="Apprisal_Detail",ColumnKey ="BeApprisalerId")]
        public IList<Apprisal_Detail> AppDetailsList { get; set; }

        /// <summary>
        /// 老师对应课程
        /// </summary>
        [HasAndBelongsToMany(Table ="Teacher_Lesson",ColumnKey ="TeacherId",ColumnRef ="LessonId")]
        public IList<Lesson> LessonList { get; set; }

        /// <summary>
        /// 学生所在班级集合
        /// </summary>
        [HasAndBelongsToMany(Table = "Student_Class", ColumnKey = "StudentId", ColumnRef = "ClassId")]
        public IList<Class> ClassList { get; set; }

        /// <summary>
        /// 老师所在部门集合
        /// </summary>
        [HasAndBelongsToMany(Table ="Teacher_Dept",ColumnKey ="TeacherId",ColumnRef ="DeptId")]
        public IList<Dept> DeptList { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Property]
        [DisplayName("姓名")]
        public string UserName { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        [Required(ErrorMessage = "请输入账户")]
        [DisplayName("账号")]
        [StringLength(maximumLength: 30, ErrorMessage = "账户长度有误，请重新输入")]
        [Property]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "请输入密码")]
        [DisplayName("密码")]
        [StringLength(maximumLength: 30, MinimumLength = 6, ErrorMessage = "密码长度有误，请重新输入")]
        [Property]
        public string PassWord { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        [Property]
        [DisplayName("是否激活")]
        public int IsActive { get; set; }

        /// <summary>
        /// 角色列表
        /// </summary>
        [HasAndBelongsToMany(Table = "SysUser_SysRole", ColumnKey = "SysUserId", ColumnRef = "SysRoleId")]
        public IList<SysRole> RoleList { get; set; }
    }
}
