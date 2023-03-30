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
    /// The city read by id query handler.
    /// </summary>
    public class CityReadByIdQueryHandler : PagilaBaseQueryHandler<CityReadByIdQuery, CityResult>
    {
        /// <summary>
        /// Handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<CityResult> Handle(CityReadByIdQuery query)
        {
            var response = new SimpleResponse<CityResult>();

            if (query.Id == null) return response;

            if ((query.Id ?? 0) < 1) return response;

            using (var database = GetDatabase())
            {
                var actorEntList = database.Select<CityEntity>(p => p.CityId == query.Id)?.ToList() ?? new List<CityEntity>();
                response.Data = new CityResult
                {
                    City = (actorEntList.Select(p => new CityViewModel
                    {
                        CityId = p.CityId,
                        City = p.City,
                        CountryId = p.CountryId,
                        LastUpdate = p.LastUpdate
                    }).ToList() ?? new List<CityViewModel>()).FirstOrDefault()
                };
                response.ResponseCode = response.Data != null ? 1 : 0;
                response.RCode = response.ResponseCode.ToString();
            }

            return response;
        }
    }
}