using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class CityValidator : AbstractValidator<City>
    {
        public CityValidator()
        {
            RuleFor(entity => entity.CityId).NotNull().WithMessage("CityId alaný boþ geçilemez.");

            RuleFor(entity => entity.City).NotEmpty().WithMessage("City alaný boþ geçilemez.");

            RuleFor(entity => entity.CountryId).NotNull().WithMessage("CountryId alaný boþ geçilemez.");

            RuleFor(entity => entity.LastUpdate).NotNull().WithMessage("LastUpdate alaný boþ geçilemez.");
        }
    }
}