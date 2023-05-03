using Pagila.Entity;
using Pagila.Query.Film;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using Simply.Crud;
using Simply.Crud.Enums;
using Simply.Crud.Interfaces;
using Simply.Crud.Objects;
using System.Collections.Generic;
using System.Data;
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
                IWhere<FilmEntity> film =
                database.Where<FilmEntity>()
                    .AddAndCondition(q => q.FilmId > 0)
                    .AddAllPropertiesForSelect(includeComputedProperties: true)
                    .AddOrderClause(q => q.LastUpdate, isDescending: true)
                    .AddJoin(
                    database.BuildJoin<FilmEntity, LanguageEntity>(JoinTypes.LeftJoin)
                    .AddJoin(p => p.LanguageId, q => q.LanguageId),
                    database.Where<LanguageEntity>()
                    .AddPropertyForSelect(q => q.Name, nameof(FilmEntity.LanguageName))
                    )
                    .AddJoin(
                    database.BuildJoin<FilmEntity, LanguageEntity>(JoinTypes.LeftJoin, destinationTableAlias: TableAliasInfo.New("t3"))
                    .AddJoin(p => p.OriginalLanguageId, q => q.LanguageId),
                    database.Where<LanguageEntity>(tableAliasInfo: TableAliasInfo.New("t3"))
                    .AddPropertyForSelect(q => q.Name, nameof(FilmEntity.OriginalLanguageName))
                    );
                database.DbCommandLogAction = PrintCommand;

                var liste = database.PartialSelect(film).ToList();
                response.Data = new FilmList
                {
                    Films = liste.Select(p => Map<FilmEntity, FilmViewModel>(p)).ToList() ?? new List<FilmViewModel>()
                };
                response.ResponseCode = response.Data?.Films?.Count ?? 0;
                response.RCode = response.ResponseCode.ToString();
            }

            return response;
        }

        /// <summary>
        /// Prints the command.
        /// </summary>
        /// <param name="command">The command.</param>
        void PrintCommand(IDbCommand command)
        {
            System.Console.WriteLine(command.CommandText);
        }
    }
}