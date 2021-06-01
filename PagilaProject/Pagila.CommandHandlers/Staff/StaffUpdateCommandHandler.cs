using Coddie.Crud;
using Coddie.Data;
using Pagila.Command.Base.Result;
using Pagila.Command.Staff;
using Pagila.Entity;
using SimpleInfra.Common.Response;
using System;

namespace Pagila.CommandHandlers.Staff
{
    public class StaffUpdateCommandHandler : PagilaBaseCommandHandler<StaffUpdateCommand, LongCommandResult>
    {
        public override SimpleResponse<LongCommandResult> Handle(StaffUpdateCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            try
            {
                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var result = connection.PartialUpdate<StaffEntity>(new
                        {
                            command.FirstName,
                            command.LastName,
                            command.AddressId,
                            command.Email,
                            command.StoreId,
                            command.Active,
                            command.Username,
                            command.Password,
                            command.LastUpdate,
                            command.Picture
                        }, p => p.StaffId == command.StaffId);
                        response.ResponseCode = result;
                        response.RCode = result.ToString();
                        response.Data = new LongCommandResult { ReturnValue = command.StaffId };
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

        public override SimpleResponse Validate(StaffUpdateCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}