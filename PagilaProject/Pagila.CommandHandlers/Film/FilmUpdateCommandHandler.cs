using Coddie.Crud;
using Coddie.Data;
using Pagila.Command.Base.Result;
using Pagila.Command.Film;
using Pagila.Entity;
using SimpleInfra.Common.Response;

namespace Pagila.CommandHandlers.Film
{
    public class FilmUpdateCommandHandler : PagilaBaseCommandHandler<FilmUpdateCommand, LongCommandResult>
    {
        public override SimpleResponse<LongCommandResult> Handle(FilmUpdateCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var result = connection.PartialUpdate<FilmEntity>(new
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
                finally
                {
                    connection.CloseIfNot();
                }
            }

            return response;
        }

        public override SimpleResponse Validate(FilmUpdateCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}