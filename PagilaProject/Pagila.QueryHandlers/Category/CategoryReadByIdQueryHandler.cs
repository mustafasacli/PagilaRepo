using Pagila.Entity;
using Pagila.Query.Category;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using Simply.Crud;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Category
{
    /// <summary>
    /// The category read by id query handler.
    /// </summary>
    public class CategoryReadByIdQueryHandler : PagilaBaseQueryHandler<CategoryReadByIdQuery, CategoryResult>
    {
        /// <summary>
        /// Handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<CategoryResult> Handle(CategoryReadByIdQuery query)
        {
            var response = new SimpleResponse<CategoryResult>();

            if (query.Id == null) return response;

            if ((query.Id ?? 0) < 1) return response;

            using (var database = GetDatabase())
            {
                var actorEntList = database.Select<CategoryEntity>(p => p.CategoryId == query.Id)?.ToList() ?? new List<CategoryEntity>();
                response.Data = new CategoryResult
                {
                    Category = (actorEntList.Select(p => new CategoryViewModel
                    {
                        CategoryId = p.CategoryId,
                        Name = p.Name,
                        LastUpdate = p.LastUpdate
                    }).ToList() ?? new List<CategoryViewModel>()).FirstOrDefault()
                };
                response.ResponseCode = response.Data != null ? 1 : 0;
                response.RCode = response.ResponseCode.ToString();
            }

            return response;
        }
    }
}