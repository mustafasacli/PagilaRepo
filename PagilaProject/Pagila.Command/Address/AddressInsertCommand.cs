using Pagila.Command.Base;

namespace Pagila.Command.Address
{
    public class AddressInsertCommand : BaseInsertCommand
    {
        /// <summary>
        /// Gets or Sets the Address
        /// </summary>
        public string Address
        { get; set; }

        /// <summary>
        /// Gets or Sets the Address2
        /// </summary>
        public string Address2
        { get; set; }

        /// <summary>
        /// Gets or Sets the District
        /// </summary>
        public string District
        { get; set; }

        /// <summary>
        /// Gets or Sets the CityId
        /// </summary>
        public int CityId
        { get; set; }

        /// <summary>
        /// Gets or Sets the PostalCode
        /// </summary>
        public string PostalCode
        { get; set; }

        /// <summary>
        /// Gets or Sets the Phone
        /// </summary>
        public string Phone
        { get; set; }
    }
}