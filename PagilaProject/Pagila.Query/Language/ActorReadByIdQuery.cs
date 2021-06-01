using SI.Query.Core;

namespace Pagila.Query.Language
{
    public class LanguageReadByIdQuery : IQuery<LanguageResult>
    {
        public int? Id
        { get; set; }
    }
}