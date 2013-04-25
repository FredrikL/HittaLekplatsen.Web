using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Lekplatser.Admin.Repository;

namespace Lekplatser.Admin
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            SetupIoc();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

        }

        private static void SetupIoc()
        {
            var builder = new ContainerBuilder();
            IocRegistration(builder);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void IocRegistration(ContainerBuilder builder)
        {
            builder.RegisterType<PlaygroundRepository>().As<IPlaygroundRepository>();
            builder.RegisterControllers(typeof (MvcApplication).Assembly);
        }
    }
}