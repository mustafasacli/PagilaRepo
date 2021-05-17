using Coddie.Crud;
using Coddie.Data;
using Pagila.Command.Base.Result;
using Pagila.Command.City;
using Pagila.Entity;
using SimpleInfra.Common.Response;
using System;

namespace Pagila.CommandHandlers.City
{
    public class CityUpdateCommandHandler : PagilaBaseCommandHandler<CityUpdateCommand, LongCommandResult>
    {
        public override SimpleResponse<LongCommandResult> Handle(CityUpdateCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            try
            {
                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var result = connection.PartialUpdate<CityEntity>(new
                        {
                            command.Name
                        }, p => p.CityId == command.CityId);
                        response.ResponseCode = result;
                        response.RCode = result.ToString();
                        response.Data = new LongCommandResult { ReturnValue = command.CityId };
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

        public override SimpleResponse Validate(CityUpdateCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}