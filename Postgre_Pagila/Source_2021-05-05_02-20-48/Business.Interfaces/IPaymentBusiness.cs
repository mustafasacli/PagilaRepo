using Pagila.Dtos;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;

namespace Pagila.Business.Interfaces
{
    /// <summary>
    /// Defines the <see cref="IPaymentBusiness"/>.
    /// </summary>
    public interface IPaymentBusiness
    {
        /// <summary>
        /// The Creates entity for PaymentViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="PaymentViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{PaymentViewModel}"/>.</returns>
        SimpleResponse<PaymentViewModel> Create(PaymentViewModel viewModel);

        /// <summary>
        /// Reads All records for PaymentViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{PaymentViewModel}}"/>.</returns>
        SimpleResponse<List<PaymentViewModel>> ReadAll();
    }
}