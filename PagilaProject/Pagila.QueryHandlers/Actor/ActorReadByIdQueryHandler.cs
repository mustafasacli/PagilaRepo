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
    public class ActorReadByIdQueryHandler : PagilaBaseQueryHandler<ActorReadByIdQuery, ActorResult>
    {
        public override SimpleResponse<ActorResult> Handle(ActorReadByIdQuery query)
        {
            var response = new SimpleResponse<ActorResult>();

            try
            {
                if (query.Id == null) return response;

                if ((query.Id ?? 0) < 1) return response;

                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var actorEntList = connection.Select<ActorEntity>(p => p.ActorId == query.Id)?.ToList() ?? new List<ActorEntity>();
                        response.Data = new ActorResult
                        {
                            Actor = (actorEntList.Select(p => new ActorViewModel
                            {
                                ActorId = p.ActorId,
                                FirstName = p.FirstName,
                                LastName = p.LastName,
                                LastUpdate = p.LastUpdate
                            }).ToList() ?? new List<ActorViewModel>()).FirstOrDefault()
                        };
                        response.ResponseCode = response.Data != null ? 1 : 0;
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

