using Coddie.Crud;
using Coddie.Data;
using Pagila.Entity;
using Pagila.Query.Category;
using Pagila.ViewModel;
using SI.QueryHandler.Base;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Category
{
    public class CategoryReadAllQueryHandler : PagilaBaseQueryHandler<CategoryReadAllQuery, CategoryList>
    {
        public override SimpleResponse<CategoryList> Handle(CategoryReadAllQuery query)
        {
            var response = new SimpleResponse<CategoryList>();

            try
            {
                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var actorEntList = connection.GetAll<CategoryEntity>();
                        // var result = connection.QueryList<Syp.Entity.ServiceDetailType>("select * from service_detail_type where is_deleted = false and lower(detail_type_name) like '%' || :name || '%'", new { name = query.Name.ToLowerInvariant() });
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
