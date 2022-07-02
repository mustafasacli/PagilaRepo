using Coddie.Common;
using Coddie.Crud;
using Coddie.Data;
using Pagila.Command.Base.Result;
using Pagila.Command.Staff;
using Pagila.Entity;
using SimpleInfra.Common.Response;

namespace Pagila.CommandHandlers.Staff
{
    public class StaffInsertCommandHandler : PagilaBaseCommandHandler<StaffInsertCommand, LongCommandResult>
    {
        public override SimpleResponse<LongCommandResult> Handle(StaffInsertCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var result = connection.PartialInsertAndReturnId<StaffEntity>(new
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

            return response;
        }

        public override SimpleResponse Validate(StaffInsertCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}