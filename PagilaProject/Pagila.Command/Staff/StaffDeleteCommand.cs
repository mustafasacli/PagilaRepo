using Pagila.Command.Base;

namespace Pagila.Command.Staff
{
    public class StaffDeleteCommand : BaseDeleteCommand
    {
        public int? Id
        { get; set; }
    }
}