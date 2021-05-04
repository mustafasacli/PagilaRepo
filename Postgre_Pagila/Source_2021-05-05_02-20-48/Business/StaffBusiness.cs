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
    /// Defines the <see cref="StaffBusiness"/>.
    /// </summary>
    public class StaffBusiness : SimpleBaseBusiness, IStaffBusiness
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StaffBusiness"/> class.
        /// </summary>
        public StaffBusiness()
        {
        }

        /// <summary>
        /// The Creates entity for StaffViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="StaffViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{StaffViewModel}"/>.</returns>
        public SimpleResponse<StaffViewModel> Create(StaffViewModel model)
        {
            var response = new SimpleResponse<StaffViewModel>();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse<StaffViewModel>
                    {
                        Data = model,
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using (var context = new PublicDbContext())
                {
                    var entity = Map<StaffViewModel, Staff>(model);
                    context.Staff.Add(entity);
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
        /// The Reads for StaffViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{StaffViewModel}"/>.</returns>
        public SimpleResponse<StaffViewModel> Read(int staffId)
        {
            var response = new SimpleResponse<StaffViewModel>();

            try
            {
                using (var context = new PublicDbContext())
                {
                    var entity = context.Staff
                        .AsNoTracking()
                        .SingleOrDefault(q => q.StaffId == staffId);

                    if (entity == null || entity == default(Staff))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    response.Data = Map<Staff, StaffViewModel>(entity);
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
        /// Updates entity for StaffViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="StaffViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Update(StaffViewModel model)
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
                    var entity = context.Staff.SingleOrDefault(q => q.StaffId == model.StaffId);
                    if (entity == null || entity == default(Staff))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    MapTo(model, entity);
                    // context.Staff.Attach(entity);
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
        /// Deletes entity for StaffViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="StaffViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Delete(StaffViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicDbContext())
                {
                    var entity = context.Staff.FirstOrDefault(q => q.StaffId == model.StaffId);
                    if (entity == null || entity == default(Staff))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Staff.Remove(entity);
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
        public SimpleResponse Delete(int staffId)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicDbContext())
                {
                    var entity = context.Staff.SingleOrDefault(q => q.StaffId == staffId);
                    if (entity == null || entity == default(Staff))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Staff.Remove(entity);
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
        /// Reads All records for StaffViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{StaffViewModel}}"/>.</returns>
        public SimpleResponse<List<StaffViewModel>> ReadAll()
        {
            var response = new SimpleResponse<List<StaffViewModel>>();

            try
            {
                using (var context = new PublicDbContext())
                {
                    var entities = context.Staff
                        .AsNoTracking()
                        .ToList() ?? new List<Staff>();

                    response.Data = MapList<Staff, StaffViewModel>(entities);
                    response.ResponseCode = response.Data.Count;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            response.Data = response.Data ?? new List<StaffViewModel>();
            return response;
        }
    }
}