using Npgsql;
using SI.Query.Core;
using SI.QueryHandler.Base;
using SimpleInfra.Mapping;
using Simply.Data.Database;
using Simply.Data.Interfaces;
using System.Data;

namespace Pagila.QueryHandlers
{
    /// <summary>
    /// The pagila base query handler.
    /// </summary>
    public abstract class PagilaBaseQueryHandler<TQuery, TResult> : BaseQueryHandler<TQuery, TResult>
              where TQuery : class, IQuery<TResult>
          where TResult : class, IQueryResult
    {
        /// <summary>
        /// Gets the db connection.
        /// </summary>
        /// <returns>A IDbConnection.</returns>
        protected override IDbConnection GetDbConnection()
        {
            return new NpgsqlConnection { ConnectionString = "server = 127.0.0.1; Database = pagila; user id = postgres; password = pg123;" };
            //return base.GetDbConnection();
        }

        /// <summary>
        /// Gets the simple database.
        /// </summary>
        /// <returns>A ISimpleDatabase.</returns>
        protected ISimpleDatabase GetDatabase()
        {
            ISimpleDatabase database = new SimpleDatabase(
                SimpleDatabase.Create<NpgsqlConnection>("server = 127.0.0.1; Database = pagila; user id = postgres; password = pg123;"));
            return database;
        }

        /// <summary>
        /// Maps the.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>A TViewModel.</returns>
        protected TViewModel Map<TEntity, TViewModel>(TEntity entity)
            where TEntity : class
            where TViewModel : class, new()
        {
            TViewModel model = SimpleMapper.Map<TEntity, TViewModel>(entity);
            return model;
        }
    }
}