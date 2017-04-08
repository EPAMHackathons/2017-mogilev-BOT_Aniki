using Adjutant.Api.Repositories;
using Adjutant.Api.Repositories.Interfaces;
using Adjutant.Api.Resolver;
using Adjutant.Common.Services;
using Adjutant.Common.Services.Interfaces;
using Microsoft.Practices.Unity;
using System.Web.Http;

namespace Adjutant.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IBotService, BotService>(new HierarchicalLifetimeManager());
            container.RegisterType<IBotRepository, BotRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Formatters.JsonFormatter.SupportedMediaTypes
                  .Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
