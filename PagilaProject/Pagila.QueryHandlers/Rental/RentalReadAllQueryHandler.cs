using Coddie.Crud;
using Coddie.Data;
using Pagila.Entity;
using Pagila.Query.Rental;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Rental
{
    public class RentalReadAllQueryHandler : PagilaBaseQueryHandler<RentalReadAllQuery, RentalList>
    {
        public override SimpleResponse<RentalList> Handle(RentalReadAllQuery query)
        {
            var response = new SimpleResponse<RentalList>();

            try
            {
                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var RentalEntList = connection.GetAll<RentalEntity>();
                        // var result = connection.QueryList<Syp.Entity.ServiceDetailType>("select * from service_detail_type where is_deleted = false and lower(detail_type_name) like '%' || :name || '%'", new { name = query.Name.ToLowerInvariant() });
                        response.Data = new RentalList
                        {
                            Rentals = RentalEntList.Select(p => Map<RentalEntity, RentalViewModel>(p)).ToList() ?? new List<RentalViewModel>()
                        };
                        response.ResponseCode = response.Data?.Rentals?.Count ?? 0;
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