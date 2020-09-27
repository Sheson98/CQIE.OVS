using CQIE.OVS.Web.Apps;
using CQIE.RIS.Core;
using CQIE.RIS.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CQIE.RIS.Web.Controllers
{
    public class UserManageController : Controller
    {
        // GET: User
        public ActionResult StuManage()
        {
            return View();



        }
        public JsonResult StuManage1()
        {
            string strSql = "select * from SysUser where Id in(select  SysUserId FROM SysUser_SysRole where SysRoleId = 1)";
            ViewBag.PrivilegeList = Container.Instance.Resolve<ISysUserService>().GetListBySQL(strSql);

            //IList<SysUser> userlist = bll.PageLikeQuery(pageNumber, limit, no, name, roleId);
            //List<string[]> User = new List<string>
            List<Hashtable> User = new List<Hashtable>(); //创建Hashtable 对象包含用键/ 值对表示
            //SysUser[] user= userlist.ToArray();
            foreach (var u in ViewBag.PrivilegeList)
            {
                Hashtable ht = new Hashtable();
                ht.Add("ID", u.Id);
                ht.Add("UserName", u.UserName);
                ht.Add("Account", u.Account);
                ht.Add("PassWord", u.PassWord);
                ht.Add("IsActive", u.IsActive);

                User.Add(ht);
            }
            //总的数据行数
            //int count = bll.Count(no, name, roleId);
            return Json(new
            {
                code = 0,
                msg = "",
                count = 10,
                data = User
            }, JsonRequestBehavior.AllowGet);



        }
    }
}