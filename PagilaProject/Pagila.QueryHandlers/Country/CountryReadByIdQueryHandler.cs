using Pagila.Entity;
using Pagila.Query.Country;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using Simply.Crud;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Country
{
    /// <summary>
    /// The country read by id query handler.
    /// </summary>
    public class CountryReadByIdQueryHandler : PagilaBaseQueryHandler<CountryReadByIdQuery, CountryResult>
    {
        /// <summary>
        /// Handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<CountryResult> Handle(CountryReadByIdQuery query)
        {
            var response = new SimpleResponse<CountryResult>();

            if (query.Id == null) return response;

            if ((query.Id ?? 0) < 1) return response;

            using (var database = GetDatabase())
            {
                var actorEntList = database.Select<CountryEntity>(p => p.CountryId == query.Id)?.ToList() ?? new List<CountryEntity>();
                response.Data = new CountryResult
                {
                    Country = (actorEntList.Select(p => new CountryViewModel
                    {
                        CountryId = p.CountryId,
                        Country = p.Country,
                        LastUpdate = p.LastUpdate
                    }).ToList() ?? new List<CountryViewModel>()).FirstOrDefault()
                };
                response.ResponseCode = response.Data != null ? 1 : 0;
                response.RCode = response.ResponseCode.ToString();
            }

            return response;
        }
    }
}