using Seventh.VideoMonitoramento.Application.AutoMapper;
using Seventh.VideoMonitoramento.Services.API.App_Start;
using System.Diagnostics;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Seventh.VideoMonitoramento.Services.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var config = GlobalConfiguration.Configuration;
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();
            SimpleInjectorInitializer.Initialize();
            
            Hangfire.HangfireAspNet.Use(HangfireInitializer.GetHangfireServers);
            StartService();

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }

        private static void StartService()
        {
            Hangfire.BackgroundJob.Enqueue(() => Debug.WriteLine("Hello World from Hangfire!!"));
        }
    }
}
