using Seventh.VideoMonitoramento.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace Seventh.VideoMonitoramento.Application.Interfaces
{
    public interface IVideoAppService : IDisposable
    {
        VideoViewModel Create(VideoViewModel video);
        VideoViewModel GetById(Guid id);
        IEnumerable<VideoViewModel> GetAll();
        IEnumerable<VideoViewModel> GetAllServerVideos(Guid serverId);
        VideoViewModel Update(VideoViewModel video);
        void Remove(Guid id);
    }
}
