using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class StoreValidator : AbstractValidator<Store>
    {
        public StoreValidator()
        {
            RuleFor(entity => entity.StoreId).NotNull().WithMessage("StoreId alaný boþ geçilemez.");

            RuleFor(entity => entity.ManagerStaffId).NotNull().WithMessage("ManagerStaffId alaný boþ geçilemez.");

            RuleFor(entity => entity.AddressId).NotNull().WithMessage("AddressId alaný boþ geçilemez.");

            RuleFor(entity => entity.LastUpdate).NotNull().WithMessage("LastUpdate alaný boþ geçilemez.");
        }
    }
}