using Hangfire;
using Hangfire.SqlServer;
using System;
using System.Collections.Generic;

namespace Seventh.VideoMonitoramento.Services.API.App_Start
{
    public class HangfireInitializer
    {
        public static IEnumerable<IDisposable> GetHangfireServers()
        {
            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage("VideoMonitoramento", new SqlServerStorageOptions()
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true,
                    //PrepareSchemaIfNecessary = false
                });

            var options = new BackgroundJobServerOptions()
            {
                Queues = new[] { "recycler" }
            };

            yield return new BackgroundJobServer();
        }
    }
}