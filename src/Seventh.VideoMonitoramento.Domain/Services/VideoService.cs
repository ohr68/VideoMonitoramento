using Seventh.VideoMonitoramento.Domain.Entities;
using Seventh.VideoMonitoramento.Domain.Interfaces.Repositories;
using Seventh.VideoMonitoramento.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Seventh.VideoMonitoramento.Domain.Services
{
    public class VideoService : IVideoService
    {
        private readonly IVideoRepository _videoRepository;

        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public Video Create(Video video)
        {
            return _videoRepository.Create(video);
        }

        public void Dispose()
        {
            _videoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Video> GetAll()
        {
            return _videoRepository.GetAll();
        }

        public IEnumerable<Video> GetAllServerVideos(Guid serverId)
        {
            return _videoRepository.GetAllServerVideos(serverId);
        }

        public Video GetById(Guid id)
        {
            return _videoRepository.GetById(id);
        }

        public void Recycle(int days)
        {
            DateTime timePoint = DateTime.Now.AddDays(-days);
            var videos = _videoRepository.Seek(v => v.RegistrationDate < timePoint);

            foreach (var video in videos)
            {
                _videoRepository.Remove(video.Id);
            }
        }

        public void Remove(Guid id)
        {
            _videoRepository.Remove(id);
        }

        public int SaveChanges()
        {
            return _videoRepository.SaveChanges();
        }

        public Video Update(Video video)
        {
            return _videoRepository.Update(video);
        }
    }
}
