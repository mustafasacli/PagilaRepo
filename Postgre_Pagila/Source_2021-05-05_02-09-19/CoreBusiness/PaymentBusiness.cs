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
    /// Defines the <see cref="PaymentBusiness"/>.
    /// </summary>
    public class PaymentBusiness : SimpleBaseBusiness, IPaymentBusiness
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentBusiness"/> class.
        /// </summary>
        public PaymentBusiness()
        {
        }

        /// <summary>
        /// The Creates entity for PaymentViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="PaymentViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{PaymentViewModel}"/>.</returns>
        public SimpleResponse<PaymentViewModel> Create(PaymentViewModel model)
        {
            var response = new SimpleResponse<PaymentViewModel>();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse<PaymentViewModel>
                    {
                        Data = model,
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using (var context = new PublicCoreDbContext())
                {
                    var entity = Map<PaymentViewModel, Payment>(model);
                    context.Payment.Add(entity);
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
        /// Reads All records for PaymentViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{PaymentViewModel}}"/>.</returns>
        public SimpleResponse<List<PaymentViewModel>> ReadAll()
        {
            var response = new SimpleResponse<List<PaymentViewModel>>();

            try
            {
                using (var context = new PublicCoreDbContext())
                {
                    var entities = context.Payment
                        .AsNoTracking()
                        .ToList() ?? new List<Payment>();

                    response.Data = MapList<Payment, PaymentViewModel>(entities);
                    response.ResponseCode = response.Data.Count;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma iþleminde hata oluþtu.";
                DayLogger.Error(ex);
            }

            response.Data = response.Data ?? new List<PaymentViewModel>();
            return response;
        }
    }
}