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
        Video Update(Video video);
        void Remove(Guid id);
        int SaveChanges();
    }
}
