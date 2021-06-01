using Pagila.ViewModel;
using SI.Query.Core;

namespace Pagila.Query.Rental
{
    public class RentalResult : IQueryResult
    {
        public RentalViewModel Rental
        { get; set; }
    }
}