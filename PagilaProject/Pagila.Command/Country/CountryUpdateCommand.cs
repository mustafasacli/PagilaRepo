using Pagila.Command.Base;

namespace Pagila.Command.Country
{
    public class CountryUpdateCommand : BaseUpdateCommand
    {
        public int CountryId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Country
        /// </summary>
        public string Country
        { get; set; }
    }
}