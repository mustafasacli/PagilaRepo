using Pagila.ViewModel;
using SI.Query.Core;

namespace Pagila.Query.Actor
{
    public class ActorResult : IQueryResult
    {
        public ActorViewModel Actor
        { get; set; }
    }
}