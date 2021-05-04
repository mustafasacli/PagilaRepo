using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(entity => entity.RentalId).NotNull().WithMessage("RentalId alaný boþ geçilemez.");

            RuleFor(entity => entity.RentalDate).NotNull().WithMessage("RentalDate alaný boþ geçilemez.");

            RuleFor(entity => entity.InventoryId).NotNull().WithMessage("InventoryId alaný boþ geçilemez.");

            RuleFor(entity => entity.CustomerId).NotNull().WithMessage("CustomerId alaný boþ geçilemez.");

            RuleFor(entity => entity.StaffId).NotNull().WithMessage("StaffId alaný boþ geçilemez.");

            RuleFor(entity => entity.LastUpdate).NotNull().WithMessage("LastUpdate alaný boþ geçilemez.");
        }
    }
}