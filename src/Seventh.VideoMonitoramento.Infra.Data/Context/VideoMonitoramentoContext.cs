using Seventh.VideoMonitoramento.Domain.Entities;
using Seventh.VideoMonitoramento.Infra.Data.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Seventh.VideoMonitoramento.Infra.Data.Context
{
    public class VideoMonitoramentoContext : DbContext
    {
        public VideoMonitoramentoContext()
            :base("VideoMonitoramento")
        {

        }

        public DbSet<Server> Servers { get; set; }
        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();


            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<short>()
                .Configure(p => p.HasColumnType("smallint"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ServerConfig());
            modelBuilder.Configurations.Add(new VideoConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
