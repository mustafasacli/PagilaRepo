using Coddie.Common;
using Coddie.Crud;
using Coddie.Data;
using Pagila.Command.Base.Result;
using Pagila.Command.Inventory;
using Pagila.Entity;
using SimpleInfra.Common.Response;

namespace Pagila.CommandHandlers.Inventory
{
    public class InventoryInsertCommandHandler : PagilaBaseCommandHandler<InventoryInsertCommand, LongCommandResult>
    {
        public override SimpleResponse<LongCommandResult> Handle(InventoryInsertCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var result = connection.PartialInsertAndReturnId<InventoryEntity>(new { command.FilmId, command.StoreId });
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

        public override SimpleResponse Validate(InventoryInsertCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}