using AutoMapper;
using Seventh.VideoMonitoramento.Application.Interfaces;
using Seventh.VideoMonitoramento.Application.ViewModel;
using Seventh.VideoMonitoramento.Domain.Entities;
using Seventh.VideoMonitoramento.Domain.Interfaces.Services;
using Seventh.VideoMonitoramento.Infra.Data.UnityOfWork;
using System;
using System.Collections.Generic;

namespace Seventh.VideoMonitoramento.Application.Services
{
    public class VideoAppService : AppService, IVideoAppService
    {
        private readonly IVideoService _videoService;

        public VideoAppService(IVideoService videoService, IUnitOfWork uow)
            :base(uow)
        {
            _videoService = videoService;
        }

        public VideoViewModel Create(VideoViewModel video)
        {
            var createdVideo = _videoService.Create(Mapper.Map<Video>(video));
            Commit();

            return Mapper.Map<VideoViewModel>(createdVideo);
        }

        public void Dispose()
        {
            _videoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<VideoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<VideoViewModel>>(_videoService.GetAll());
        }

        public IEnumerable<VideoViewModel> GetAllServerVideos(Guid serverId)
        {
            return Mapper.Map<IEnumerable<VideoViewModel>>(_videoService.GetAllServerVideos(serverId));
        }

        public VideoViewModel GetById(Guid id)
        {
            return Mapper.Map<VideoViewModel>(_videoService.GetById(id));
        }

        public void Recycle(int days)
        {
            _videoService.Recycle(days);
            Commit();
        }

        public void Remove(Guid id)
        {
            _videoService.Remove(id);
            Commit();
        }

        public VideoViewModel Update(VideoViewModel video)
        {
            var updatedVideo = _videoService.Update(Mapper.Map<Video>(video));
            Commit();

            return Mapper.Map<VideoViewModel>(updatedVideo);
        }
    }
}
