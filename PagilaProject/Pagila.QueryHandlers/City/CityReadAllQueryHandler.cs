using Pagila.Entity;
using Pagila.Query.City;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using Simply.Common;
using Simply.Crud;
using Simply.Crud.Enums;
using Simply.Crud.Interfaces;
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
                IWhere<CityEntity> city =
                database.Where<CityEntity>()
                    .AddAndCondition(q => q.CityId > 0)
                    .AddPropertyForSelect(q => q.CityId)
                    .AddPropertyForSelect(q => q.City)
                    .AddPropertyForSelect(q => q.CountryId)
                    .AddPropertyForSelect(q => q.LastUpdate)
                    .AddOrderClause(q => q.LastUpdate, isDescending: true)
                    .AddJoin(
                    database.BuildJoin<CityEntity, CountryEntity>(JoinTypes.LeftJoin)
                    .AddJoin(p => p.CountryId, q => q.CountryId),
                    database.Where<CountryEntity>()
                    .AddAndCondition(q => q.CountryId > 0)
                    .AddPropertyForSelect(q => q.Country, "CountryName")
                    );

                var liste = database.PartialSelect(city).ToList();
                response.Data = new CityList
                {
                    Cities = liste.Select(p => new CityViewModel
                    {
                        CityId = p.CityId,
                        City = p.City,
                        CountryId = p.CountryId,
                        LastUpdate = p.LastUpdate,
                        CountryName = p.CountryName
                    }).ToList() ?? new List<CityViewModel>()
                };
                //var entityList = database.GetAll<CityEntity>();
                //var countryIdList = entityList.Select(q => q.CountryId).Distinct().ToArray();
                //var where = database.Where<CountryEntity>().AddAndListContainsCondition(q => q.CountryId, countryIdList);
                //var countryList = database.Select(where);
                //response.Data = new CityList
                //{
                //    Cities = entityList.Select(p => new CityViewModel
                //    {
                //        CityId = p.CityId,
                //        City = p.City,
                //        CountryId = p.CountryId,
                //        LastUpdate = p.LastUpdate,
                //        CountryName = countryList.FirstOrDefault(q => q.CountryId == p.CountryId)?.Country
                //    }).OrderByDescending(p => p.LastUpdate)
                //    .ToList() ?? new List<CityViewModel>()
                //};
                response.ResponseCode = response.Data?.Cities?.Count ?? 0;
                response.RCode = response.ResponseCode.ToString();
            }

            return response;
        }
    }
}