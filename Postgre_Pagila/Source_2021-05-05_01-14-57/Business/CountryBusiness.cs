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
    /// Defines the <see cref="CountryBusiness"/>.
    /// </summary>
    public class CountryBusiness : SimpleBaseBusiness, ICountryBusiness
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountryBusiness"/> class.
        /// </summary>
        public CountryBusiness()
        {
        }

        /// <summary>
        /// The Creates entity for CountryViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="CountryViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{CountryViewModel}"/>.</returns>
        public SimpleResponse<CountryViewModel> Create(CountryViewModel model)
        {
            var response = new SimpleResponse<CountryViewModel>();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse<CountryViewModel>
                    {
                        Data = model,
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using (var context = new PublicDbContext())
                {
                    var entity = Map<CountryViewModel, Country>(model);
                    context.Country.Add(entity);
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
        /// The Reads for CountryViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{CountryViewModel}"/>.</returns>
        public SimpleResponse<CountryViewModel> Read(int countryId)
        {
            var response = new SimpleResponse<CountryViewModel>();

            try
            {
                using (var context = new PublicDbContext())
                {
                    var entity = context.Country
                        .AsNoTracking()
                        .SingleOrDefault(q => q.CountryId == countryId);

                    if (entity == null || entity == default(Country))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    response.Data = Map<Country, CountryViewModel>(entity);
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
        /// Updates entity for CountryViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="CountryViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Update(CountryViewModel model)
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
                    var entity = context.Country.SingleOrDefault(q => q.CountryId == model.CountryId);
                    if (entity == null || entity == default(Country))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    MapTo(model, entity);
                    // context.Country.Attach(entity);
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
        /// Deletes entity for CountryViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="CountryViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Delete(CountryViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicDbContext())
                {
                    var entity = context.Country.FirstOrDefault(q => q.CountryId == model.CountryId);
                    if (entity == null || entity == default(Country))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Country.Remove(entity);
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
        public SimpleResponse Delete(int countryId)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicDbContext())
                {
                    var entity = context.Country.SingleOrDefault(q => q.CountryId == countryId);
                    if (entity == null || entity == default(Country))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Country.Remove(entity);
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
        /// Reads All records for CountryViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{CountryViewModel}}"/>.</returns>
        public SimpleResponse<List<CountryViewModel>> ReadAll()
        {
            var response = new SimpleResponse<List<CountryViewModel>>();

            try
            {
                using (var context = new PublicDbContext())
                {
                    var entities = context.Country
                        .AsNoTracking()
                        .ToList() ?? new List<Country>();

                    response.Data = MapList<Country, CountryViewModel>(entities);
                    response.ResponseCode = response.Data.Count;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            response.Data = response.Data ?? new List<CountryViewModel>();
            return response;
        }
    }
}