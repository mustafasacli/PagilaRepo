using SI.Query.Core;

namespace Pagila.Query.Payment
{
    public class PaymentReadAllQuery : IQuery<PaymentList>
    {
        public PaymentReadAllQuery()
        {
        }

        public static PaymentReadAllQuery GetEmptyInstance()
        {
            return new PaymentReadAllQuery();
        }
    }
}
