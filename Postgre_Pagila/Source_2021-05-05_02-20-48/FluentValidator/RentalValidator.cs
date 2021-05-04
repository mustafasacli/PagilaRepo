using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(entity => entity.RentalId).NotNull().WithMessage("RentalId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.RentalDate).NotNull().WithMessage("RentalDate alan� bo� ge�ilemez.");

            RuleFor(entity => entity.InventoryId).NotNull().WithMessage("InventoryId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.CustomerId).NotNull().WithMessage("CustomerId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.StaffId).NotNull().WithMessage("StaffId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.LastUpdate).NotNull().WithMessage("LastUpdate alan� bo� ge�ilemez.");
        }
    }
}