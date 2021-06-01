using Pagila.Command.Base;

namespace Pagila.Command.Language
{
    public class LanguageDeleteCommand : BaseDeleteCommand
    {
        public int? Id
        { get; set; }
    }
}