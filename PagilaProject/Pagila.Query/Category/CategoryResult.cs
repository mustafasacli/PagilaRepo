using Pagila.ViewModel;
using SI.Query.Core;

namespace Pagila.Query.Category
{
    public class CategoryResult : IQueryResult
    {
        public CategoryViewModel Category
        { get; set; }
    }
}