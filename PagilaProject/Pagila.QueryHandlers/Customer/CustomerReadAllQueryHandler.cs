using Pagila.Entity;
using Pagila.Query.Customer;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using Simply.Crud;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Customer
{
    /// <summary>
    /// The customer read all query handler.
    /// </summary>
    public class CustomerReadAllQueryHandler : PagilaBaseQueryHandler<CustomerReadAllQuery, CustomerList>
    {
        /// <summary>
        /// Handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<CustomerList> Handle(CustomerReadAllQuery query)
        {
            var response = new SimpleResponse<CustomerList>();

            using (var database = GetDatabase())
            {
                var customerEntList = database.GetAll<CustomerEntity>();
                response.Data = new CustomerList
                {
                    Customers = customerEntList.Select(p => new CustomerViewModel
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

            return response;
        }
    }
}