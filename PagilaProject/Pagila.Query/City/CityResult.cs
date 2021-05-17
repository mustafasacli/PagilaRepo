using Pagila.ViewModel;
using SI.Query.Core;

namespace Pagila.Query.City
{
    public class CityResult : IQueryResult
    {
        public CityViewModel Actor
        { get; set; }
    }
}