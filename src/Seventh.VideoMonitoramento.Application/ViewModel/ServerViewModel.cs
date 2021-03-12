using Seventh.VideoMonitoramento.Application.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Seventh.VideoMonitoramento.Application.ViewModel
{
    public class ServerViewModel
    {
        [NotEmpty]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [IpAddress]
        [Required]
        public string IP { get; set; }

        [Required]
        [Range(0,65353)]
        public int Port { get; set; }
        public virtual ICollection<VideoViewModel> Videos { get; set; }
    }
}
