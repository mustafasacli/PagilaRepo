using Coddie.Crud;
using Coddie.Data;
using Pagila.Command.Base.Result;
using Pagila.Command.Country;
using Pagila.Entity;
using SimpleInfra.Common.Response;
using System;

namespace Pagila.CommandHandlers.Country
{
    public class CountryDeleteCommandHandler : PagilaBaseCommandHandler<CountryDeleteCommand, LongCommandResult>
    {
        public override SimpleResponse<LongCommandResult> Handle(CountryDeleteCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            try
            {
                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var result = connection.DeleteAll<CountryEntity>(p => p.CountryId == command.Id);
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

        public override SimpleResponse Validate(CountryDeleteCommand command)
        {
            SimpleResponse response = new SimpleResponse();

            if (command.Id == null || command.Id < 1)
            {
                response.ResponseCode = -100;
                response.ResponseMessage = "Invalid id value";
            }
            // Validation process will be added  in future.

            return response;
        }
    }
}