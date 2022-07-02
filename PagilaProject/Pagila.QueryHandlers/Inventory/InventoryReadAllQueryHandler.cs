using Coddie.Crud;
using Coddie.Data;
using Pagila.Entity;
using Pagila.Query.Inventory;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Inventory
{
    public class InventoryReadAllQueryHandler : PagilaBaseQueryHandler<InventoryReadAllQuery, InventoryList>
    {
        public override SimpleResponse<InventoryList> Handle(InventoryReadAllQuery query)
        {
            var response = new SimpleResponse<InventoryList>();

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var InventoryEntList = connection.GetAll<InventoryEntity>();
                    response.Data = new InventoryList
                    {
                        Inventories = InventoryEntList.Select(p => Map<InventoryEntity, InventoryViewModel>(p)).ToList() ?? new List<InventoryViewModel>()
                    };
                    response.ResponseCode = response.Data?.Inventories?.Count ?? 0;
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