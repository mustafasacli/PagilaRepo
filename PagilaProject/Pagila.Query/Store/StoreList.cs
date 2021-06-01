using Pagila.ViewModel;
using SI.Query.Core;
using System.Collections.Generic;

namespace Pagila.Query.Store
{
    public class StoreList : IQueryResult
    {
        public List<StoreViewModel> Stores
        { get; set; }
    }
}
