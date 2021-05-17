using Pagila.Command.Base;

namespace Pagila.Command.Address
{
    public class AddressDeleteCommand : BaseDeleteCommand
    {
        public int? Id
        { get; set; }
    }
}