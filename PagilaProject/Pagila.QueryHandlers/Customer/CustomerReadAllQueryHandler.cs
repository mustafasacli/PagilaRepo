using Coddie.Crud;
using Coddie.Data;
using Pagila.Entity;
using Pagila.Query.Customer;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Customer
{
    public class CustomerReadAllQueryHandler : PagilaBaseQueryHandler<CustomerReadAllQuery, CustomerList>
    {
        public override SimpleResponse<CustomerList> Handle(CustomerReadAllQuery query)
        {
            var response = new SimpleResponse<CustomerList>();

            try
            {
                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var CustomerEntList = connection.GetAll<CustomerEntity>();
                        // var result = connection.QueryList<Syp.Entity.ServiceDetailType>("select * from service_detail_type where is_deleted = false and lower(detail_type_name) like '%' || :name || '%'", new { name = query.Name.ToLowerInvariant() });
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