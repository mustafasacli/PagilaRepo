using Coddie.Crud;
using Coddie.Data;
using Pagila.Entity;
using Pagila.Query.Actor;
using Pagila.ViewModel;
using SI.QueryHandler.Base;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Actor
{
    public class ActorReadAllQueryHandler : BaseQueryHandler<ActorReadAllQuery, ActorList>
    {
        public override SimpleResponse<ActorList> Handle(ActorReadAllQuery query)
        {
            var response = new SimpleResponse<ActorList>();

            try
            {
                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var actorEntList = connection.GetAll<ActorEntity>();
                        // var result = connection.QueryList<Syp.Entity.ServiceDetailType>("select * from service_detail_type where is_deleted = false and lower(detail_type_name) like '%' || :name || '%'", new { name = query.Name.ToLowerInvariant() });
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
            }
            catch (Exception ex)
            {
                response.ResponseCode = -500;
                DayLogger.Error(ex);
            }

            return response;
        }
    }
}
