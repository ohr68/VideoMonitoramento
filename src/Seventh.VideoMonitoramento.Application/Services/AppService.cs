using Seventh.VideoMonitoramento.Infra.Data.UnityOfWork;
using System.Threading.Tasks;

namespace Seventh.VideoMonitoramento.Application.Services
{
    public class AppService
    {
        private readonly IUnitOfWork _uow;

        public AppService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected void Commit()
        {
            _uow.Commit();
        }

        protected async Task CommitAsync()
        {
            await _uow.CommitAsync();
        }
    }
}
