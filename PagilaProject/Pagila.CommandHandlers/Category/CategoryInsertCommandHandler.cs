using Pagila.Command.Base.Result;
using Pagila.Command.Category;
using Pagila.Entity;
using SimpleInfra.Common.Response;
using Simply.Common;
using Simply.Crud;

namespace Pagila.CommandHandlers.Category
{
    /// <summary>
    /// The category insert command handler.
    /// </summary>
    public class CategoryInsertCommandHandler : PagilaBaseCommandHandler<CategoryInsertCommand, LongCommandResult>
    {
        /// <summary>
        /// Handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<LongCommandResult> Handle(CategoryInsertCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var database = GetDatabase())
            {
                var result = database.PartialInsertAndReturnId<CategoryEntity>(new { command.Name });
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
        public override SimpleResponse Validate(CategoryInsertCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}