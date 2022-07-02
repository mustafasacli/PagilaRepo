using Coddie.Crud;
using Coddie.Data;
using Pagila.Command.Base.Result;
using Pagila.Command.City;
using Pagila.Entity;
using SimpleInfra.Common.Response;

namespace Pagila.CommandHandlers.City
{
    public class CityDeleteCommandHandler : PagilaBaseCommandHandler<CityDeleteCommand, LongCommandResult>
    {
        public override SimpleResponse<LongCommandResult> Handle(CityDeleteCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var result = connection.DeleteAll<CityEntity>(p => p.CityId == command.Id);
                    response.ResponseCode = result;
                    response.RCode = result.ToString();
                    response.Data = new LongCommandResult { ReturnValue = command.Id };
                }
                finally
                {
                    connection.CloseIfNot();
                }
            }

            return response;
        }

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