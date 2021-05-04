using Pagila.Dtos;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;

namespace Pagila.Business.Interfaces
{
    /// <summary>
    /// Defines the <see cref="ICityBusiness"/>.
    /// </summary>
    public interface ICityBusiness
    {
        /// <summary>
        /// The Creates entity for CityViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="CityViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{CityViewModel}"/>.</returns>
        SimpleResponse<CityViewModel> Create(CityViewModel viewModel);

        /// <summary>
        /// The Reads for CityViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{CityViewModel}"/>.</returns>
        SimpleResponse<CityViewModel> Read(int cityId);

        /// <summary>
        /// Updates entity for CityViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="CityViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Update(CityViewModel viewModel);

        /// <summary>
        /// Deletes entity for CityViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="CityViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(CityViewModel viewModel);

        /// <summary>
        /// Deletes record by given id value(s).
        /// </summary>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(int cityId);

        /// <summary>
        /// Reads All records for CityViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{CityViewModel}}"/>.</returns>
        SimpleResponse<List<CityViewModel>> ReadAll();
    }
}