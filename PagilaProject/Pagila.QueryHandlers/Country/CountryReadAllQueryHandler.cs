using Coddie.Crud;
using Coddie.Data;
using Pagila.Entity;
using Pagila.Query.Country;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Country
{
    public class CountryReadAllQueryHandler : PagilaBaseQueryHandler<CountryReadAllQuery, CountryList>
    {
        public override SimpleResponse<CountryList> Handle(CountryReadAllQuery query)
        {
            var response = new SimpleResponse<CountryList>();

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var actorEntList = connection.GetAll<CountryEntity>();
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
                finally
                {
                    connection.CloseIfNot();
                }
            }

            return response;
        }
    }
}