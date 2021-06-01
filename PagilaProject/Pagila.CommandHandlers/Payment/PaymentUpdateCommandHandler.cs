using Coddie.Crud;
using Coddie.Data;
using Pagila.Command.Base.Result;
using Pagila.Command.Payment;
using Pagila.Entity;
using SimpleInfra.Common.Response;
using System;

namespace Pagila.CommandHandlers.Payment
{
    public class PaymentUpdateCommandHandler : PagilaBaseCommandHandler<PaymentUpdateCommand, LongCommandResult>
    {
        public override SimpleResponse<LongCommandResult> Handle(PaymentUpdateCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            try
            {
                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var result = connection.PartialUpdate<PaymentEntity>(new
                        {
                            command.CustomerId,
                            command.StaffId,
                            command.RentalId,
                            command.Amount,
                            command.PaymentDate,
                            command.LastUpdate
                        }, p => p.PaymentId == command.PaymentId);
                        response.ResponseCode = result;
                        response.RCode = result.ToString();
                        response.Data = new LongCommandResult { ReturnValue = command.PaymentId };
                    }
                    finally
                    {
                        connection.CloseIfNot();
                    }
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = -500;
                DayLogger.Error(ex);
            }

            return response;
        }

        public override SimpleResponse Validate(PaymentUpdateCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}