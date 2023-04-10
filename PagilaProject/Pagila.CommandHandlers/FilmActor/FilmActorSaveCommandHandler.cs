using Pagila.Command.Base.Result;
using Pagila.Command.FilmActor;
using Pagila.Entity;
using SimpleInfra.Common.Response;
using Simply.Crud;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.CommandHandlers.FilmActor
{
    /// <summary>
    /// The film actor save command handler.
    /// </summary>
    public class FilmActorSaveCommandHandler : PagilaBaseCommandHandler<FilmActorSaveCommand, LongCommandResult>
    {
        /// <summary>
        /// Handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>A SimpleResponse.</returns>
        public override SimpleResponse<LongCommandResult> Handle(FilmActorSaveCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            using (var database = GetDatabase())
            {
                try
                {
                    List<FilmActorEntity> filmactors = command.Actors
                                .Select(q => new FilmActorEntity { FilmId = (int)command.FilmId, ActorId = (int)q, LastUpdate = DateTime.Now })
                                .ToList();
                    database.Begin();
                    int deleteResult = database.DeleteAll<FilmActorEntity>(q => q.FilmId == command.FilmId);
                    int insertResult = database.Insert(filmactors);
                    database.Commit();
                    response.ResponseCode = insertResult;
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
        public override SimpleResponse Validate(FilmActorSaveCommand command)
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