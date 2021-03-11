using AutoMapper;
using Seventh.VideoMonitoramento.Application.ViewModel;
using Seventh.VideoMonitoramento.Domain.Entities;

namespace Seventh.VideoMonitoramento.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Server, ServerViewModel>();
            CreateMap<Video, VideoViewModel>();
        }
    }
}
