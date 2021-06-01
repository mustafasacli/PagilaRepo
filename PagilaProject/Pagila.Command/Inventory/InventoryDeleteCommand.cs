using Pagila.Command.Base;

namespace Pagila.Command.Inventory
{
    public class InventoryDeleteCommand : BaseDeleteCommand
    {
        public int? Id
        { get; set; }
    }
}