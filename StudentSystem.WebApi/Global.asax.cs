using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace StudentSystem.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private void InitAutoFac()
        {
            var configuration = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();
            // Register API controllers using assembly scanning.   
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(configuration);


            Assembly[] services =
            {
                Assembly.Load("StudentSystem.IDAL"),
                Assembly.Load("StudentSystem.DAL"),
                Assembly.Load("StudentSystem.IBLL"),
                Assembly.Load("StudentSystem.BLL")
            };
            builder.RegisterAssemblyTypes(services)
                .Where(type => !type.IsAbstract)
                .AsImplementedInterfaces()
                .SingleInstance();



            var container = builder.Build();
            // Set the WebApi dependency resolver.   

            var resolver = new AutofacWebApiDependencyResolver(container);
            configuration.DependencyResolver = resolver;
        }


        protected void Application_Start()
        {
            InitAutoFac();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
