using System;

namespace Seventh.VideoMonitoramento.Domain.Entities
{
    public class Video
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Byte[] FileData { get; set; }
        public int SizeInBytes { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public Guid ServerId { get; set; }
        public virtual Server Server { get; set; }
    }
}
