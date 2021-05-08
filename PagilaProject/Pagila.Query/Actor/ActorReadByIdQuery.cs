using SI.Query.Core;

namespace Pagila.Query.Actor
{
    public class ActorReadByIdQuery : IQuery<ActorResult>
    {
        public int? Id
        { get; set; }
    }
}