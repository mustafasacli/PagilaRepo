using Coddie.Crud;
using Coddie.Data;
using Pagila.Entity;
using Pagila.Query.Payment;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Payment
{
    public class PaymentReadAllQueryHandler : PagilaBaseQueryHandler<PaymentReadAllQuery, PaymentList>
    {
        public override SimpleResponse<PaymentList> Handle(PaymentReadAllQuery query)
        {
            var response = new SimpleResponse<PaymentList>();

            try
            {
                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var PaymentEntList = connection.GetAll<PaymentEntity>();
                        // var result = connection.QueryList<Syp.Entity.ServiceDetailType>("select * from service_detail_type where is_deleted = false and lower(detail_type_name) like '%' || :name || '%'", new { name = query.Name.ToLowerInvariant() });
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
            }
            catch (Exception ex)
            {
                response.ResponseCode = -500;
                DayLogger.Error(ex);
            }

            return response;
        }
    }
}