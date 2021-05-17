using Pagila.ViewModel;
using SI.Query.Core;
using System.Collections.Generic;

namespace Pagila.Query.Category
{
    public class CategoryList : IQueryResult
    {
        public List<CategoryViewModel> Categories
        { get; set; }
    }
}
