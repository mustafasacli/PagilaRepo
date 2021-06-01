using Coddie.Crud;
using Coddie.Data;
using Pagila.Entity;
using Pagila.Query.Language;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Language
{
    public class LanguageReadAllQueryHandler : PagilaBaseQueryHandler<LanguageReadAllQuery, LanguageList>
    {
        public override SimpleResponse<LanguageList> Handle(LanguageReadAllQuery query)
        {
            var response = new SimpleResponse<LanguageList>();

            try
            {
                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var LanguageEntList = connection.GetAll<LanguageEntity>();
                        // var result = connection.QueryList<Syp.Entity.ServiceDetailType>("select * from service_detail_type where is_deleted = false and lower(detail_type_name) like '%' || :name || '%'", new { name = query.Name.ToLowerInvariant() });
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