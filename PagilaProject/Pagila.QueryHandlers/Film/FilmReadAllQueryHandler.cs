using Coddie.Crud;
using Coddie.Data;
using Pagila.Entity;
using Pagila.Query.Film;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Film
{
    public class FilmReadAllQueryHandler : PagilaBaseQueryHandler<FilmReadAllQuery, FilmList>
    {
        public override SimpleResponse<FilmList> Handle(FilmReadAllQuery query)
        {
            var response = new SimpleResponse<FilmList>();

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var FilmEntList = connection.GetAll<FilmEntity>();
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

            return response;
        }
    }
}