using Pagila.Dtos;
using Pagila.ViewModel;
using SimpleInfra.Common.Response;
using System.Collections.Generic;

namespace Pagila.BusinessCore.Interfaces
{
    /// <summary>
    /// Defines the <see cref="ICountryBusiness"/>.
    /// </summary>
    public interface ICountryBusiness
    {
        /// <summary>
        /// The Creates entity for CountryViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="CountryViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse{CountryViewModel}"/>.</returns>
        SimpleResponse<CountryViewModel> Create(CountryViewModel viewModel);

        /// <summary>
        /// The Reads for CountryViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{CountryViewModel}"/>.</returns>
        SimpleResponse<CountryViewModel> Read(int countryId);

        /// <summary>
        /// Updates entity for CountryViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="CountryViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Update(CountryViewModel viewModel);

        /// <summary>
        /// Deletes entity for CountryViewModel.
        /// </summary>
        /// <param name="viewModel">The viewModel <see cref="CountryViewModel"/>.</param>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(CountryViewModel viewModel);

        /// <summary>
        /// Deletes record by given id value(s).
        /// </summary>
        /// <returns>The <see cref="SimpleResponse"/>.</returns>
        SimpleResponse Delete(int countryId);

        /// <summary>
        /// Reads All records for CountryViewModel.
        /// </summary>
        /// <returns>The <see cref="SimpleResponse{List{CountryViewModel}}"/>.</returns>
        SimpleResponse<List<CountryViewModel>> ReadAll();
    }
}