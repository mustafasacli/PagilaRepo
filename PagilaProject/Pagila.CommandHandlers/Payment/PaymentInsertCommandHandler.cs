using Coddie.Common;
using Coddie.Crud;
using Coddie.Data;
using Pagila.Command.Base.Result;
using Pagila.Command.Payment;
using Pagila.Entity;
using SimpleInfra.Common.Response;

namespace Pagila.CommandHandlers.Payment
{
    public class PaymentInsertCommandHandler : PagilaBaseCommandHandler<PaymentInsertCommand, LongCommandResult>
    {
        public override SimpleResponse<LongCommandResult> Handle(PaymentInsertCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var result = connection.PartialInsertAndReturnId<PaymentEntity>(new
                    {
                        command.CustomerId,
                        command.StaffId,
                        command.RentalId,
                        command.Amount,
                        command.PaymentDate,
                        command.LastUpdate
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

        public override SimpleResponse Validate(PaymentInsertCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}