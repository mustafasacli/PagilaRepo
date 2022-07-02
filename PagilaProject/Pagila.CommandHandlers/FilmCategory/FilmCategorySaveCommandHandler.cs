using Pagila.Command.Base.Result;
using Pagila.Command.FilmCategory;
using SimpleInfra.Common.Response;

namespace Pagila.CommandHandlers.FilmCategory
{
    public class FilmCategorySaveCommandHandler : PagilaBaseCommandHandler<FilmCategorySaveCommand, LongCommandResult>
    {
        public override SimpleResponse<LongCommandResult> Handle(FilmCategorySaveCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var connection = GetDbConnection())
            {
                try
                {
                    //connection.OpenIfNot();
                    //var result = connection.PartialUpdate<FilmEntity>(new
                    //{
                    //}, p => p.FilmId == command.CustomerId);
                    //response.ResponseCode = result;
                    //response.RCode = result.ToString();
                    //response.Data = new LongCommandResult { ReturnValue = command.CustomerId };
                }
                finally
                {
                    //connection.CloseIfNot();
                }
            }

            return response;
        }

        public override SimpleResponse Validate(FilmCategorySaveCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            if (command.FilmId < 1)
            {
                response.ResponseCode = -100;
                response.ResponseMessage = "FilmId belirtilmelidir.";
            }
            // Validation process will be added  in future.
            return response;
        }
    }
}