using Pagila.Command.Base.Result;
using Pagila.Command.Film;
using Pagila.Entity;
using SimpleInfra.Common.Response;
using Simply.Crud;

namespace Pagila.CommandHandlers.Film
{
    /// <summary>
    /// The film update command handler.
    /// </summary>
    public class FilmUpdateCommandHandler : PagilaBaseCommandHandler<FilmUpdateCommand, LongCommandResult>
    {
        /// <summary>
        /// Handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<LongCommandResult> Handle(FilmUpdateCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var database = GetDatabase())
            {
                var result = database.PartialUpdate<FilmEntity>(new
                {
                    command.Title,
                    command.Description,
                    command.ReleaseYear,
                    command.LanguageId,
                    command.RentalDuration,
                    command.RentalRate,
                    command.Length,
                    command.ReplacementCost,
                    command.Rating,
                    command.SpecialFeatures,
                    command.Fulltext
                }, p => p.FilmId == command.FilmId);
                response.ResponseCode = result;
                response.RCode = result.ToString();
                response.Data = new LongCommandResult { ReturnValue = command.FilmId };
            }

            return response;
        }

        /// <summary>
        /// Validates the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse Validate(FilmUpdateCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}