using Pagila.ViewModel;
using SI.Query.Core;
using System.Collections.Generic;

namespace Pagila.Query.Country
{
    public class CountryList : IQueryResult
    {
        public List<CountryViewModel> Countries
        { get; set; }
    }
}
