using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CQIE.RIS.Web.Controllers
{
    /// <summary>
    /// 登录验证
    /// </summary>
    /// <returns></returns>
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
    }
}