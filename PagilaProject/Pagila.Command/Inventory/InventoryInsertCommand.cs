using Pagila.Command.Base;

namespace Pagila.Command.Inventory
{
    public class InventoryInsertCommand : BaseInsertCommand
    {
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