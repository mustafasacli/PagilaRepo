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
    /// Defines the <see cref="FilmCategoryBusiness"/>.
    /// </summary>
    public class FilmCategoryBusiness : SimpleBaseBusiness, IFilmCategoryBusiness
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilmCategoryBusiness"/> class.
        /// </summary>
        public FilmCategoryBusiness()
        {
        }

        /// <summary>
        /// The Creates entity for FilmCategoryViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="FilmCategoryViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{FilmCategoryViewModel}"/>.</returns>
        public SimpleResponse<FilmCategoryViewModel> Create(FilmCategoryViewModel model)
        {
            var response = new SimpleResponse<FilmCategoryViewModel>();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse<FilmCategoryViewModel>
                    {
                        Data = model,
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using (var context = new PublicCoreDbContext())
                {
                    var entity = Map<FilmCategoryViewModel, FilmCategory>(model);
                    context.FilmCategory.Add(entity);
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
        /// The Reads for FilmCategoryViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{FilmCategoryViewModel}"/>.</returns>
        public SimpleResponse<FilmCategoryViewModel> Read(int filmId, int categoryId)
        {
            var response = new SimpleResponse<FilmCategoryViewModel>();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.FilmCategory
                        .AsNoTracking()
                        .FirstOrDefault(q => q.FilmId == filmId && q.CategoryId == categoryId);

                    if (entity == null || entity == default(FilmCategory))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    response.Data = Map<FilmCategory, FilmCategoryViewModel>(entity);
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
        /// Updates entity for FilmCategoryViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="FilmCategoryViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Update(FilmCategoryViewModel model)
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
                    var entity = context.FilmCategory.SingleOrDefault(q => q.FilmId == model.FilmId && q.CategoryId == model.CategoryId);
                    if (entity == null || entity == default(FilmCategory))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    MapTo(model, entity);
                    context.FilmCategory.Attach(entity);
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
        /// Deletes entity for FilmCategoryViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="FilmCategoryViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Delete(FilmCategoryViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.FilmCategory.SingleOrDefault(q => q.FilmId == model.FilmId && q.CategoryId == model.CategoryId);
                    if (entity == null || entity == default(FilmCategory))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.FilmCategory.Remove(entity);
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
        public SimpleResponse Delete(int filmId, int categoryId)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.FilmCategory.SingleOrDefault(q => q.FilmId == filmId && q.CategoryId == categoryId);
                    if (entity == null || entity == default(FilmCategory))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.FilmCategory.Remove(entity);
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
        /// Reads All records for FilmCategoryViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{FilmCategoryViewModel}}"/>.</returns>
        public SimpleResponse<List<FilmCategoryViewModel>> ReadAll()
        {
            var response = new SimpleResponse<List<FilmCategoryViewModel>>();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entities = context.FilmCategory
                        .AsNoTracking()
                        .ToList() ?? new List<FilmCategory>();

                    response.Data = MapList<FilmCategory, FilmCategoryViewModel>(entities);
                    response.ResponseCode = response.Data.Count;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            response.Data = response.Data ?? new List<FilmCategoryViewModel>();
            return response;
        }
    }
}