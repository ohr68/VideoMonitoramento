using Seventh.VideoMonitoramento.Application.AutoMapper;
using Seventh.VideoMonitoramento.WebAPI.App_Start;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Seventh.VideoMonitoramento.WebAPI
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
            AutoMapperConfig.RegisterMappings();
            SimpleInjectorInitializer.Initialize();

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }
    }
}
