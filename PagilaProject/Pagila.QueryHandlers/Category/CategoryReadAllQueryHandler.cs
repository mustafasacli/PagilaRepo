using Coddie.Crud;
using Coddie.Data;
using Pagila.Entity;
using Pagila.Query.Category;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Category
{
    public class CategoryReadAllQueryHandler : PagilaBaseQueryHandler<CategoryReadAllQuery, CategoryList>
    {
        public override SimpleResponse<CategoryList> Handle(CategoryReadAllQuery query)
        {
            var response = new SimpleResponse<CategoryList>();

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var actorEntList = connection.GetAll<CategoryEntity>();
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
                finally
                {
                    connection.CloseIfNot();
                }
            }

            return response;
        }
    }
}