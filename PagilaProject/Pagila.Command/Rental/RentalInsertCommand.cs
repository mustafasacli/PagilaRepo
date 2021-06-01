using Pagila.Command.Base;
using System;

namespace Pagila.Command.Rental
{
    public class RentalInsertCommand : BaseInsertCommand
    {
        /// <summary>
        /// Gets or Sets the RentalDate
        /// </summary>
        public DateTime RentalDate
        { get; set; }

        /// <summary>
        /// Gets or Sets the InventoryId
        /// </summary>
        public int InventoryId
        { get; set; }

        /// <summary>
        /// Gets or Sets the CustomerId
        /// </summary>
        public int CustomerId
        { get; set; }

        /// <summary>
        /// Gets or Sets the ReturnDate
        /// </summary>
        public DateTime? ReturnDate
        { get; set; }

        /// <summary>
        /// Gets or Sets the StaffId
        /// </summary>
        public int StaffId
        { get; set; }
    }
}