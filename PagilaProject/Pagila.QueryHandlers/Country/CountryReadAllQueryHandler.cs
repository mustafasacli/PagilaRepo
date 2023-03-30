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
    /// The country read all query handler.
    /// </summary>
    public class CountryReadAllQueryHandler : PagilaBaseQueryHandler<CountryReadAllQuery, CountryList>
    {
        /// <summary>
        /// Handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<CountryList> Handle(CountryReadAllQuery query)
        {
            var response = new SimpleResponse<CountryList>();

            using (var database = GetDatabase())
            {
                var actorEntList = database.GetAll<CountryEntity>();
                response.Data = new CountryList
                {
                    Countries = actorEntList.Select(p => new CountryViewModel
                    {
                        CountryId = p.CountryId,
                        Country = p.Country,
                        LastUpdate = p.LastUpdate
                    }).ToList() ?? new List<CountryViewModel>()
                };
                response.ResponseCode = response.Data?.Countries?.Count ?? 0;
                response.RCode = response.ResponseCode.ToString();
            }

            return response;
        }
    }
}