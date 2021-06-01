using Pagila.ViewModel;
using SI.Query.Core;
using System.Collections.Generic;

namespace Pagila.Query.Customer
{
    public class CustomerList : IQueryResult
    {
        public List<CustomerViewModel> Customers
        { get; set; }
    }
}
