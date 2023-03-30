using Npgsql;
using SI.Command.Core;
using SI.CommandHandler.Base;
using Simply.Data.Database;
using Simply.Data.Interfaces;
using System.Data;

namespace Pagila.CommandHandlers
{
    /// <summary>
    /// The pagila base command handler.
    /// </summary>
    public abstract class PagilaBaseCommandHandler<TCommand, TCommandResult>
         : BaseCommandHandler<TCommand, TCommandResult>
         where TCommand : class, ICommand<TCommandResult>
         where TCommandResult : class, ICommandResult
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
            ISimpleDatabase database = new SimpleDatabase(SimpleDatabase.Create<NpgsqlConnection>("server = 127.0.0.1; Database = pagila; user id = postgres; password = pg123;"));
            return database;
        }
    }
}