using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class StoreValidator : AbstractValidator<Store>
    {
        public StoreValidator()
        {
            RuleFor(entity => entity.StoreId).NotNull().WithMessage("StoreId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.ManagerStaffId).NotNull().WithMessage("ManagerStaffId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.AddressId).NotNull().WithMessage("AddressId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.LastUpdate).NotNull().WithMessage("LastUpdate alan� bo� ge�ilemez.");
        }
    }
}