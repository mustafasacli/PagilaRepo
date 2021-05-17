using SI.Query.Core;

namespace Pagila.Query.Category
{
    public class CategoryReadByIdQuery : IQuery<CategoryResult>
    {
        public int? Id
        { get; set; }
    }
}