using Pagila.ViewModel;
using SI.Query.Core;

namespace Pagila.Query.Store
{
    public class StoreResult : IQueryResult
    {
        public StoreViewModel Store
        { get; set; }
    }
}