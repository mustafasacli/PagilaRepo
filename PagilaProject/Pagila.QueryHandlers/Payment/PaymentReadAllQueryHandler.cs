using Coddie.Crud;
using Coddie.Data;
using Pagila.Entity;
using Pagila.Query.Payment;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Payment
{
    public class PaymentReadAllQueryHandler : PagilaBaseQueryHandler<PaymentReadAllQuery, PaymentList>
    {
        public override SimpleResponse<PaymentList> Handle(PaymentReadAllQuery query)
        {
            var response = new SimpleResponse<PaymentList>();

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var PaymentEntList = connection.GetAll<PaymentEntity>();
                    response.Data = new PaymentList
                    {
                        Payments = PaymentEntList.Select(p => Map<PaymentEntity, PaymentViewModel>(p)).ToList() ?? new List<PaymentViewModel>()
                    };
                    response.ResponseCode = response.Data?.Payments?.Count ?? 0;
                    response.RCode = response.ResponseCode.ToString();
                }
                finally
                {
                    connection.CloseIfNot();
                }
            }

            return response;
        }
    }
}