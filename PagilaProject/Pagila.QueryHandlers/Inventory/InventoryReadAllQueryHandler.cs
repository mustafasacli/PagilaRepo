using Pagila.Entity;
using Pagila.Query.Inventory;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using Simply.Crud;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Inventory
{
    /// <summary>
    /// The ınventory read all query handler.
    /// </summary>
    public class InventoryReadAllQueryHandler : PagilaBaseQueryHandler<InventoryReadAllQuery, InventoryList>
    {
        /// <summary>
        /// Handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<InventoryList> Handle(InventoryReadAllQuery query)
        {
            var response = new SimpleResponse<InventoryList>();

            using (var database = GetDatabase())
            {
                var InventoryEntList = database.GetAll<InventoryEntity>();
                response.Data = new InventoryList
                {
                    Inventories = InventoryEntList.Select(p => Map<InventoryEntity, InventoryViewModel>(p)).ToList() ?? new List<InventoryViewModel>()
                };
                response.ResponseCode = response.Data?.Inventories?.Count ?? 0;
                response.RCode = response.ResponseCode.ToString();
            }

            return response;
        }
    }
}