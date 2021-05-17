using Pagila.ViewModel;
using SI.Query.Core;

namespace Pagila.Query.Address
{
    public class AddressResult : IQueryResult
    {
        public AddressViewModel Address
        { get; set; }
    }
}