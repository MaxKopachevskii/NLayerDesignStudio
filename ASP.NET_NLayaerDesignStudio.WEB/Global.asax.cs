using ASP.NET_NLayaerDesignStudio.WEB.Util;
using ASP.NET_NLayerDesignStudio.BLL.Infrastructure;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ASP.NET_NLayaerDesignStudio.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // ��������� ������������
            NinjectModule orderModule = new StudioModule();
            NinjectModule serviceModule = new ServiceModule("DefaultConnection");
            var kernel = new StandardKernel(orderModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            //// ��������� ������������
            //NinjectModule orderModule = new StudioModule();
            //var kernel = new StandardKernel(orderModule);
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}