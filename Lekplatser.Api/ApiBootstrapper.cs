using Lekplatser.Api.App_Start;
using Nancy;

namespace Lekplatser.Api
{
    public class ApiBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(Nancy.TinyIoc.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            AutoMapperConfig.Configure();
        }
    }
}