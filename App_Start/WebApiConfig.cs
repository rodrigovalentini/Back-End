using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Back_End
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web

            //Serializando JSON
            /* var formatters = GlobalConfiguration.Configuration.Formatters;
             var jsonFormatter = formatters.JsonFormatter;
             var settings = jsonFormatter.SerializerSettings;

             jsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
             config.Formatters.Remove(config.Formatters.XmlFormatter); 
             settings.Formatting = Formatting.Indented;
             settings.ContractResolver = new CamelCasePropertyNamesContractResolver(); */
            //config.EnableCors();
            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            
        }
    }
}
