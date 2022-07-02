using Pagila.ViewModel;
using SI.Query.Core;
using System.Collections.Generic;

namespace Pagila.Query.Actor
{
    public class ActorList : IQueryResult
    {
        public List<ActorViewModel> Actors
        { get; set; }
    }
}