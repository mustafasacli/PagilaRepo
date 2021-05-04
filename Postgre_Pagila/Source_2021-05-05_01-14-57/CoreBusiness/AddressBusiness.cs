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
    /// Defines the <see cref="AddressBusiness"/>.
    /// </summary>
    public class AddressBusiness : SimpleBaseBusiness, IAddressBusiness
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressBusiness"/> class.
        /// </summary>
        public AddressBusiness()
        {
        }

        /// <summary>
        /// The Creates entity for AddressViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="AddressViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{AddressViewModel}"/>.</returns>
        public SimpleResponse<AddressViewModel> Create(AddressViewModel model)
        {
            var response = new SimpleResponse<AddressViewModel>();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse<AddressViewModel>
                    {
                        Data = model,
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using (var context = new PublicCoreDbContext())
                {
                    var entity = Map<AddressViewModel, Address>(model);
                    context.Address.Add(entity);
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
        /// The Reads for AddressViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{AddressViewModel}"/>.</returns>
        public SimpleResponse<AddressViewModel> Read(int addressId)
        {
            var response = new SimpleResponse<AddressViewModel>();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.Address
                        .AsNoTracking()
                        .FirstOrDefault(q => q.AddressId == addressId);

                    if (entity == null || entity == default(Address))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    response.Data = Map<Address, AddressViewModel>(entity);
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
        /// Updates entity for AddressViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="AddressViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Update(AddressViewModel model)
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
                    var entity = context.Address.SingleOrDefault(q => q.AddressId == model.AddressId);
                    if (entity == null || entity == default(Address))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    MapTo(model, entity);
                    context.Address.Attach(entity);
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
        /// Deletes entity for AddressViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="AddressViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Delete(AddressViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.Address.SingleOrDefault(q => q.AddressId == model.AddressId);
                    if (entity == null || entity == default(Address))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Address.Remove(entity);
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
        public SimpleResponse Delete(int addressId)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.Address.SingleOrDefault(q => q.AddressId == addressId);
                    if (entity == null || entity == default(Address))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Address.Remove(entity);
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
        /// Reads All records for AddressViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{AddressViewModel}}"/>.</returns>
        public SimpleResponse<List<AddressViewModel>> ReadAll()
        {
            var response = new SimpleResponse<List<AddressViewModel>>();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entities = context.Address
                        .AsNoTracking()
                        .ToList() ?? new List<Address>();

                    response.Data = MapList<Address, AddressViewModel>(entities);
                    response.ResponseCode = response.Data.Count;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            response.Data = response.Data ?? new List<AddressViewModel>();
            return response;
        }
    }
}