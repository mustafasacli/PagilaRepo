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
    /// Defines the <see cref="CategoryBusiness"/>.
    /// </summary>
    public class CategoryBusiness : SimpleBaseBusiness, ICategoryBusiness
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryBusiness"/> class.
        /// </summary>
        public CategoryBusiness()
        {
        }

        /// <summary>
        /// The Creates entity for CategoryViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="CategoryViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{CategoryViewModel}"/>.</returns>
        public SimpleResponse<CategoryViewModel> Create(CategoryViewModel model)
        {
            var response = new SimpleResponse<CategoryViewModel>();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse<CategoryViewModel>
                    {
                        Data = model,
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using (var context = new PublicCoreDbContext())
                {
                    var entity = Map<CategoryViewModel, Category>(model);
                    context.Category.Add(entity);
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
        /// The Reads for CategoryViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{CategoryViewModel}"/>.</returns>
        public SimpleResponse<CategoryViewModel> Read(int categoryId)
        {
            var response = new SimpleResponse<CategoryViewModel>();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.Category
                        .AsNoTracking()
                        .FirstOrDefault(q => q.CategoryId == categoryId);

                    if (entity == null || entity == default(Category))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    response.Data = Map<Category, CategoryViewModel>(entity);
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
        /// Updates entity for CategoryViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="CategoryViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Update(CategoryViewModel model)
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
                    var entity = context.Category.SingleOrDefault(q => q.CategoryId == model.CategoryId);
                    if (entity == null || entity == default(Category))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    MapTo(model, entity);
                    context.Category.Attach(entity);
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
        /// Deletes entity for CategoryViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="CategoryViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Delete(CategoryViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.Category.SingleOrDefault(q => q.CategoryId == model.CategoryId);
                    if (entity == null || entity == default(Category))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Category.Remove(entity);
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
        public SimpleResponse Delete(int categoryId)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.Category.SingleOrDefault(q => q.CategoryId == categoryId);
                    if (entity == null || entity == default(Category))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Category.Remove(entity);
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
        /// Reads All records for CategoryViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{CategoryViewModel}}"/>.</returns>
        public SimpleResponse<List<CategoryViewModel>> ReadAll()
        {
            var response = new SimpleResponse<List<CategoryViewModel>>();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entities = context.Category
                        .AsNoTracking()
                        .ToList() ?? new List<Category>();

                    response.Data = MapList<Category, CategoryViewModel>(entities);
                    response.ResponseCode = response.Data.Count;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            response.Data = response.Data ?? new List<CategoryViewModel>();
            return response;
        }
    }
}