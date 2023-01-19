using Coddie.Crud;
using Coddie.Data;
using Pagila.Entity;
using Pagila.Query.Language;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Language
{
    public class LanguageReadAllQueryHandler : PagilaBaseQueryHandler<LanguageReadAllQuery, LanguageList>
    {
        public override SimpleResponse<LanguageList> Handle(LanguageReadAllQuery query)
        {
            var response = new SimpleResponse<LanguageList>();

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var LanguageEntList = connection.GetAll<LanguageEntity>();
                    response.Data = new LanguageList
                    {
                        Languages = LanguageEntList.Select(p => Map<LanguageEntity, LanguageViewModel>(p)).ToList() ?? new List<LanguageViewModel>()
                    };
                    response.ResponseCode = response.Data?.Languages?.Count ?? 0;
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