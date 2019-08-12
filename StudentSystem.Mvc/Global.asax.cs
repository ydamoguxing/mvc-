using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace StudentSystem.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //把当前程序集中的 Controller 都注册 
            // 获取所有相关类库的程序集 
            Assembly[] assemblies = { Assembly.Load("StudentSystem.IBLL"), Assembly.Load("StudentSystem.BLL"), Assembly.Load("StudentSystem.IDAL"), Assembly.Load("StudentSystem.DAL") };

            builder.RegisterAssemblyTypes(assemblies)
                .Where(type => !type.IsAbstract)
                .AsImplementedInterfaces();
            var container = builder.Build();
            //注册系统级别的 DependencyResolver，这样当 MVC 框架创建 Controller 等对象的时候都是管 Autofac 要对象。 
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));




            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
