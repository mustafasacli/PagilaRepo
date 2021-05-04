using Pagila.Dtos;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;

namespace Pagila.Business.Interfaces
{
    /// <summary>
    /// Defines the <see cref="ILanguageBusiness"/>.
    /// </summary>
    public interface ILanguageBusiness
    {
        /// <summary>
        /// The Creates entity for LanguageViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="LanguageViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{LanguageViewModel}"/>.</returns>
        SimpleResponse<LanguageViewModel> Create(LanguageViewModel viewModel);

        /// <summary>
        /// The Reads for LanguageViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{LanguageViewModel}"/>.</returns>
        SimpleResponse<LanguageViewModel> Read(int languageId);

        /// <summary>
        /// Updates entity for LanguageViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="LanguageViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Update(LanguageViewModel viewModel);

        /// <summary>
        /// Deletes entity for LanguageViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="LanguageViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(LanguageViewModel viewModel);

        /// <summary>
        /// Deletes record by given id value(s).
        /// </summary>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(int languageId);

        /// <summary>
        /// Reads All records for LanguageViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{LanguageViewModel}}"/>.</returns>
        SimpleResponse<List<LanguageViewModel>> ReadAll();
    }
}