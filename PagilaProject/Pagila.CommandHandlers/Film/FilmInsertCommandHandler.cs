using Coddie.Common;
using Coddie.Crud;
using Coddie.Data;
using Pagila.Command.Base.Result;
using Pagila.Command.Film;
using Pagila.Entity;
using SimpleInfra.Common.Response;

namespace Pagila.CommandHandlers.Film
{
    public class FilmInsertCommandHandler : PagilaBaseCommandHandler<FilmInsertCommand, LongCommandResult>
    {
        public override SimpleResponse<LongCommandResult> Handle(FilmInsertCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var result = connection.PartialInsertAndReturnId<FilmEntity>(new
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
                finally
                {
                    connection.CloseIfNot();
                }
            }

            return response;
        }

        public override SimpleResponse Validate(FilmInsertCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}