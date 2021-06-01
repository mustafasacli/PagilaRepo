using SI.Query.Core;

namespace Pagila.Query.Store
{
    public class StoreReadByIdQuery : IQuery<StoreResult>
    {
        public int? Id
        { get; set; }
    }
}