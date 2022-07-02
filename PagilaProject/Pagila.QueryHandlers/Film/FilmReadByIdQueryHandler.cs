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
    public class FilmReadByIdQueryHandler : PagilaBaseQueryHandler<FilmReadByIdQuery, FilmResult>
    {
        public override SimpleResponse<FilmResult> Handle(FilmReadByIdQuery query)
        {
            var response = new SimpleResponse<FilmResult>();

            if (query.Id == null) return response;

            if ((query.Id ?? 0) < 1) return response;

            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.OpenIfNot();
                    var FilmEntList = connection.Select<FilmEntity>(p => p.FilmId == query.Id)?.ToList() ?? new List<FilmEntity>();
                    response.Data = new FilmResult
                    {
                        Film = (FilmEntList.Select(p => Map<FilmEntity, FilmViewModel>(p)).ToList() ?? new List<FilmViewModel>()).FirstOrDefault()
                    };
                    response.ResponseCode = response.Data != null ? 1 : 0;
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