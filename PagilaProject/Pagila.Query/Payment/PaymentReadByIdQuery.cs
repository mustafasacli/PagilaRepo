using SI.Query.Core;

namespace Pagila.Query.Payment
{
    public class PaymentReadByIdQuery : IQuery<PaymentResult>
    {
        public int? Id
        { get; set; }
    }
}