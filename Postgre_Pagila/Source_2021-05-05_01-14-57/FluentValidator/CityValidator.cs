using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class CityValidator : AbstractValidator<City>
    {
        public CityValidator()
        {
            RuleFor(entity => entity.CityId).NotNull().WithMessage("CityId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.City).NotEmpty().WithMessage("City alan� bo� ge�ilemez.");

            RuleFor(entity => entity.CountryId).NotNull().WithMessage("CountryId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.LastUpdate).NotNull().WithMessage("LastUpdate alan� bo� ge�ilemez.");
        }
    }
}