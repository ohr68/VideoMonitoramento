using Seventh.VideoMonitoramento.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Seventh.VideoMonitoramento.Domain.Interfaces.Services
{
    public interface IVideoService : IDisposable
    {
        Video Create(Video video);
        Video GetById(Guid id);
        IEnumerable<Video> GetAll();
        IEnumerable<Video> GetAllServerVideos(Guid serverId);
        Video Update(Video video);
        void Remove(Guid id);
        void Recycle(int days);
        int SaveChanges();
    }
}
