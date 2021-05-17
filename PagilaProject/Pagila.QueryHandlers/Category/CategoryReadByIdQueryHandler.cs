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
    public class CategoryReadByIdQueryHandler : PagilaBaseQueryHandler<CategoryReadByIdQuery, CategoryResult>
    {
        public override SimpleResponse<CategoryResult> Handle(CategoryReadByIdQuery query)
        {
            var response = new SimpleResponse<CategoryResult>();

            try
            {
                if (query.Id == null) return response;

                if ((query.Id ?? 0) < 1) return response;

                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var actorEntList = connection.Select<CategoryEntity>(p => p.CategoryId == query.Id)?.ToList() ?? new List<CategoryEntity>();
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

