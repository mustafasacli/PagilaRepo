using Pagila.Command.Base.Result;
using Pagila.Command.City;
using Pagila.Entity;
using SimpleInfra.Common.Response;
using Simply.Crud;

namespace Pagila.CommandHandlers.City
{
    /// <summary>
    /// The city delete command handler.
    /// </summary>
    public class CityDeleteCommandHandler : PagilaBaseCommandHandler<CityDeleteCommand, LongCommandResult>
    {
        /// <summary>
        /// Handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<LongCommandResult> Handle(CityDeleteCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var database = GetDatabase())
            {
                response.ResponseCode = database.DeleteAll<CityEntity>(p => p.CityId == command.Id);
                response.RCode = response.ResponseCode.ToString();
                response.Data = new LongCommandResult { ReturnValue = command.Id };
            }

            return response;
        }

        /// <summary>
        /// Validates the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse Validate(CityDeleteCommand command)
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