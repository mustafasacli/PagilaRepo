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
    public class CustomerReadAllQueryHandler : PagilaBaseQueryHandler<CustomerReadAllQuery, CustomerList>
    {
        public override SimpleResponse<CustomerList> Handle(CustomerReadAllQuery query)
        {
            var response = new SimpleResponse<CustomerList>();

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var CustomerEntList = connection.GetAll<CustomerEntity>();
                    response.Data = new CustomerList
                    {
                        Customers = CustomerEntList.Select(p => new CustomerViewModel
                        {
                            CustomerId = p.CustomerId,
                            FirstName = p.FirstName,
                            LastName = p.LastName,
                            LastUpdate = p.LastUpdate
                        }).ToList() ?? new List<CustomerViewModel>()
                    };
                    response.ResponseCode = response.Data?.Customers?.Count ?? 0;
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