using Pagila.Command.Base;

namespace Pagila.Command.Customer
{
    public class CustomerDeleteCommand : BaseDeleteCommand
    {
        public int? Id
        { get; set; }
    }
}