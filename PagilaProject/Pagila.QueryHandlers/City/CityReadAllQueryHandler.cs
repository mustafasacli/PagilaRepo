using Coddie.Crud;
using Coddie.Data;
using Pagila.Entity;
using Pagila.Query.City;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.City
{
    public class CityReadAllQueryHandler : PagilaBaseQueryHandler<CityReadAllQuery, CityList>
    {
        public override SimpleResponse<CityList> Handle(CityReadAllQuery query)
        {
            var response = new SimpleResponse<CityList>();

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var actorEntList = connection.GetAll<CityEntity>();
                    response.Data = new CityList
                    {
                        Cities = actorEntList.Select(p => new CityViewModel
                        {
                            CityId = p.CityId,
                            City = p.City,
                            CountryId = p.CountryId,
                            LastUpdate = p.LastUpdate
                        }).ToList() ?? new List<CityViewModel>()
                    };
                    response.ResponseCode = response.Data?.Cities?.Count ?? 0;
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