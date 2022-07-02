using Pagila.ViewModel;
using SI.Query.Core;
using System.Collections.Generic;

namespace Pagila.Query.Payment
{
    public class PaymentList : IQueryResult
    {
        public List<PaymentViewModel> Payments
        { get; set; }
    }
}