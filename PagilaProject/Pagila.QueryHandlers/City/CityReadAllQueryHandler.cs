using Coddie.Crud;
using Coddie.Data;
using Pagila.Entity;
using Pagila.Query.City;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.City
{
    public class CityReadAllQueryHandler : PagilaBaseQueryHandler<CityReadAllQuery, CityList>
    {
        public override SimpleResponse<CityList> Handle(CityReadAllQuery query)
        {
            var response = new SimpleResponse<CityList>();

            try
            {
                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var actorEntList = connection.GetAll<CityEntity>();
                        // var result = connection.QueryList<Syp.Entity.ServiceDetailType>("select * from service_detail_type where is_deleted = false and lower(detail_type_name) like '%' || :name || '%'", new { name = query.Name.ToLowerInvariant() });
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
