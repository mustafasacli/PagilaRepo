using Pagila.Dtos;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;

namespace Pagila.Business.Interfaces
{
    /// <summary>
    /// Defines the <see cref="IFilmActorBusiness"/>.
    /// </summary>
    public interface IFilmActorBusiness
    {
        /// <summary>
        /// The Creates entity for FilmActorViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="FilmActorViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{FilmActorViewModel}"/>.</returns>
        SimpleResponse<FilmActorViewModel> Create(FilmActorViewModel viewModel);

        /// <summary>
        /// The Reads for FilmActorViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{FilmActorViewModel}"/>.</returns>
        SimpleResponse<FilmActorViewModel> Read(int actorId, int filmId);

        /// <summary>
        /// Updates entity for FilmActorViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="FilmActorViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Update(FilmActorViewModel viewModel);

        /// <summary>
        /// Deletes entity for FilmActorViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="FilmActorViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(FilmActorViewModel viewModel);

        /// <summary>
        /// Deletes record by given id value(s).
        /// </summary>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(int actorId, int filmId);

        /// <summary>
        /// Reads All records for FilmActorViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{FilmActorViewModel}}"/>.</returns>
        SimpleResponse<List<FilmActorViewModel>> ReadAll();
    }
}