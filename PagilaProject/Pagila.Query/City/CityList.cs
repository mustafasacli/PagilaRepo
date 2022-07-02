using Pagila.ViewModel;
using SI.Query.Core;
using System.Collections.Generic;

namespace Pagila.Query.City
{
    public class CityList : IQueryResult
    {
        public List<CityViewModel> Cities
        { get; set; }
    }
}