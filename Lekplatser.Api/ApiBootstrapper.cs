using Autofac;
using Lekplatser.Api.App_Start;
using Lekplatser.Api.Repositories;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;

namespace Lekplatser.Api
{
    public class ApiBootstrapper : AutofacNancyBootstrapper
    {
        protected override void ApplicationStartup(ILifetimeScope container, IPipelines pipelines)
        {
            // No registrations should be performed in here, however you may
            // resolve things that are needed during application startup.

            base.ApplicationStartup(container, pipelines);

            AutoMapperConfig.Configure();
        }

        protected override void ConfigureApplicationContainer(ILifetimeScope existingContainer)
        {
            // Perform registation that should have an application lifetime

            base.ConfigureApplicationContainer(existingContainer);

            var builder = new ContainerBuilder();
            builder.RegisterType<PlaygroundsRepository>().As<IPlaygroundsRepository>();
            builder.Update(existingContainer.ComponentRegistry);

        }

        protected override void ConfigureRequestContainer(ILifetimeScope container, NancyContext context)
        {
            // Perform registrations that should have a request lifetime
            base.ConfigureRequestContainer(container, context);
        }

        //protected override void RequestStartup(ILifetimeScope container, IPipelines pipelines, NancyContext context)
        //{
        //    // No registrations should be performed in here, however you may
        //    // resolve things that are needed during request startup.
        //}
    }
}