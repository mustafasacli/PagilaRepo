using Coddie.Crud;
using Coddie.Data;
using Pagila.Entity;
using Pagila.Query.Rental;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Rental
{
    public class RentalReadAllQueryHandler : PagilaBaseQueryHandler<RentalReadAllQuery, RentalList>
    {
        public override SimpleResponse<RentalList> Handle(RentalReadAllQuery query)
        {
            var response = new SimpleResponse<RentalList>();

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var RentalEntList = connection.GetAll<RentalEntity>();
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

            return response;
        }
    }
}