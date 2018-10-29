using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using System.Net.Http.Headers;
using System.Web.Http;
using Unity;

namespace ASPWebAPI
{
    public static class WebApiConfig
    {
        public static IUnityContainer UnityContainer;

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.EnableCors();
            
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            UnityContainer = new UnityContainer();
            //UnityContainer.LoadConfiguration("RegisteredTypes");
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(UnityContainer, "RegisteredTypes");
        }
    }
}
