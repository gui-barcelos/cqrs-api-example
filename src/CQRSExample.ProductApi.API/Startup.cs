using System.Web.Http;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using CQRSExample.ProductApi.Infra.CrossCutting.Common;
using CQRSExample.ProductApi.Infra.CrossCutting.IoC;

namespace CQRSExample.ProductApi.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            log4net.Config.XmlConfigurator.Configure();

            Log.LogInfo("API: Starting...");

            HttpConfiguration config = new HttpConfiguration();

            // WebApi Configuration
            Log.LogInfo("API: Configuring WebApi.");
            WebApiConfig.Register(config);
            app.UseWebApi(config);

            // Dependency Injection Configuration
            Log.LogInfo("API: Configuring DI.");
            var container = IoCBootstraper.GetContainer();

            container.RegisterWebApiControllers(config);
            container.Verify();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            // Swagger Configuration
            Log.LogInfo("API: Configuring Swagger.");
            SwaggerConfig.Register(config);

            Log.LogInfo("API: Sucessfully Started.");
        }
    }
}