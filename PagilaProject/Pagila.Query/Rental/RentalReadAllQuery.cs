using SI.Query.Core;

namespace Pagila.Query.Rental
{
    public class RentalReadAllQuery : IQuery<RentalList>
    {
        public RentalReadAllQuery()
        {
        }

        public static RentalReadAllQuery GetEmptyInstance()
        {
            return new RentalReadAllQuery();
        }
    }
}
