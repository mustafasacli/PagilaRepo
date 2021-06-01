using Coddie.Crud;
using Coddie.Data;
using Pagila.Entity;
using Pagila.Query.Film;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Film
{
    public class FilmReadAllQueryHandler : PagilaBaseQueryHandler<FilmReadAllQuery, FilmList>
    {
        public override SimpleResponse<FilmList> Handle(FilmReadAllQuery query)
        {
            var response = new SimpleResponse<FilmList>();

            try
            {
                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var FilmEntList = connection.GetAll<FilmEntity>();
                        // var result = connection.QueryList<Syp.Entity.ServiceDetailType>("select * from service_detail_type where is_deleted = false and lower(detail_type_name) like '%' || :name || '%'", new { name = query.Name.ToLowerInvariant() });
                        response.Data = new FilmList
                        {
                            Films = FilmEntList.Select(p => Map<FilmEntity, FilmViewModel>(p)).ToList() ?? new List<FilmViewModel>()
                        };
                        response.ResponseCode = response.Data?.Films?.Count ?? 0;
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