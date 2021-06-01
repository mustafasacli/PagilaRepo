using SI.Query.Core;
using SI.QueryHandler.Base;
using SimpleInfra.Mapping;
using System.Data;

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

        protected TViewModel Map<TEntity, TViewModel>(TEntity entity)
            where TEntity : class
            where TViewModel : class, new()
        {
            TViewModel model = SimpleMapper.Map<TEntity, TViewModel>(entity);
            return model;
        }
    }
}