using Pagila.Command.Base;

namespace Pagila.Command.Customer
{
    public class CustomerInsertCommand : BaseInsertCommand
    {
        public string FirstName
        { get; set; }

        public string LastName
        { get; set; }
    }
}