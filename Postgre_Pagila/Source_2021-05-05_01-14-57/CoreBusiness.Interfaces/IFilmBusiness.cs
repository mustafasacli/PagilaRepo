using Pagila.Dtos;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System.Collections.Generic;

namespace Pagila.BusinessCore.Interfaces
{
    /// <summary>
    /// Defines the <see cref="IFilmBusiness"/>.
    /// </summary>
    public interface IFilmBusiness
    {
        /// <summary>
        /// The Creates entity for FilmViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="FilmViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{FilmViewModel}"/>.</returns>
        SimpleResponse<FilmViewModel> Create(FilmViewModel viewModel);

        /// <summary>
        /// The Reads for FilmViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{FilmViewModel}"/>.</returns>
        SimpleResponse<FilmViewModel> Read(int filmId);

        /// <summary>
        /// Updates entity for FilmViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="FilmViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Update(FilmViewModel viewModel);

        /// <summary>
        /// Deletes entity for FilmViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="FilmViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(FilmViewModel viewModel);

        /// <summary>
        /// Deletes record by given id value(s).
        /// </summary>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(int filmId);

        /// <summary>
        /// Reads All records for FilmViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{FilmViewModel}}"/>.</returns>
        SimpleResponse<List<FilmViewModel>> ReadAll();
    }
}