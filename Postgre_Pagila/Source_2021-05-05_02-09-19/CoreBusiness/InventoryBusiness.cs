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
    /// Defines the <see cref="InventoryBusiness"/>.
    /// </summary>
    public class InventoryBusiness : SimpleBaseBusiness, IInventoryBusiness
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryBusiness"/> class.
        /// </summary>
        public InventoryBusiness()
        {
        }

        /// <summary>
        /// The Creates entity for InventoryViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="InventoryViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{InventoryViewModel}"/>.</returns>
        public SimpleResponse<InventoryViewModel> Create(InventoryViewModel model)
        {
            var response = new SimpleResponse<InventoryViewModel>();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse<InventoryViewModel>
                    {
                        Data = model,
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using (var context = new PublicCoreDbContext())
                {
                    var entity = Map<InventoryViewModel, Inventory>(model);
                    context.Inventory.Add(entity);
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
        /// The Reads for InventoryViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{InventoryViewModel}"/>.</returns>
        public SimpleResponse<InventoryViewModel> Read(int inventoryId)
        {
            var response = new SimpleResponse<InventoryViewModel>();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.Inventory
                        .AsNoTracking()
                        .FirstOrDefault(q => q.InventoryId == inventoryId);

                    if (entity == null || entity == default(Inventory))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    response.Data = Map<Inventory, InventoryViewModel>(entity);
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
        /// Updates entity for InventoryViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="InventoryViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Update(InventoryViewModel model)
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
                    var entity = context.Inventory.SingleOrDefault(q => q.InventoryId == model.InventoryId);
                    if (entity == null || entity == default(Inventory))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    MapTo(model, entity);
                    context.Inventory.Attach(entity);
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
        /// Deletes entity for InventoryViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="InventoryViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Delete(InventoryViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.Inventory.SingleOrDefault(q => q.InventoryId == model.InventoryId);
                    if (entity == null || entity == default(Inventory))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Inventory.Remove(entity);
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
        public SimpleResponse Delete(int inventoryId)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.Inventory.SingleOrDefault(q => q.InventoryId == inventoryId);
                    if (entity == null || entity == default(Inventory))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Inventory.Remove(entity);
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
        /// Reads All records for InventoryViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{InventoryViewModel}}"/>.</returns>
        public SimpleResponse<List<InventoryViewModel>> ReadAll()
        {
            var response = new SimpleResponse<List<InventoryViewModel>>();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entities = context.Inventory
                        .AsNoTracking()
                        .ToList() ?? new List<Inventory>();

                    response.Data = MapList<Inventory, InventoryViewModel>(entities);
                    response.ResponseCode = response.Data.Count;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            response.Data = response.Data ?? new List<InventoryViewModel>();
            return response;
        }
    }
}