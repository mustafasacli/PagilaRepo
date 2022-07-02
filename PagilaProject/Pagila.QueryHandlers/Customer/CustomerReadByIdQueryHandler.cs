using Coddie.Crud;
using Coddie.Data;
using Pagila.Entity;
using Pagila.Query.Customer;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Customer
{
    public class CustomerReadByIdQueryHandler : PagilaBaseQueryHandler<CustomerReadByIdQuery, CustomerResult>
    {
        public override SimpleResponse<CustomerResult> Handle(CustomerReadByIdQuery query)
        {
            var response = new SimpleResponse<CustomerResult>();

            if (query.Id == null) return response;

            if ((query.Id ?? 0) < 1) return response;

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var CustomerEntList = connection.Select<CustomerEntity>(p => p.CustomerId == query.Id)?.ToList() ?? new List<CustomerEntity>();
                    response.Data = new CustomerResult
                    {
                        Customer = (CustomerEntList.Select(p => new CustomerViewModel
                        {
                            CustomerId = p.CustomerId,
                            FirstName = p.FirstName,
                            LastName = p.LastName,
                            LastUpdate = p.LastUpdate
                        }).ToList() ?? new List<CustomerViewModel>()).FirstOrDefault()
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