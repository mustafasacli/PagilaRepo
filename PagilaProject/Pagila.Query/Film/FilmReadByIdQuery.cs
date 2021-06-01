using SI.Query.Core;

namespace Pagila.Query.Film
{
    public class FilmReadByIdQuery : IQuery<FilmResult>
    {
        public int? Id
        { get; set; }
    }
}