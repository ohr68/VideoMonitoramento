using Seventh.VideoMonitoramento.Domain.Entities;
using Seventh.VideoMonitoramento.Domain.Interfaces.Repositories;
using Seventh.VideoMonitoramento.Infra.Data.Context;

namespace Seventh.VideoMonitoramento.Infra.Data.Repository
{
    public class ServerRepository : Repository<Server>, IServerRepository
    {
        public ServerRepository(VideoMonitoramentoContext context) : base(context)
        {
        }
    }
}
