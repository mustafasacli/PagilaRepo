using Coddie.Data.Objects;
using SI.Command.Core;
using SI.CommandHandler.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagila.CommandHandlers
{
    public abstract class PagilaBaseCommandHandler<TCommand, TCommandResult>
         : BaseCommandHandler<TCommand, TCommandResult>
         where TCommand : class, ICommand<TCommandResult>
         where TCommandResult : class, ICommandResult
    {
        protected override IDbConnection GetDbConnection()
        {
            return new Npgsql.NpgsqlConnection { ConnectionString= "server = 127.0.0.1; Database = pagila; user id = postgres; password = 123456;" };
            //return base.GetDbConnection();
        }
    }
}
