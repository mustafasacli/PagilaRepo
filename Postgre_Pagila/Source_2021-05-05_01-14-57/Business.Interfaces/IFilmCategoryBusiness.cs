using Pagila.Dtos;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;

namespace Pagila.Business.Interfaces
{
    /// <summary>
    /// Defines the <see cref="IFilmCategoryBusiness"/>.
    /// </summary>
    public interface IFilmCategoryBusiness
    {
        /// <summary>
        /// The Creates entity for FilmCategoryViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="FilmCategoryViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{FilmCategoryViewModel}"/>.</returns>
        SimpleResponse<FilmCategoryViewModel> Create(FilmCategoryViewModel viewModel);

        /// <summary>
        /// The Reads for FilmCategoryViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{FilmCategoryViewModel}"/>.</returns>
        SimpleResponse<FilmCategoryViewModel> Read(int filmId, int categoryId);

        /// <summary>
        /// Updates entity for FilmCategoryViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="FilmCategoryViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Update(FilmCategoryViewModel viewModel);

        /// <summary>
        /// Deletes entity for FilmCategoryViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="FilmCategoryViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(FilmCategoryViewModel viewModel);

        /// <summary>
        /// Deletes record by given id value(s).
        /// </summary>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(int filmId, int categoryId);

        /// <summary>
        /// Reads All records for FilmCategoryViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{FilmCategoryViewModel}}"/>.</returns>
        SimpleResponse<List<FilmCategoryViewModel>> ReadAll();
    }
}