using Pagila.Command.Base;

namespace Pagila.Command.Category
{
    public class CategoryUpdateCommand : BaseUpdateCommand
    {
        public int CategoryId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Name
        /// </summary>
        public string Name
        { get; set; }
    }
}