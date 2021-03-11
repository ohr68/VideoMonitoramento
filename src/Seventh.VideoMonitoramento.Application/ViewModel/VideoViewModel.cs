using System;

namespace Seventh.VideoMonitoramento.Application.ViewModel
{
    public class VideoViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Byte[] FileData { get; set; }
        public int SizeInBytes { get; set; }
        public Guid ServerId { get; set; }
        public virtual ServerViewModel Server { get; set; }
    }
}
