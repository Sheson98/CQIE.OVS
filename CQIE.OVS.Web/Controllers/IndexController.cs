using CQIE.OVS.Web.Apps;
using CQIE.RIS.Core;
using CQIE.RIS.Service;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;


namespace CQIE.RIS.Web.Controllers
{
    /// <summary>
    /// 登录后的控制器
    /// </summary>
    public class IndexController : Controller
    {
            
        // GET: Index
        public ActionResult Index()
        {
            
             AppHelper.LoginedUser = Container.Instance.Resolve<ISysUserService>().GetEntity(1);
             ViewBag.PrivilegeList = AppHelper.Privileges;

             return View();

        }
        
    }
}