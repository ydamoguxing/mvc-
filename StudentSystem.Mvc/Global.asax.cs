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
            //�ѵ�ǰ�����е� Controller ��ע�� 
            // ��ȡ����������ĳ��� 
            Assembly[] assemblies = { Assembly.Load("StudentSystem.IBLL"), Assembly.Load("StudentSystem.BLL"), Assembly.Load("StudentSystem.IDAL"), Assembly.Load("StudentSystem.DAL") };

            builder.RegisterAssemblyTypes(assemblies)
                .Where(type => !type.IsAbstract)
                .AsImplementedInterfaces();
            var container = builder.Build();
            //ע��ϵͳ����� DependencyResolver�������� MVC ��ܴ��� Controller �ȶ����ʱ���ǹ� Autofac Ҫ���� 
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));




            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
