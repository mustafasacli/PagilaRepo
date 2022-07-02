using Coddie.Crud;
using Coddie.Data;
using Pagila.Entity;
using Pagila.Query.Actor;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Actor
{
    public class ActorReadAllQueryHandler : PagilaBaseQueryHandler<ActorReadAllQuery, ActorList>
    {
        public override SimpleResponse<ActorList> Handle(ActorReadAllQuery query)
        {
            var response = new SimpleResponse<ActorList>();

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var actorEntList = connection.GetAll<ActorEntity>();
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
                finally
                {
                    connection.CloseIfNot();
                }
            }

            return response;
        }
    }
}