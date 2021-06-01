using Pagila.Command.Base;

namespace Pagila.Command.Store
{
    public class StoreDeleteCommand : BaseDeleteCommand
    {
        public int? Id
        { get; set; }
    }
}