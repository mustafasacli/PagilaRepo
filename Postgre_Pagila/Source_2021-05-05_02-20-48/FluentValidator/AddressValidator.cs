using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(entity => entity.AddressId).NotNull().WithMessage("AddressId alaný boþ geçilemez.");

            RuleFor(entity => entity.Address).NotEmpty().WithMessage("Address alaný boþ geçilemez.");

            RuleFor(entity => entity.District).NotEmpty().WithMessage("District alaný boþ geçilemez.");

            RuleFor(entity => entity.CityId).NotNull().WithMessage("CityId alaný boþ geçilemez.");

            RuleFor(entity => entity.Phone).NotEmpty().WithMessage("Phone alaný boþ geçilemez.");

            RuleFor(entity => entity.LastUpdate).NotNull().WithMessage("LastUpdate alaný boþ geçilemez.");
        }
    }
}