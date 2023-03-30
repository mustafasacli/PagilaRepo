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
    /// The rental read by id query handler.
    /// </summary>
    public class RentalReadByIdQueryHandler : PagilaBaseQueryHandler<RentalReadByIdQuery, RentalResult>
    {
        /// <summary>
        /// Handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<RentalResult> Handle(RentalReadByIdQuery query)
        {
            var response = new SimpleResponse<RentalResult>();

            if (query.Id == null) return response;

            if ((query.Id ?? 0) < 1) return response;

            using (var database = GetDatabase())
            {
                var RentalEntList = database.Select<RentalEntity>(p => p.RentalId == query.Id)?.ToList() ?? new List<RentalEntity>();
                response.Data = new RentalResult
                {
                    Rental = (RentalEntList.Select(p => Map<RentalEntity, RentalViewModel>(p)).ToList() ?? new List<RentalViewModel>()).FirstOrDefault()
                };
                response.ResponseCode = response.Data != null ? 1 : 0;
                response.RCode = response.ResponseCode.ToString();
            }

            return response;
        }
    }
}