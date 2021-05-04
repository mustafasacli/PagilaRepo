using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class InventoryValidator : AbstractValidator<Inventory>
    {
        public InventoryValidator()
        {
            RuleFor(entity => entity.InventoryId).NotNull().WithMessage("InventoryId alaný boþ geçilemez.");

            RuleFor(entity => entity.FilmId).NotNull().WithMessage("FilmId alaný boþ geçilemez.");

            RuleFor(entity => entity.StoreId).NotNull().WithMessage("StoreId alaný boþ geçilemez.");

            RuleFor(entity => entity.LastUpdate).NotNull().WithMessage("LastUpdate alaný boþ geçilemez.");
        }
    }
}