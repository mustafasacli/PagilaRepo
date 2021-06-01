using Coddie.Crud;
using Coddie.Data;
using Pagila.Entity;
using Pagila.Query.Country;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Country
{
    public class CountryReadByIdQueryHandler : PagilaBaseQueryHandler<CountryReadByIdQuery, CountryResult>
    {
        public override SimpleResponse<CountryResult> Handle(CountryReadByIdQuery query)
        {
            var response = new SimpleResponse<CountryResult>();

            try
            {
                if (query.Id == null) return response;

                if ((query.Id ?? 0) < 1) return response;

                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var actorEntList = connection.Select<CountryEntity>(p => p.CountryId == query.Id)?.ToList() ?? new List<CountryEntity>();
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