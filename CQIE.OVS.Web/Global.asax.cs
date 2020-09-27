using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using CQIE.RIS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CQIE.RIS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IConfigurationSource source = System.Configuration.ConfigurationManager.GetSection("activerecord") as IConfigurationSource;
            ActiveRecordStarter.Initialize(typeof(SysUser).Assembly, source);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
