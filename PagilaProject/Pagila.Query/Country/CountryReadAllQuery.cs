using SI.Query.Core;

namespace Pagila.Query.Country
{
    public class CountryReadAllQuery : IQuery<CountryList>
    {
        public CountryReadAllQuery()
        {
        }

        public static CountryReadAllQuery GetEmptyInstance()
        {
            return new CountryReadAllQuery();
        }
    }
}
