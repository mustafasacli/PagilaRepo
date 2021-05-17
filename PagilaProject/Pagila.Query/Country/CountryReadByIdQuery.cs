using SI.Query.Core;

namespace Pagila.Query.Country
{
    public class CountryReadByIdQuery : IQuery<CountryResult>
    {
        public int? Id
        { get; set; }
    }
}