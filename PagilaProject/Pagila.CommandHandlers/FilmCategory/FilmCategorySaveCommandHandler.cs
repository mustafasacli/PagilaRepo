using Pagila.Command.Base.Result;
using Pagila.Command.FilmCategory;
using Pagila.Entity;
using SimpleInfra.Common.Response;
using Simply.Crud;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.CommandHandlers.FilmCategory
{
    /// <summary>
    /// The film category save command handler.
    /// </summary>
    public class FilmCategorySaveCommandHandler : PagilaBaseCommandHandler<FilmCategorySaveCommand, LongCommandResult>
    {
        /// <summary>
        /// Handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<LongCommandResult> Handle(FilmCategorySaveCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var database = GetDatabase())
            {
                try
                {
                    List<FilmCategoryEntity> filmcategories = command.Categories
                                .Select(q => new FilmCategoryEntity { FilmId = (int)command.FilmId, CategoryId = q, LastUpdate = DateTime.Now })
                                .ToList();
                    database.Begin();
                    int deleteResult = database.DeleteAll<FilmCategoryEntity>(q => q.FilmId == command.FilmId);
                    int insertResult = database.Insert(filmcategories);
                    database.Commit();
                    response.ResponseCode = (int)insertResult;
                    response.RCode = deleteResult.ToString();
                    response.Data = new LongCommandResult { ReturnValue = insertResult };
                }
                catch (Exception)
                {
                    database.Rollback();
                    throw;
                }
            }

            return response;
        }

        /// <summary>
        /// Validates the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse Validate(FilmCategorySaveCommand command)
        {
            SimpleResponse response = new SimpleResponse();
            if (command.FilmId < 1)
            {
                response.ResponseCode = -100;
                response.ResponseMessage = "FilmId belirtilmelidir.";
            }
            // Validation process will be added  in future.
            return response;
        }
    }
}