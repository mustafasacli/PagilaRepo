using Pagila.Dtos;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System.Collections.Generic;

namespace Pagila.BusinessCore.Interfaces
{
    /// <summary>
    /// Defines the <see cref="IStaffBusiness"/>.
    /// </summary>
    public interface IStaffBusiness
    {
        /// <summary>
        /// The Creates entity for StaffViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="StaffViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{StaffViewModel}"/>.</returns>
        SimpleResponse<StaffViewModel> Create(StaffViewModel viewModel);

        /// <summary>
        /// The Reads for StaffViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{StaffViewModel}"/>.</returns>
        SimpleResponse<StaffViewModel> Read(int staffId);

        /// <summary>
        /// Updates entity for StaffViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="StaffViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Update(StaffViewModel viewModel);

        /// <summary>
        /// Deletes entity for StaffViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="StaffViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(StaffViewModel viewModel);

        /// <summary>
        /// Deletes record by given id value(s).
        /// </summary>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(int staffId);

        /// <summary>
        /// Reads All records for StaffViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{StaffViewModel}}"/>.</returns>
        SimpleResponse<List<StaffViewModel>> ReadAll();
    }
}