using Seventh.VideoMonitoramento.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Seventh.VideoMonitoramento.Infra.Data.EntityConfig
{
    public class ServerConfig : EntityTypeConfiguration<Server>
    {
        public ServerConfig()
        {
            HasKey(s => s.Id);

            Property(s => s.Name)
                .HasMaxLength(200)
                .IsRequired();

            Property(s => s.IP)
                .HasMaxLength(40)
                .IsRequired();

            Property(s => s.Port)
                .IsRequired();

            HasMany(s => s.Videos)
                .WithRequired(v => v.Server)
                .HasForeignKey(v => v.ServerId);

            ToTable("Server");
        }
    }
}
