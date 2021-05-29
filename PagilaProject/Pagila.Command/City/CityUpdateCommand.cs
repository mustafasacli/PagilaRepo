using Pagila.Command.Base;

namespace Pagila.Command.City
{
    public class CityUpdateCommand : BaseUpdateCommand
    {
        public int CityId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Name
        /// </summary>
        public string City
        { get; set; }

        public int CountryId
        { get; set; }
    }
}