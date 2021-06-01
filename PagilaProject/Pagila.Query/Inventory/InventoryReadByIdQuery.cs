using SI.Query.Core;

namespace Pagila.Query.Inventory
{
    public class InventoryReadByIdQuery : IQuery<InventoryResult>
    {
        public int? Id
        { get; set; }
    }
}