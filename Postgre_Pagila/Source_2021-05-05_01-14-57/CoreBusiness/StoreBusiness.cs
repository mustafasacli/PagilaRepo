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
    /// Defines the <see cref="StoreBusiness"/>.
    /// </summary>
    public class StoreBusiness : SimpleBaseBusiness, IStoreBusiness
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreBusiness"/> class.
        /// </summary>
        public StoreBusiness()
        {
        }

        /// <summary>
        /// The Creates entity for StoreViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="StoreViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{StoreViewModel}"/>.</returns>
        public SimpleResponse<StoreViewModel> Create(StoreViewModel model)
        {
            var response = new SimpleResponse<StoreViewModel>();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse<StoreViewModel>
                    {
                        Data = model,
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using (var context = new PublicCoreDbContext())
                {
                    var entity = Map<StoreViewModel, Store>(model);
                    context.Store.Add(entity);
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
        /// The Reads for StoreViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{StoreViewModel}"/>.</returns>
        public SimpleResponse<StoreViewModel> Read(int storeId)
        {
            var response = new SimpleResponse<StoreViewModel>();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.Store
                        .AsNoTracking()
                        .FirstOrDefault(q => q.StoreId == storeId);

                    if (entity == null || entity == default(Store))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    response.Data = Map<Store, StoreViewModel>(entity);
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
        /// Updates entity for StoreViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="StoreViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Update(StoreViewModel model)
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
                    var entity = context.Store.SingleOrDefault(q => q.StoreId == model.StoreId);
                    if (entity == null || entity == default(Store))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    MapTo(model, entity);
                    context.Store.Attach(entity);
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
        /// Deletes entity for StoreViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="StoreViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Delete(StoreViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.Store.SingleOrDefault(q => q.StoreId == model.StoreId);
                    if (entity == null || entity == default(Store))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Store.Remove(entity);
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
        public SimpleResponse Delete(int storeId)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.Store.SingleOrDefault(q => q.StoreId == storeId);
                    if (entity == null || entity == default(Store))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Store.Remove(entity);
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
        /// Reads All records for StoreViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{StoreViewModel}}"/>.</returns>
        public SimpleResponse<List<StoreViewModel>> ReadAll()
        {
            var response = new SimpleResponse<List<StoreViewModel>>();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entities = context.Store
                        .AsNoTracking()
                        .ToList() ?? new List<Store>();

                    response.Data = MapList<Store, StoreViewModel>(entities);
                    response.ResponseCode = response.Data.Count;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            response.Data = response.Data ?? new List<StoreViewModel>();
            return response;
        }
    }
}