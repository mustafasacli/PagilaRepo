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
        public string Name
        { get; set; }
    }
}