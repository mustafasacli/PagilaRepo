using Pagila.Command.Base;

namespace Pagila.Command.Staff
{
    public class StaffUpdateCommand : BaseUpdateCommand
    {
        public int StaffId
        { get; set; }

        public string FirstName
        { get; set; }

        public string LastName
        { get; set; }

        /// <summary>
        /// Gets or Sets the AddressId
        /// </summary>
        public int AddressId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Email
        /// </summary>
        public string Email
        { get; set; }

        /// <summary>
        /// Gets or Sets the StoreId
        /// </summary>
        public int StoreId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Username
        /// </summary>
        public string Username
        { get; set; }

        /// <summary>
        /// Gets or Sets the Password
        /// </summary>
        public string Password
        { get; set; }

        /// <summary>
        /// Gets or Sets the Picture
        /// </summary>
        public byte[] Picture
        { get; set; }
    }
}