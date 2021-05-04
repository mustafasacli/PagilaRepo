using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(entity => entity.AddressId).NotNull().WithMessage("AddressId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.Address).NotEmpty().WithMessage("Address alan� bo� ge�ilemez.");

            RuleFor(entity => entity.District).NotEmpty().WithMessage("District alan� bo� ge�ilemez.");

            RuleFor(entity => entity.CityId).NotNull().WithMessage("CityId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.Phone).NotEmpty().WithMessage("Phone alan� bo� ge�ilemez.");

            RuleFor(entity => entity.LastUpdate).NotNull().WithMessage("LastUpdate alan� bo� ge�ilemez.");
        }
    }
}