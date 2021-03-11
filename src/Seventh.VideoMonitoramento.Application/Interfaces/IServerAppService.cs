using Seventh.VideoMonitoramento.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace Seventh.VideoMonitoramento.Application.Interfaces
{
    public interface IServerAppService : IDisposable
    {
        ServerViewModel Create(ServerViewModel server);
        ServerViewModel GetById(Guid id);
        IEnumerable<ServerViewModel> GetAll();
        ServerViewModel Update(ServerViewModel server);
        void Remove(Guid id);
    }
}
