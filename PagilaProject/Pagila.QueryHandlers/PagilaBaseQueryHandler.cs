using SI.Query.Core;
using SI.QueryHandler.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagila.QueryHandlers
{
    public abstract class PagilaBaseQueryHandler<TQuery, TResult> : BaseQueryHandler<TQuery, TResult>
              where TQuery : class, IQuery<TResult>
          where TResult : class, IQueryResult
    {
        protected override IDbConnection GetDbConnection()
        {
            return new Npgsql.NpgsqlConnection { ConnectionString = "server = 127.0.0.1; Database = pagila; user id = postgres; password = 123456;" };
            //return base.GetDbConnection();
        }
    }
}
