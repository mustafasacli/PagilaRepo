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
    /// Defines the <see cref="RentalBusiness"/>.
    /// </summary>
    public class RentalBusiness : SimpleBaseBusiness, IRentalBusiness
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentalBusiness"/> class.
        /// </summary>
        public RentalBusiness()
        {
        }

        /// <summary>
        /// The Creates entity for RentalViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="RentalViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{RentalViewModel}"/>.</returns>
        public SimpleResponse<RentalViewModel> Create(RentalViewModel model)
        {
            var response = new SimpleResponse<RentalViewModel>();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse<RentalViewModel>
                    {
                        Data = model,
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using (var context = new PublicCoreDbContext())
                {
                    var entity = Map<RentalViewModel, Rental>(model);
                    context.Rental.Add(entity);
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
        /// The Reads for RentalViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{RentalViewModel}"/>.</returns>
        public SimpleResponse<RentalViewModel> Read(int rentalId)
        {
            var response = new SimpleResponse<RentalViewModel>();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.Rental
                        .AsNoTracking()
                        .FirstOrDefault(q => q.RentalId == rentalId);

                    if (entity == null || entity == default(Rental))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    response.Data = Map<Rental, RentalViewModel>(entity);
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
        /// Updates entity for RentalViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="RentalViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Update(RentalViewModel model)
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
                    var entity = context.Rental.SingleOrDefault(q => q.RentalId == model.RentalId);
                    if (entity == null || entity == default(Rental))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    MapTo(model, entity);
                    context.Rental.Attach(entity);
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
        /// Deletes entity for RentalViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="RentalViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Delete(RentalViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.Rental.SingleOrDefault(q => q.RentalId == model.RentalId);
                    if (entity == null || entity == default(Rental))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Rental.Remove(entity);
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
        public SimpleResponse Delete(int rentalId)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.Rental.SingleOrDefault(q => q.RentalId == rentalId);
                    if (entity == null || entity == default(Rental))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Rental.Remove(entity);
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
        /// Reads All records for RentalViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{RentalViewModel}}"/>.</returns>
        public SimpleResponse<List<RentalViewModel>> ReadAll()
        {
            var response = new SimpleResponse<List<RentalViewModel>>();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entities = context.Rental
                        .AsNoTracking()
                        .ToList() ?? new List<Rental>();

                    response.Data = MapList<Rental, RentalViewModel>(entities);
                    response.ResponseCode = response.Data.Count;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            response.Data = response.Data ?? new List<RentalViewModel>();
            return response;
        }
    }
}