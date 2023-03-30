using Pagila.Command.Base.Result;
using Pagila.Command.Payment;
using Pagila.Entity;
using SimpleInfra.Common.Response;
using Simply.Crud;

namespace Pagila.CommandHandlers.Payment
{
    /// <summary>
    /// The payment update command handler.
    /// </summary>
    public class PaymentUpdateCommandHandler : PagilaBaseCommandHandler<PaymentUpdateCommand, LongCommandResult>
    {
        /// <summary>
        /// Handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<LongCommandResult> Handle(PaymentUpdateCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var database = GetDatabase())
            {
                var result = database.PartialUpdate<PaymentEntity>(new
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

            return response;
        }

        /// <summary>
        /// Validates the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse Validate(PaymentUpdateCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            // Validation process will be added  in future.
            return response;
        }
    }
}