using Pagila.Dtos;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System.Collections.Generic;

namespace Pagila.BusinessCore.Interfaces
{
    /// <summary>
    /// Defines the <see cref="ICustomerBusiness"/>.
    /// </summary>
    public interface ICustomerBusiness
    {
        /// <summary>
        /// The Creates entity for CustomerViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="CustomerViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{CustomerViewModel}"/>.</returns>
        SimpleResponse<CustomerViewModel> Create(CustomerViewModel viewModel);

        /// <summary>
        /// The Reads for CustomerViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{CustomerViewModel}"/>.</returns>
        SimpleResponse<CustomerViewModel> Read(int customerId);

        /// <summary>
        /// Updates entity for CustomerViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="CustomerViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Update(CustomerViewModel viewModel);

        /// <summary>
        /// Deletes entity for CustomerViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="CustomerViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(CustomerViewModel viewModel);

        /// <summary>
        /// Deletes record by given id value(s).
        /// </summary>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(int customerId);

        /// <summary>
        /// Reads All records for CustomerViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{CustomerViewModel}}"/>.</returns>
        SimpleResponse<List<CustomerViewModel>> ReadAll();
    }
}