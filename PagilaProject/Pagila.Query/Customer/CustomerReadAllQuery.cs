using SI.Query.Core;

namespace Pagila.Query.Customer
{
    public class CustomerReadAllQuery : IQuery<CustomerList>
    {
        public CustomerReadAllQuery()
        {
        }

        public static CustomerReadAllQuery GetEmptyInstance()
        {
            return new CustomerReadAllQuery();
        }
    }
}
