using Pagila.Business.Interfaces;
using Pagila.Context;
using Pagila.Entity;
using Pagila.ViewModel;
using SimpleFileLogging;
using SimpleInfra.Common.Core;
using SimpleInfra.Common.Response;
using SimpleInfra.Business.Core;
using SimpleInfra.Mapping;
using SimpleInfra.Validation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Pagila.Business
{
    /// <summary>
    /// Defines the <see cref="ActorBusiness"/>.
    /// </summary>
    public class ActorBusiness : SimpleBaseBusiness, IActorBusiness
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActorBusiness"/> class.
        /// </summary>
        public ActorBusiness()
        {
        }

        /// <summary>
        /// The Creates entity for ActorViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="ActorViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{ActorViewModel}"/>.</returns>
        public SimpleResponse<ActorViewModel> Create(ActorViewModel model)
        {
            var response = new SimpleResponse<ActorViewModel>();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse<ActorViewModel>
                    {
                        Data = model,
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using (var context = new PublicDbContext())
                {
                    var entity = Map<ActorViewModel, Actor>(model);
                    context.Actor.Add(entity);
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
        /// The Reads for ActorViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{ActorViewModel}"/>.</returns>
        public SimpleResponse<ActorViewModel> Read(int actorId)
        {
            var response = new SimpleResponse<ActorViewModel>();

            try
            {
                using (var context = new PublicDbContext())
                {
                    var entity = context.Actor
                        .AsNoTracking()
                        .SingleOrDefault(q => q.ActorId == actorId);

                    if (entity == null || entity == default(Actor))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    response.Data = Map<Actor, ActorViewModel>(entity);
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
        /// Updates entity for ActorViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="ActorViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Update(ActorViewModel model)
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

                using (var context = new PublicDbContext())
                {
                    var entity = context.Actor.SingleOrDefault(q => q.ActorId == model.ActorId);
                    if (entity == null || entity == default(Actor))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    MapTo(model, entity);
                    // context.Actor.Attach(entity);
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
        /// Deletes entity for ActorViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="ActorViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Delete(ActorViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicDbContext())
                {
                    var entity = context.Actor.FirstOrDefault(q => q.ActorId == model.ActorId);
                    if (entity == null || entity == default(Actor))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Actor.Remove(entity);
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
        public SimpleResponse Delete(int actorId)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicDbContext())
                {
                    var entity = context.Actor.SingleOrDefault(q => q.ActorId == actorId);
                    if (entity == null || entity == default(Actor))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Actor.Remove(entity);
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
        /// Reads All records for ActorViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{ActorViewModel}}"/>.</returns>
        public SimpleResponse<List<ActorViewModel>> ReadAll()
        {
            var response = new SimpleResponse<List<ActorViewModel>>();

            try
            {
                using (var context = new PublicDbContext())
                {
                    var entities = context.Actor
                        .AsNoTracking()
                        .ToList() ?? new List<Actor>();

                    response.Data = MapList<Actor, ActorViewModel>(entities);
                    response.ResponseCode = response.Data.Count;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            response.Data = response.Data ?? new List<ActorViewModel>();
            return response;
        }
    }
}