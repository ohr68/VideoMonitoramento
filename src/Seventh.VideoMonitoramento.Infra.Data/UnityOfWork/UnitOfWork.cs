using Seventh.VideoMonitoramento.Infra.Data.Context;
using System.Threading.Tasks;

namespace Seventh.VideoMonitoramento.Infra.Data.UnityOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VideoMonitoramentoContext _context;
        private bool _disposed;

        public UnitOfWork(VideoMonitoramentoContext context)
        {
            _context = context;
            _disposed = false;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!_disposed)
            {
                if(disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
