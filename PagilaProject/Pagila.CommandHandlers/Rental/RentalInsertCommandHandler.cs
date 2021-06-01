using Coddie.Common;
using Coddie.Crud;
using Coddie.Data;
using Pagila.Command.Base.Result;
using Pagila.Command.Rental;
using Pagila.Entity;
using SimpleInfra.Common.Response;
using System;

namespace Pagila.CommandHandlers.Rental
{
    public class RentalInsertCommandHandler : PagilaBaseCommandHandler<RentalInsertCommand, LongCommandResult>
    {
        public override SimpleResponse<LongCommandResult> Handle(RentalInsertCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            try
            {
                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var result = connection.PartialInsertAndReturnId<RentalEntity>(new
                        {
                            command.RentalDate,
                            command.InventoryId,
                            command.CustomerId,
                            command.ReturnDate,
                            command.StaffId
                        });
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

        public override SimpleResponse Validate(RentalInsertCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}