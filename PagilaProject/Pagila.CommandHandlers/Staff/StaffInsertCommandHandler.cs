using Pagila.Command.Base.Result;
using Pagila.Command.Staff;
using Pagila.Entity;
using SimpleInfra.Common.Response;
using Simply.Common;
using Simply.Crud;

namespace Pagila.CommandHandlers.Staff
{
    /// <summary>
    /// The staff insert command handler.
    /// </summary>
    public class StaffInsertCommandHandler : PagilaBaseCommandHandler<StaffInsertCommand, LongCommandResult>
    {
        /// <summary>
        /// Handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<LongCommandResult> Handle(StaffInsertCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var database = GetDatabase())
            {
                var result = database.PartialInsertAndReturnId<StaffEntity>(new
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

            return response;
        }

        /// <summary>
        /// Validates the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse Validate(StaffInsertCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}