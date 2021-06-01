using SI.Query.Core;

namespace Pagila.Query.Rental
{
    public class RentalReadByIdQuery : IQuery<RentalResult>
    {
        public int? Id
        { get; set; }
    }
}