using Pagila.Dtos;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System.Collections.Generic;

namespace Pagila.BusinessCore.Interfaces
{
    /// <summary>
    /// Defines the <see cref="IInventoryBusiness"/>.
    /// </summary>
    public interface IInventoryBusiness
    {
        /// <summary>
        /// The Creates entity for InventoryViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="InventoryViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{InventoryViewModel}"/>.</returns>
        SimpleResponse<InventoryViewModel> Create(InventoryViewModel viewModel);

        /// <summary>
        /// The Reads for InventoryViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{InventoryViewModel}"/>.</returns>
        SimpleResponse<InventoryViewModel> Read(int inventoryId);

        /// <summary>
        /// Updates entity for InventoryViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="InventoryViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Update(InventoryViewModel viewModel);

        /// <summary>
        /// Deletes entity for InventoryViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="InventoryViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(InventoryViewModel viewModel);

        /// <summary>
        /// Deletes record by given id value(s).
        /// </summary>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(int inventoryId);

        /// <summary>
        /// Reads All records for InventoryViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{InventoryViewModel}}"/>.</returns>
        SimpleResponse<List<InventoryViewModel>> ReadAll();
    }
}