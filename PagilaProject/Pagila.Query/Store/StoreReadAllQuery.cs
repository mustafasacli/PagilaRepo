using SI.Query.Core;

namespace Pagila.Query.Store
{
    public class StoreReadAllQuery : IQuery<StoreList>
    {
        public StoreReadAllQuery()
        {
        }

        public static StoreReadAllQuery GetEmptyInstance()
        {
            return new StoreReadAllQuery();
        }
    }
}