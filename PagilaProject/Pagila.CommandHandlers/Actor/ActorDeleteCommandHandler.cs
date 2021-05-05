using Coddie.Crud;
using Coddie.Data;
using Pagila.Command.Actor;
using Pagila.Command.Base.Result;
using Pagila.Entity;
using SI.CommandHandler.Base;
using SimpleInfra.Common.Response;
using System;

namespace Pagila.CommandHandlers.Actor
{
    public class ActorDeleteCommandHandler : BaseCommandHandler<ActorDeleteCommand, LongCommandResult>
    {
        public override SimpleResponse<LongCommandResult> Handle(ActorDeleteCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            try
            {
                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var result = connection.DeleteAll<ActorEntity>(p => p.ActorId == command.Id);
                        response.ResponseCode = result;
                        response.RCode = result.ToString();
                        response.Data = new LongCommandResult { ReturnValue = command.Id };
                    }
                    finally
                    {
                        connection.CloseIfNot();
                    }
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = -500;
                DayLogger.Error(ex);
            }

            return response;
        }

        public override SimpleResponse Validate(ActorDeleteCommand command)
        {
            SimpleResponse response = new SimpleResponse();

            if (command.Id < 1)
            {
                response.ResponseCode = -100;
                response.ResponseMessage = "Invalid id value";
            }
            // Validation process will be added  in future.

            return response;
        }
    }
}