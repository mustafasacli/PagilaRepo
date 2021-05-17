using Pagila.ViewModel;
using SI.Query.Core;

namespace Pagila.Query.Country
{
    public class CountryResult : IQueryResult
    {
        public CountryViewModel Actor
        { get; set; }
    }
}