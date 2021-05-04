using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class StaffValidator : AbstractValidator<Staff>
    {
        public StaffValidator()
        {
            RuleFor(entity => entity.StaffId).NotNull().WithMessage("StaffId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.FirstName).NotEmpty().WithMessage("FirstName alan� bo� ge�ilemez.");

            RuleFor(entity => entity.LastName).NotEmpty().WithMessage("LastName alan� bo� ge�ilemez.");

            RuleFor(entity => entity.AddressId).NotNull().WithMessage("AddressId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.StoreId).NotNull().WithMessage("StoreId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.Active).NotNull().WithMessage("Active alan� bo� ge�ilemez.");

            RuleFor(entity => entity.Username).NotEmpty().WithMessage("Username alan� bo� ge�ilemez.");

            RuleFor(entity => entity.LastUpdate).NotNull().WithMessage("LastUpdate alan� bo� ge�ilemez.");
        }
    }
}