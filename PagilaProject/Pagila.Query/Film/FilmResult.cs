using Pagila.ViewModel;
using SI.Query.Core;

namespace Pagila.Query.Film
{
    public class FilmResult : IQueryResult
    {
        public FilmViewModel Film
        { get; set; }
    }
}