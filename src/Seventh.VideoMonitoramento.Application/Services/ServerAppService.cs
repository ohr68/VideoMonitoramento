using AutoMapper;
using Seventh.VideoMonitoramento.Application.Interfaces;
using Seventh.VideoMonitoramento.Application.ViewModel;
using Seventh.VideoMonitoramento.Domain.Entities;
using Seventh.VideoMonitoramento.Domain.Interfaces.Services;
using Seventh.VideoMonitoramento.Infra.Data.UnityOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;

namespace Seventh.VideoMonitoramento.Application.Services
{
    public class ServerAppService : AppService, IServerAppService
    {
        private readonly IServerService _serverService;

        public ServerAppService(IServerService serverService, IUnitOfWork uow)
            :base(uow)
        {
            _serverService = serverService;
        }

        public PingReply CheckServerAvailability(Guid id)
        {
            var serverInfo = _serverService.GetById(id);

            if (serverInfo == null)
                throw new Exception("The server was not found in databse!");

            byte[] serverAddress = serverInfo.IP.Split('.').Select(byte.Parse).ToArray();

            try
            {
                var ping = new Ping();
                var reply = ping.Send(new IPAddress(serverAddress), 60 * 1000);

                return reply;

            }catch(Exception e)
            {
                throw;
            }
        }

        public ServerViewModel Create(ServerViewModel server)
        {
            var createdServer = _serverService.Create(Mapper.Map<Server>(server));
            Commit();

            return Mapper.Map<ServerViewModel>(createdServer);
        }

        public void Dispose()
        {
            _serverService.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<ServerViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<ServerViewModel>>(_serverService.GetAll());
        }

        public ServerViewModel GetById(Guid id)
        {
            return Mapper.Map<ServerViewModel>(_serverService.GetById(id));
        }

        public void Remove(Guid id)
        {
            _serverService.Remove(id);
            Commit();
        }


        public ServerViewModel Update(ServerViewModel server)
        {
            var updatedServer = _serverService.Update(Mapper.Map<Server>(server));
            Commit();

            return Mapper.Map<ServerViewModel>(updatedServer);
        }
    }
}
