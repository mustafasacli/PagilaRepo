using Pagila.ViewModel;
using SI.Query.Core;
using System.Collections.Generic;

namespace Pagila.Query.FilmCategory
{
    public class FilmCategoryList : IQueryResult
    {
        public FilmCategoryList()
        {
        }

        public List<FilmCategoryViewModel> FilmCategories
        { get; set; }
    }
}