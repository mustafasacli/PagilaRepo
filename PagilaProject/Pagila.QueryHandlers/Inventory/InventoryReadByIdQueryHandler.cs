using Coddie.Crud;
using Coddie.Data;
using Pagila.Entity;
using Pagila.Query.Inventory;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Inventory
{
    public class InventoryReadByIdQueryHandler : PagilaBaseQueryHandler<InventoryReadByIdQuery, InventoryResult>
    {
        public override SimpleResponse<InventoryResult> Handle(InventoryReadByIdQuery query)
        {
            var response = new SimpleResponse<InventoryResult>();

            try
            {
                if (query.Id == null) return response;

                if ((query.Id ?? 0) < 1) return response;

                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var InventoryEntList = connection.Select<InventoryEntity>(p => p.InventoryId == query.Id)?.ToList() ?? new List<InventoryEntity>();
                        response.Data = new InventoryResult
                        {
                            Inventory = (InventoryEntList.Select(p => Map<InventoryEntity, InventoryViewModel>(p)).ToList() ?? new List<InventoryViewModel>()).FirstOrDefault()
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