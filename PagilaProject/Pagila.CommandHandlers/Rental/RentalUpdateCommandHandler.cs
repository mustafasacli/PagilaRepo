using Pagila.Command.Base.Result;
using Pagila.Command.Rental;
using Pagila.Entity;
using SimpleInfra.Common.Response;
using Simply.Crud;

namespace Pagila.CommandHandlers.Rental
{
    /// <summary>
    /// The rental update command handler.
    /// </summary>
    public class RentalUpdateCommandHandler : PagilaBaseCommandHandler<RentalUpdateCommand, LongCommandResult>
    {
        /// <summary>
        /// Handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<LongCommandResult> Handle(RentalUpdateCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var database = GetDatabase())
            {
                var result = database.PartialUpdate<RentalEntity>(new
                {
                    command.RentalDate,
                    command.InventoryId,
                    command.CustomerId,
                    command.ReturnDate,
                    command.StaffId
                }, p => p.RentalId == command.RentalId);
                response.ResponseCode = result;
                response.RCode = result.ToString();
                response.Data = new LongCommandResult { ReturnValue = command.RentalId };
            }

            return response;
        }

        /// <summary>
        /// Validates the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse Validate(RentalUpdateCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}