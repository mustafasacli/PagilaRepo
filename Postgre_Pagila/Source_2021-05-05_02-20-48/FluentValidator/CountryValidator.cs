using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class CountryValidator : AbstractValidator<Country>
    {
        public CountryValidator()
        {
            RuleFor(entity => entity.CountryId).NotNull().WithMessage("CountryId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.Country).NotEmpty().WithMessage("Country alan� bo� ge�ilemez.");

            RuleFor(entity => entity.LastUpdate).NotNull().WithMessage("LastUpdate alan� bo� ge�ilemez.");
        }
    }
}