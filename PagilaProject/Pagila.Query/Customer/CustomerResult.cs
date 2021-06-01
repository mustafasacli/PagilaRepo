using Pagila.ViewModel;
using SI.Query.Core;

namespace Pagila.Query.Customer
{
    public class CustomerResult : IQueryResult
    {
        public CustomerViewModel Customer
        { get; set; }
    }
}