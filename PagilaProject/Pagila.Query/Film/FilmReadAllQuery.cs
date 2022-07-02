using SI.Query.Core;

namespace Pagila.Query.Film
{
    public class FilmReadAllQuery : IQuery<FilmList>
    {
        public FilmReadAllQuery()
        {
        }

        public static FilmReadAllQuery GetEmptyInstance()
        {
            return new FilmReadAllQuery();
        }
    }
}