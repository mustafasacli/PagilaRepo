using Coddie.Common;
using Coddie.Crud;
using Coddie.Data;
using Pagila.Command.Base.Result;
using Pagila.Command.City;
using Pagila.Entity;
using SimpleInfra.Common.Response;
using System;

namespace Pagila.CommandHandlers.City
{
    public class CityInsertCommandHandler : PagilaBaseCommandHandler<CityInsertCommand, LongCommandResult>
    {
        public override SimpleResponse<LongCommandResult> Handle(CityInsertCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            try
            {
                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var result = connection.PartialInsertAndReturnId<CityEntity>(new { City = command.City, CountryId = command.CountryId });
                        response.ResponseCode = (int)result.Result;
                        response.RCode = result.ToString();
                        response.Data = new LongCommandResult { ReturnValue = result.Result.ToLongNullable() };
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

        public override SimpleResponse Validate(CityInsertCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}