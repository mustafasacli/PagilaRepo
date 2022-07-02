using Coddie.Crud;
using Coddie.Data;
using Pagila.Command.Base.Result;
using Pagila.Command.Customer;
using Pagila.Entity;
using SimpleInfra.Common.Response;

namespace Pagila.CommandHandlers.Customer
{
    public class CustomerUpdateCommandHandler : PagilaBaseCommandHandler<CustomerUpdateCommand, LongCommandResult>
    {
        public override SimpleResponse<LongCommandResult> Handle(CustomerUpdateCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var result = connection.PartialUpdate<CustomerEntity>(new
                    {
                        command.FirstName,
                        command.LastName,
                        command.LastUpdate
                    }, p => p.CustomerId == command.CustomerId);
                    response.ResponseCode = result;
                    response.RCode = result.ToString();
                    response.Data = new LongCommandResult { ReturnValue = command.CustomerId };
                }
                finally
                {
                    connection.CloseIfNot();
                }
            }

            return response;
        }

        public override SimpleResponse Validate(CustomerUpdateCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}