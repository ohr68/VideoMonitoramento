using Dapper;
using Seventh.VideoMonitoramento.CrossCutting.ExtensionMethods;
using Seventh.VideoMonitoramento.Domain.Entities;
using Seventh.VideoMonitoramento.Domain.Interfaces.Repositories;
using Seventh.VideoMonitoramento.Infra.Data.Context;
using Seventh.VideoMonitoramento.Infra.Data.Procedures;
using Slapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Seventh.VideoMonitoramento.Infra.Data.Repository
{
    public class VideoRepository : Repository<Video>, IVideoRepository
    {
        public VideoRepository(VideoMonitoramentoContext context) : base(context)
        {
        }

        public IEnumerable<Video> GetAllServerVideos(Guid serverId)
        {
            var cn = Db.Database.Connection;

            var query = cn.Query<dynamic>(VideoProcedures.GetAllServerVideos.GetDescription(),
                new {serverId = serverId},
                commandType: CommandType.StoredProcedure);

            AutoMapper.Configuration.AddIdentifier(typeof(Video), "Id");

            List<Video> videos = (AutoMapper.MapDynamic<Video>(query, false) as IEnumerable<Video>).ToList();
            return videos;
        }

        public override Video GetById(Guid id)
        {
            var cn = Db.Database.Connection;

            return cn.Query<Video>(VideoProcedures.GetById.GetDescription(),
                new { sid = id },
                commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
    }
}
