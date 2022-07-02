using SI.Query.Core;

namespace Pagila.Query.FilmCategory
{
    public class FilmCategoryReadByFilmIdQuery : IQuery<FilmCategoryList>
    {
        public FilmCategoryReadByFilmIdQuery()
        {
        }

        public long FilmId
        { get; set; }

        public static FilmCategoryReadByFilmIdQuery GetEmptyInstance()
        {
            return new FilmCategoryReadByFilmIdQuery();
        }
    }
}