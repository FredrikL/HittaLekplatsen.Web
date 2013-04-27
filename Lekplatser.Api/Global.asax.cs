using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Lekplatser.Api.App_Start;
using Lekplatser.Api.Repositories;

namespace Lekplatser.Api
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            SetupIoc();


            WebApiConfig.Register(GlobalConfiguration.Configuration);
            AutoMapperConfig.Configure();
        }

        private static void SetupIoc()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register other dependencies.
            builder.RegisterType<PlaygroundsRepository>().As<IPlaygroundsRepository>();
            
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}