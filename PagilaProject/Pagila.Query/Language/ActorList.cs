using Pagila.ViewModel;
using SI.Query.Core;
using System.Collections.Generic;

namespace Pagila.Query.Language
{
    public class LanguageList : IQueryResult
    {
        public List<LanguageViewModel> Languages
        { get; set; }
    }
}