using Pagila.Entity;
using Pagila.Query.Actor;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using Simply.Crud;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Actor
{
    /// <summary>
    /// The actor read all query handler.
    /// </summary>
    public class ActorReadAllQueryHandler : PagilaBaseQueryHandler<ActorReadAllQuery, ActorList>
    {
        /// <summary>
        /// Handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<ActorList> Handle(ActorReadAllQuery query)
        {
            var response = new SimpleResponse<ActorList>();

            using (var database = GetDatabase())
            {
                var actorEntList = database.GetAll<ActorEntity>();
                response.Data = new ActorList
                {
                    Actors = actorEntList.Select(p => new ActorViewModel
                    {
                        ActorId = p.ActorId,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        LastUpdate = p.LastUpdate
                    }).ToList() ?? new List<ActorViewModel>()
                };
                response.ResponseCode = response.Data?.Actors?.Count ?? 0;
                response.RCode = response.ResponseCode.ToString();
            }

            return response;
        }
    }
}