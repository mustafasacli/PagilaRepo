using Coddie.Common;
using Coddie.Crud;
using Coddie.Data;
using Pagila.Command.Address;
using Pagila.Command.Base.Result;
using Pagila.Entity;
using SimpleInfra.Common.Response;

namespace Pagila.CommandHandlers.Address
{
    public class AddressInsertCommandHandler : PagilaBaseCommandHandler<AddressInsertCommand, LongCommandResult>
    {
        public override SimpleResponse<LongCommandResult> Handle(AddressInsertCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var result = connection.PartialInsertAndReturnId<AddressEntity>(new
                    {
                        command.Address,
                        command.Address2,
                        command.CityId,
                        command.District,
                        command.PostalCode,
                        command.Phone
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

        public override SimpleResponse Validate(AddressInsertCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}