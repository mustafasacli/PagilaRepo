using Pagila.Command.Base.Result;
using Pagila.Command.City;
using Pagila.Entity;
using SimpleInfra.Common.Response;
using Simply.Crud;
using System;

namespace Pagila.CommandHandlers.City
{
    /// <summary>
    /// The city update command handler.
    /// </summary>
    public class CityUpdateCommandHandler : PagilaBaseCommandHandler<CityUpdateCommand, LongCommandResult>
    {
        /// <summary>
        /// Handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<LongCommandResult> Handle(CityUpdateCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var database = GetDatabase())
            {
                var result = database.PartialUpdate<CityEntity>(new
                {
                    command.City,
                    command.CountryId,
                    LastUpdate = DateTime.UtcNow
                }, p => p.CityId == command.CityId);
                response.ResponseCode = result;
                response.RCode = result.ToString();
                response.Data = new LongCommandResult { ReturnValue = command.CityId };
            }

            return response;
        }

        /// <summary>
        /// Validates the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse Validate(CityUpdateCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}