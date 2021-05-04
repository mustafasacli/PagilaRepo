using Pagila.Dtos;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System.Collections.Generic;

namespace Pagila.BusinessCore.Interfaces
{
    /// <summary>
    /// Defines the <see cref="IActorBusiness"/>.
    /// </summary>
    public interface IActorBusiness
    {
        /// <summary>
        /// The Creates entity for ActorViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="ActorViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{ActorViewModel}"/>.</returns>
        SimpleResponse<ActorViewModel> Create(ActorViewModel viewModel);

        /// <summary>
        /// The Reads for ActorViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{ActorViewModel}"/>.</returns>
        SimpleResponse<ActorViewModel> Read(int actorId);

        /// <summary>
        /// Updates entity for ActorViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="ActorViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Update(ActorViewModel viewModel);

        /// <summary>
        /// Deletes entity for ActorViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="ActorViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(ActorViewModel viewModel);

        /// <summary>
        /// Deletes record by given id value(s).
        /// </summary>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(int actorId);

        /// <summary>
        /// Reads All records for ActorViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{ActorViewModel}}"/>.</returns>
        SimpleResponse<List<ActorViewModel>> ReadAll();
    }
}