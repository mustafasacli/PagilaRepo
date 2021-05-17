using Pagila.Command.Base;

namespace Pagila.Command.Country
{
    public class CountryDeleteCommand : BaseDeleteCommand
    {
        public int? Id
        { get; set; }
    }
}