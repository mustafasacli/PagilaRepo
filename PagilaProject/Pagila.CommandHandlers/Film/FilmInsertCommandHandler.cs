using Pagila.Command.Base.Result;
using Pagila.Command.Film;
using Pagila.Entity;
using SimpleInfra.Common.Response;
using Simply.Common;
using Simply.Crud;

namespace Pagila.CommandHandlers.Film
{
    /// <summary>
    /// The film insert command handler.
    /// </summary>
    public class FilmInsertCommandHandler : PagilaBaseCommandHandler<FilmInsertCommand, LongCommandResult>
    {
        /// <summary>
        /// Handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<LongCommandResult> Handle(FilmInsertCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var database = GetDatabase())
            {
                var result = database.PartialInsertAndReturnId<FilmEntity>(new
                {
                    command.Title,
                    command.Description,
                    command.ReleaseYear,
                    command.LanguageId,
                    command.OriginalLanguageId,
                    command.RentalDuration,
                    command.RentalRate,
                    command.Length,
                    command.ReplacementCost,
                    command.Rating,
                    command.SpecialFeatures,
                    command.Fulltext
                });
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
        public override SimpleResponse Validate(FilmInsertCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}