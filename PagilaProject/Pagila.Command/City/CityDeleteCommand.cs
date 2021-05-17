using Pagila.Command.Base;

namespace Pagila.Command.City
{
    public class CityDeleteCommand : BaseDeleteCommand
    {
        public int? Id
        { get; set; }
    }
}