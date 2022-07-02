using Coddie.Common;
using Coddie.Crud;
using Coddie.Data;
using Pagila.Command.Actor;
using Pagila.Command.Base.Result;
using Pagila.Entity;
using SimpleInfra.Common.Response;

namespace Pagila.CommandHandlers.Actor
{
    public class ActorInsertCommandHandler : PagilaBaseCommandHandler<ActorInsertCommand, LongCommandResult>
    {
        public override SimpleResponse<LongCommandResult> Handle(ActorInsertCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var result = connection.PartialInsertAndReturnId<ActorEntity>(new { command.FirstName, command.LastName });
                    response.ResponseCode = (int)result.Result;
                    response.RCode = result.ToString();
                    response.Data = new LongCommandResult { ReturnValue = result.Result.ToLongNullable() };
                }
                finally
                {
                    connection.CloseIfNot();
                }
            }

            return response;
        }

        public override SimpleResponse Validate(ActorInsertCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}