using Seventh.VideoMonitoramento.Infra.Data.Context;
using System.Data.Entity.Migrations;

namespace Seventh.VideoMonitoramento.Infra.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<VideoMonitoramentoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(VideoMonitoramentoContext context)
        {
            //base.Seed(context);
        }
    }
}
