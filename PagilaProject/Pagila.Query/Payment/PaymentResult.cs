using Pagila.ViewModel;
using SI.Query.Core;

namespace Pagila.Query.Payment
{
    public class PaymentResult : IQueryResult
    {
        public PaymentViewModel Payment
        { get; set; }
    }
}