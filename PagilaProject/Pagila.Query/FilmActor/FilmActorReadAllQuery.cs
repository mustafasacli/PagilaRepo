using SI.Query.Core;

namespace Pagila.Query.FilmActor
{
    public class FilmActorReadAllQuery : IQuery<FilmActorList>
    {
        public FilmActorReadAllQuery()
        {
        }

        public long FilmId
        { get; set; }
    }
}