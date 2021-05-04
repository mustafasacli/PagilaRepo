using Pagila.Dtos;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;

namespace Pagila.Business.Interfaces
{
    /// <summary>
    /// Defines the <see cref="IStoreBusiness"/>.
    /// </summary>
    public interface IStoreBusiness
    {
        /// <summary>
        /// The Creates entity for StoreViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="StoreViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{StoreViewModel}"/>.</returns>
        SimpleResponse<StoreViewModel> Create(StoreViewModel viewModel);

        /// <summary>
        /// The Reads for StoreViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{StoreViewModel}"/>.</returns>
        SimpleResponse<StoreViewModel> Read(int storeId);

        /// <summary>
        /// Updates entity for StoreViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="StoreViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Update(StoreViewModel viewModel);

        /// <summary>
        /// Deletes entity for StoreViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="StoreViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(StoreViewModel viewModel);

        /// <summary>
        /// Deletes record by given id value(s).
        /// </summary>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(int storeId);

        /// <summary>
        /// Reads All records for StoreViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{StoreViewModel}}"/>.</returns>
        SimpleResponse<List<StoreViewModel>> ReadAll();
    }
}