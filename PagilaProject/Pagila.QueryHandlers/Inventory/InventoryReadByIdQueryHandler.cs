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
    /// The ınventory read by id query handler.
    /// </summary>
    public class InventoryReadByIdQueryHandler : PagilaBaseQueryHandler<InventoryReadByIdQuery, InventoryResult>
    {
        /// <summary>
        /// Handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<InventoryResult> Handle(InventoryReadByIdQuery query)
        {
            var response = new SimpleResponse<InventoryResult>();

            if (query.Id == null) return response;

            if ((query.Id ?? 0) < 1) return response;

            using (var database = GetDatabase())
            {
                var InventoryEntList = database.Select<InventoryEntity>(p => p.InventoryId == query.Id)?.ToList() ?? new List<InventoryEntity>();
                response.Data = new InventoryResult
                {
                    Inventory = (InventoryEntList.Select(p => Map<InventoryEntity, InventoryViewModel>(p)).ToList() ?? new List<InventoryViewModel>()).FirstOrDefault()
                };
                response.ResponseCode = response.Data != null ? 1 : 0;
                response.RCode = response.ResponseCode.ToString();
            }

            return response;
        }
    }
}