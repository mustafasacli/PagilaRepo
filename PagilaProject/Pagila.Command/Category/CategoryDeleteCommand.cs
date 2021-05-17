using Pagila.Command.Base;

namespace Pagila.Command.Category
{
    public class CategoryDeleteCommand : BaseDeleteCommand
    {
        public int? Id
        { get; set; }
    }
}