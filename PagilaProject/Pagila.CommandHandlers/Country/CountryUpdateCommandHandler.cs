using Coddie.Crud;
using Coddie.Data;
using Pagila.Command.Base.Result;
using Pagila.Command.Country;
using Pagila.Entity;
using SimpleInfra.Common.Response;
using System;

namespace Pagila.CommandHandlers.Country
{
    public class CountryUpdateCommandHandler : PagilaBaseCommandHandler<CountryUpdateCommand, LongCommandResult>
    {
        public override SimpleResponse<LongCommandResult> Handle(CountryUpdateCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            try
            {
                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var result = connection.PartialUpdate<CountryEntity>(new
                        {
                            command.Country
                        }, p => p.CountryId == command.CountryId);
                        response.ResponseCode = result;
                        response.RCode = result.ToString();
                        response.Data = new LongCommandResult { ReturnValue = command.CountryId };
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

        public override SimpleResponse Validate(CountryUpdateCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}