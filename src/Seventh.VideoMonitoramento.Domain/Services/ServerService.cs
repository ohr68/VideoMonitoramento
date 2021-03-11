using Seventh.VideoMonitoramento.Domain.Entities;
using Seventh.VideoMonitoramento.Domain.Interfaces.Repositories;
using Seventh.VideoMonitoramento.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Seventh.VideoMonitoramento.Domain.Services
{
    public class ServerService : IServerService
    {
        private readonly IServerRepository _serverRepository;

        public ServerService(IServerRepository serverRepository)
        {
            _serverRepository = serverRepository;
        }

        public Server Create(Server server)
        {
            return _serverRepository.Create(server);
        }

        public void Dispose()
        {
            _serverRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Server> GetAll()
        {
            return _serverRepository.GetAll();
        }

        public Server GetById(Guid id)
        {
            return _serverRepository.GetById(id);
        }

        public void Remove(Guid id)
        {
            _serverRepository.Remove(id);
        }

        public int SaveChanges()
        {
            return _serverRepository.SaveChanges();
        }

        public Server Update(Server server)
        {
            return _serverRepository.Update(server);
        }
    }
}
