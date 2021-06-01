using Coddie.Crud;
using Coddie.Data;
using Pagila.Command.Actor;
using Pagila.Command.Base.Result;
using Pagila.Entity;
using SimpleInfra.Common.Response;
using System;

namespace Pagila.CommandHandlers.Actor
{
    public class ActorUpdateCommandHandler : PagilaBaseCommandHandler<ActorUpdateCommand, LongCommandResult>
    {
        public override SimpleResponse<LongCommandResult> Handle(ActorUpdateCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            try
            {
                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var result = connection.PartialUpdate<ActorEntity>(new
                        {
                            command.FirstName,
                            command.LastName,
                            command.LastUpdate
                        }, p => p.ActorId == command.ActorId);
                        response.ResponseCode = result;
                        response.RCode = result.ToString();
                        response.Data = new LongCommandResult { ReturnValue = command.ActorId };
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

        public override SimpleResponse Validate(ActorUpdateCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}