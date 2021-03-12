using Seventh.VideoMonitoramento.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Seventh.VideoMonitoramento.Domain.Interfaces.Repositories
{
    public interface IVideoRepository : IRepository<Video>
    {
        IEnumerable<Video> GetAllServerVideos(Guid serverId);
    }
}
