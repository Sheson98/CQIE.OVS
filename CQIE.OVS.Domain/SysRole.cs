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
    /// 角色类
    /// 一共四个角色 : 学生 、老师 、领导 、管理员
    /// </summary>
    [ActiveRecord]
    public class SysRole:BaseEntity<SysRole>
    {
        /// <summary>
        /// 所属评价计划
        /// </summary>
        [BelongsTo("App_Plan")]
        public Apprisal_Plan App_Plan { get; set; }

        /// <summary>
        /// 对应指标表
        /// </summary>
        [HasAndBelongsToMany(Table = "SysRole_Mark", ColumnKey ="SysRoleId",ColumnRef ="MarkId")]
        public IList<Mark> MarkList { get; set; }

        /// <summary>
        /// 用户集合
        /// </summary>
        [HasAndBelongsToMany(Table = "SysUser_SysRole", ColumnKey = "SysRoleId", ColumnRef = "SysUserId")]
        public IList<SysUser> UserList { get; set; }

        /// <summary>
        /// 功能集合
        /// </summary>
        [HasAndBelongsToMany(Table = "SysRole_SysFunction", ColumnKey = "SysRoleId", ColumnRef = "SysFunId")]
        public IList<SysFunction> SysFunList { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [Property]
        [DisplayName("角色名称")]
        [Required(ErrorMessage = "请输入角色名称")]
        [StringLength(maximumLength: 30, ErrorMessage = "最大支持30个字符")]
        public string RoleName { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        [Property]
        [DisplayName("是否激活")]
        public int IsActive { get; set; }
    }
}
