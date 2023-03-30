using Pagila.Command.Base.Result;
using Pagila.Command.Inventory;
using Pagila.Entity;
using SimpleInfra.Common.Response;
using Simply.Common;
using Simply.Crud;

namespace Pagila.CommandHandlers.Inventory
{
    /// <summary>
    /// The ınventory insert command handler.
    /// </summary>
    public class InventoryInsertCommandHandler : PagilaBaseCommandHandler<InventoryInsertCommand, LongCommandResult>
    {
        /// <summary>
        /// Handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<LongCommandResult> Handle(InventoryInsertCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var database = GetDatabase())
            {
                var result = database.PartialInsertAndReturnId<InventoryEntity>(new { command.FilmId, command.StoreId });
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
        public override SimpleResponse Validate(InventoryInsertCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}