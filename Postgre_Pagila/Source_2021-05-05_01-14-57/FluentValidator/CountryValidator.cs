using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class CountryValidator : AbstractValidator<Country>
    {
        public CountryValidator()
        {
            RuleFor(entity => entity.CountryId).NotNull().WithMessage("CountryId alaný boþ geçilemez.");

            RuleFor(entity => entity.Country).NotEmpty().WithMessage("Country alaný boþ geçilemez.");

            RuleFor(entity => entity.LastUpdate).NotNull().WithMessage("LastUpdate alaný boþ geçilemez.");
        }
    }
}