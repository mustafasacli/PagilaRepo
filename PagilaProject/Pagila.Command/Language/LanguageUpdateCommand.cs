using Pagila.Command.Base;

namespace Pagila.Command.Language
{
    public class LanguageUpdateCommand : BaseUpdateCommand
    {
        public int LanguageId
        { get; set; }

        /// <summary>
        /// Gets or Sets the Name
        /// </summary>
        public string Name
        { get; set; }
    }
}