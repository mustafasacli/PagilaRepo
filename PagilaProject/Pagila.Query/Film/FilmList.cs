using Pagila.ViewModel;
using SI.Query.Core;
using System.Collections.Generic;

namespace Pagila.Query.Film
{
    public class FilmList : IQueryResult
    {
        public List<FilmViewModel> Films
        { get; set; }
    }
}