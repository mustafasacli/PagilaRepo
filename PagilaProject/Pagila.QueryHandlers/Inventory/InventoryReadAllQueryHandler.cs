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
    public class InventoryReadAllQueryHandler : PagilaBaseQueryHandler<InventoryReadAllQuery, InventoryList>
    {
        public override SimpleResponse<InventoryList> Handle(InventoryReadAllQuery query)
        {
            var response = new SimpleResponse<InventoryList>();

            try
            {
                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var InventoryEntList = connection.GetAll<InventoryEntity>();
                        // var result = connection.QueryList<Syp.Entity.ServiceDetailType>("select * from service_detail_type where is_deleted = false and lower(detail_type_name) like '%' || :name || '%'", new { name = query.Name.ToLowerInvariant() });
                        response.Data = new InventoryList
                        {
                            Inventorys = InventoryEntList.Select(p => Map<InventoryEntity, InventoryViewModel>(p)).ToList() ?? new List<InventoryViewModel>()
                        };
                        response.ResponseCode = response.Data?.Inventorys?.Count ?? 0;
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