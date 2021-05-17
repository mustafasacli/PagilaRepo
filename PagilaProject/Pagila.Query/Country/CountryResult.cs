using Pagila.ViewModel;
using SI.Query.Core;

namespace Pagila.Query.Country
{
    public class CountryResult : IQueryResult
    {
        public CountryViewModel Country
        { get; set; }
    }
}