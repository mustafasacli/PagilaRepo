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
    /// Defines the <see cref="CustomerBusiness"/>.
    /// </summary>
    public class CustomerBusiness : SimpleBaseBusiness, ICustomerBusiness
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerBusiness"/> class.
        /// </summary>
        public CustomerBusiness()
        {
        }

        /// <summary>
        /// The Creates entity for CustomerViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="CustomerViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{CustomerViewModel}"/>.</returns>
        public SimpleResponse<CustomerViewModel> Create(CustomerViewModel model)
        {
            var response = new SimpleResponse<CustomerViewModel>();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse<CustomerViewModel>
                    {
                        Data = model,
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using (var context = new PublicCoreDbContext())
                {
                    var entity = Map<CustomerViewModel, Customer>(model);
                    context.Customer.Add(entity);
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
        /// The Reads for CustomerViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{CustomerViewModel}"/>.</returns>
        public SimpleResponse<CustomerViewModel> Read(int customerId)
        {
            var response = new SimpleResponse<CustomerViewModel>();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.Customer
                        .AsNoTracking()
                        .FirstOrDefault(q => q.CustomerId == customerId);

                    if (entity == null || entity == default(Customer))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    response.Data = Map<Customer, CustomerViewModel>(entity);
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
        /// Updates entity for CustomerViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="CustomerViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Update(CustomerViewModel model)
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
                    var entity = context.Customer.SingleOrDefault(q => q.CustomerId == model.CustomerId);
                    if (entity == null || entity == default(Customer))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    MapTo(model, entity);
                    context.Customer.Attach(entity);
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
        /// Deletes entity for CustomerViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="CustomerViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        public SimpleResponse Delete(CustomerViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.Customer.SingleOrDefault(q => q.CustomerId == model.CustomerId);
                    if (entity == null || entity == default(Customer))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Customer.Remove(entity);
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
        public SimpleResponse Delete(int customerId)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entity = context.Customer.SingleOrDefault(q => q.CustomerId == customerId);
                    if (entity == null || entity == default(Customer))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayýt bulunamadý.";
                        return response;
                    }

                    context.Customer.Remove(entity);
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
        /// Reads All records for CustomerViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{CustomerViewModel}}"/>.</returns>
        public SimpleResponse<List<CustomerViewModel>> ReadAll()
        {
            var response = new SimpleResponse<List<CustomerViewModel>>();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entities = context.Customer
                        .AsNoTracking()
                        .ToList() ?? new List<Customer>();

                    response.Data = MapList<Customer, CustomerViewModel>(entities);
                    response.ResponseCode = response.Data.Count;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            response.Data = response.Data ?? new List<CustomerViewModel>();
            return response;
        }
    }
}