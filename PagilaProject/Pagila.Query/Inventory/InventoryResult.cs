using Pagila.ViewModel;
using SI.Query.Core;

namespace Pagila.Query.Inventory
{
    public class InventoryResult : IQueryResult
    {
        public InventoryViewModel Inventory
        { get; set; }
    }
}