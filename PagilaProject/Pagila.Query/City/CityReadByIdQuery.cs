using SI.Query.Core;

namespace Pagila.Query.City
{
    public class CityReadByIdQuery : IQuery<CityResult>
    {
        public int? Id
        { get; set; }
    }
}