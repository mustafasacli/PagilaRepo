using SI.Query.Core;

namespace Pagila.Query.Address
{
    public class AddressReadAllQuery : IQuery<AddressList>
    {
        public AddressReadAllQuery()
        {
        }

        public static AddressReadAllQuery GetEmptyInstance()
        {
            return new AddressReadAllQuery();
        }
    }
}