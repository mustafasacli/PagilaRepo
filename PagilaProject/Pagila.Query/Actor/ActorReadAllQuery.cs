using SI.Query.Core;

namespace Pagila.Query.Actor
{
    public class ActorReadAllQuery : IQuery<ActorList>
    {
        public ActorReadAllQuery()
        {
        }

        public static ActorReadAllQuery GetEmptyInstance()
        {
            return new ActorReadAllQuery();
        }
    }
}