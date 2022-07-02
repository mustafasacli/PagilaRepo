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
    public class PaymentReadByIdQueryHandler : PagilaBaseQueryHandler<PaymentReadByIdQuery, PaymentResult>
    {
        public override SimpleResponse<PaymentResult> Handle(PaymentReadByIdQuery query)
        {
            var response = new SimpleResponse<PaymentResult>();

            if (query.Id == null) return response;

            if ((query.Id ?? 0) < 1) return response;

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var PaymentEntList = connection.Select<PaymentEntity>(p => p.PaymentId == query.Id)?.ToList() ?? new List<PaymentEntity>();
                    response.Data = new PaymentResult
                    {
                        Payment = (PaymentEntList.Select(p => Map<PaymentEntity, PaymentViewModel>(p)).ToList() ?? new List<PaymentViewModel>()).FirstOrDefault()
                    };
                    response.ResponseCode = response.Data != null ? 1 : 0;
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