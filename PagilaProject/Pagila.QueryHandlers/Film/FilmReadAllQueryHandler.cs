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
    /// The film read all query handler.
    /// </summary>
    public class FilmReadAllQueryHandler : PagilaBaseQueryHandler<FilmReadAllQuery, FilmList>
    {
        /// <summary>
        /// Handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<FilmList> Handle(FilmReadAllQuery query)
        {
            var response = new SimpleResponse<FilmList>();

            using (var database = GetDatabase())
            {
                var FilmEntList = database.GetAll<FilmEntity>();
                response.Data = new FilmList
                {
                    Films = FilmEntList.Select(p => Map<FilmEntity, FilmViewModel>(p)).ToList() ?? new List<FilmViewModel>()
                };
                response.ResponseCode = response.Data?.Films?.Count ?? 0;
                response.RCode = response.ResponseCode.ToString();
            }

            return response;
        }
    }
}