using System.Net.Http.Extensions.Compression.Core.Compressors;
using System.Web.Http;
using Microsoft.AspNet.WebApi.Extensions.Compression.Server;
using Newtonsoft.Json;

namespace CQRSExample.ProductApi.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Compression
            config.MessageHandlers.Insert(0, new ServerCompressionHandler(1000, new GZipCompressor(), new DeflateCompressor()));

            // Formatters settings 
            var formatters = config.Formatters;
            config.Formatters.Remove(formatters.XmlFormatter);
            config.Formatters.JsonFormatter.Indent = true;

            // Serialize values by reference instead of by value
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
        }
    }
}
