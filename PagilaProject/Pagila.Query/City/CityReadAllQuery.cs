using SI.Query.Core;

namespace Pagila.Query.City
{
    public class CityReadAllQuery : IQuery<CityList>
    {
        public CityReadAllQuery()
        {
        }

        public static CityReadAllQuery GetEmptyInstance()
        {
            return new CityReadAllQuery();
        }
    }
}
