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
    /// Defines the <see cref="CityBusiness"/>.
    /// </summary>
    public class CityBusiness : SimpleBaseBusiness, ICityBusiness
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CityBusiness"/> class.
        /// </summary>
        public CityBusiness()
        {
        }

        /// <summary>
        /// The Creates entity for CityViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="CityViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{CityViewModel}"/>.</returns>
        public SimpleResponse<CityViewModel> Create(CityViewModel model)
        {
            var response = new SimpleResponse<CityViewModel>();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse<CityViewModel>
                    {
                        Data = model,
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using (var context = new PublicCoreDbContext())
                {
                    var entity = Map<CityViewModel, City>(model);
                    context.City.Add(entity);
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
        /// The Reads for CityViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{CityViewModel}"/>.</returns>
        public SimpleResponse<CityViewModel> Read(int cityId)
        {
            var response = new SimpleResponse<CityViewModel>();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.City
                        .AsNoTracking()
                        .FirstOrDefault(q => q.CityId == cityId);

                    if (entity == null || entity == default(City))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    response.Data = Map<City, CityViewModel>(entity);
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
        /// Updates entity for CityViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="CityViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Update(CityViewModel model)
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
                    var entity = context.City.SingleOrDefault(q => q.CityId == model.CityId);
                    if (entity == null || entity == default(City))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    MapTo(model, entity);
                    context.City.Attach(entity);
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
        /// Deletes entity for CityViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="CityViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Delete(CityViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.City.SingleOrDefault(q => q.CityId == model.CityId);
                    if (entity == null || entity == default(City))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.City.Remove(entity);
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
        public SimpleResponse Delete(int cityId)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.City.SingleOrDefault(q => q.CityId == cityId);
                    if (entity == null || entity == default(City))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.City.Remove(entity);
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
        /// Reads All records for CityViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{CityViewModel}}"/>.</returns>
        public SimpleResponse<List<CityViewModel>> ReadAll()
        {
            var response = new SimpleResponse<List<CityViewModel>>();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entities = context.City
                        .AsNoTracking()
                        .ToList() ?? new List<City>();

                    response.Data = MapList<City, CityViewModel>(entities);
                    response.ResponseCode = response.Data.Count;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            response.Data = response.Data ?? new List<CityViewModel>();
            return response;
        }
    }
}