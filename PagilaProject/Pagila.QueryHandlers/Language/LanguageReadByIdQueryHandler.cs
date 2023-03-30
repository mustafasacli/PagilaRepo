using Pagila.Entity;
using Pagila.Query.Language;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using Simply.Crud;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Language
{
    /// <summary>
    /// The language read by id query handler.
    /// </summary>
    public class LanguageReadByIdQueryHandler : PagilaBaseQueryHandler<LanguageReadByIdQuery, LanguageResult>
    {
        /// <summary>
        /// Handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<LanguageResult> Handle(LanguageReadByIdQuery query)
        {
            var response = new SimpleResponse<LanguageResult>();

            if (query.Id == null) return response;

            if ((query.Id ?? 0) < 1) return response;

            using (var database = GetDatabase())
            {
                var LanguageEntList = database.Select<LanguageEntity>(p => p.LanguageId == query.Id)?.ToList() ?? new List<LanguageEntity>();
                response.Data = new LanguageResult
                {
                    Language = (LanguageEntList.Select(p => Map<LanguageEntity, LanguageViewModel>(p)).ToList() ?? new List<LanguageViewModel>()).FirstOrDefault()
                };
                response.ResponseCode = response.Data != null ? 1 : 0;
                response.RCode = response.ResponseCode.ToString();
            }

            return response;
        }
    }
}