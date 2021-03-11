using System.Threading.Tasks;

namespace Seventh.VideoMonitoramento.Infra.Data.UnityOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
    }
}
