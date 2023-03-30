using Pagila.Entity;
using Pagila.Query.Rental;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using Simply.Crud;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Rental
{
    /// <summary>
    /// The rental read all query handler.
    /// </summary>
    public class RentalReadAllQueryHandler : PagilaBaseQueryHandler<RentalReadAllQuery, RentalList>
    {
        /// <summary>
        /// Handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<RentalList> Handle(RentalReadAllQuery query)
        {
            var response = new SimpleResponse<RentalList>();

            using (var database = GetDatabase())
            {
                var RentalEntList = database.GetAll<RentalEntity>();
                response.Data = new RentalList
                {
                    Rentals = RentalEntList.Select(p => Map<RentalEntity, RentalViewModel>(p)).ToList() ?? new List<RentalViewModel>()
                };
                response.ResponseCode = response.Data?.Rentals?.Count ?? 0;
                response.RCode = response.ResponseCode.ToString();
            }

            return response;
        }
    }
}