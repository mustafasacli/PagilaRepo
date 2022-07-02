using Coddie.Common;
using Coddie.Crud;
using Coddie.Data;
using Pagila.Command.Base.Result;
using Pagila.Command.Customer;
using Pagila.Entity;
using SimpleInfra.Common.Response;

namespace Pagila.CommandHandlers.Customer
{
    public class CustomerInsertCommandHandler : PagilaBaseCommandHandler<CustomerInsertCommand, LongCommandResult>
    {
        public override SimpleResponse<LongCommandResult> Handle(CustomerInsertCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var result = connection.PartialInsertAndReturnId<CustomerEntity>(new { command.FirstName, command.LastName });
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

        public override SimpleResponse Validate(CustomerInsertCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}