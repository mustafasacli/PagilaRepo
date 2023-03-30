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
    /// The payment read all query handler.
    /// </summary>
    public class PaymentReadAllQueryHandler : PagilaBaseQueryHandler<PaymentReadAllQuery, PaymentList>
    {
        /// <summary>
        /// Handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<PaymentList> Handle(PaymentReadAllQuery query)
        {
            var response = new SimpleResponse<PaymentList>();

            using (var database = GetDatabase())
            {
                var PaymentEntList = database.GetAll<PaymentEntity>();
                response.Data = new PaymentList
                {
                    Payments = PaymentEntList.Select(p => Map<PaymentEntity, PaymentViewModel>(p)).ToList() ?? new List<PaymentViewModel>()
                };
                response.ResponseCode = response.Data?.Payments?.Count ?? 0;
                response.RCode = response.ResponseCode.ToString();
            }

            return response;
        }
    }
}