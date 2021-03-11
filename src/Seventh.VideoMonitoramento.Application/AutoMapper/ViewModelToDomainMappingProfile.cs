using AutoMapper;
using Seventh.VideoMonitoramento.Application.ViewModel;
using Seventh.VideoMonitoramento.Domain.Entities;

namespace Seventh.VideoMonitoramento.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ServerViewModel, Server>();
            CreateMap<VideoViewModel, Video>();
        }
    }
}
