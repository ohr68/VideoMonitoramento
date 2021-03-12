using Seventh.VideoMonitoramento.Application.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Seventh.VideoMonitoramento.Application.ViewModel
{
    public class VideoViewModel
    {
        [NotEmpty]
        [Key]       
        public Guid Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Byte[] FileData { get; set; }
        [Required]
        public int SizeInBytes { get; set; }
        [Required]
        public Guid ServerId { get; set; }
        public virtual ServerViewModel Server { get; set; }
    }
}
