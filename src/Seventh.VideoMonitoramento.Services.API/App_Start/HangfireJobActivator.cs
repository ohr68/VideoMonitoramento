using Hangfire;
using Hangfire.SimpleInjector;
using SimpleInjector;

namespace Seventh.VideoMonitoramento.Services.API.App_Start
{
    public class HangfireJobActivator
    {
        public static void InitializeActivator(Container container)
        {
            GlobalConfiguration.Configuration.UseActivator(new SimpleInjectorJobActivator(container));
        }
    }
}