using Pagila.Command.Actor;
using Pagila.Command.Base.Result;
using Pagila.Entity;
using SimpleInfra.Common.Response;
using Simply.Crud;

namespace Pagila.CommandHandlers.Actor
{
    /// <summary>
    /// The actor update command handler.
    /// </summary>
    public class ActorUpdateCommandHandler : PagilaBaseCommandHandler<ActorUpdateCommand, LongCommandResult>
    {
        /// <summary>
        /// Handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<LongCommandResult> Handle(ActorUpdateCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var database = GetDatabase())
            {
                var result = database.PartialUpdate<ActorEntity>(new
                {
                    command.FirstName,
                    command.LastName,
                    command.LastUpdate
                }, p => p.ActorId == command.ActorId);
                response.ResponseCode = result;
                response.RCode = result.ToString();
                response.Data = new LongCommandResult { ReturnValue = command.ActorId };
            }

            return response;
        }

        /// <summary>
        /// Validates the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse Validate(ActorUpdateCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}