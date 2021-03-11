using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Seventh.VideoMonitoramento.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        TEntity Create(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        TEntity Update(TEntity obj);
        void Remove(Guid id);
        IEnumerable<TEntity> Seek(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}
