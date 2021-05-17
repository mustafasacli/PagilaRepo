using SI.Query.Core;

namespace Pagila.Query.Address
{
    public class AddressReadByIdQuery : IQuery<AddressResult>
    {
        public int? Id
        { get; set; }
    }
}