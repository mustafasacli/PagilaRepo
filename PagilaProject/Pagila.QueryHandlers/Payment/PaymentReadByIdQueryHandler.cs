using Pagila.Entity;
using Pagila.Query.Payment;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using Simply.Crud;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Payment
{
    /// <summary>
    /// The payment read by id query handler.
    /// </summary>
    public class PaymentReadByIdQueryHandler : PagilaBaseQueryHandler<PaymentReadByIdQuery, PaymentResult>
    {
        /// <summary>
        /// Handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<PaymentResult> Handle(PaymentReadByIdQuery query)
        {
            var response = new SimpleResponse<PaymentResult>();

            if (query.Id == null) return response;

            if ((query.Id ?? 0) < 1) return response;

            using (var database = GetDatabase())
            {
                var PaymentEntList = database.Select<PaymentEntity>(p => p.PaymentId == query.Id)?.ToList() ?? new List<PaymentEntity>();
                response.Data = new PaymentResult
                {
                    Payment = (PaymentEntList.Select(p => Map<PaymentEntity, PaymentViewModel>(p)).ToList() ?? new List<PaymentViewModel>()).FirstOrDefault()
                };
                response.ResponseCode = response.Data != null ? 1 : 0;
                response.RCode = response.ResponseCode.ToString();
            }

            return response;
        }
    }
}