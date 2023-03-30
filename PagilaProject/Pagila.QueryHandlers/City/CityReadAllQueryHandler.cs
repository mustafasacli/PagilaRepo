using Pagila.Entity;
using Pagila.Query.City;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using Simply.Crud;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.City
{
    /// <summary>
    /// The city read all query handler.
    /// </summary>
    public class CityReadAllQueryHandler : PagilaBaseQueryHandler<CityReadAllQuery, CityList>
    {
        /// <summary>
        /// Handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<CityList> Handle(CityReadAllQuery query)
        {
            var response = new SimpleResponse<CityList>();

            using (var database = GetDatabase())
            {
                var actorEntList = database.GetAll<CityEntity>();
                response.Data = new CityList
                {
                    Cities = actorEntList.Select(p => new CityViewModel
                    {
                        CityId = p.CityId,
                        City = p.City,
                        CountryId = p.CountryId,
                        LastUpdate = p.LastUpdate
                    }).OrderByDescending(p => p.LastUpdate)
                    .ToList() ?? new List<CityViewModel>()
                };
                response.ResponseCode = response.Data?.Cities?.Count ?? 0;
                response.RCode = response.ResponseCode.ToString();
            }

            return response;
        }
    }
}