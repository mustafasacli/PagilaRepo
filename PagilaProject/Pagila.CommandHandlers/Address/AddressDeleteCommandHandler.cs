using Pagila.Command.Address;
using Pagila.Command.Base.Result;
using Pagila.Entity;
using SimpleInfra.Common.Response;
using Simply.Crud;

namespace Pagila.CommandHandlers.Address
{
    /// <summary>
    /// The address delete command handler.
    /// </summary>
    public class AddressDeleteCommandHandler : PagilaBaseCommandHandler<AddressDeleteCommand, LongCommandResult>
    {
        /// <summary>
        /// Handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<LongCommandResult> Handle(AddressDeleteCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var database = GetDatabase())
            {
                var result = database.DeleteAll<AddressEntity>(p => p.AddressId == command.Id);
                response.ResponseCode = result;
                response.RCode = result.ToString();
                response.Data = new LongCommandResult { ReturnValue = command.Id };
            }

            return response;
        }

        /// <summary>
        /// Validates the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse Validate(AddressDeleteCommand command)
        {
            SimpleResponse response = new SimpleResponse();

            if (command.Id == null || command.Id < 1)
            {
                response.ResponseCode = -100;
                response.ResponseMessage = "Invalid id value";
            }
            // Validation process will be added  in future.

            return response;
        }
    }
}