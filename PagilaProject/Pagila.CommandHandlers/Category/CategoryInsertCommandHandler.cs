using Coddie.Common;
using Coddie.Crud;
using Coddie.Data;
using Pagila.Command.Base.Result;
using Pagila.Command.Category;
using Pagila.Entity;
using SimpleInfra.Common.Response;

namespace Pagila.CommandHandlers.Category
{
    public class CategoryInsertCommandHandler : PagilaBaseCommandHandler<CategoryInsertCommand, LongCommandResult>
    {
        public override SimpleResponse<LongCommandResult> Handle(CategoryInsertCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var result = connection.PartialInsertAndReturnId<CategoryEntity>(new { command.Name });
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

        public override SimpleResponse Validate(CategoryInsertCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}