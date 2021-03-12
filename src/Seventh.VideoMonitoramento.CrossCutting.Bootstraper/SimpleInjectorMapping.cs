using Seventh.VideoMonitoramento.Application.Interfaces;
using Seventh.VideoMonitoramento.Application.Services;
using Seventh.VideoMonitoramento.Domain.Interfaces.Repositories;
using Seventh.VideoMonitoramento.Domain.Interfaces.Services;
using Seventh.VideoMonitoramento.Domain.Services;
using Seventh.VideoMonitoramento.Infra.Data.Context;
using Seventh.VideoMonitoramento.Infra.Data.Repository;
using Seventh.VideoMonitoramento.Infra.Data.UnityOfWork;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Seventh.VideoMonitoramento.CrossCutting.Bootstraper
{
    public class SimpleInjectorMapping
    {
        public static void Register(Container container)
        {
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<VideoMonitoramentoContext>(Lifestyle.Scoped);
            
            container.Register<IServerAppService, ServerAppService>(Lifestyle.Scoped);
            container.Register<IVideoAppService, VideoAppService>(Lifestyle.Scoped);

            container.Register<IServerService, ServerService>(Lifestyle.Scoped);
            container.Register<IVideoService, VideoService>(Lifestyle.Scoped);

            container.Register<IServerRepository, ServerRepository>(Lifestyle.Scoped);
            container.Register<IVideoRepository, VideoRepository>(Lifestyle.Scoped);
        }
    }
}
