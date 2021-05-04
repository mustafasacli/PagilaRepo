using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class StaffValidator : AbstractValidator<Staff>
    {
        public StaffValidator()
        {
            RuleFor(entity => entity.StaffId).NotNull().WithMessage("StaffId alaný boþ geçilemez.");

            RuleFor(entity => entity.FirstName).NotEmpty().WithMessage("FirstName alaný boþ geçilemez.");

            RuleFor(entity => entity.LastName).NotEmpty().WithMessage("LastName alaný boþ geçilemez.");

            RuleFor(entity => entity.AddressId).NotNull().WithMessage("AddressId alaný boþ geçilemez.");

            RuleFor(entity => entity.StoreId).NotNull().WithMessage("StoreId alaný boþ geçilemez.");

            RuleFor(entity => entity.Active).NotNull().WithMessage("Active alaný boþ geçilemez.");

            RuleFor(entity => entity.Username).NotEmpty().WithMessage("Username alaný boþ geçilemez.");

            RuleFor(entity => entity.LastUpdate).NotNull().WithMessage("LastUpdate alaný boþ geçilemez.");
        }
    }
}