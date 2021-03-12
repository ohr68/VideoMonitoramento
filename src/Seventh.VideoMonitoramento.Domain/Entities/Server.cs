using System;
using System.Collections.Generic;

namespace Seventh.VideoMonitoramento.Domain.Entities
{
    public class Server
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
    }
}
