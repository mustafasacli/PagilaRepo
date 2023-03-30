using Pagila.Command.Base.Result;
using Pagila.Command.City;
using Pagila.Entity;
using SimpleInfra.Common.Response;
using Simply.Common;
using Simply.Crud;

namespace Pagila.CommandHandlers.City
{
    /// <summary>
    /// The city insert command handler.
    /// </summary>
    public class CityInsertCommandHandler : PagilaBaseCommandHandler<CityInsertCommand, LongCommandResult>
    {
        /// <summary>
        /// Handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<LongCommandResult> Handle(CityInsertCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var database = GetDatabase())
            {
                var result = database.PartialInsertAndReturnId<CityEntity>(new { City = command.City, CountryId = command.CountryId });
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
        public override SimpleResponse Validate(CityInsertCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}