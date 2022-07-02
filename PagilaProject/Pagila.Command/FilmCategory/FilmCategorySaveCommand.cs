using Pagila.Command.Base;

namespace Pagila.Command.FilmCategory
{
    public class FilmCategorySaveCommand : BaseUpdateCommand
    {
        public long FilmId
        { get; set; }

        public int[] Categories
        { get; set; }

        public string UserId
        { get; set; }
    }
}