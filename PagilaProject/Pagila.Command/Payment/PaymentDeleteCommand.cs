using Pagila.Command.Base;

namespace Pagila.Command.Payment
{
    public class PaymentDeleteCommand : BaseDeleteCommand
    {
        public int? Id
        { get; set; }
    }
}