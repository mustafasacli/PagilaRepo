using Pagila.ViewModel;
using SI.Query.Core;

namespace Pagila.Query.Language
{
    public class LanguageResult : IQueryResult
    {
        public LanguageViewModel Language
        { get; set; }
    }
}