using Pagila.Command.Base;

namespace Pagila.Command.Rental
{
    public class RentalDeleteCommand : BaseDeleteCommand
    {
        public int? Id
        { get; set; }
    }
}