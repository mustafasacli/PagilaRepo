using Pagila.Command.Base;

namespace Pagila.Command.Inventory
{
    public class InventoryUpdateCommand : BaseUpdateCommand
    {
        /// <summary>
        /// Gets or Sets the InventoryId
        /// </summary>
        public int InventoryId
        { get; set; }

        /// <summary>
        /// Gets or Sets the FilmId
        /// </summary>
        public int FilmId
        { get; set; }

        /// <summary>
        /// Gets or Sets the StoreId
        /// </summary>
        public int StoreId
        { get; set; }
    }
}