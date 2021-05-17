using Pagila.Command.Base;

namespace Pagila.Command.Country
{
    public class CountryInsertCommand : BaseInsertCommand
    {
        public string Country
        { get; set; }
    }
}