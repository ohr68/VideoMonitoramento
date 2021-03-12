using System.ComponentModel;

namespace Seventh.VideoMonitoramento.Infra.Data.Procedures
{
    public enum ServerProcedures
    {
        [Description("usp_Server_GetAll")]
        GetAll,
        [Description("usp_Server_GetById")]
        GetById
    }
}
