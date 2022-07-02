using SI.Query.Core;

namespace Pagila.Query.Inventory
{
    public class InventoryReadAllQuery : IQuery<InventoryList>
    {
        public InventoryReadAllQuery()
        {
        }

        public static InventoryReadAllQuery GetEmptyInstance()
        {
            return new InventoryReadAllQuery();
        }
    }
}