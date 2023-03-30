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
    /// The category read all query handler.
    /// </summary>
    public class CategoryReadAllQueryHandler : PagilaBaseQueryHandler<CategoryReadAllQuery, CategoryList>
    {
        /// <summary>
        /// Handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<CategoryList> Handle(CategoryReadAllQuery query)
        {
            var response = new SimpleResponse<CategoryList>();

            using (var database = GetDatabase())
            {
                var actorEntList = database.GetAll<CategoryEntity>();
                response.Data = new CategoryList
                {
                    Categories = actorEntList.Select(p => new CategoryViewModel
                    {
                        CategoryId = p.CategoryId,
                        Name = p.Name,
                        LastUpdate = p.LastUpdate
                    }).ToList() ?? new List<CategoryViewModel>()
                };
                response.ResponseCode = response.Data?.Categories?.Count ?? 0;
                response.RCode = response.ResponseCode.ToString();
            }

            return response;
        }
    }
}