using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using CQIE.RIS.Domain;
using CQIE.RIS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CQIE.RIS.Service;
using NHibernate.Criterion;

namespace CQIE.RIS.Web
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ret = "<br />";
            if (!ActiveRecordStarter.IsInitialized)
            {
                IConfigurationSource source = System.Configuration.ConfigurationManager.GetSection("activerecord") as IConfigurationSource;
                ActiveRecordStarter.Initialize(typeof(SysUser).Assembly, source);
            }
            ret += "正在创建数据库...<br />";
            ActiveRecordStarter.CreateSchema();
            ret += "数据库创建完成...<br />";
            ret += "初始化完成...<br />";
            Response.Write(ret);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            CQIE.RIS.Core.Container.Instance.Resolve<IApprisalService>().Add(new Apprisal
            {
                Title = "你猜",
                CreateTime = "你大爷"
            });
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Container.Instance.Resolve<ISysFunctionService>().Add(new SysFunction
            {
                SysFunctionName="教学评价",
                ClassName= "CQIE.RIS.Web.Controlls.StuAppTchController",
                ControllName= "StuAppTch",
                ActionName="Index",
                ParentFunc=null,
                IsActive=1
            });
            Container.Instance.Resolve<ISysRoleService>().Add(new SysRole
            {
                RoleName = "学生",
                IsActive = 1,
                SysFunList = Container.Instance.Resolve<ISysFunctionService>().Query(new List<ICriterion>() {
                    Expression.In("Id",new int[]{1})
                })
            });
            Container.Instance.Resolve<ISysUserService>().Add(new SysUser
            {
                Account = "Admin",
                PassWord = "123",
                UserName = "张三",
                IsActive = 1,
                RoleList = Container.Instance.Resolve<ISysRoleService>().Query(new List<ICriterion>()
                {
                    Expression.In("Id",new int[]{1})
                })
            });
        }
    }
}