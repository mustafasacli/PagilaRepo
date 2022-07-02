using Pagila.ViewModel;
using SI.Query.Core;
using System.Collections.Generic;

namespace Pagila.Query.Inventory
{
    public class InventoryList : IQueryResult
    {
        public List<InventoryViewModel> Inventories
        { get; set; }
    }
}