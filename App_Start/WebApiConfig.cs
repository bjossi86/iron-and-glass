using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.EnableCors(new EnableCorsAttribute("*", "*", "GET"));
            config.Routes.MapHttpRoute(
                name: "JoGAPI",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
