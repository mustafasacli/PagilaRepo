using Pagila.ViewModel;
using SI.Query.Core;
using System.Collections.Generic;

namespace Pagila.Query.Address
{
    public class AddressList : IQueryResult
    {
        public List<AddressViewModel> Actors
        { get; set; }
    }
}