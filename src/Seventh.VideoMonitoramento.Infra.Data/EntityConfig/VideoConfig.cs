using Seventh.VideoMonitoramento.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Seventh.VideoMonitoramento.Infra.Data.EntityConfig
{
    public class VideoConfig : EntityTypeConfiguration<Video>
    {
        public VideoConfig()
        {
            HasKey(v => v.Id);

            Property(v => v.Description)
                .HasMaxLength(150)
                .IsRequired();

            Property(v => v.SizeInBytes)
                .IsRequired();

            Property(v => v.FileData)
                .HasColumnType("VARBINARY(MAX)")
                .IsRequired();
        }
    }
}
