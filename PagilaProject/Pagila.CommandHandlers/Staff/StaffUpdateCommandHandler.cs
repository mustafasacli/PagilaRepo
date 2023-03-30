using Pagila.Command.Base.Result;
using Pagila.Command.Staff;
using Pagila.Entity;
using SimpleInfra.Common.Response;
using Simply.Crud;

namespace Pagila.CommandHandlers.Staff
{
    /// <summary>
    /// The staff update command handler.
    /// </summary>
    public class StaffUpdateCommandHandler : PagilaBaseCommandHandler<StaffUpdateCommand, LongCommandResult>
    {
        /// <summary>
        /// Handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<LongCommandResult> Handle(StaffUpdateCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var database = GetDatabase())
            {
                var result = database.PartialUpdate<StaffEntity>(new
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

            return response;
        }

        /// <summary>
        /// Validates the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse Validate(StaffUpdateCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}