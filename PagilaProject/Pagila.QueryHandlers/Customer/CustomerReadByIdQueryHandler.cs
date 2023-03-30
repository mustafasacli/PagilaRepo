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
    /// The customer read by id query handler.
    /// </summary>
    public class CustomerReadByIdQueryHandler : PagilaBaseQueryHandler<CustomerReadByIdQuery, CustomerResult>
    {
        /// <summary>
        /// Handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<CustomerResult> Handle(CustomerReadByIdQuery query)
        {
            var response = new SimpleResponse<CustomerResult>();

            if (query.Id == null) return response;

            if ((query.Id ?? 0) < 1) return response;

            using (var database = GetDatabase())
            {
                var customerEntList = database.Select<CustomerEntity>(p => p.CustomerId == query.Id)?.ToList() ?? new List<CustomerEntity>();
                response.Data = new CustomerResult
                {
                    Customer = (customerEntList.Select(p => new CustomerViewModel
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

            return response;
        }
    }
}