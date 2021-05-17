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
    public class CityReadByIdQueryHandler : PagilaBaseQueryHandler<CityReadByIdQuery, CityResult>
    {
        public override SimpleResponse<CityResult> Handle(CityReadByIdQuery query)
        {
            var response = new SimpleResponse<CityResult>();

            try
            {
                if (query.Id == null) return response;

                if ((query.Id ?? 0) < 1) return response;

                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var actorEntList = connection.Select<CityEntity>(p => p.CityId == query.Id)?.ToList() ?? new List<CityEntity>();
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

