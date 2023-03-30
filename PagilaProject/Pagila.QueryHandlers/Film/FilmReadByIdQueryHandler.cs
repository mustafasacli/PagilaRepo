using Pagila.Entity;
using Pagila.Query.Film;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using Simply.Crud;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.QueryHandlers.Film
{
    /// <summary>
    /// The film read by id query handler.
    /// </summary>
    public class FilmReadByIdQueryHandler : PagilaBaseQueryHandler<FilmReadByIdQuery, FilmResult>
    {
        /// <summary>
        /// Handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<FilmResult> Handle(FilmReadByIdQuery query)
        {
            var response = new SimpleResponse<FilmResult>();

            if (query.Id == null) return response;

            if ((query.Id ?? 0) < 1) return response;

            using (var database = GetDatabase())
            {
                var filmEntList = database.Select<FilmEntity>(p => p.FilmId == query.Id)?.ToList() ?? new List<FilmEntity>();
                response.Data = new FilmResult
                {
                    Film = (filmEntList.Select(p => Map<FilmEntity, FilmViewModel>(p)).ToList() ?? new List<FilmViewModel>()).FirstOrDefault()
                };
                response.ResponseCode = response.Data != null ? 1 : 0;
                response.RCode = response.ResponseCode.ToString();
            }

            return response;
        }
    }
}