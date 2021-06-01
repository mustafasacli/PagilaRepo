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
    public class LanguageReadByIdQueryHandler : PagilaBaseQueryHandler<LanguageReadByIdQuery, LanguageResult>
    {
        public override SimpleResponse<LanguageResult> Handle(LanguageReadByIdQuery query)
        {
            var response = new SimpleResponse<LanguageResult>();

            try
            {
                if (query.Id == null) return response;

                if ((query.Id ?? 0) < 1) return response;

                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var LanguageEntList = connection.Select<LanguageEntity>(p => p.LanguageId == query.Id)?.ToList() ?? new List<LanguageEntity>();
                        response.Data = new LanguageResult
                        {
                            Language = (LanguageEntList.Select(p => Map<LanguageEntity, LanguageViewModel>(p)).ToList() ?? new List<LanguageViewModel>()).FirstOrDefault()
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