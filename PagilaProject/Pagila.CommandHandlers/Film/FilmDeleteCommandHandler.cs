using Pagila.Command.Base.Result;
using Pagila.Command.Film;
using Pagila.Entity;
using SimpleInfra.Common.Response;
using Simply.Crud;

namespace Pagila.CommandHandlers.Film
{
    /// <summary>
    /// The film delete command handler.
    /// </summary>
    public class FilmDeleteCommandHandler : PagilaBaseCommandHandler<FilmDeleteCommand, LongCommandResult>
    {
        /// <summary>
        /// Handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<LongCommandResult> Handle(FilmDeleteCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var database = GetDatabase())
            {
                var result = database.DeleteAll<FilmEntity>(p => p.FilmId == command.Id);
                response.ResponseCode = result;
                response.RCode = result.ToString();
                response.Data = new LongCommandResult { ReturnValue = command.Id };
            }

            return response;
        }

        /// <summary>
        /// Validates the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse Validate(FilmDeleteCommand command)
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