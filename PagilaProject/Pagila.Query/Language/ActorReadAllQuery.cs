using SI.Query.Core;

namespace Pagila.Query.Language
{
    public class LanguageReadAllQuery : IQuery<LanguageList>
    {
        public LanguageReadAllQuery()
        {
        }

        public static LanguageReadAllQuery GetEmptyInstance()
        {
            return new LanguageReadAllQuery();
        }
    }
}