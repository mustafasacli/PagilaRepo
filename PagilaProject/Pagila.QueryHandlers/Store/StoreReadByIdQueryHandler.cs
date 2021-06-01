using Coddie.Crud;
using Coddie.Data;
using Pagila.Entity;
using Pagila.Query.Store;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Store
{
    public class StoreReadByIdQueryHandler : PagilaBaseQueryHandler<StoreReadByIdQuery, StoreResult>
    {
        public override SimpleResponse<StoreResult> Handle(StoreReadByIdQuery query)
        {
            var response = new SimpleResponse<StoreResult>();

            try
            {
                if (query.Id == null) return response;

                if ((query.Id ?? 0) < 1) return response;

                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var StoreEntList = connection.Select<StoreEntity>(p => p.StoreId == query.Id)?.ToList() ?? new List<StoreEntity>();
                        response.Data = new StoreResult
                        {
                            Store = (StoreEntList.Select(p => Map<StoreEntity, StoreViewModel>(p)).ToList() ?? new List<StoreViewModel>()).FirstOrDefault()
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