using Seventh.VideoMonitoramento.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Seventh.VideoMonitoramento.Domain.Interfaces.Services
{
    public interface IServerService : IDisposable
    {
        Server Create(Server server);
        Server GetById(Guid id);
        IEnumerable<Server> GetAll();
        Server Update(Server server);
        void Remove(Guid id);
        int SaveChanges();
    }
}
