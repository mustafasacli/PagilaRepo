using Pagila.Command.Base;

namespace Pagila.Command.City
{
    public class CityInsertCommand : BaseInsertCommand
    {
        public int CountryId
        { get; set; }

        public string City
        { get; set; }
    }
}