using Pagila.Dtos;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System.Collections.Generic;

namespace Pagila.BusinessCore.Interfaces
{
    /// <summary>
    /// Defines the <see cref="IAddressBusiness"/>.
    /// </summary>
    public interface IAddressBusiness
    {
        /// <summary>
        /// The Creates entity for AddressViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="AddressViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{AddressViewModel}"/>.</returns>
        SimpleResponse<AddressViewModel> Create(AddressViewModel viewModel);

        /// <summary>
        /// The Reads for AddressViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{AddressViewModel}"/>.</returns>
        SimpleResponse<AddressViewModel> Read(int addressId);

        /// <summary>
        /// Updates entity for AddressViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="AddressViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Update(AddressViewModel viewModel);

        /// <summary>
        /// Deletes entity for AddressViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="AddressViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(AddressViewModel viewModel);

        /// <summary>
        /// Deletes record by given id value(s).
        /// </summary>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(int addressId);

        /// <summary>
        /// Reads All records for AddressViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{AddressViewModel}}"/>.</returns>
        SimpleResponse<List<AddressViewModel>> ReadAll();
    }
}