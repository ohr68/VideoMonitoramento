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
    public class ServerRepository : Repository<Server>, IServerRepository
    {
        public ServerRepository(VideoMonitoramentoContext context) : base(context)
        {
        }

        public override Server GetById(Guid id)
        {
            var cn = Db.Database.Connection;

            return cn.Query<Server>(ServerProcedures.GetById.GetDescription(),
                new { sid = id },
                commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public override IEnumerable<Server> GetAll()
        {
            var cn = Db.Database.Connection;

            var query = cn.Query<dynamic>(ServerProcedures.GetAll.GetDescription(),
                null,
                commandType: CommandType.StoredProcedure);

            AutoMapper.Configuration.AddIdentifier(typeof(Server), "Id");

            List<Server> servers = (AutoMapper.MapDynamic<Server>(query, false) as IEnumerable<Server>).ToList();
            return servers;
        }
    }
}
