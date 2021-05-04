using Pagila.Dtos;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;

namespace Pagila.Business.Interfaces
{
    /// <summary>
    /// Defines the <see cref="IRentalBusiness"/>.
    /// </summary>
    public interface IRentalBusiness
    {
        /// <summary>
        /// The Creates entity for RentalViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="RentalViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{RentalViewModel}"/>.</returns>
        SimpleResponse<RentalViewModel> Create(RentalViewModel viewModel);

        /// <summary>
        /// The Reads for RentalViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{RentalViewModel}"/>.</returns>
        SimpleResponse<RentalViewModel> Read(int rentalId);

        /// <summary>
        /// Updates entity for RentalViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="RentalViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Update(RentalViewModel viewModel);

        /// <summary>
        /// Deletes entity for RentalViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="RentalViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(RentalViewModel viewModel);

        /// <summary>
        /// Deletes record by given id value(s).
        /// </summary>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(int rentalId);

        /// <summary>
        /// Reads All records for RentalViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{RentalViewModel}}"/>.</returns>
        SimpleResponse<List<RentalViewModel>> ReadAll();
    }
}