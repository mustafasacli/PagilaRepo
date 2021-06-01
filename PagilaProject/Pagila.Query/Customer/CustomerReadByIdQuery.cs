using SI.Query.Core;

namespace Pagila.Query.Customer
{
    public class CustomerReadByIdQuery : IQuery<CustomerResult>
    {
        public int? Id
        { get; set; }
    }
}