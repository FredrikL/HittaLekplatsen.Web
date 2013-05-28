using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Lekplatser.Web.Repository;

namespace Lekplatser.Web
{
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

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
           
        }

        private static void IocRegistration(ContainerBuilder builder)
        {
            builder.RegisterType<PlaygroundsRepository>().As<IPlaygroundsRepository>();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
        }
    }
}