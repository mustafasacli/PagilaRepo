using Pagila.Command.Base;

namespace Pagila.Command.Customer
{
    public class CustomerUpdateCommand : BaseUpdateCommand
    {
        public int CustomerId
        { get; set; }

        public string FirstName
        { get; set; }

        public string LastName
        { get; set; }
    }
}