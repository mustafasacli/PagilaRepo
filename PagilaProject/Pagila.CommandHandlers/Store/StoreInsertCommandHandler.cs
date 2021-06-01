using Coddie.Common;
using Coddie.Crud;
using Coddie.Data;
using Pagila.Command.Base.Result;
using Pagila.Command.Store;
using Pagila.Entity;
using SimpleInfra.Common.Response;
using System;

namespace Pagila.CommandHandlers.Store
{
    public class StoreInsertCommandHandler : PagilaBaseCommandHandler<StoreInsertCommand, LongCommandResult>
    {
        public override SimpleResponse<LongCommandResult> Handle(StoreInsertCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            try
            {
                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var result = connection.PartialInsertAndReturnId<StoreEntity>(new
                        {
                            command.ManagerStaffId,
                            command.AddressId,
                            command.LastUpdate
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

        public override SimpleResponse Validate(StoreInsertCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}