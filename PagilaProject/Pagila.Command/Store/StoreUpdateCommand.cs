using Pagila.Command.Base;

namespace Pagila.Command.Store
{
    public class StoreUpdateCommand : BaseUpdateCommand
    {
        public int StoreId
        { get; set; }

        /// <summary>
        /// Gets or Sets the ManagerStaffId
        /// </summary>
        public int ManagerStaffId
        { get; set; }

        /// <summary>
        /// Gets or Sets the AddressId
        /// </summary>
        public int AddressId
        { get; set; }
    }
}