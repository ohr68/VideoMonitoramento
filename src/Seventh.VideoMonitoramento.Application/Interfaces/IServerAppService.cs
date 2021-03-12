using Seventh.VideoMonitoramento.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace Seventh.VideoMonitoramento.Application.Interfaces
{
    public interface IServerAppService : IDisposable
    {
        ServerViewModel Create(ServerViewModel server);
        ServerViewModel GetById(Guid id);
        IEnumerable<ServerViewModel> GetAll();
        ServerViewModel Update(ServerViewModel server);
        void Remove(Guid id);
        PingReply CheckServerAvailability(Guid id);
    }
}
