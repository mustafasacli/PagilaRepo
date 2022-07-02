using Coddie.Crud;
using Coddie.Data;
using Pagila.Command.Address;
using Pagila.Command.Base.Result;
using Pagila.Entity;
using SimpleInfra.Common.Response;

namespace Pagila.CommandHandlers.Address
{
    public class AddressUpdateCommandHandler : PagilaBaseCommandHandler<AddressUpdateCommand, LongCommandResult>
    {
        public override SimpleResponse<LongCommandResult> Handle(AddressUpdateCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var result = connection.PartialUpdate<AddressEntity>(new
                    {
                        command.Address,
                        command.Address2,
                        command.CityId,
                        command.District,
                        command.PostalCode,
                        command.Phone
                    }, p => p.AddressId == command.AddressId);
                    response.ResponseCode = result;
                    response.RCode = result.ToString();
                    response.Data = new LongCommandResult { ReturnValue = command.AddressId };
                }
                finally
                {
                    connection.CloseIfNot();
                }
            }

            return response;
        }

        public override SimpleResponse Validate(AddressUpdateCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}