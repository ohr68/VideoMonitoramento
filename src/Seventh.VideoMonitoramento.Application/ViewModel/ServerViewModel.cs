using System;
using System.Collections.Generic;

namespace Seventh.VideoMonitoramento.Application.ViewModel
{
    public class ServerViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public virtual ICollection<VideoViewModel> Videos { get; set; }
    }
}
