using Pagila.BusinessCore.Interfaces;
using Pagila.CoreContext;
using Pagila.Entity;
using Pagila.ViewModel;
using Gsb.Common.Core;
using SimpleFileLogging;
using Microsoft.EntityFrameworkCore;
using SimpleInfra.Common.Response;
using SimpleInfra.Mapping;
using SimpleInfra.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pagila.BusinessCore
{
    /// <summary>
    /// Defines the <see cref="FilmActorBusiness"/>.
    /// </summary>
    public class FilmActorBusiness : SimpleBaseBusiness, IFilmActorBusiness
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilmActorBusiness"/> class.
        /// </summary>
        public FilmActorBusiness()
        {
        }

        /// <summary>
        /// The Creates entity for FilmActorViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="FilmActorViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{FilmActorViewModel}"/>.</returns>
        public SimpleResponse<FilmActorViewModel> Create(FilmActorViewModel model)
        {
            var response = new SimpleResponse<FilmActorViewModel>();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse<FilmActorViewModel>
                    {
                        Data = model,
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using (var context = new PublicCoreDbContext())
                {
                    var entity = Map<FilmActorViewModel, FilmActor>(model);
                    context.FilmActor.Add(entity);
                    response.ResponseCode = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Ekleme iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            return response;
        }

        /// <summary>
        /// The Reads for FilmActorViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{FilmActorViewModel}"/>.</returns>
        public SimpleResponse<FilmActorViewModel> Read(int actorId, int filmId)
        {
            var response = new SimpleResponse<FilmActorViewModel>();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.FilmActor
                        .AsNoTracking()
                        .FirstOrDefault(q => q.ActorId == actorId && q.FilmId == filmId);

                    if (entity == null || entity == default(FilmActor))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    response.Data = Map<FilmActor, FilmActorViewModel>(entity);
                    response.ResponseCode = 1;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            return response;
        }

        /// <summary>
        /// Updates entity for FilmActorViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="FilmActorViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Update(FilmActorViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse
                    {
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.FilmActor.SingleOrDefault(q => q.ActorId == model.ActorId && q.FilmId == model.FilmId);
                    if (entity == null || entity == default(FilmActor))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    MapTo(model, entity);
                    context.FilmActor.Attach(entity);
                    // context.Entry(entity).State = EntityState.Modified;
                    response.ResponseCode = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            return response;
        }

        /// <summary>
        /// Deletes entity for FilmActorViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="FilmActorViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Delete(FilmActorViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.FilmActor.SingleOrDefault(q => q.ActorId == model.ActorId && q.FilmId == model.FilmId);
                    if (entity == null || entity == default(FilmActor))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.FilmActor.Remove(entity);
                    response.ResponseCode = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            return response;
        }

        /// <summary>
        /// Deletes record by given id value(s).
        /// </summary>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Delete(int actorId, int filmId)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.FilmActor.SingleOrDefault(q => q.ActorId == actorId && q.FilmId == filmId);
                    if (entity == null || entity == default(FilmActor))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.FilmActor.Remove(entity);
                    response.ResponseCode = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            return response;
        }

        /// <summary>
        /// Reads All records for FilmActorViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{FilmActorViewModel}}"/>.</returns>
        public SimpleResponse<List<FilmActorViewModel>> ReadAll()
        {
            var response = new SimpleResponse<List<FilmActorViewModel>>();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entities = context.FilmActor
                        .AsNoTracking()
                        .ToList() ?? new List<FilmActor>();

                    response.Data = MapList<FilmActor, FilmActorViewModel>(entities);
                    response.ResponseCode = response.Data.Count;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            response.Data = response.Data ?? new List<FilmActorViewModel>();
            return response;
        }
    }
}