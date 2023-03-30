using Pagila.Command.Base.Result;
using Pagila.Command.Customer;
using Pagila.Entity;
using SimpleInfra.Common.Response;
using Simply.Common;
using Simply.Crud;

namespace Pagila.CommandHandlers.Customer
{
    /// <summary>
    /// The customer insert command handler.
    /// </summary>
    public class CustomerInsertCommandHandler : PagilaBaseCommandHandler<CustomerInsertCommand, LongCommandResult>
    {
        /// <summary>
        /// Handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<LongCommandResult> Handle(CustomerInsertCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var database = GetDatabase())
            {
                var result = database.PartialInsertAndReturnId<CustomerEntity>(new { command.FirstName, command.LastName });
                response.ResponseCode = (int)result.Result;
                response.RCode = result.ToString();
                response.Data = new LongCommandResult { ReturnValue = result.Result.ToLongNullable() };
            }

            return response;
        }

        /// <summary>
        /// Validates the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse Validate(CustomerInsertCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}