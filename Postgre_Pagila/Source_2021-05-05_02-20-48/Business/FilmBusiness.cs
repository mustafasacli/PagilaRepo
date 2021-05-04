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
    /// Defines the <see cref="FilmBusiness"/>.
    /// </summary>
    public class FilmBusiness : SimpleBaseBusiness, IFilmBusiness
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilmBusiness"/> class.
        /// </summary>
        public FilmBusiness()
        {
        }

        /// <summary>
        /// The Creates entity for FilmViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="FilmViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{FilmViewModel}"/>.</returns>
        public SimpleResponse<FilmViewModel> Create(FilmViewModel model)
        {
            var response = new SimpleResponse<FilmViewModel>();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse<FilmViewModel>
                    {
                        Data = model,
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using (var context = new PublicDbContext())
                {
                    var entity = Map<FilmViewModel, Film>(model);
                    context.Film.Add(entity);
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
        /// The Reads for FilmViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{FilmViewModel}"/>.</returns>
        public SimpleResponse<FilmViewModel> Read(int filmId)
        {
            var response = new SimpleResponse<FilmViewModel>();

            try
            {
                using (var context = new PublicDbContext())
                {
                    var entity = context.Film
                        .AsNoTracking()
                        .SingleOrDefault(q => q.FilmId == filmId);

                    if (entity == null || entity == default(Film))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    response.Data = Map<Film, FilmViewModel>(entity);
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
        /// Updates entity for FilmViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="FilmViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Update(FilmViewModel model)
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
                    var entity = context.Film.SingleOrDefault(q => q.FilmId == model.FilmId);
                    if (entity == null || entity == default(Film))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    MapTo(model, entity);
                    // context.Film.Attach(entity);
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
        /// Deletes entity for FilmViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="FilmViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Delete(FilmViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicDbContext())
                {
                    var entity = context.Film.FirstOrDefault(q => q.FilmId == model.FilmId);
                    if (entity == null || entity == default(Film))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Film.Remove(entity);
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
        public SimpleResponse Delete(int filmId)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicDbContext())
                {
                    var entity = context.Film.SingleOrDefault(q => q.FilmId == filmId);
                    if (entity == null || entity == default(Film))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Film.Remove(entity);
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
        /// Reads All records for FilmViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{FilmViewModel}}"/>.</returns>
        public SimpleResponse<List<FilmViewModel>> ReadAll()
        {
            var response = new SimpleResponse<List<FilmViewModel>>();

            try
            {
                using (var context = new PublicDbContext())
                {
                    var entities = context.Film
                        .AsNoTracking()
                        .ToList() ?? new List<Film>();

                    response.Data = MapList<Film, FilmViewModel>(entities);
                    response.ResponseCode = response.Data.Count;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            response.Data = response.Data ?? new List<FilmViewModel>();
            return response;
        }
    }
}