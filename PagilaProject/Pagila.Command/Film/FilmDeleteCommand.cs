using Pagila.Command.Base;

namespace Pagila.Command.Film
{
    public class FilmDeleteCommand : BaseDeleteCommand
    {
        public int? Id
        { get; set; }
    }
}