using System.ComponentModel;

namespace Seventh.VideoMonitoramento.Infra.Data.Procedures
{
    public enum VideoProcedures
    {
        [Description("usp_Video_GetAllServerVideos")]
        GetAllServerVideos,
        [Description("usp_Video_GetById")]
        GetById
    }
}
