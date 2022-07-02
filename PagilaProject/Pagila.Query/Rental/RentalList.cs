using Pagila.ViewModel;
using SI.Query.Core;
using System.Collections.Generic;

namespace Pagila.Query.Rental
{
    public class RentalList : IQueryResult
    {
        public List<RentalViewModel> Rentals
        { get; set; }
    }
}