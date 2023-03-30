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
    /// The language read all query handler.
    /// </summary>
    public class LanguageReadAllQueryHandler : PagilaBaseQueryHandler<LanguageReadAllQuery, LanguageList>
    {
        /// <summary>
        /// Handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<LanguageList> Handle(LanguageReadAllQuery query)
        {
            var response = new SimpleResponse<LanguageList>();

            using (var database = GetDatabase())
            {
                var LanguageEntList = database.GetAll<LanguageEntity>();
                response.Data = new LanguageList
                {
                    Languages = LanguageEntList.Select(p => Map<LanguageEntity, LanguageViewModel>(p)).ToList() ?? new List<LanguageViewModel>()
                };
                response.ResponseCode = response.Data?.Languages?.Count ?? 0;
                response.RCode = response.ResponseCode.ToString();
            }

            return response;
        }
    }
}