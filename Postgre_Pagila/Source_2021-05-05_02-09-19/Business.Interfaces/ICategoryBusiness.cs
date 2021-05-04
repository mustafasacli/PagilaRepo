using Pagila.Dtos;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;

namespace Pagila.Business.Interfaces
{
    /// <summary>
    /// Defines the <see cref="ICategoryBusiness"/>.
    /// </summary>
    public interface ICategoryBusiness
    {
        /// <summary>
        /// The Creates entity for CategoryViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="CategoryViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{CategoryViewModel}"/>.</returns>
        SimpleResponse<CategoryViewModel> Create(CategoryViewModel viewModel);

        /// <summary>
        /// The Reads for CategoryViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{CategoryViewModel}"/>.</returns>
        SimpleResponse<CategoryViewModel> Read(int categoryId);

        /// <summary>
        /// Updates entity for CategoryViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="CategoryViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Update(CategoryViewModel viewModel);

        /// <summary>
        /// Deletes entity for CategoryViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="CategoryViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(CategoryViewModel viewModel);

        /// <summary>
        /// Deletes record by given id value(s).
        /// </summary>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(int categoryId);

        /// <summary>
        /// Reads All records for CategoryViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{CategoryViewModel}}"/>.</returns>
        SimpleResponse<List<CategoryViewModel>> ReadAll();
    }
}