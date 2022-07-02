using Pagila.Command.Base;

namespace Pagila.Command.FilmActor
{
    public class FilmActorSaveCommand : BaseUpdateCommand
    {
        public long FilmId
        { get; set; }

        public long[] Actors
        { get; set; }

        public string UserId
        { get; set; }
    }
}